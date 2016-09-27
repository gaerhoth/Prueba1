' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class INFO
    Inherits Page

    Private Sub INFO_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading

    End Sub

    Private Sub BTN_TERMINOS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_TERMINOS.Click
        Me.Frame.Navigate(GetType(TEXTOLEGAL))
    End Sub
End Class
