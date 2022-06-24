//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace e2.Data.EFCore
//{
//  public static class CacheD<V>
//  {
//    //private static object _lock = new object();
//    public static void Set(Dictionary<string, V> _DList, V Value)
//    {

//      if (_DList == null)
//        _DList = new Dictionary<string, V>();

//      if (Csla.ApplicationContext.GlobalContext["_Company"] != null)
//      {
//        string CompanyID = (Csla.ApplicationContext.GlobalContext["_Company"]).ToString();
//        if (!string.IsNullOrEmpty(CompanyID))
//        {
//          var d = _DList.Where(p => p.Key.Equals(CompanyID)).FirstOrDefault().Value;

//          //_Dlist.Remove(CompanyID);
//          lock (_DList)
//          {
//            if (_DList.Keys.Contains(CompanyID))
//            {
//              _DList.Remove(CompanyID);
//            }
//            _DList.Add(CompanyID, Value);
//          }

//        }
//        else
//        {
//          lock (_DList)
//          {
//            if (_DList.Keys.Contains("D"))
//            {
//              _DList.Remove("D");
//            }
//            _DList.Add("D", Value);
//          }
//        }

//      }
//      else
//      {
//        lock (_DList)
//        {
//          if (_DList.Keys.Contains("D"))
//          {
//            _DList.Remove("D");
//          }
//          _DList.Add("D", Value);
//        }
//      }
//    }
//    public static V Get(Dictionary<string, V> _DList)
//    {
//       if (_DList == null)
//        _DList = new Dictionary<string, V>();

//      if (Csla.ApplicationContext.GlobalContext["_Company"] != null)
//      {
//        string CompanyID = (Csla.ApplicationContext.GlobalContext["_Company"]).ToString();
//        if (!string.IsNullOrEmpty(CompanyID))
//        {
//          var d = _DList.Where(p => p.Key.Equals(CompanyID)).FirstOrDefault();
//          if (d.Value != null)
//            return d.Value;
//        }
//        else
//        {
//          var d = _DList.Where(p => p.Key.Equals("D")).FirstOrDefault();
//          if (d.Value != null)
//            return d.Value;
//        }
//      }
//      else
//      {
//        var d = _DList.Where(p => p.Key.Equals("D")).FirstOrDefault();
//        if (d.Value != null)
//          return d.Value;
//      }
//      return default(V);
//    }

//    public static void Set(ConcurrentDictionary<string, V> _DList, V Value)
//    {
//      if (_DList == null)
//        _DList = new ConcurrentDictionary<string, V>();

//      if (Csla.ApplicationContext.GlobalContext["_Company"] != null)
//      {
//        string CompanyID = (Csla.ApplicationContext.GlobalContext["_Company"]).ToString();
//        if (!string.IsNullOrEmpty(CompanyID))
//        {
//          var d = _DList.Where(p => p.Key.Equals(CompanyID)).FirstOrDefault().Value;
//          //_Dlist.Remove(CompanyID);
//          if (_DList.Keys.Contains(CompanyID))
//          {
//            V q;
//            _DList.TryRemove(CompanyID,out q);
//          }
//          _DList.TryAdd(CompanyID, Value);

//        }
//        else
//        {
//          if (_DList.Keys.Contains("D"))
//          {
//            V q;
//            _DList.TryRemove("D",out q);
//          }
//          _DList.TryAdd("D", Value);
//        }

//      }
//      else
//      {
//        if (_DList.Keys.Contains("D"))
//        {
//          V q;
//          _DList.TryRemove("D",out q);
//        }
//        _DList.TryAdd("D", Value);
//      }
//    }
//    public static V Get(ConcurrentDictionary<string, V> _DList)
//    {
//      if (_DList == null)
//        _DList = new ConcurrentDictionary<string, V>();

//      if (Csla.ApplicationContext.GlobalContext["_Company"] != null)
//      {
//        string CompanyID = (Csla.ApplicationContext.GlobalContext["_Company"]).ToString();
//        if (!string.IsNullOrEmpty(CompanyID))
//        {
//          var d = _DList.Where(p => p.Key.Equals(CompanyID)).FirstOrDefault();
//          if (d.Value != null)
//            return d.Value;
//        }
//        else
//        {
//          var d = _DList.Where(p => p.Key.Equals("D")).FirstOrDefault();
//          if (d.Value != null)
//            return d.Value;
//        }
//      }
//      else
//      {
//        var d = _DList.Where(p => p.Key.Equals("D")).FirstOrDefault();
//        if (d.Value != null)
//          return d.Value;
//      }
//      return default(V);
//    }
//  }




//}
