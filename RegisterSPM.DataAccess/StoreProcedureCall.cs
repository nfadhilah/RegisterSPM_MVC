using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegisterSPM.DataAccess.Data;
using RegisterSPM.DataAccess.IRepository;

namespace RegisterSPM.DataAccess
{
  public class StoreProcedureCall : IStoreProcedureCall
  {
    private readonly ApplicationDbContext _db;
    private static string _connectionString = "";

    public StoreProcedureCall(ApplicationDbContext db)
    {
      _db = db;
      _connectionString = db.Database.GetConnectionString();
    }

    public void Dispose()
    {
      _db.Dispose();
    }

    public T Single<T>(string procedureName, DynamicParameters param = null)
    {
      using var sqlCon = new SqlConnection(_connectionString);
      sqlCon.Open();
      var result = sqlCon.ExecuteScalar<T>(procedureName, param, commandType: CommandType.StoredProcedure);
      return (T) Convert.ChangeType(result, typeof(T));
    }

    public void Execute(string procedureName, DynamicParameters param = null)
    {
      using var sqlCon = new SqlConnection(_connectionString);
      sqlCon.Open();
      sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
    }

    public T OneRecord<T>(string procedureName, DynamicParameters param = null)
    {
      using var sqlCon = new SqlConnection(_connectionString);
      sqlCon.Open();
      var result =  sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
      return (T) Convert.ChangeType(result.FirstOrDefault(), typeof(T));
    }

    public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
    {
      using var sqlCon = new SqlConnection(_connectionString);
      sqlCon.Open();
      return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
    }

    public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
    {
      using var sqlCon = new SqlConnection(_connectionString);
      sqlCon.Open();
      var result = sqlCon.QueryMultiple(procedureName, param, commandType: CommandType.StoredProcedure);
      var firstResult = result.Read<T1>().ToList();
      var secondResult = result.Read<T2>().ToList();

      return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(firstResult, secondResult);
    }
  }
}