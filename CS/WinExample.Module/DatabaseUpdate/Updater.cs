using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using WinExample.Module.BusinessObjects;

namespace WinExample.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            DomainObject1 master = ObjectSpace.FindObject<DomainObject1>(new BinaryOperator("Name", "Master"));
            if (master == null) {
                master = ObjectSpace.CreateObject<DomainObject1>();
                master.Name = "Master";
                DomainObject2 detail1 = ObjectSpace.CreateObject<DomainObject2>();
                detail1.Name = "Detail 1";
                detail1.DomainObject1 = master;
                DomainObject2 detail2 = ObjectSpace.CreateObject<DomainObject2>();
                detail2.Name = "Detail 2";
                detail2.DomainObject1 = master;
            }
        }
    }
}
