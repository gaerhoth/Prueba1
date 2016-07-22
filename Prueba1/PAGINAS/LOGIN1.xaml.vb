' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class LOGIN1
    Inherits Page

    Private Sub BTN_NO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_NO.Click
        Me.Frame.Navigate(GetType(UNETE1))
    End Sub

    Private Sub BTN_Entrar_Click(sender As Object, e As RoutedEventArgs) Handles BTN_Entrar.Click
        Me.Frame.Navigate(GetType(TUTORIAL1))
    End Sub
End Class
