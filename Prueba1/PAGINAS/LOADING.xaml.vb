Imports Prueba1.ModHelp
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class LOADING
    Inherits Page

    Public Async Sub Girar()
        While 1 = 1
            'LOADI.GetChildObject(Of RotateTransform)("Giro2").Angle = 90
            Await Task.Delay(TimeSpan.FromMilliseconds(10))
            giro.Angle = giro.Angle + 0.3
            ' LOADI.GetChildObject(Of RotateTransform)("Giro2").Angle = 90
        End While

    End Sub

    Private Sub LOADING_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Girar()
    End Sub


End Class
