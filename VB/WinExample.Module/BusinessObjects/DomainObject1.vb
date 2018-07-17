Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinExample.Module.BusinessObjects
    <DefaultClassOptions>
    Public Class DomainObject1
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Name", _Name, value)
            End Set
        End Property
        <Association("DomainObject1-DomainObject2s")>
        Public ReadOnly Property DomainObject2s() As XPCollection(Of DomainObject2)
            Get
                Return GetCollection(Of DomainObject2)("DomainObject2s")
            End Get
        End Property
    End Class
End Namespace
