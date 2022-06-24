
using System;
using System.Data;
using System.Linq;
using Csla;
using Csla.Data;

namespace e2.CDM.Lib
{
    [Serializable()]
    public partial class EntityMetaInfoDetail : Csla.ReadOnlyBase<EntityMetaInfoDetail>
    {
        #region Constuctor
        public EntityMetaInfoDetail()
        { }
    #endregion

    #region Business Properties and Methods

    
    public static readonly PropertyInfo<string> EntityMetaInfoDetailIDProperty = RegisterProperty<string>(nameof(EntityMetaInfoDetailID));
    public string EntityMetaInfoDetailID
        {
        get => GetProperty(EntityMetaInfoDetailIDProperty);
        set => LoadProperty(EntityMetaInfoDetailIDProperty, value);
    } 
        public static readonly PropertyInfo<string> EntityMetaInfoIDProperty = RegisterProperty<string>(nameof(EntityMetaInfoID));
    public string EntityMetaInfoID
        {
        get => GetProperty(EntityMetaInfoIDProperty);
        set => LoadProperty(EntityMetaInfoIDProperty, value);
    } 
    public static readonly PropertyInfo<string> MetaInfoTypeIDProperty = RegisterProperty<string>(c => c.MetaInfoTypeID);
    public string MetaInfoTypeID
        {
      get { return GetProperty(MetaInfoTypeIDProperty); }
      set { LoadProperty(MetaInfoTypeIDProperty, value); }
    }
        public static readonly PropertyInfo<string> AsileProperty = RegisterProperty<string>(c => c.Asile);
    public string Asile
        {
      get { return GetProperty(AsileProperty); }
      set { LoadProperty(AsileProperty, value); }
    }
        public static readonly PropertyInfo<string> RackProperty = RegisterProperty<string>(c => c.Rack);
    public string Rack
        {
      get { return GetProperty(RackProperty); }
      set { LoadProperty(RackProperty, value); }
    }
        public static readonly PropertyInfo<string> PositionProperty = RegisterProperty<string>(c => c.Position);
    public string Position
        {
      get { return GetProperty(PositionProperty); }
      set { LoadProperty(PositionProperty, value); }
    }
        public static readonly PropertyInfo<string> ShelfProperty = RegisterProperty<string>(c => c.Shelf);
    public string Shelf
        {
      get { return GetProperty(ShelfProperty); }
      set { LoadProperty(ShelfProperty, value); }
    }
        public static readonly PropertyInfo<string> BinLocationProperty = RegisterProperty<string>(c => c.BinLocation);
    public string BinLocation
        {
      get { return GetProperty(BinLocationProperty); }
      set { LoadProperty(BinLocationProperty, value); }
    }
        public static readonly PropertyInfo<string> AvailStatusProperty = RegisterProperty<string>(c => c.AvailStatus);
    public string AvailStatus
        {
      get { return GetProperty(AvailStatusProperty); }
      set { LoadProperty(AvailStatusProperty, value); }
    }


    #endregion //Business Properties and Methods

    #region Authorization Rules
    protected void AddAuthorizationRules()
        {


        }

        #endregion //Authorization Rules

        #region Factory Methods

        #endregion //Factory Methods

        #region Data Access

        #region Data Access - Fetch
#if !NETFX_CORE
        internal static EntityMetaInfoDetail GetEntityMetaInfoDetail(e2.CDM.DAL.Lib.EntityMetaInfoDetails_GetAllResult data)
        {
            EntityMetaInfoDetail item = new EntityMetaInfoDetail();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.EntityMetaInfoDetails_GetAllResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                EntityMetaInfoID = data.EntityMetaInfoID;
                EntityMetaInfoDetailID = data.EntityMetaInfoDetailID;
                MetaInfoTypeID = data.MetaInfoTypeID;
                Asile = data.Asile;
                Rack = data.Rack;
                Position = data.Position;
                Shelf = data.Shelf;
                BinLocation = data.BinLocation;
                AvailStatus = data.AvailStatusID;

            }
            OnFetched();
        }

        internal static EntityMetaInfoDetail GetEntityMetaInfoDetail(e2.CDM.DAL.Lib.EntityMetaInfoDetail_GetResult data)
        {
            EntityMetaInfoDetail item = new EntityMetaInfoDetail();
            item.Fetch(data);
            return item;
        }


        private void Fetch(e2.CDM.DAL.Lib.EntityMetaInfoDetail_GetResult data)
        {
            bool cancel = false;
            OnFetching(ref cancel);
            if (cancel) return;
            if (data != null)
            {
                EntityMetaInfoID = data.EntityMetaInfoID;
                EntityMetaInfoDetailID = data.EntityMetaInfoDetailID;
                MetaInfoTypeID = data.MetaInfoTypeID;
                Asile = data.Asile;
                Rack = data.Rack;
                Position = data.Position;
                Shelf = data.Shelf;
                BinLocation = data.BinLocation;
                AvailStatus = data.AvailStatusID;

            }
            OnFetched();
        }

        partial void OnFetching(ref bool cancel);
        partial void OnFetched();

        private void FetchObject(SafeDataReader dr)
        {


        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
#endif

        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
