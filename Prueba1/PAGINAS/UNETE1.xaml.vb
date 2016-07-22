' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class UNETE1
    Inherits Page

    Private Sub BTN_REG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_REG.Click
        Me.Frame.Navigate(GetType(UNETE2))
    End Sub

    Private Sub BTN_GO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_GO.Click
        Me.Frame.Navigate(GetType(LOGIN1))
    End Sub
End Class
