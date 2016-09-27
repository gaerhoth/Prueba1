Imports Prueba1.VAR_GLOBALES
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded



        '  Me.Frame.Navigate(GetType(ExtendedSplash))
        '  

        '  Me.Frame.Navigate(GetType(HOME), "80|3")

        Dim a As String = "d|b|c"
        Dim b As String()
        b = a.Split("|")
        'Frame.Navigate(typeof(Pagina2), "Podemos enviar un parámetro");


        'boton atras
        '        En el archivo App.xaml.cs, en el constructor de nuestra aplicación añadimos


        'HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        'El evento será


        'Void HardwareButtons_BackPressed(Object sender, BackPressedEventArgs e)
        '{
        '     Frame Frame = Window.Current.Content as Frame;

        '     If (Frame == null) Then
        '            Return;

        '     If (Frame.CanGoBack) Then
        '                     {
        '          Frame.GoBack();
        '          e.Handled = True;
        '     }
        '}


    End Sub

    Private Sub BTN_SI_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SI.Click
        Me.Frame.Navigate(GetType(LOGIN1))
        ' Me.Frame.Navigate(GetType(HOME))
    End Sub

    Private Sub BTN_NO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_NO.Click
        ' Me.Frame.Navigate(GetType(HOME))

        Me.Frame.Navigate(GetType(UNETE1))
    End Sub

    'Private Async Sub MainPage_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
    '    Dim USUARIO As TUSUARIO
    '    Dim ID As Integer


    '    Dim epass As New WS_SEGURIDAD_PRODUCCION.EncriptarPasswordResponse
    '    Dim Req_Damepass As New WS_WAH_PRODUCCION.DamePasswordRequest
    '    Dim Res_Damepass As New WS_WAH_PRODUCCION.DamePasswordResponse
    '    Dim p As New WS_SEGURIDAD_PRODUCCION.DesencriptarPasswordResponse
    '    Dim Datos_Usu As New WS_WAH_PRODUCCION.DameDatosUsuarioResponse
    '    Dim ArrDatos As String()
    '    Dim ps As String()



    '    USUARIO = (From z In conn.Table(Of TUSUARIO)() Where z.active.Contains("S") Select z).FirstOrDefault


    '    If USUARIO IsNot Nothing Then

    '        ID = USUARIO.id_trabajador


    '        Datos_Usu = Await C_WAH.DameDatosUsuarioAsync(USUARIO.cod_identificador)
    '        ArrDatos = AYUDA.JsonToDatos(Datos_Usu.Body.DameDatosUsuarioResult, "DameDatosUsuario")

    '        'Le pasamos el COD_USUARIO de seguridad para sacar la contraseña
    '        Res_Damepass = Await C_WAH.DamePasswordAsync(ArrDatos(1))
    '        ps = AYUDA.JsonToDatos(Res_Damepass.Body.DamePasswordResult, "DamePassword")

    '        If ps(0) = USUARIO.password Then
    '            Me.Frame.Navigate(GetType(HOME), USUARIO.id_trabajador)


    '        End If



    '    End If

    'End Sub
End Class
