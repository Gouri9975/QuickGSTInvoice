using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public class POCDocs : Csla.BusinessListBase<POCDocs, POCDoc>
    {
        #region Constuctor
        public POCDocs()
        {
            MarkAsChild();
        }
    public void UpdateObjectIDs(string ReferenceID, string ReferenceType)
    {
      foreach (POCDoc itm in this)
        itm.UpdateObjectID(ReferenceID, ReferenceType);
    }
    #endregion

    #region BindingList Overrides



    #endregion //BindingList Overrides

    #region Factory Methods
    public static POCDocs NewPOCDocs()
        {
            return new POCDocs();
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
    private class ReferenceIDCriteria : CriteriaBase<ReferenceIDCriteria>
    {
      public ReferenceIDCriteria() { }
      public static readonly PropertyInfo<string> ReferenceIDProperty = RegisterProperty<string>(c => c.ReferenceID);
      public string ReferenceID
      {
        get { return ReadProperty(ReferenceIDProperty); }
        private set { LoadProperty(ReferenceIDProperty, value); }
      }
      public ReferenceIDCriteria(string BId)
      {
        this.ReferenceID = BId;
      }
    }
    #region Data Access

#if !NETFX_CORE

    internal static POCDocs GetItemPOCDocs(string Id)
        {
            POCDocs list = DataPortal.Fetch<POCDocs>(new Criteria(Id));
            list.MarkAsChild();
            return list;
        }

    public static POCDocs POCDocs_ByReferenceID(string ReferenceID)
    {
      POCDocs list = DataPortal.Fetch<POCDocs>(new ReferenceIDCriteria(ReferenceID));
      list.MarkAsChild();
      return list;
    }
    
    private void DataPortal_Fetch(ReferenceIDCriteria ReferenceIDCriteria)
    {
      this.RaiseListChangedEvents = false;

      using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
      {

        var List = ctx.DataContext.POCDoc_GetByRefID(ReferenceIDCriteria.ReferenceID);

        foreach (var itm in List)
          this.Add(Csla.DataPortal.FetchChild<POCDoc>(itm));
      }

      this.RaiseListChangedEvents = true;
    }

    private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;

            using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {

                //var List = ctx.DataContext.POCDocs_All();

                //foreach (var itm in List)
                //    this.Add(Csla.DataPortal.FetchChild<POCDoc>(itm));
            }

            this.RaiseListChangedEvents = true;
        }
#endif
    #endregion
  }
}