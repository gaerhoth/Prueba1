Imports SQLite.Net
Imports SQLite.Net.Platform.WinRT
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.ApplicationModel
Imports Windows.ApplicationModel.Activation
Imports Windows.Foundation
Imports Windows.Foundation.Collections
Imports Windows.Storage
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Navigation
Imports Prueba1.TABLAS
Imports Prueba1.DESCARGA_DATOS
Imports Prueba1.VAR_GLOBALES
Imports System.Text
''' <summary>
''' Proporciona un comportamiento específico de la aplicación para complementar la clase Application predeterminada.
''' </summary>
''' 






NotInheritable Class App
        Inherits Application

        ''' <summary>
        ''' Se invoca cuando el usuario final inicia la aplicación normalmente. Se usarán otros puntos
        ''' cuando la aplicación se inicie para abrir un archivo específico, para mostrar
        ''' resultados de la búsqueda, etc.
        ''' </summary>
        ''' <param name="e">Información detallada acerca de la solicitud y el proceso de inicio.</param>

        Protected Overrides Sub OnLaunched(e As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
#If DEBUG Then
            ' Mostrar información de generación de perfiles de gráficos durante la depuración.
            If System.Diagnostics.Debugger.IsAttached Then
                ' Mostrar los contadores de velocidad de marcos actual
                Me.DebugSettings.EnableFrameRateCounter = False
            End If
#End If

            Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

            ' No repetir la inicialización de la aplicación si la ventana tiene contenido todavía,
            ' solo asegurarse de que la ventana está activa.

            If rootFrame Is Nothing Then
                ' Crear un marco para que actúe como contexto de navegación y navegar a la primera página.
                rootFrame = New Frame()

                AddHandler rootFrame.NavigationFailed, AddressOf OnNavigationFailed

                If e.PreviousExecutionState = ApplicationExecutionState.Terminated Then
                    ' TODO: Cargar el estado de la aplicación suspendida previamente
                End If
                ' Poner el marco en la ventana actual.
                Window.Current.Content = rootFrame
            End If

            If e.PrelaunchActivated = False Then
                If rootFrame.Content Is Nothing Then
                    ' Cuando no se restaura la pila de navegación, navegar a la primera página,
                    ' configurando la nueva página pasándole la información requerida como
                    'parámetro de navegación

                    ' rootFrame.Navigate(GetType(MainPage), e.Arguments)
                End If

                'o en el mainpage
                'antes de esto deberiamos ver lo del usuario si hay o no hay y comprobar que la contraseña guardada es la misma 
                'sino mandariamos a login1 y si es todo correcto a home
                Iniciar(e)

                ' Asegurarse de que la ventana actual está activa.
                Window.Current.Activate()
            End If
        End Sub

    Public Async Sub Iniciar(e As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
        'Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)
        'rootFrame.Navigate(GetType(PHOTO))
        'Window.Current.Activate()

        Await CreaBBDD(e)
    End Sub
    Public Async Function CreaBBDD(e As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs) As Task



            ' Await DESCARGA_MAESTROS()

            Dim Ruta As String


            Ruta = Conexion()
            conn = New SQLite.Net.SQLiteConnection(New SQLite.Net.Platform.WinRT.SQLitePlatformWinRT, Ruta)
        conn.Execute("PRAGMA encoding='utf-8'")

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        Encoding.GetEncoding("UTF-8")


        conn.CreateTable(Of TDOCUMENTOS2)()
        conn.CreateTable(Of TAVISOS)()
        conn.CreateTable(Of TCENTROS)()
        conn.CreateTable(Of TCONSTANT)()

            conn.CreateTable(Of TUSUARIO)()
            conn.CreateTable(Of TTIPOAGUA)()
            conn.CreateTable(Of TTIPOALCOHOL)()
            conn.CreateTable(Of TTIPOALIMENTA)()
            conn.CreateTable(Of TTIPOCAFE)()
            conn.CreateTable(Of TTIPOEJER)()
            conn.CreateTable(Of TTIPOSUENO)()
            conn.CreateTable(Of TTIPOTABACO)()

            conn.CreateTable(Of TCOLOR)()
            conn.CreateTable(Of TUNIDADES)()
            conn.CreateTable(Of TTIPOAVISO)()
        conn.CreateTable(Of TRECOMENDACIONES)()
        conn.CreateTable(Of TTIPOCITA)()

        conn.CreateTable(Of TPRUEBA)()
        conn.CreateTable(Of TCALACTIVIDAD)()
            conn.CreateTable(Of TCALCARDIO)()
            conn.CreateTable(Of TCALHABITOS)()
            conn.CreateTable(Of TCALMETAS)()
            conn.CreateTable(Of TCALPULMONAR)()
            conn.CreateTable(Of TCALSENTIDOS)()

            conn.CreateTable(Of TRESACTIVIDAD)()
            conn.CreateTable(Of TRESCARDIO)()
            conn.CreateTable(Of TRESHABITOS)()
            conn.CreateTable(Of TRESMETAS)()
            conn.CreateTable(Of TRESPULMONAR)()
            conn.CreateTable(Of TRESSENTIDOS)()
        conn.CreateTable(Of TRESANALI)()
        conn.CreateTable(Of AUX_PRUEBAS)()

        Dim ULT_CONEX As TCONSTANT
            ULT_CONEX = (From P In conn.Table(Of TCONSTANT)() Where P.DES_CONSTANTE.Contains("FEC_ULT_CONEX") Select P).FirstOrDefault

            If ULT_CONEX IsNot Nothing Then
                Await DESCARGA_MAESTROS(ULT_CONEX.VAL_CONSTANTE)
            Else
                conn.Execute("INSERT INTO TCONSTANT VALUES(1,'FEC_ULT_CONEX','01/01/2015')")
                Await DESCARGA_MAESTROS("01/01/2015")
            End If



        'recuperar los colores

        listaColores = conn.Query(Of TCOLOR)("SELECT * FROM TCOLOR WHERE FEC_BAJA IS NOT NULL") ' WHERE ID_TRABAJADOR=48")


        Await comprueba_usuario_logado(e)





        End Function

        Public Async Function comprueba_usuario_logado(e As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs) As Task
            Dim USUARIO As TUSUARIO
            Dim ID As Integer
            Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)


            Dim epass As New WS_SEGURIDAD_PRODUCCION.EncriptarPasswordResponse
            Dim Req_Damepass As New WS_WAH_PRODUCCION.DamePasswordRequest
            Dim Res_Damepass As New WS_WAH_PRODUCCION.DamePasswordResponse
            Dim p As New WS_SEGURIDAD_PRODUCCION.DesencriptarPasswordResponse
            Dim Datos_Usu As New WS_WAH_PRODUCCION.DameDatosUsuarioResponse
            Dim ArrDatos As String()
            Dim ps As String()



            USUARIO = (From z In conn.Table(Of TUSUARIO)() Where z.active.Contains("S") Select z).FirstOrDefault


            If USUARIO IsNot Nothing Then

                ID = USUARIO.id_trabajador


                Datos_Usu = Await C_WAH.DameDatosUsuarioAsync(USUARIO.cod_identificador)
                ArrDatos = AYUDA.JsonToDatos(Datos_Usu.Body.DameDatosUsuarioResult, "DameDatosUsuario")

                'Le pasamos el COD_USUARIO de seguridad para sacar la contraseña
                Res_Damepass = Await C_WAH.DamePasswordAsync(ArrDatos(1))
                ps = AYUDA.JsonToDatos(Res_Damepass.Body.DamePasswordResult, "DamePassword")

                If ps(0) = USUARIO.password Then

                    rootFrame.Navigate(GetType(HOME))
                    Window.Current.Activate()
                Else
                    rootFrame.Navigate(GetType(LOGIN1))
                    Window.Current.Activate()

                End If

            Else
                rootFrame.Navigate(GetType(MainPage), e.Arguments)
                Window.Current.Activate()

            End If
        End Function

        Public Function Conexion() As String
            Return Path.Combine(ApplicationData.Current.LocalFolder.Path, "misalud.sqlite")
        End Function
        ''' <summary>
        ''' Se invoca cuando la aplicación la inicia normalmente el usuario final. Se usarán otros puntos
        ''' </summary>
        ''' <param name="sender">Marco que produjo el error de navegación</param>
        ''' <param name="e">Detalles sobre el error de navegación</param>
        Private Sub OnNavigationFailed(sender As Object, e As NavigationFailedEventArgs)
            Throw New Exception("Failed to load Page " + e.SourcePageType.FullName)
        End Sub

        ''' <summary>
        ''' Se invoca al suspender la ejecución de la aplicación. El estado de la aplicación se guarda
        ''' sin saber si la aplicación se terminará o se reanudará con el contenido
        ''' de la memoria aún intacto.
        ''' </summary>
        ''' <param name="sender">Origen de la solicitud de suspensión.</param>
        ''' <param name="e">Detalles sobre la solicitud de suspensión.</param>
        Private Sub OnSuspending(sender As Object, e As SuspendingEventArgs) Handles Me.Suspending
            Dim deferral As SuspendingDeferral = e.SuspendingOperation.GetDeferral()
            ' TODO: Guardar el estado de la aplicación y detener toda actividad en segundo plano
            deferral.Complete()
        End Sub




        'Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)

        '    ' Para usar el SplashScreen personalizado                   (07/Ene/13)
        '    If args.PreviousExecutionState <> ApplicationExecutionState.Running Then
        '        Dim loadState As Boolean = (args.PreviousExecutionState = ApplicationExecutionState.Terminated)
        '        Dim extendedSplash As ExtendedSplash = New ExtendedSplash(args.SplashScreen, loadState)
        '        Window.Current.Content = extendedSplash

        '        ' ExtendedSplash will activate the window when its initial content has been painted.

        '        ' Salir
        '        Exit Sub
        '    End If


        '    Dim rootFrame As Frame = TryCast(Window.Current.Content, Frame)

        '    ' Do not repeat app initialization when the Window already has content,
        '    ' just ensure that the window is active

        '    If rootFrame Is Nothing Then
        '        ' Create a Frame to act as the navigation context and navigate to the first page
        '        rootFrame = New Frame()
        '        If args.PreviousExecutionState = ApplicationExecutionState.Terminated Then
        '            ' TODO: Load state from previously suspended application
        '        End If
        '        ' Place the frame in the current Window
        '        Window.Current.Content = rootFrame
        '    End If
        '    If rootFrame.Content Is Nothing Then
        '        ' When the navigation stack isn't restored navigate to the first page,
        '        ' configuring the new page by passing required information as a navigation
        '        ' parameter
        '        If Not rootFrame.Navigate(GetType(MainPage), args.Arguments) Then
        '            Throw New Exception("Failed to create initial page")
        '        End If
        '    End If

        '    ' Ensure the current window is active
        '    Window.Current.Activate()
        'End Sub




    End Class
