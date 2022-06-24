using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace e2.Data.EFCore
{
  
  public class ExecuteQuery
  {
    public static string GettParaStr(object[] parameters)
    {
      string pa = "";
      if (parameters != null && parameters.Count() > 0)
      {
        for (int i = 0; i < parameters.Count(); i++)
        {
          pa = pa + " @p" + i + ",";
        }
        int p = pa.LastIndexOf(",");
        pa = pa.Substring(0, p);
      }
      return pa;
    }
    //public static string Getarg(object[] parameters)
    //{
    //  List<String> dataTypes = new List<String>();
    //  dataTypes.Add("string");      
    //  string pa = "";
    //  if (parameters != null && parameters.Count() > 0)
    //  {
    //    foreach (var para in parameters) 
    //    {
    //      if(dataTypes.Contains(para.GetType().Name.ToLower()))
    //      pa = pa +"'"+ para + "',";
    //      else
    //     pa = pa + para + ",";

    //    }
    //    int p = pa.LastIndexOf(",");
    //    pa = pa.Substring(0, p);
    //  }
    //  return pa;
    //}

  }
  public class ExecuteQuery<T> where T : class
  {
    
    /// <summary>
    /// Stored procedure with Schema name
    /// </summary>
    /// <param name="storedProcedureName"></param>
    /// <param name="parameters"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static IEnumerable<T> ExecuteStoredProcedure(DbContext context, string storedProcedureName, object[] parameters = null)
    {
      StringBuilder querySb = new StringBuilder($"exec {storedProcedureName}");
      try
      {
       
        //string pa = "";
        if (parameters != null && parameters.Count() > 0)
        {
          querySb.Append(ExecuteQuery.GettParaStr(parameters));
          return context.Set<T>().FromSqlRaw(querySb.ToString(), parameters);
        }
        return context.Set<T>().FromSqlRaw(querySb.ToString());
      }
      catch (Exception ex)
      {
        var x = new Exception(storedProcedureName, ex);
        throw x;
      }
      finally
      {
        querySb.Clear();
        querySb = null;
        //parameters = null;
      }
    }
    public static IEnumerable<T> ExecuteStoredProcedure(DbContext context, string storedProcedureName,List<SqlParameter> param)
    {
      var parameters = ExecuteNonQuery.ProcessSqlParams(param);
      StringBuilder querySb = new StringBuilder($"exec {storedProcedureName}");
      try
      {
      
        if (parameters != null && parameters.Count() > 0)
        {
          for (int i = 0; i < parameters.Count(); i++)
          {
            if (i != 0)
              querySb.Append(",");
            querySb.Append($" {parameters[i].ParameterName}={parameters[i].ParameterName}");
            if (parameters[i].Direction == ParameterDirection.Output)
              querySb.Append(" output");
          }

          return context.Set<T>().FromSqlRaw(querySb.ToString(), parameters.ToArray());
          //return result;
        }
        return context.Set<T>().FromSqlRaw(querySb.ToString());
      }
      catch (Exception ex)
      {
        var x = new Exception(storedProcedureName, ex);
        throw x;
      }
      finally
      {
        querySb.Clear();
        querySb = null;
       // parameters.Clear();
        //parameters = null;
      }
    }

    //public static IEnumerable<T> ExecuteFunction(DbContext context, string storedProcedureName, object[] parameters = null)
    //{
    //  String parameter = ExecuteQuery.Getarg(parameters);
    //  StringBuilder querySb = new StringBuilder($"select * from {storedProcedureName}("+ parameter +")");
    //  //string pa = "";

    //  if (parameters != null && parameters.Count() > 0)
    //  {
    //    return context.Set<T>().FromSqlRaw(querySb.ToString());
    //  }
    //  return context.Set<T>().FromSqlRaw(querySb.ToString());
    //}

    /// <summary>
    /// FunctionName with SchemaName
    /// Parameters should be array of value type(int, float, string)
    /// </summary>
    /// <param name="context"></param>
    /// <param name="functionName"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static IQueryable<T> ExecuteFunction(DbContext context, string functionName, object[] parameters)
    {
      StringBuilder querySb = new StringBuilder($"SELECT * FROM {functionName}(");
      try
      {
      

        if (parameters != null && parameters.Count() > 0)
        {
          var parameterStr = string.Join(",", parameters.Select(x => "'" + x.ToString().Replace("'", "''") + "'"));
          querySb.Append(parameterStr);
        }
        querySb.Append(")");

        return context.Set<T>().FromSqlRaw(querySb.ToString());      
       }
      catch (Exception ex)
      {
        var x = new Exception(functionName, ex);
        throw x;
      }
      finally
      {
        querySb.Clear();
        querySb = null;       
       // parameters = null;
      }
    }

        public static IQueryable<T> ExecuteFunction1(DbContext context, string functionName, List<SqlParameter> parameters)
        {
            StringBuilder querySb = new StringBuilder($"SELECT * FROM {functionName}(");
            try
            {


                //if (parameters != null && parameters.Count() > 0)
                //{
                    
                //    var parameterStr = string.Join(",", parameters.Select(x => "'" + x.Value.ToString().Replace("'", "''").Replace(".m.","M") + "'"));
                //    querySb.Append(parameterStr);
                //}
                string parameterStr = "";
                foreach (var parameter in parameters)
                {
                    parameterStr = string.IsNullOrEmpty(parameterStr) ? parameterStr : parameterStr + ",";
                    if (parameter.Value.GetType().Name.Equals("DateTime"))
                    {

                        parameterStr = parameterStr + "'" + ((DateTime)parameter.Value).ToString("yyyy-MM-dd hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).Replace("'", "''") + "'";  // string.Join(",", "'" + parameter.ToString().Replace("'", "''") + "'");

                    }
                    else
                    {
                        parameterStr = parameterStr + "'" + parameter.Value.ToString().Replace("'", "''") + "'";  //parameterStr + string.Join(",", "'" + parameter.ToString().Replace("'", "''") + "'");

                    }
                    
                }
                querySb.Append(parameterStr);
                querySb.Append(")");

                return context.Set<T>().FromSqlRaw(querySb.ToString());
            }
            catch (Exception ex)
            {
                var x = new Exception(functionName, ex);
                throw x;
            }
            finally
            {
                querySb.Clear();
                querySb = null;
                // parameters = null;
            }
        }



    }
    public class ExecuteNonQuery
  {
    public static Int32 ExecuteStoredProcedure(DbContext context, string storedProcedureName, object[] parameters = null)
    {
      StringBuilder querySb = new StringBuilder($"exec {storedProcedureName}");
      try
      {
        
        //string pa = "";
        if (parameters != null && parameters.Count() > 0)
        {
          //for (int i = 0; i < parameters.Count(); i++)
          //{
          //  pa = pa + " @p" + i + ",";
          //}
          //int p = pa.LastIndexOf(",");
          //pa = pa.Substring(0, p);
          //// querySb.Append($" @p{i},");
          querySb.Append(ExecuteQuery.GettParaStr(parameters));
          return context.Database.ExecuteSqlRaw(querySb.ToString(), parameters);
        }
        return context.Database.ExecuteSqlRaw(querySb.ToString(), parameters);
      }
      catch(Exception ex)
      {
        var x = new Exception(storedProcedureName, ex);
        throw x;
      }
      finally
      {
        querySb.Clear();
        querySb = null;
        //parameters = null;
      }
    }

    public static int ExecuteStoredProcedure(DbContext context, string storedProcedureName
        , ref List<SqlParameter> param)
    {
      var parameters = ProcessSqlParams(param);
      StringBuilder querySb = new StringBuilder($"exec {storedProcedureName}");
      try
      {
       

        if (parameters != null && parameters.Count() > 0)
        {
          for (int i = 0; i < parameters.Count(); i++)
          {
            if (i != 0)
              querySb.Append(",");
            querySb.Append($" {parameters[i].ParameterName}={parameters[i].ParameterName}");
            if (parameters[i].Direction == ParameterDirection.Output)
              querySb.Append(" output");
          }

          var result = context.Database.ExecuteSqlRaw(querySb.ToString(), parameters.ToArray());
          return result;
        }
        return context.Database.ExecuteSqlRaw(querySb.ToString());
      }
      catch(Exception ex)
      {
        var x = new Exception(storedProcedureName, ex);
        throw x;
      }
      finally
      {
        querySb.Clear();
        querySb = null;
        //parameters.Clear();
        //parameters = null;
      }
    }

    public static int ExecuteStoredProcedure(DbContext context, string storedProcedureName
       , List<SqlParameter> param)
    {
      var parameters = ProcessSqlParams(param);
      StringBuilder querySb = new StringBuilder($"exec {storedProcedureName}");
      try
      {
      

        if (parameters != null && parameters.Count() > 0)
        {
          for (int i = 0; i < parameters.Count(); i++)
          {
            if (i != 0)
              querySb.Append(",");
            querySb.Append($" {parameters[i].ParameterName}={parameters[i].ParameterName}");
            if (parameters[i].Direction == ParameterDirection.Output)
              querySb.Append(" output");
          }

          var result = context.Database.ExecuteSqlRaw(querySb.ToString(), parameters.ToArray());
          return result;
        }
        return context.Database.ExecuteSqlRaw(querySb.ToString());
      }
      catch(Exception ex)
      {
        var x = new Exception(storedProcedureName, ex);
        throw x;
      }
      finally
      {
        querySb.Clear();
        querySb = null;
        //parameters.Clear();
        //parameters = null;
      }
    }

    public static List<SqlParameter> ProcessSqlParams(List<SqlParameter> parameters)
    {
      foreach (var item in parameters)
      {
        if (item.Value == null)
        {
          item.Value = DBNull.Value;
          item.IsNullable = true;
        }
        if (item.DbType == DbType.DateTime)
        {
           if(item.Value != DBNull.Value)
           {
               if (Convert.ToDateTime(item.Value) == DateTime.MaxValue || Convert.ToDateTime(item.Value) == DateTime.MinValue)
               {
                   item.IsNullable = true;
                   item.Value = DBNull.Value;
               }
           }
        }
        //if (item.Direction!=ParameterDirection.Output)
        {
          if (item.DbType == DbType.String)
          {
            if (item.Value != null)
            {
              if(item.Size==0)
                item.Size = item.Value.ToString().Length;
            }
            else
              item.Size = 0;
          }
        }
      }
      return parameters;
    }


  }


  public class ExecuteNonQuery<T> where T : class
  {

    public static IEnumerable<T> ExecuteStoredProcedure(DbContext context, string storedProcedureName
        , ref List<SqlParameter> param)
    {
      var parameters = ExecuteNonQuery.ProcessSqlParams(param);
      StringBuilder querySb = new StringBuilder($"exec {storedProcedureName}");
      try
      {
       
        if (parameters != null && parameters.Count() > 0)
        {
          for (int i = 0; i < parameters.Count(); i++)
          {
            if (i != 0)
              querySb.Append(",");
            querySb.Append($" {parameters[i].ParameterName}={parameters[i].ParameterName}");
            if (parameters[i].Direction == ParameterDirection.Output)
              querySb.Append(" output");
          }
          return context.Set<T>().FromSqlRaw(querySb.ToString(), parameters.ToArray());
        }
        return context.Set<T>().FromSqlRaw(querySb.ToString());
      }
      catch(Exception ex)
      {
        var x = new Exception(storedProcedureName, ex);
        throw x;
      }
      finally
      {
        querySb.Clear();
        querySb = null;
        //parameters.Clear();
        //parameters = null;
      }
    }

    //public static IEnumerable<T> ExecuteStoredProcedure(DbContext context, string storedProcedureName
    //, ref SqlParameter[] parameters)
    //{
    //  StringBuilder querySb = new StringBuilder($"exec {storedProcedureName}");
    //  if (parameters != null && parameters.Count() > 0)
    //  {
    //    for (int i = 0; i < parameters.Count(); i++)
    //    {
    //      if (i != 0)
    //        querySb.Append(",");
    //      querySb.Append($" {parameters[i].ParameterName}={parameters[i].ParameterName}");
    //      if (parameters[i].Direction == ParameterDirection.Output)
    //        querySb.Append(" output");
    //    }
    //    return context.Set<T>().FromSqlRaw(querySb.ToString(), parameters);
    //  }
    //  return context.Set<T>().FromSqlRaw(querySb.ToString());
    //}

  }

  public class XElement1
  {
    public static XElement Parse(string info)
    {
      if (info != null)
        return XElement.Parse(info);
      else return null;

    }
  }
}
