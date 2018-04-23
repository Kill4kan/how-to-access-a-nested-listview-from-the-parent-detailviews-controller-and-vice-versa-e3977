Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Security
Imports WinExample.Module.BusinessObjects

Namespace WinExample.Module.DatabaseUpdate
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim master As DomainObject1 = ObjectSpace.FindObject(Of DomainObject1)(New BinaryOperator("Name", "Master"))
            If master Is Nothing Then
                master = ObjectSpace.CreateObject(Of DomainObject1)()
                master.Name = "Master"
                Dim detail1 As DomainObject2 = ObjectSpace.CreateObject(Of DomainObject2)()
                detail1.Name = "Detail 1"
                detail1.DomainObject1 = master
                Dim detail2 As DomainObject2 = ObjectSpace.CreateObject(Of DomainObject2)()
                detail2.Name = "Detail 2"
                detail2.DomainObject1 = master
            End If
        End Sub
    End Class
End Namespace
