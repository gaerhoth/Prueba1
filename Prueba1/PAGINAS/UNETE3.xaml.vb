Imports Windows.UI.Popups
Imports Prueba1.VAR_GLOBALES
Imports System.Text
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class UNETE3
    Inherits Page

    Dim M_parametros As String()

    Private Async Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click
        'Flujo de alta de usuario

        'El email no debe ser vacio
        If ValEmail(Me.txtemail.Text) = True Then



            Dim Cod As Integer
            'insetamos en EUSUARIO
            Cod = Await C_SPFM.insertarEusuarioAsync(M_parametros(1), "", txtemail.Text, "", Nothing, Nothing, Nothing, txttelefono.Text, M_parametros(0), 1, M_parametros(3), Nothing, "", "S", "", "N", Date.Now)


            'Insertamos el tipo de usuario
            Dim tipu As New WS_SPFM_PRODUCCION.insertarTipoUsuarioRequest
            tipu.iCodUsuario = Cod
            tipu.iModificado = Nothing
            tipu.iTipoUsuario = 16
            tipu.sFecAlta = Date.Now

            Await C_SPFM.insertarTipoUsuarioAsync(tipu)


            'Generamos la contraseña
            Dim epass As WS_SEGURIDAD_PRODUCCION.EncriptarPasswordResponse
            Dim Npass As WS_WAH_PRODUCCION.GeneraPasswordResponse = Await C_WAH.GeneraPasswordAsync()


            epass = Await C_SEGURIDAD.EncriptarPasswordAsync(Npass.Body.GeneraPasswordResult)

            'insertamos la contraseña
            Await C_SPFM.insertarEusupwdAsync(Cod, epass.Body.EncriptarPasswordResult.ToString)


            'insertamos en TTRABAJADOR
            Dim RInsertaU As New WS_WAH_PRODUCCION.InsertarTrabajadorResponse
            RInsertaU = Await C_WAH.InsertarTrabajadorAsync(M_parametros(0), M_parametros(1), M_parametros(3), M_parametros(2), Date.Now, "Win")


            Dim mensaje As MessageDialog
            mensaje = New MessageDialog("Pronto recibirá un correo")
            Await mensaje.ShowAsync()

            Dim DAT_T As WS_WAH_PRODUCCION.DameTrabajadorResponse
            Dim ARR_DAT As String()
            DAT_T = Await C_WAH.DameTrabajadorAsync(M_parametros(0))
            ARR_DAT = AYUDA.JsonToDatos(DAT_T.Body.DameTrabajadorResult, "DameTrabajador")

            Dim INSERT As String = ""
            INSERT = "INSERT INTO TUSUARIO ( id_trabajador , cod_trab_spa, cod_identificador, nom_trabajador, 
                     fecha_nacimiento, sexo, fec_alta, num_cif, des_razon_social,
                     des_email, num_telefono, cod_contrato,
                     password, active, ind_tutorial) VALUES(" & ARR_DAT(1) & ",'" & ARR_DAT(3) & "','" & M_parametros(0) & "','" & M_parametros(1) & "','" &
                      M_parametros(3) & "','" & M_parametros(2) & "','" & Date.Now & "','" & ARR_DAT(21) & "','" & ARR_DAT(23) & "','" & Me.txtemail.Text & "','" & Me.txttelefono.Text & "','" &
                     ARR_DAT(13) & "','" & epass.Body.EncriptarPasswordResult & "','S','S')"

            conn.Execute(INSERT)


            Me.Frame.Navigate(GetType(LOGIN1), M_parametros(0))
        Else
            Dim mensaje As MessageDialog
            mensaje = New MessageDialog("Debe proporcionar un email valido")
            Await mensaje.ShowAsync()

        End If
    End Sub


    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        M_parametros = e.Parameter.ToString.Split(";")


    End Sub


    Public Function ValEmail(email As String) As Boolean
        If email = String.Empty Then Return False
        Dim re As RegularExpressions.Regex = New RegularExpressions.Regex("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
        Dim m As RegularExpressions.Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function
End Class



