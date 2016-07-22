' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class UNETE2
    Inherits Page

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(UNETE1))
    End Sub

    Private Sub legal_Click(sender As Object, e As RoutedEventArgs) Handles legal.Click
        Me.Frame.Navigate(GetType(TEXTOLEGAL))
    End Sub

    Private Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click
        Me.Frame.Navigate(GetType(UNETE3))
    End Sub
End Class
