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
    public partial class AccessNestedListViewController : ViewController {
        public AccessNestedListViewController() {
            InitializeComponent();
            RegisterActions(components);
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(DomainObject1);
        }
        protected override void OnActivated() {
            base.OnActivated();
            ListPropertyEditor listPropertyEditor = ((DetailView)View).FindItem("DomainObject2s") as ListPropertyEditor;
            if (listPropertyEditor != null) {
                listPropertyEditor.ControlCreated += new EventHandler<EventArgs>(listPropertyEditor_ControlCreated);
            }
        }
        void listPropertyEditor_ControlCreated(object sender, EventArgs e) {
            ListPropertyEditor listPropertyEditor = (ListPropertyEditor)sender;
            Frame listViewFrame = listPropertyEditor.Frame;
            ListView nestedListView = listPropertyEditor.ListView;
            UpdateMySimpleAction1Caption((DomainObject2)nestedListView.CurrentObject);
            nestedListView.CurrentObjectChanged += new EventHandler(nestedListView_CurrentObjectChanged);
            AccessParentDetailViewController accessParentDetailViewController = listViewFrame.GetController<AccessParentDetailViewController>();
            if (accessParentDetailViewController != null) {
                accessParentDetailViewController.MySimpleAction2.Caption = CurrentObject.Name;
            }
        }
        void nestedListView_CurrentObjectChanged(object sender, EventArgs e) {
            UpdateMySimpleAction1Caption((DomainObject2)((ListView)sender).CurrentObject);
        }
        private void UpdateMySimpleAction1Caption(DomainObject2 obj) {
            if (obj != null) {
                MySimpleAction1.Caption = obj.Name;
            }
        }
        public DomainObject1 CurrentObject {
            get { return (DomainObject1)View.CurrentObject; }
        }
        public SimpleAction MySimpleAction1 {
            get { return simpleAction1; }
        }
    }
}
