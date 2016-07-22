' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class TEXTOLEGAL
    Inherits Page

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Dim viene As Integer = 1

        If viene = 1 Then
            Me.Frame.Navigate(GetType(LOGIN1))
        Else
            Me.Frame.Navigate(GetType(UNETE2))
        End If
    End Sub
End Class
