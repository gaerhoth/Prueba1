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
Imports Prueba1.App
Imports Prueba1.VAR_GLOBALES


' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
''' 
Public NotInheritable Class HOME


    Inherits Page



    Public POR_META As Decimal
    Public POR_ACTIVIDAD As Decimal
    Public POR_CARDIO As Decimal
    Public POR_HABITOS As Decimal
    Public POR_PULMONAR As Decimal
    Public POR_SENTIDOS As Decimal

    Public C_Sentidos As String()
    Public C_Cardio As String()
    Public C_Pulmonar As String()
    Public C_actividad As String()
    Public C_Habitos As String()
    Public C_Meta As String()

    'Parametros es el ID_TRABAJADOR
    Public Parametros As String
    Public X1 As Integer
    Public X2 As Integer
    Dim antes As Boolean


    Private Async Sub HOME_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading

        'gridMain.ManipulationMode = ManipulationModes.TranslateX Or ManipulationModes.TranslateY
        'gridMain_ManipulationCompleted(ManipulationModes.TranslateX, ManipulationModes.TranslateX)
        'GridMain_ManipulationStarted(sender, gridMain.ManipulationMode.)
        Dim usuario As TUSUARIO
        Dim usua As String()
        usuario = (From p In conn.Table(Of TUSUARIO) Where p.active.Contains("S") Select p).FirstOrDefault
        usua = usuario.nom_trabajador.Split("|")
        Me.txtnombre.Text = usua(2) & " " & usua(0)
        Me.txtcorreo.Text = usuario.des_email

        limpiarHex()


        ' Await C_WAH.RESETAR_USUARIOAsync("50987325M")
        ' Parametros = 48

        AYUDA.Mostrar(GrLoad, customIndeterminateProgressBar, HOME)

        Await descarga()

        Await DescargaCal()

        AYUDA.Ocualtar(GrLoad, customIndeterminateProgressBar, HOME)



    End Sub


    Public Async Function descarga() As Task(Of String)

        RES_SENTIDOS = Await C_WAH.DameResSentidosAsync(Parametros)
        AYUDA.LimpiarJson(RES_SENTIDOS.Body.DameResSentidosResult, "DameResSentidos", "TRESSENTIDOS")
        CAL_SENTIDOS = Await C_WAH.DameCalSentidosAsync(Parametros, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_SENTIDOS.Body.DameCalSentidosResult, "DameCalSentidos", "TCALSENTIDOS")

        RES_PULMONAR = Await C_WAH.DameResPulmonaresAsync(Parametros)
        AYUDA.LimpiarJson(RES_PULMONAR.Body.DameResPulmonaresResult, "DameResPulmonares", "TRESPULMONAR")
        CAL_PULMONAR = Await C_WAH.DameCalPulmonaresAsync(Parametros, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_PULMONAR.Body.DameCalPulmonaresResult, "DameCalPulmonares", "TCALPULMONAR")

        RES_HABITOS = Await C_WAH.DameResHabitosAsync(Parametros, IND_ENVIADO)
        AYUDA.LimpiarJson(RES_HABITOS.Body.DameResHabitosResult, "DameResHabitos", "TRESHABITOS")
        CAL_HABITOS = Await C_WAH.DameCalHabitosAsync(Parametros, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_HABITOS.Body.DameCalHabitosResult, "DameCalHabitos", "TCALHABITOS")

        RES_CARIDIO = Await C_WAH.DameResCardiosAsync(Parametros)
        AYUDA.LimpiarJson(RES_CARIDIO.Body.DameResCardiosResult, "DameResCardios", "TRESCARDIO")
        CAL_CARIDIO = Await C_WAH.DameCalCardiosAsync(Parametros, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_CARIDIO.Body.DameCalCardiosResult, "DameCalCardios", "TCALCARDIO")

        RES_ACTIVIDAD = Await C_WAH.DameResActividadesAsync(Parametros)
        AYUDA.LimpiarJson(RES_ACTIVIDAD.Body.DameResActividadesResult, "DameResActividades", "TRESACTIVIDAD")
        CAL_ACTIVIDAD = Await C_WAH.DameCalActividadesAsync(Parametros, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_ACTIVIDAD.Body.DameCalActividadesResult, "DameCalActividades", "TCALACTIVIDAD")

        RES_META = Await C_WAH.DameResMetasAsync(Parametros)
        AYUDA.LimpiarJson(RES_META.Body.DameResMetasResult, "DameResMetas", "TRESMETAS")
        CAL_META = Await C_WAH.DameCalMetasAsync(Parametros, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_META.Body.DameCalMetasResult, "DameCalMetas", "TCALMETAS")

        ' Dim News As List(Of TAVISOS)

        MAVISOS = Await C_WAH.DameAvisoAsync(Parametros)
        AYUDA.LimpiarJson(MAVISOS.Body.DameAvisoResult, "DameAviso", "TAVISOS")



        LSAV = conn.Query(Of TAVISOS)("SELECT * FROM TAVISOS WHERE IND_ENVIADO ='N'")

        If LSAV.Count <> 0 Then
            Me.EL_verde.Visibility = Visibility.Collapsed
            Me.El_rojo.Visibility = Visibility.Visible
            Me.C_ok.Visibility = Visibility.Collapsed
            C_no_ok.Visibility = Visibility.Visible
            Me.C_no_ok.Text = LSAV.Count.ToString
        Else
            Me.EL_verde.Visibility = Visibility.Visible
            Me.El_rojo.Visibility = Visibility.Collapsed
            Me.C_ok.Visibility = Visibility.Visible
            C_no_ok.Visibility = Visibility.Collapsed


        End If

        LSR = conn.Query(Of TRESSENTIDOS)("SELECT * FROM TRESSENTIDOS")
        LCR = conn.Query(Of TRESCARDIO)("SELECT * FROM TRESCARDIO")
        LHR = conn.Query(Of TRESHABITOS)("SELECT * FROM TRESHABITOS")
        LPR = conn.Query(Of TRESPULMONAR)("SELECT * FROM TRESPULMONAR")
        LAR = conn.Query(Of TRESACTIVIDAD)("SELECT * FROM TRESACTIVIDAD")
        LMR = conn.Query(Of TRESMETAS)("SELECT * FROM TRESMETAS")

        Return "ok"

    End Function
    'Private Sub BTN_AVISOS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_AVISOS.Click
    '    Me.Frame.Navigate(GetType(AVISOS))
    'End Sub

    'Private Sub contar_Checked(sender As Object, e As RoutedEventArgs) Handles contar.Checked
    '    Me.Frame.Navigate(GetType(AVISOS))
    'End Sub

    Private Sub BTN_MISALUD_Click(sender As Object, e As RoutedEventArgs) Handles BTN_MISALUD.Click
        Me.Frame.Navigate(GetType(HOME))
    End Sub

    Private Sub BTN_INFO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_INFO.Click
        Me.Frame.Navigate(GetType(INFO))
    End Sub

    Private Sub BTN_DOC_Click(sender As Object, e As RoutedEventArgs) Handles BTN_DOC.Click
        Me.Frame.Navigate(GetType(DOCUMENTOS), Parametros)
    End Sub

    Private Sub BTN_OBJ_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OBJ.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_OBJ.Content & ",1")
    End Sub

    Private Sub BTN_CENTROS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CENTROS.Click
        Me.Frame.Navigate(GetType(CENTROS), Me.BTN_CENTROS.Content)

    End Sub

    Private Sub BTN_CITAS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CITAS.Click
        Me.Frame.Navigate(GetType(CITAS), Me.BTN_CITAS.Content)
    End Sub

    Private Sub BTN_RECOM_Click(sender As Object, e As RoutedEventArgs) Handles BTN_RECOM.Click
        Me.Frame.Navigate(GetType(RECOMENDACIONES), Me.BTN_RECOM.Content)

    End Sub

    Private Sub PERFIL_Click(sender As Object, e As RoutedEventArgs) Handles PERFIL.Click
        Me.Frame.Navigate(GetType(PERFIL))
    End Sub
    Private Sub BTN_CAMPA_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CAMPA.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_CAMPA.Content & ",2")
    End Sub




    Private Sub gridMain_ManipulationCompleted(x1 As Integer, x2 As Integer)

        If (x1 > x2) Then

            MySplitView.IsPaneOpen = True


        Else

            MySplitView.IsPaneOpen = False


        End If
    End Sub


    Private Sub GridMain_ManipulationStarted(sender As Object, e As ManipulationStartedRoutedEventArgs)
        X1 = CInt(e.Position.X)
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        If Me.MySplitView.IsPaneOpen = False Then
            MySplitView.IsPaneOpen = True
        Else
            MySplitView.IsPaneOpen = False
        End If
    End Sub

    Private Sub BTN_SENTIDOS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SENTIDOS.Click
        If antes <> True Then
            Aparecer()


            Me.NOM_HEX.Text = "Sentidos"

            gira(CInt(MaxSentidos * 100))

            'calcular la diferencia
            Me.dife.Text = LS(0).CAN_SENTIDOS - LS(1).CAN_SENTIDOS & " %"
        Else
            Desaparecer()
        End If

    End Sub

    Public Async Sub Aparecer()
        GC.Collect()

        If GrLoad.Visibility = Visibility.Collapsed Then
            Dim i As Decimal = 0

            Me.H_Zomm.Visibility = Visibility.Visible
            While i <= 1
                Await Task.Delay(TimeSpan.FromMilliseconds(20))
                H_Zomm.Opacity = i
                Me.BTN_GR.Opacity = i
                i = i + 0.05
            End While
        End If
    End Sub

    Public Async Sub Desaparecer()
        Dim i As Decimal = 1


        While i >= 0
            Await Task.Delay(TimeSpan.FromMilliseconds(10))
            H_Zomm.Opacity = i
            Me.BTN_GR.Opacity = i
            i = i - 0.05
        End While
        Me.H_Zomm.Visibility = Visibility.Collapsed
    End Sub
    Public Async Sub gira(valor As Integer)
        'For i = 0 To valor Step 0.01
        '    Me.slider.Value = i

        'Next

        Dim i As Decimal

        While i <= valor
            'Me.LA.GradientStops.Clear()
            Await Task.Delay(TimeSpan.FromMilliseconds(10))

            Me.slider.Value = i
            i = i + 1
        End While



    End Sub
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter

    End Sub

    Private Sub HOME_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded


        'LS = conn.Query(Of TCALSENTIDOS)("SELECT * FROM TCALSENTIDOS ORDER BY ID_CALSENTIDOS") ' WHERE ID_TRABAJADOR=48")
        'POR_SENTIDOS = LS(0).CAN_SENTIDOS
        'C_Sentidos = AYUDA.CreaColores(listaColores(CInt(LS(0).COD_COL_SENTIDOS) - 1).DES_COLOR)

        'LP = conn.Query(Of TCALPULMONAR)("SELECT * FROM TCALPULMONAR ORDER BY ID_CALPULMONAR") ' WHERE ID_TRABAJADOR=48")
        'POR_PULMONAR = LP(0).CAN_PULMONAR
        'C_Pulmonar = AYUDA.CreaColores(listaColores(CInt(LP(0).COD_COL_PULMONAR) - 1).DES_COLOR)

        'LH = conn.Query(Of TCALHABITOS)("SELECT * FROM TCALHABITOS ORDER BY ID_CALHABITOS") ' WHERE ID_TRABAJADOR=48")
        'POR_HABITOS = LH(0).CAN_HABITOS
        'C_Habitos = AYUDA.CreaColores(listaColores(CInt(LH(0).COD_COL_HABITOS) - 1).DES_COLOR)

        'LC = conn.Query(Of TCALCARDIO)("SELECT * FROM TCALCARDIO ORDER BY ID_CALCARDIO") ' WHERE ID_TRABAJADOR=48")
        'POR_CARDIO = LC(0).CAN_CARDIO
        'C_Cardio = AYUDA.CreaColores(listaColores(CInt(LC(0).COD_COL_CARDIO) - 1).DES_COLOR)

        'LA = conn.Query(Of TCALACTIVIDAD)("SELECT * FROM TCALACTIVIDAD ORDER BY ID_CALACTIVIDAD") ' WHERE ID_TRABAJADOR=48")
        'POR_ACTIVIDAD = LA(0).CAN_ACTIVIDAD
        'C_actividad = AYUDA.CreaColores(listaColores(CInt(LA(0).COD_COL_ACTIVIDAD) - 1).DES_COLOR)

        'LM = conn.Query(Of TCALMETAS)("SELECT * FROM TCALMETAS ORDER BY ID_CALMETA") ' WHERE ID_TRABAJADOR=48")
        'POR_META = LM(0).CAN_META
        'C_Meta = AYUDA.CreaColores(listaColores(CInt(LM(0).COD_COL_META) - 1).DES_COLOR)


        'LLENADO()

    End Sub


    Private Async Function DescargaCal() As Task(Of String)

        LS = conn.Query(Of TCALSENTIDOS)("SELECT * FROM TCALSENTIDOS ORDER BY ID_CALSENTIDOS") ' WHERE ID_TRABAJADOR=48")
        POR_SENTIDOS = LS(0).CAN_SENTIDOS
        C_Sentidos = AYUDA.CreaColores(listaColores(CInt(LS(0).COD_COL_SENTIDOS) - 1).DES_COLOR)

        LP = conn.Query(Of TCALPULMONAR)("SELECT * FROM TCALPULMONAR ORDER BY ID_CALPULMONAR") ' WHERE ID_TRABAJADOR=48")
        POR_PULMONAR = LP(0).CAN_PULMONAR
        C_Pulmonar = AYUDA.CreaColores(listaColores(CInt(LP(0).COD_COL_PULMONAR) - 1).DES_COLOR)

        LH = conn.Query(Of TCALHABITOS)("SELECT * FROM TCALHABITOS ORDER BY ID_CALHABITOS") ' WHERE ID_TRABAJADOR=48")
        POR_HABITOS = LH(0).CAN_HABITOS
        C_Habitos = AYUDA.CreaColores(listaColores(CInt(LH(0).COD_COL_HABITOS) - 1).DES_COLOR)

        LC = conn.Query(Of TCALCARDIO)("SELECT * FROM TCALCARDIO ORDER BY ID_CALCARDIO") ' WHERE ID_TRABAJADOR=48")
        POR_CARDIO = LC(0).CAN_CARDIO
        C_Cardio = AYUDA.CreaColores(listaColores(CInt(LC(0).COD_COL_CARDIO) - 1).DES_COLOR)

        LA = conn.Query(Of TCALACTIVIDAD)("SELECT * FROM TCALACTIVIDAD ORDER BY ID_CALACTIVIDAD") ' WHERE ID_TRABAJADOR=48")
        POR_ACTIVIDAD = LA(0).CAN_ACTIVIDAD
        C_actividad = AYUDA.CreaColores(listaColores(CInt(LA(0).COD_COL_ACTIVIDAD) - 1).DES_COLOR)

        LM = conn.Query(Of TCALMETAS)("SELECT * FROM TCALMETAS ORDER BY ID_CALMETA") ' WHERE ID_TRABAJADOR=48")
        POR_META = LM(0).CAN_META
        C_Meta = AYUDA.CreaColores(listaColores(CInt(LM(0).COD_COL_META) - 1).DES_COLOR)


        LLENADO()

        Return "ok"
    End Function




    Public Async Sub LLENADO()

        Dim I As Decimal





        MaxActividad = POR_ACTIVIDAD / 100
        MaxMeta = POR_META / 100
        MaxHabitos = POR_HABITOS / 100
        MaxPulmonar = POR_PULMONAR / 100
        MaxCardio = POR_CARDIO / 100
        MaxSentidos = POR_SENTIDOS / 100




        Me.LACTIVIDAD.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = MaxActividad})
        Me.LMETA.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = MaxMeta})
        Me.LHABITOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = MaxHabitos})
        Me.LPULMONAR.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = MaxPulmonar})
        Me.LCARDIO.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = MaxCardio})
        Me.LSENTIDOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = MaxSentidos})


        While I < MaxPulmonar
            'Me.LA.GradientStops.Clear()
            Await Task.Delay(TimeSpan.FromMilliseconds(10))

            Dim a As Windows.UI.Color
            a.A = 5


            If I < MaxActividad Then

                Me.LACTIVIDAD.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Color.FromArgb(255, CInt(C_actividad(0)), CInt(C_actividad(1)), CInt(C_actividad(2))), .Offset = I})
                ' Me.LACTIVIDAD.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Red, .Offset = I})
            End If

            If I < MaxMeta Then
                Me.LMETA.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Color.FromArgb(255, CInt(C_Meta(0)), CInt(C_Meta(1)), CInt(C_Meta(2))), .Offset = I})
                'Me.LMETA.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Red, .Offset = I})
            End If


            If I < MaxHabitos Then
                Me.LHABITOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Color.FromArgb(255, CInt(C_Habitos(0)), CInt(C_Habitos(1)), CInt(C_Habitos(2))), .Offset = I})
                '  Me.LHABITOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Red, .Offset = I})
            End If

            If I < MaxPulmonar Then
                Me.LPULMONAR.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Color.FromArgb(255, CInt(C_Pulmonar(0)), CInt(C_Pulmonar(1)), CInt(C_Pulmonar(2))), .Offset = I})
                'Me.LPULMONAR.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Red, .Offset = I})
            End If

            If I < MaxCardio Then
                Me.LCARDIO.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Color.FromArgb(255, CInt(C_Cardio(0)), CInt(C_Cardio(1)), CInt(C_Cardio(2))), .Offset = I})
                'Me.LCARDIO.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Red, .Offset = I})
            End If

            If I < MaxSentidos Then
                Me.LSENTIDOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Color.FromArgb(255, CInt(C_Sentidos(0)), CInt(C_Sentidos(1)), CInt(C_Sentidos(2))), .Offset = I})
                ' Me.LSENTIDOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Red, .Offset = I})
            End If

            I = I + 0.01
        End While
        antes = False
    End Sub



    ' Private Sub b1_Click(sender As Object, e As RoutedEventArgs) Handles b1.Click
    Public Sub limpiarHex()
        Me.LACTIVIDAD.GradientStops.Clear()
        Me.LACTIVIDAD.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = 1})

        Me.LMETA.GradientStops.Clear()
        Me.LMETA.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = 1})

        Me.LSENTIDOS.GradientStops.Clear()
        Me.LSENTIDOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = 1})

        Me.LPULMONAR.GradientStops.Clear()
        Me.LPULMONAR.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = 1})

        Me.LCARDIO.GradientStops.Clear()
        Me.LCARDIO.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = 1})

        Me.LHABITOS.GradientStops.Clear()
        Me.LHABITOS.GradientStops.Add(New GradientStop With {.Color = Windows.UI.Colors.Gray, .Offset = 1})
    End Sub

    Private Sub BTN_GR_Click(sender As Object, e As RoutedEventArgs) Handles BTN_GR.Click
        Select Case NOM_HEX.Text
            Case "Sentidos"
                Me.Frame.Navigate(GetType(DISEÑOS3), "Sentidos" & "," & LS(0).ID_CALSENTIDOS & "," & slider.Value)
            Case "Actividad"
                Me.Frame.Navigate(GetType(DET_HEXAGONO))
            Case "Metabolismo"
                Me.Frame.Navigate(GetType(DET_HEXAGONO))
            Case "Cardio"
                Me.Frame.Navigate(GetType(DET_HEXAGONO))
            Case "Hábitos"
                Me.Frame.Navigate(GetType(DET_HEXAGONO))
            Case "Respiración"
                Me.Frame.Navigate(GetType(DET_HEXAGONO))
        End Select
    End Sub

    Private Sub H_Zomm_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles H_Zomm.Tapped
        '   H_Zomm.Visibility = Visibility.Collapsed
        Desaparecer()
    End Sub

    Private Sub BTN_PULMONAR_Click(sender As Object, e As RoutedEventArgs) Handles BTN_PULMONAR.Click
        If antes <> True Then
            Aparecer()

            Me.NOM_HEX.Text = "Respiraicón"

            gira(CInt(MaxPulmonar * 100))

            'calcular la diferencia
            Me.dife.Text = LP(0).CAN_PULMONAR - LP(1).CAN_PULMONAR & " %"
        Else
            Desaparecer()

        End If
    End Sub

    Private Sub BTN_HABITOS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_HABITOS.Click
        If antes <> True Then
            Aparecer()

            Me.NOM_HEX.Text = "Hábitos"

            gira(CInt(MaxHabitos * 100))

            'calcular la diferencia
            Me.dife.Text = LH(0).CAN_HABITOS - LH(1).CAN_HABITOS & " %"
        Else
            Desaparecer()
        End If
    End Sub

    Private Sub BTN_ACTIVIDAD_Click(sender As Object, e As RoutedEventArgs) Handles BTN_ACTIVIDAD.Click
        ' limpiarHex()
        ' LLENADO()
        If antes <> True Then
            Aparecer()


            Me.NOM_HEX.Text = "Actividad"

            gira(CInt(MaxActividad * 100))

            'calcular la diferencia
            Me.dife.Text = LA(0).CAN_ACTIVIDAD - LA(1).CAN_ACTIVIDAD & " %"
        Else
            Desaparecer()
        End If
    End Sub

    Private Sub BTN_META_Click(sender As Object, e As RoutedEventArgs) Handles BTN_META.Click
        If antes <> True Then
            Aparecer()


            Me.NOM_HEX.Text = "Metabolismo"

            gira(CInt(MaxMeta * 100))

            'calcular la diferencia
            Me.dife.Text = LM(0).CAN_META - LM(1).CAN_META & " %"
        Else
            Desaparecer()
        End If
    End Sub

    Private Sub BTN_CARDIO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CARDIO.Click
        If antes <> True Then
            Aparecer()


            Me.NOM_HEX.Text = "Cardio"

            gira(CInt(MaxCardio * 100))

            'calcular la diferencia
            Me.dife.Text = LC(0).CAN_CARDIO - LC(1).CAN_CARDIO & " %"
        Else
            Desaparecer()
        End If
    End Sub

    Private Sub Campana_Click(sender As Object, e As RoutedEventArgs) Handles Campana.Click
        Frame.Navigate(GetType(AVISOS), Parametros)
    End Sub

    Private Sub GrLoad_PointerCanceled(sender As Object, e As PointerRoutedEventArgs)

    End Sub

    Private Sub GrLoad_PointerCaptureLost(sender As Object, e As PointerRoutedEventArgs)

    End Sub

    Private Sub GrLoad_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        antes = True

    End Sub
End Class
