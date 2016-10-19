' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class SOLCITA
    Inherits Page

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Frame.Navigate(GetType(CITAS))
    End Sub

    Private Sub btnpart_Click(sender As Object, e As RoutedEventArgs) Handles btnpart.Click
        Me.btnemp.Background = New SolidColorBrush(Windows.UI.Colors.LightGray)
        Me.btnpart.Background = New SolidColorBrush(Windows.UI.Colors.White)

        Me.Empresa.Visibility = Visibility.Collapsed


    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Frame.Navigate(GetType(CENTROS), "Solicitar Cita")
    End Sub
End Class
