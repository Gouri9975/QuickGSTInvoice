using Csla;
using Csla.Serialization;
using System;
using System.Threading.Tasks;

namespace e2.CDM.Lib
{
  #region OdataJsonHelper
  public class OdataCDMJson<T>
  {

    public static string GetJsonString(T DTOClass)
    {
      Newtonsoft.Json.JsonSerializerSettings set = new Newtonsoft.Json.JsonSerializerSettings();
      set.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
      serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
      return Newtonsoft.Json.JsonConvert.SerializeObject(DTOClass);
    }


  }
  public class CDMDTO
  {
    public String ClassName { get; set; }
  }

  #endregion

  [Serializable()]
  public class CDMEntityKeys : Csla.BusinessBase<CDMEntityKeys>
  {
    #region GetNextIdValue


    [Serializable]
    public class GetNextIdValueCommand : CommandBase<GetNextIdValueCommand>
    {
      public static readonly PropertyInfo<System.Boolean> WithSvrIdProperty = RegisterProperty<System.Boolean>(c => c.WithSvrId);
      private System.Boolean WithSvrId
      {
        get { return ReadProperty(WithSvrIdProperty); }
        set { LoadProperty(WithSvrIdProperty, value); }
      }

      public static readonly PropertyInfo<System.String> BillTypeProperty = RegisterProperty<System.String>(c => c.BillType);
      private System.String BillType
      {
        get { return ReadProperty(BillTypeProperty); }
        set { LoadProperty(BillTypeProperty, value); }
      }

      public static readonly PropertyInfo<System.String> NewIDProperty = RegisterProperty<System.String>(c => c.NewID);
      public System.String NewID
      {
        get { return ReadProperty(NewIDProperty); }
        private set { LoadProperty(NewIDProperty, value); }
      }

      public GetNextIdValueCommand(string billType, bool withSvrId)
      {
        this.BillType = billType;
        this.WithSvrId = withSvrId;
      }

      public GetNextIdValueCommand()
      { }

      #if !SILVERLIGHT && !NETFX_CORE

      protected override void DataPortal_Execute()
      {
        using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                  .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
        {
          string Result = string.Empty;
          if (WithSvrId)
            ctx.DataContext.GetNextBillingID_OUT(BillType, ref Result);
          else
            ctx.DataContext.GetNextBillingIDExcptSvrID_OUT(BillType, ref Result);
          NewID = Result;
        }
      }

      #endif
    }



    #endregion


    public static string ActivityIDNextId()
    {
      var cmd = new GetNextIdValueCommand("ACTIVITYID", true);
      cmd = DataPortal.Execute<GetNextIdValueCommand>(cmd);
      return cmd.NewID;
    }
    public static string HResourceIDNextId()
    {
      var cmd = new GetNextIdValueCommand("HRESOURCEID", true);
      cmd = DataPortal.Execute<GetNextIdValueCommand>(cmd);
      return cmd.NewID;
    }
    public static string HResourceCodeNextId()
    {
      var cmd = new GetNextIdValueCommand("HRESOURCECODE", true);
      cmd = DataPortal.Execute<GetNextIdValueCommand>(cmd);
      return cmd.NewID;
    }

    public static string TaskIDNextId()
    {
      var cmd = new GetNextIdValueCommand("TASKID", true);
      cmd = DataPortal.Execute<GetNextIdValueCommand>(cmd);
      return cmd.NewID;
    }

    public static string ProjectIDNextId()
    {
      var cmd = new GetNextIdValueCommand("PROJECTID", true);
      cmd = DataPortal.Execute<GetNextIdValueCommand>(cmd);
      return cmd.NewID;
    }

    public static string EquipmentIDNextId()
    {
      var cmd = new GetNextIdValueCommand("EQUIPMENTID", true);
      cmd = DataPortal.Execute<GetNextIdValueCommand>(cmd);
      return cmd.NewID;
    }
 

  }
}
