using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Models.ViewModels;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Main.Controllers
{
  [Area("Main")]
  [Authorize]
  public class ReportController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _config;

    public ReportController(IUnitOfWork unitOfWork, IHttpClientFactory clientFactory, IConfiguration config)
    {
      _unitOfWork = unitOfWork;
      _clientFactory = clientFactory;
      _config = config;
    }

    public async Task<IActionResult> KartuKendali(int? id = null)
    {
      var model = new LookupSPMRptViewModel();
      if (id.HasValue)
      {
        var spm = await _unitOfWork.SPM.GetAsync(id.Value);
        model.NoSPM = spm.NoSPM;
        model.Id = spm.Id;
      }
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> KartuKendali(LookupSPMRptViewModel model)
    {
      if (!ModelState.IsValid) return View(model);

      var client = _clientFactory.CreateClient();
      var rptParam = JsonConvert.SerializeObject(new ReportParam
      {
        FormatType = ReportType.Pdf,
        ReportName = "KartuKendaliSPM.rpt",
        Parameters = new Dictionary<string, object>
        {
          ["Id"] = model.Id
        }
      }, Formatting.None, new JsonSerializerSettings
      {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
      });

      var requestBody = new StringContent(rptParam, Encoding.UTF8);
      client.DefaultRequestHeaders.Add("x-api-tahun", HttpContext.Session.GetObject<string>(SD.SsTahun));
      var request = new HttpRequestMessage(HttpMethod.Post, _config.GetSection("ReportServerSettings")["BaseUrl"]);
      request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      request.Content = requestBody;
      request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      var response = await client.SendAsync(request);
      if (response.IsSuccessStatusCode)
      {
        var responseStream = await response.Content.ReadAsStreamAsync();
        return File(responseStream, "application/pdf", "kartu_kendali.pdf");
      }
      return BadRequest();
    }

    public async Task<IActionResult> LookupSPMRpt()
    {
      var model = await _unitOfWork.SPM.GetAllAsync();
      return View(model);
    }


  }
}