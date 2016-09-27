Imports Prueba1.VAR_GLOBALES

' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class TUTORIAL4
    Inherits Page
    Public M_Parametros As String()
    Private Async Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click



        'If Me.CMB_SUENO.SelectedIndex = 0 Then
        '    CMB_SUENO.SelectionBoxItem.KEY = DEFAULT_SUENO
        'End If

        'If Me.CMB_CAFE.SelectedIndex = 0 Then
        '    CMB_CAFE.SelectionBoxItem.KEY = DEFAULT_CAFE
        'End If

        'If Me.CMB_TABACO.SelectedIndex = 0 Then
        '    CMB_TABACO.SelectionBoxItem.KEY = DEFAULT_TAB
        'End If

        'If Me.CMB_ALM.SelectedIndex = 0 Then
        '    CMB_ALM.SelectionBoxItem.KEY = DEFAULT_ALM
        'End If

        'If Me.CMB_EJERCI.SelectedIndex = 0 Then
        '    CMB_EJERCI.SelectionBoxItem.KEY = DEFAULT_EJER
        'End If

        'If Me.CMB_ALC.SelectedIndex = 0 Then
        '    CMB_ALC.SelectionBoxItem.KEY = DEFAULT_ALC
        'End If

        Dim usuario As TUSUARIO

        usuario = (From z In conn.Table(Of TUSUARIO)() Where z.cod_identificador.Contains(M_Parametros(0)) Select z).FirstOrDefault


        'CON ESTO RECUPERAMOS LOS DATOS DE TCAL Y TRES Y LO INSERTAMOS EN NUESTRA BBDD LOCAL ESTO DEBE FUNCIONAR CON TODOS LOS HEXÁGONOS
        'LLAMAMO A IRC PARA INSERTAR LOS DATOS NUEVOS
        R_IRC = Await C_WAH.IRCAsync(Nothing, Nothing, CH_N, Nothing, CH_N, Nothing, CH_N, Nothing, CH_N, Nothing, CH_N, M_Parametros(2), CH_S, CMB_TABACO.SelectionBoxItem.Key, CH_S, M_Parametros(1), CH_S, USU_ALTA, M_Parametros(0), Date.Now)
        'LIMPIAMOS EL JSON QUE NOS ENVIA IRC Y LO INSERTAMOS EN NUESTRA BBDD LOCAL
        AYUDA.LimpiarJson(R_IRC.Body.IRCResult, "DameResCardios", "TRESCARDIO")
        'SACAMOS LOS DATOS DE LOS CALCULOS QUE NO TENEMOS
        CAL_CARIDIO = Await C_WAH.DameCalCardiosAsync(usuario.id_trabajador, IND_ENVIADO)
        'LIMPIAMOS EL JSON QUE NO VIENE DE DAMECAL... INSERTAMOS LOS DATOS DE TCAL EN NUESTRA BBDD
        AYUDA.LimpiarJson(CAL_CARIDIO.Body.DameCalCardiosResult, "DameCalCardios", "TCALCARDIO")


        R_IRH = Await C_WAH.IRHAsync(CMB_TABACO.SelectionBoxItem.Key, CMB_ALC.SelectionBoxItem.Key,
                             CMB_CAFE.SelectionBoxItem.Key, CMB_ALM.SelectionBoxItem.Key,
                             CMB_EJERCI.SelectionBoxItem.Key, CMB_SUENO.SelectionBoxItem.Key,
                             CH_S, USU_ALTA, M_Parametros(0), Date.Now)
        AYUDA.LimpiarJson(R_IRH.Body.IRHResult, "DameResHabitos", "TRESHABITOS")
        CAL_HABITOS = Await C_WAH.DameCalHabitosAsync(usuario.id_trabajador, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_HABITOS.Body.DameCalHabitosResult, "DameCalHabitos", "TCALHABITOS")

        Me.Frame.Navigate(GetType(HOME))
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        M_Parametros = e.Parameter.ToString.Split(";")

    End Sub

    Private Sub TUTORIAL4_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading

        Dim LSUENO As List(Of TTIPOSUENO)
        Dim LCAFE As List(Of TTIPOCAFE)
        Dim LEJER As List(Of TTIPOEJER)
        Dim LALM As List(Of TTIPOALIMENTA)
        Dim LALC As List(Of TTIPOALCOHOL)
        Dim LTABACO As List(Of TTIPOTABACO)

        'PARA CARGAR EL COMBOBOX 
        'BUSCAMOS LOS RESUTLADOS
        'SEUÑO
        LSUENO = conn.Query(Of TTIPOSUENO)("SELECT  ID_TIPO_SUENO, DES_SUENO FROM TTIPOSUENO ORDER BY NUM_ORDEN")
        'HACEMOS UN DICCIONARIO
        Dim DIC_LSUENO As New System.Collections.Generic.Dictionary(Of Integer, String)
        'CARGAMOS
        For i = 0 To LSUENO.Count - 1
            DIC_LSUENO.Add(LSUENO.Item(i).ID_TIPO_SUENO, LSUENO.Item(i).DES_SUENO)
        Next
        CMB_SUENO.DisplayMemberPath = "Value"
        CMB_SUENO.SelectedValuePath = "key"
        CMB_SUENO.ItemsSource = DIC_LSUENO.ToArray

        'CAFE
        LCAFE = conn.Query(Of TTIPOCAFE)("SELECT  ID_TIPO_CAFE, DES_CAFE FROM TTIPOCAFE ORDER BY NUM_ORDEN")
        Dim DIC_LCAFE As New System.Collections.Generic.Dictionary(Of Integer, String)
        For i = 0 To LCAFE.Count - 1
            DIC_LCAFE.Add(LCAFE.Item(i).ID_TIPO_CAFE, LCAFE.Item(i).DES_CAFE)
        Next
        CMB_CAFE.DisplayMemberPath = "Value"
        CMB_CAFE.SelectedValuePath = "key"
        CMB_CAFE.ItemsSource = DIC_LCAFE.ToArray

        'EJERCICIO
        LEJER = conn.Query(Of TTIPOEJER)("SELECT  ID_TIPO_EJERCICI, DES_EJERCICI FROM TTIPOEJER ORDER BY NUM_ORDEN")
        Dim DIC_LEJER As New System.Collections.Generic.Dictionary(Of Integer, String)
        For i = 0 To LEJER.Count - 1
            DIC_LEJER.Add(LEJER.Item(i).ID_TIPO_EJERCICI, LEJER.Item(i).DES_EJERCICI)
        Next
        CMB_EJERCI.DisplayMemberPath = "Value"
        CMB_EJERCI.SelectedValuePath = "key"
        CMB_EJERCI.ItemsSource = DIC_LEJER.ToArray

        'ALCOHOL
        LALC = conn.Query(Of TTIPOALCOHOL)("SELECT  ID_TIPO_ALCOHOL, DES_ALCOHOL FROM TTIPOALCOHOL ORDER BY NUM_ORDEN")
        Dim DIC_ALC As New System.Collections.Generic.Dictionary(Of Integer, String)
        For i = 0 To LALC.Count - 1
            DIC_ALC.Add(LALC.Item(i).ID_TIPO_ALCOHOL, LALC.Item(i).DES_ALCOHOL)
        Next
        CMB_ALC.DisplayMemberPath = "Value"
        CMB_ALC.SelectedValuePath = "key"
        CMB_ALC.ItemsSource = DIC_ALC.ToArray

        'CAFE
        LCAFE = conn.Query(Of TTIPOCAFE)("SELECT  ID_TIPO_CAFE, DES_CAFE FROM TTIPOCAFE ORDER BY NUM_ORDEN")
        Dim DIC_CAFE As New System.Collections.Generic.Dictionary(Of Integer, String)
        For i = 0 To LCAFE.Count - 1
            DIC_CAFE.Add(LCAFE.Item(i).ID_TIPO_CAFE, LCAFE.Item(i).DES_CAFE)
        Next
        CMB_CAFE.DisplayMemberPath = "Value"
        CMB_CAFE.SelectedValuePath = "key"
        CMB_CAFE.ItemsSource = DIC_CAFE.ToArray

        'ALIMENTACION
        LALM = conn.Query(Of TTIPOALIMENTA)("SELECT  ID_TIPO_ALIMENTA, DES_ALIMENTA FROM TTIPOALIMENTA ORDER BY NUM_ORDEN")
        Dim DIC_ALM As New System.Collections.Generic.Dictionary(Of Integer, String)
        For i = 0 To LALM.Count - 1
            DIC_ALM.Add(LALM.Item(i).ID_TIPO_ALIMENTA, LALM.Item(i).DES_ALIMENTA)
        Next
        CMB_ALM.DisplayMemberPath = "Value"
        CMB_ALM.SelectedValuePath = "key"
        CMB_ALM.ItemsSource = DIC_ALC.ToArray

        'TABACO
        LTABACO = conn.Query(Of TTIPOTABACO)("SELECT  ID_TIPO_TABACO, DES_TABACO FROM TTIPOTABACO ORDER BY NUM_ORDEN")
        Dim DIC_TABACO As New System.Collections.Generic.Dictionary(Of Integer, String)
        For i = 0 To LTABACO.Count - 1
            DIC_TABACO.Add(LTABACO.Item(i).ID_TIPO_TABACO, LTABACO.Item(i).DES_TABACO)
        Next
        CMB_TABACO.DisplayMemberPath = "Value"
        CMB_TABACO.SelectedValuePath = "key"
        CMB_TABACO.ItemsSource = DIC_TABACO.ToArray



    End Sub
End Class
