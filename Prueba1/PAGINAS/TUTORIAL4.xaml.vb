' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class TUTORIAL4
    Inherits Page

    Private Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click
        Me.Frame.Navigate(GetType(TUTORIAL5))
    End Sub
End Class
