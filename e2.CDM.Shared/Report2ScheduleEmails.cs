using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
  [Serializable()]
  public class Report2ScheduleEmails : Csla.BusinessListBase<Report2ScheduleEmails, Report2ScheduleEmail>
  {
    #region Constuctor
    public Report2ScheduleEmails()
    {
      MarkAsChild();
    }
    #endregion

    #region BindingList Overrides


    //internal void UpdateObjectIDs(Guid Id)
    //{
    //    foreach (Report2ScheduleEmail itm in this)
    //        itm.UpdateObjectIDs(Id);
    //}
    #endregion //BindingList Overrides

    #region Factory Methods
    internal static Report2ScheduleEmails NewReport2ScheduleEmails()
    {
      return new Report2ScheduleEmails();
    }
    #endregion //Factory Methods

    [Serializable()]
    private class Criteria : CriteriaBase<Criteria>
    {

      public static readonly PropertyInfo<Guid> IDProperty = RegisterProperty<Guid>(c => c.ID);
      public Guid ID
      {
        get { return ReadProperty(IDProperty); }
        set { LoadProperty(IDProperty, value); }
      }
      public Criteria()
      { }
      public Criteria(Guid ID)
      {
        this.ID = ID;
      }
    }

    #region Data Access

#if !NETFX_CORE

    internal static Report2ScheduleEmails GetItemReport2ScheduleEmails(Guid Id)
        {
            Report2ScheduleEmails list = DataPortal.Fetch<Report2ScheduleEmails>(new Criteria(Id));
            list.MarkAsChild();
            return list;
        }
    private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;

            using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {

                var List = ctx.DataContext.Report2ScheduleEmail_GetByID(criteria.ID);

                foreach (var itm in List)
                    this.Add(Csla.DataPortal.FetchChild<Report2ScheduleEmail>(itm));
            }

            this.RaiseListChangedEvents = true;
        }
#endif
    #endregion
  }
}