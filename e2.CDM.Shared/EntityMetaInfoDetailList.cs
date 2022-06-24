
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;
using System.Xml;
using System.Xml.Serialization;

namespace e2.CDM.Lib
{
    [Serializable()]
    public class EntityMetaInfoDetailList : Csla.ReadOnlyListBase<EntityMetaInfoDetailList, EntityMetaInfoDetail>
    {
        #region Constuctor
        public EntityMetaInfoDetailList()
        { }
        #endregion

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in EntityMetaInfoDetailList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BlogInfosViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods

        public static async System.Threading.Tasks.Task<EntityMetaInfoDetailList> GetEntityMetaInfoDetailListAsync()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<EntityMetaInfoDetailList>();
        }
        public static async System.Threading.Tasks.Task<EntityMetaInfoDetailList> EntityMetaInfoDetail_GetByEntityDetailsIDAsync(string EntityMetaInfoDetailID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BlogInfos");
            return await DataPortal.FetchAsync<EntityMetaInfoDetailList>(new EntityMetaInfoDetailIDCriteria(EntityMetaInfoDetailID));
        }




#if !NETFX_CORE
#endif
        #endregion //Factory Methods


        #region Filter Criteria

        [Serializable()]
        private class EntityMetaInfoDetailIDCriteria : CriteriaBase<EntityMetaInfoDetailIDCriteria>
        {

            public static readonly PropertyInfo<string> EntityMetaInfoDetailIDProperty = RegisterProperty<string>(c => c.EntityMetaInfoDetailID);
            public string EntityMetaInfoDetailID
            {
                get { return ReadProperty(EntityMetaInfoDetailIDProperty); }
                set { LoadProperty(EntityMetaInfoDetailIDProperty, value); }
            }
            public EntityMetaInfoDetailIDCriteria()
            { }
            public EntityMetaInfoDetailIDCriteria(string _EntityMetaInfoDetailIDCriteria)
            {
                this.EntityMetaInfoDetailID = _EntityMetaInfoDetailIDCriteria;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
#if !NETFX_CORE
        private void DataPortal_Fetch()
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.EntityMetaInfoDetails_GetAll()
                  select EntityMetaInfoDetail.GetEntityMetaInfoDetail(row)
                );

                IsReadOnly = true;
            } //using
        }

        private void DataPortal_Fetch(EntityMetaInfoDetailIDCriteria criteria)
        {
            using (var mgr = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                       .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection))
            {
                IsReadOnly = false;

                this.AddRange(
                  from row in mgr.DataContext.EntityMetaInfoDetail_Get(criteria.EntityMetaInfoDetailID)
                  select EntityMetaInfoDetail.GetEntityMetaInfoDetail(row)
                );

                IsReadOnly = true;
            } //using
        }

#endif


        //Standard Ver


        #endregion //Data Access
    }
}
