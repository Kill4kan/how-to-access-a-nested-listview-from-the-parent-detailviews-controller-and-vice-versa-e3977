Namespace WinExample.Module.Controllers
    Partial Public Class AccessParentDetailViewController
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Component Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.simpleAction1 = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
            ' 
            ' simpleAction1
            ' 
            Me.simpleAction1.Caption = Nothing
            Me.simpleAction1.ConfirmationMessage = Nothing
            Me.simpleAction1.Id = "276bbc79-194f-4671-aaee-8e047e92ac61"
            Me.simpleAction1.ToolTip = Nothing
            ' 
            ' AccessParentDetailViewController
            ' 
            Me.Actions.Add(Me.simpleAction1)

        End Sub

        #End Region

        Private simpleAction1 As DevExpress.ExpressApp.Actions.SimpleAction
    End Class
End Namespace
