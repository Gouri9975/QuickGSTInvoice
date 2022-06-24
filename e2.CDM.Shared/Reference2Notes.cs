using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public class Reference2Notes : Csla.BusinessListBase<Reference2Notes, Reference2Note>
    {
        #region Constuctor
        public Reference2Notes()
        {
            MarkAsChild();
        }
    public void UpdateObjectIDs(string ReferenceID, string ReferenceType)
    {
      foreach (Reference2Note itm in this)
        itm.UpdateObjectID(ReferenceID, ReferenceType);
    }
    #endregion

    #region BindingList Overrides



    #endregion //BindingList Overrides

    #region Factory Methods
    public static Reference2Notes NewReference2Notes()
        {
            return new Reference2Notes();
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
      public static readonly PropertyInfo<string> ReferenceTypeProperty = RegisterProperty<string>(c => c.ReferenceType);
      public string ReferenceType
      {
        get { return ReadProperty(ReferenceTypeProperty); }
        private set { LoadProperty(ReferenceTypeProperty, value); }
      }
      public ReferenceIDCriteria(string _ReferenceID, string _ReferenceType)
      {
        this.ReferenceID = _ReferenceID;
        this.ReferenceType = _ReferenceType;
      }
    }
    #region Data Access

#if !NETFX_CORE

    //internal static Reference2Notes GetItemReference2Notes(string ReferenceID,string ReferenceType)
    //    {
    //        Reference2Notes list = DataPortal.Fetch<Reference2Notes>(new ReferenceIDCriteria(ReferenceID, ReferenceType));
    //        list.MarkAsChild();
    //        return list;
    //    }

    public static Reference2Notes Reference2Notes_ByReferenceID(string ReferenceID, string ReferenceType)
    {
      Reference2Notes list = DataPortal.Fetch<Reference2Notes>(new ReferenceIDCriteria(ReferenceID, ReferenceType));
      list.MarkAsChild();
      return list;
    }
    
    private void DataPortal_Fetch(ReferenceIDCriteria ReferenceIDCriteria)
    {
      this.RaiseListChangedEvents = false;

      using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
      {

        var List = ctx.DataContext.References2Notes_GetByReference(ReferenceIDCriteria.ReferenceID, ReferenceIDCriteria.ReferenceType);

        foreach (var itm in List)
          this.Add(Csla.DataPortal.FetchChild<Reference2Note>(itm));
      }

      this.RaiseListChangedEvents = true;
    }

    private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;

            using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {

                //var List = ctx.DataContext.Reference2Notes_All();

                //foreach (var itm in List)
                //    this.Add(Csla.DataPortal.FetchChild<Reference2Note>(itm));
            }

            this.RaiseListChangedEvents = true;
        }
#endif
    #endregion
  }
}