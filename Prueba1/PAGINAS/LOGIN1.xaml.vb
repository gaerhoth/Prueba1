Imports Prueba1.VAR_GLOBALES
Imports Windows.UI.Popups
Imports Prueba1.AYUDA
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class LOGIN1
    Inherits Page
    Public Parametros As Object
    Private Sub BTN_NO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_NO.Click
        'Me.Frame.Navigate(GetType(UNETE1))

        Me.Frame.Navigate(GetType(INFO))
    End Sub

    Private Async Sub BTN_Entrar_Click(sender As Object, e As RoutedEventArgs) Handles BTN_Entrar.Click
        Dim CDNI As String
        Dim mensaje As MessageDialog

        CDNI = CalculaNIF(Me.txtdni.Text.ToUpper)

        If CDNI.ToUpper = Me.txtdni.Text.ToUpper Then



            If OK.IsOn Then

                Dim epass As New WS_SEGURIDAD_PRODUCCION.EncriptarPasswordResponse
                Dim Req_Damepass As New WS_WAH_PRODUCCION.DamePasswordRequest
                Dim Res_Damepass As New WS_WAH_PRODUCCION.DamePasswordResponse
                Dim p As New WS_SEGURIDAD_PRODUCCION.DesencriptarPasswordResponse
                Dim Datos_Usu As New WS_WAH_PRODUCCION.DameDatosUsuarioResponse
                Dim ArrDatos As String()

                'Encrita la password
                epass = Await C_SEGURIDAD.EncriptarPasswordAsync(Me.txtpass.Text)


                'nos da los datos del usuario para sacar la contraseña
                Datos_Usu = Await C_WAH.DameDatosUsuarioAsync(Me.txtdni.Text)
                ArrDatos = JsonToDatos(Datos_Usu.Body.DameDatosUsuarioResult, "DameDatosUsuario")

                'Le pasamos el COD_USUARIO de seguridad para sacar la contraseña
                Res_Damepass = Await C_WAH.DamePasswordAsync(ArrDatos(1))


                ArrDatos = JsonToDatos(Res_Damepass.Body.DamePasswordResult, "DamePassword")
                'Desencriptamos la contraseña para compararla con la que ha introducido
                p = Await C_SEGURIDAD.DesencriptarPasswordAsync(ArrDatos(0))


                'Comparamos la contraseña para ver sea la misma
                If Me.txtpass.Text = p.Body.DesencriptarPasswordResult Then

                    Dim usuario As TUSUARIO

                    usuario = (From z In conn.Table(Of TUSUARIO)() Where z.ind_tutorial.Contains("S") Select z).FirstOrDefault
                    If usuario IsNot Nothing Then
                        Me.Frame.Navigate(GetType(TUTORIAL1), CDNI)
                    Else

                        'insertamos el trabajador en nuestra bbdd local
                        Dim DAT_T As WS_WAH_PRODUCCION.DameTrabajadorResponse
                        Dim ARR_DAT As String()
                    DAT_T = Await C_WAH.DameTrabajadorAsync(Me.txtdni.Text)
                    ARR_DAT = AYUDA.JsonToDatos(DAT_T.Body.DameTrabajadorResult, "DameTrabajador")

                    Dim INSERT As String
                        INSERT = "INSERT INTO TUSUARIO ( id_trabajador , cod_trab_spa, cod_identificador, nom_trabajador, 
                     fecha_nacimiento, sexo, fec_alta, num_cif, des_razon_social,
                     des_email, num_telefono, cod_contrato,
                     password, active, ind_tutorial) VALUES(" & ARR_DAT(1) & ",'" & ARR_DAT(3) & "','" & ARR_DAT(5) & "','" & ARR_DAT(7) & "'," &
                         ARR_DAT(9).Substring(0, 10) & ",'" & ARR_DAT(11) & "'," & Date.Now.ToString.Substring(0, 10) & ",'" & ARR_DAT(21) & "','" & ARR_DAT(23) & "','" & ARR_DAT(25) & "','" & ARR_DAT(27) & "','" &
                         ARR_DAT(13) & "','" & ArrDatos(0) & "','S','N')"

                        conn.Execute(INSERT)


                        Me.Frame.Navigate(GetType(HOME), ARR_DAT(1))
                    End If

            Else

                        mensaje = New MessageDialog("Contraseña incorrecta")
                    Await mensaje.ShowAsync()

                End If

                Else

                    mensaje = New MessageDialog("Debe aceptar las condiciones para acceder a la aplicación")
                    Await mensaje.ShowAsync()

                End If

            Else



                mensaje = New MessageDialog("El DNI/NIE introducido no es valido")
            Await mensaje.ShowAsync()


        End If
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter

        If Parametros <> "" Then
            Me.txtdni.Text = Parametros
        End If

    End Sub

    Private Sub TextBlock_SelectionChanged(sender As Object, e As RoutedEventArgs)

    End Sub



    Private Sub REC_CON_Click(sender As Object, e As RoutedEventArgs) Handles REC_CON.Click
        Me.Frame.Navigate(GetType(RECUPERARPASS))
    End Sub

    Private Sub LEG_Click(sender As Object, e As RoutedEventArgs) Handles LEG.Click
        Me.Frame.Navigate(GetType(TEXTOLEGAL))
    End Sub
End Class
