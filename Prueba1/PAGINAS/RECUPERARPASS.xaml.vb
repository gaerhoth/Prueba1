Imports Prueba1.VAR_GLOBALES
Imports Prueba1.AYUDA
Imports Windows.UI.Popups
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class RECUPERARPASS
    Inherits Page

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(LOGIN1))
    End Sub

    Private Async Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click


        Dim Res_Contra As New WS_WAH_PRODUCCION.RecuperarContraseñaResponse


        Dim Res_Damepass As New WS_WAH_PRODUCCION.DamePasswordResponse
        Dim Datos_Usu As New WS_WAH_PRODUCCION.DameDatosUsuarioResponse
        Dim ArrDatos As String()
        Dim p As New WS_SEGURIDAD_PRODUCCION.DesencriptarPasswordResponse


        Dim CNIF As String
        Dim mensaje As MessageDialog
        CNIF = CalculaNIF(txtdni.Text.ToUpper)


        If CNIF.ToUpper = txtdni.Text.ToUpper Then


            Datos_Usu = Await C_WAH.DameDatosUsuarioAsync(Me.txtdni.Text)
            ArrDatos = JsonToDatos(Datos_Usu.Body.DameDatosUsuarioResult, "DameDatosUsuario")

            'sacar la fecha
            Dim fecha As String
            fecha = Me.FNACI.Date.ToString.Substring(0, 10)

            Res_Contra = Await C_WAH.RecuperarContraseñaAsync(ArrDatos(3), fecha, Me.txtdni.Text)
            ArrDatos = JsonToDatos(Res_Contra.Body.RecuperarContraseñaResult, "DamePassword")

            If ArrDatos(0) <> "False" Then

                'Desencriptamos la contraseña para compararla con la que ha introducido
                p = Await C_SEGURIDAD.DesencriptarPasswordAsync(ArrDatos(0))



                Await C_WAH.MailRecuperacionAsync(Me.txtdni.Text, p.Body.DesencriptarPasswordResult)


                mensaje = New MessageDialog("Si los datos proporcionados son correctos recibirá en brreve la nueva contraseña")
                Await mensaje.ShowAsync()

                Me.Frame.Navigate(GetType(LOGIN1), Me.txtdni.Text)
            Else
                mensaje = New MessageDialog("Revise los datos introducidos no se corresponden con los datos guadados en nuestro sistema.")
                Await mensaje.ShowAsync()
            End If
        Else
                mensaje = New MessageDialog("El DNI/NIE introducido no es valido")
            Await mensaje.ShowAsync()

        End If

    End Sub
End Class
