using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinExample.Module.BusinessObjects {
    [DefaultClassOptions]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session)
            : base(session) { }
        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }
        [Association("DomainObject1-DomainObject2s")]
        public XPCollection<DomainObject2> DomainObject2s {
            get {
                return GetCollection<DomainObject2>("DomainObject2s");
            }
        }
    }
}
