
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
    public class RoutineDetails : Csla.BusinessListBase<RoutineDetails, RoutineDetail>
    {

        #region Constuctor
        public RoutineDetails()
        {
            MarkAsChild();
        }
        #endregion

        #region BindingList Overrides


        //internal void UpdateObjectIDs(Guid Id)
        //{
        //    foreach (WorkHourDtl itm in this)
        //        itm.UpdateObjectIDs(Id);
        //}
        #endregion //BindingList Overrides

        #region Factory Methods
        public static RoutineDetails NewRoutineDetails()
        {
            return new RoutineDetails();
        }

        public static async System.Threading.Tasks.Task<RoutineDetails> GetRoutineDetailsAsync(Guid RoutineHeaderID)
        {
            return await DataPortal.FetchChildAsync<RoutineDetails>(new Criteria(RoutineHeaderID));
        }
        #endregion //Factory Methods

        [Serializable()]
        private class Criteria : CriteriaBase<Criteria>
        {
            public Criteria() { }
            public static readonly PropertyInfo<Guid> RoutineHeaderIDProperty = RegisterProperty<Guid>(c => c.RoutineHeaderID);
            public Guid RoutineHeaderID
            {
                get { return ReadProperty(RoutineHeaderIDProperty); }
                private set { LoadProperty(RoutineHeaderIDProperty, value); }
            }
            
            public Criteria(Guid BId)
            {
                this.RoutineHeaderID = BId;
            }
        }


        #region Data Access

#if !NETFX_CORE

        public static RoutineDetails GetRoutineDetailsList(Guid RoutineHeaderID)
        {
            RoutineDetails list = DataPortal.Fetch<RoutineDetails>(new Criteria(RoutineHeaderID));
            list.MarkAsChild();
            return list;
        }
       

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;

            using (var ctx = Csla.Data.EntityFrameworkCore1.DbContextManager<e2.CDM.DAL.Lib.CDMEntitiesDataContext>
                                      .GetManager(e2.CDM.DAL.Lib.Database.CDMConnection, "CDMDb"))
            {
                var List = ctx.DataContext.RoutineDetail_GetByRoutineHeaderID(criteria.RoutineHeaderID);

                foreach (var itm in List)
                {                   
                     this.Add(Csla.DataPortal.FetchChild<RoutineDetail>(itm));
                }
            }

            this.RaiseListChangedEvents = true;
        }
#endif
        #endregion
    }
}
