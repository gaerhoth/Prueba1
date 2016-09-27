' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class LST_CENTROS
    Inherits Page

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(CENTROS))
    End Sub
End Class
