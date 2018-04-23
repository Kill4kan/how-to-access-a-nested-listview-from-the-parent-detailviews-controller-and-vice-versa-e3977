using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using WinExample.Module.BusinessObjects;
using DevExpress.ExpressApp.Editors;

namespace WinExample.Module.Controllers {
    public partial class AccessParentDetailViewController : ViewController {
        public AccessParentDetailViewController() {
            InitializeComponent();
            RegisterActions(components);
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Nested;
            TargetObjectType = typeof(DomainObject2);
        }
        protected override void OnActivated() {
            base.OnActivated();
            View.CurrentObjectChanged += new EventHandler(View_CurrentObjectChanged);
            UpdateDetailViewCaption();
        }
        void View_CurrentObjectChanged(object sender, EventArgs e) {
            UpdateDetailViewCaption();
        }
        private void UpdateDetailViewCaption() {
            if (Frame is NestedFrame) {
                if (CurrentObject != null) {
                    ((NestedFrame)Frame).ViewItem.View.Caption = CurrentObject.Name;
                }
            }
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            View.CurrentObjectChanged -= new EventHandler(View_CurrentObjectChanged);
        }
        public DomainObject2 CurrentObject {
            get { return (DomainObject2)View.CurrentObject; }
        }
        public SimpleAction MySimpleAction2 {
            get { return simpleAction1; }
        }
    }
}
