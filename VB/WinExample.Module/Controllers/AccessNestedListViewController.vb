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
    Partial Public Class AccessNestedListViewController
        Inherits ViewController

        Public Sub New()
            InitializeComponent()
            RegisterActions(components)
            TargetViewType = ViewType.DetailView
            TargetObjectType = GetType(DomainObject1)
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim listPropertyEditor As ListPropertyEditor = TryCast(CType(View, DetailView).FindItem("DomainObject2s"), ListPropertyEditor)
            If listPropertyEditor IsNot Nothing Then
                AddHandler listPropertyEditor.ControlCreated, AddressOf listPropertyEditor_ControlCreated
            End If
        End Sub
        Private Sub listPropertyEditor_ControlCreated(ByVal sender As Object, ByVal e As EventArgs)
            Dim listPropertyEditor As ListPropertyEditor = DirectCast(sender, ListPropertyEditor)
            Dim listViewFrame As Frame = listPropertyEditor.Frame
            Dim nestedListView As ListView = listPropertyEditor.ListView
            UpdateMySimpleAction1Caption(DirectCast(nestedListView.CurrentObject, DomainObject2))
            AddHandler nestedListView.CurrentObjectChanged, AddressOf nestedListView_CurrentObjectChanged
            Dim accessParentDetailViewController As AccessParentDetailViewController = listViewFrame.GetController(Of AccessParentDetailViewController)()
            If accessParentDetailViewController IsNot Nothing Then
                accessParentDetailViewController.MySimpleAction2.Caption = CurrentObject.Name
            End If
        End Sub
        Private Sub nestedListView_CurrentObjectChanged(ByVal sender As Object, ByVal e As EventArgs)
            UpdateMySimpleAction1Caption(DirectCast(DirectCast(sender, ListView).CurrentObject, DomainObject2))
        End Sub
        Private Sub UpdateMySimpleAction1Caption(ByVal obj As DomainObject2)
            If obj IsNot Nothing Then
                MySimpleAction1.Caption = obj.Name
            End If
        End Sub
        Public ReadOnly Property CurrentObject() As DomainObject1
            Get
                Return DirectCast(View.CurrentObject, DomainObject1)
            End Get
        End Property
        Public ReadOnly Property MySimpleAction1() As SimpleAction
            Get
                Return simpleAction1
            End Get
        End Property
    End Class
End Namespace
