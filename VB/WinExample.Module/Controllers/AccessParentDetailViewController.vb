Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports WinExample.Module.BusinessObjects
Imports DevExpress.ExpressApp.Editors

Namespace WinExample.Module.Controllers
    Partial Public Class AccessParentDetailViewController
        Inherits ViewController

        Public Sub New()
            InitializeComponent()
            RegisterActions(components)
            TargetViewType = ViewType.ListView
            TargetViewNesting = Nesting.Nested
            TargetObjectType = GetType(DomainObject2)
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler View.CurrentObjectChanged, AddressOf View_CurrentObjectChanged
            UpdateDetailViewCaption()
        End Sub
        Private Sub View_CurrentObjectChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateDetailViewCaption()
        End Sub
        Private Sub UpdateDetailViewCaption()
            If TypeOf Frame Is NestedFrame Then
                If CurrentObject IsNot Nothing Then
                    CType(Frame, NestedFrame).ViewItem.View.Caption = CurrentObject.Name
                End If
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            MyBase.OnDeactivated()
            RemoveHandler View.CurrentObjectChanged, AddressOf View_CurrentObjectChanged
        End Sub
        Public ReadOnly Property CurrentObject() As DomainObject2
            Get
                Return DirectCast(View.CurrentObject, DomainObject2)
            End Get
        End Property
        Public ReadOnly Property MySimpleAction2() As SimpleAction
            Get
                Return simpleAction1
            End Get
        End Property
    End Class
End Namespace
