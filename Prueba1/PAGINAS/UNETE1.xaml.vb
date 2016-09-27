Imports Prueba1.VAR_GLOBALES
Imports Windows.UI.Popups
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
''' 
Public NotInheritable Class UNETE1
    Inherits Page


    Private Async Sub BTN_REG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_REG.Click
        Dim CNIF As String
        Dim mensaje As MessageDialog
        CNIF = CalculaNIF(txt1.Text.ToUpper)

        Dim respuesta As Boolean

        If CNIF.ToUpper = txt1.Text.ToUpper Then
            respuesta = Await C_SPFM.existeNumeroDocumentoAsync(Me.txt1.Text)




            If respuesta = True Then

                mensaje = New MessageDialog("El usuario ya esta registrado.")
                Await mensaje.ShowAsync()

            Else

                Me.Frame.Navigate(GetType(UNETE2), Me.txt1.Text)

            End If

        Else
            mensaje = New MessageDialog("El DNI/NIE introducido no es valido")
            Await mensaje.ShowAsync()

        End If


    End Sub

    Private Sub BTN_GO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_GO.Click
        Me.Frame.Navigate(GetType(LOGIN1))
    End Sub

End Class
