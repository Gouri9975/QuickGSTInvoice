using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public class Activities2Tasks : Csla.BusinessListBase<Activities2Tasks, Activities2Task>
    {
        #region Constuctor
        public Activities2Tasks()
        {
            MarkAsChild();
        }
        #endregion

        #region BindingList Overrides


        //internal void UpdateObjectIDs(Guid Id)
        //{
        //    foreach (Activities2Task itm in this)
        //        itm.UpdateObjectIDs(Id);
        //}
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static Activities2Tasks NewActivities2Tasks()
        {
            return new Activities2Tasks();
        }
        #endregion //Factory Methods

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public Criteria() { }
            public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(c => c.Id);
            public string Id
            {
                get { return ReadProperty(IdProperty); }
                private set { LoadProperty(IdProperty, value); }
            }
            public Criteria(string BId)
            {
                this.Id = BId;
            }
        }


    [Serializable()]
    private class ActivitiesIDCriteria : CriteriaBase<ActivitiesIDCriteria>
    {
      public ActivitiesIDCriteria() { }
      public static readonly PropertyInfo<string> ActivitiesIDProperty = RegisterProperty<string>(c => c.ActivitiesID);
      public string ActivitiesID
      {
        get { return ReadProperty(ActivitiesIDProperty); }
        private set { LoadProperty(ActivitiesIDProperty, value); }
      }
      public ActivitiesIDCriteria(string BId)
      {
        this.ActivitiesID = BId;
      }
    }
    #region Data Access

#if !NETFX_CORE

    internal static Activities2Tasks GetItemActivities2Tasks(string Id)
        {
            Activities2Tasks list = DataPortal.Fetch<Activities2Tasks>(new Criteria(Id));
            list.MarkAsChild();
            return list;
        }

    internal static Activities2Tasks GetItemActivities2Tasks_ByActivitiesID(string ActivitiesID)
    {
      Activities2Tasks list = DataPortal.Fetch<Activities2Tasks>(new ActivitiesIDCriteria(ActivitiesID));
      list.MarkAsChild();
      return list;
    }

    private void DataPortal_Fetch(ActivitiesIDCriteria ActivitiesIDCriteria)
    {
      this.RaiseListChangedEvents = false;

      using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
      {

        var List = ctx.DataContext.Activities2Tasks_GetByActivitiesID(ActivitiesIDCriteria.ActivitiesID);

        foreach (var itm in List)
          this.Add(Csla.DataPortal.FetchChild<Activities2Task>(itm));
      }

      this.RaiseListChangedEvents = true;
    }

    private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;

            using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {

                var List = ctx.DataContext.Activities2Tasks_All();

                foreach (var itm in List)
                    this.Add(Csla.DataPortal.FetchChild<Activities2Task>(itm));
            }

            this.RaiseListChangedEvents = true;
        }
#endif
        #endregion
    }
}