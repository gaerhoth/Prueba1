Imports Windows.UI.Xaml.Controls.Maps
Imports Windows.Devices.Geolocation
Imports Prueba1.AYUDA
Imports Prueba1.VAR_GLOBALES
Imports Windows.Storage.Streams
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class CENTROS
    Inherits Page
    ' Dim poiManager As AYUDA.PointOfInterestsManager
#Region "Menu"


    Private Sub BTN_MISALUD_Click(sender As Object, e As RoutedEventArgs) Handles BTN_MISALUD.Click
        Me.Frame.Navigate(GetType(HOME))
    End Sub

    Private Sub BTN_INFO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_INFO.Click
        Me.Frame.Navigate(GetType(INFO))
    End Sub

    Private Sub BTN_DOC_Click(sender As Object, e As RoutedEventArgs) Handles BTN_DOC.Click
        Me.Frame.Navigate(GetType(DOCUMENTOS))
    End Sub

    Private Sub BTN_OBJ_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OBJ.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_OBJ.Content)
    End Sub

    Private Sub BTN_CENTROS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CENTROS.Click
        Me.Frame.Navigate(GetType(CENTROS))
    End Sub

    Private Sub BTN_CITAS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CITAS.Click
        Me.Frame.Navigate(GetType(CITAS))
    End Sub

    Private Sub BTN_RECOM_Click(sender As Object, e As RoutedEventArgs) Handles BTN_RECOM.Click
        Me.Frame.Navigate(GetType(RECOMENDACIONES), Me.BTN_RECOM.Content)

    End Sub

    Private Sub PERFIL_Click(sender As Object, e As RoutedEventArgs) Handles PERFIL.Click
        Me.Frame.Navigate(GetType(PERFIL))
    End Sub
    Private Sub BTN_CAMPA_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CAMPA.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_CAMPA.Content)
    End Sub
#End Region

    Private Sub Menu_Checked(sender As Object, e As RoutedEventArgs) Handles Menu.Checked

        If Me.MySplitView.IsPaneOpen = False Then
            MySplitView.IsPaneOpen = True
        Else
            MySplitView.IsPaneOpen = False
        End If

    End Sub
    Private Async Sub CENTROS_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        'Centra el mapa para que se vea toda españa
        mapa.Center = New Geopoint(New BasicGeoposition() With {
        .Latitude = 40.416667,
        .Longitude = -3.75
    })
        mapa.ZoomLevel = 5


        '  Await DAMECENTROS()


        CMB_Provincias.Items.Insert(0, "Albacete")


        'CMB_Provincias.Items.Insert(02, "Albacete")
        'CMB_Provincias.Items.Insert(03, "Alicante / Alacant")
        'CMB_Provincias.Items.Insert(04, "Almería")
        'CMB_Provincias.Items.Insert(01, "Araba / Álava")
        'CMB_Provincias.Items.Insert(33, "Asturias")
        'CMB_Provincias.Items.Insert(05, "Ávila")
        'CMB_Provincias.Items.Insert(06, "Badajoz")
        'CMB_Provincias.Items.Insert(07, "Balears, Illes")
        'CMB_Provincias.Items.Insert(08, "Barcelona")
        'CMB_Provincias.Items.Insert(48, "Bizkaia")
        'CMB_Provincias.Items.Insert(09, "Burgos")
        'CMB_Provincias.Items.Insert(10, "Cáceres")
        'CMB_Provincias.Items.Insert(11, "Cádiz")
        'CMB_Provincias.Items.Insert(39, "Cantabria")
        'CMB_Provincias.Items.Insert(12, "Castellón / Castelló")
        'CMB_Provincias.Items.Insert(13, "Ciudad Real")
        'CMB_Provincias.Items.Insert(14, "Córdoba")
        'CMB_Provincias.Items.Insert(15, "Coruña, A")
        'CMB_Provincias.Items.Insert(16, "Cuenca")
        'CMB_Provincias.Items.Insert(20, "Gipuzkoa")
        'CMB_Provincias.Items.Insert(17, "Girona")
        'CMB_Provincias.Items.Insert(18, "Granada")
        'CMB_Provincias.Items.Insert(19, "Guadalajara")
        'CMB_Provincias.Items.Insert(21, "Huelva")
        'CMB_Provincias.Items.Insert(22, "Huesca")
        'CMB_Provincias.Items.Insert(23, "Jaén")
        'CMB_Provincias.Items.Insert(24, "León")
        'CMB_Provincias.Items.Insert(25, "Lleida")
        'CMB_Provincias.Items.Insert(27, "Lugo")
        'CMB_Provincias.Items.Insert(28, "Madrid")
        'CMB_Provincias.Items.Insert(29, "Málaga")
        'CMB_Provincias.Items.Insert(30, "Murcia")
        'CMB_Provincias.Items.Insert(31, "Navarra")
        'CMB_Provincias.Items.Insert(32, "Ourense")
        'CMB_Provincias.Items.Insert(34, "Palencia")
        'CMB_Provincias.Items.Insert(35, "Palmas, Las")
        'CMB_Provincias.Items.Insert(36, "Pontevedra")
        'CMB_Provincias.Items.Insert(26, "Rioja, La")
        'CMB_Provincias.Items.Insert(37, "Salamanca")
        'CMB_Provincias.Items.Insert(38, "Santa Cruz de Tenerife")
        'CMB_Provincias.Items.Insert(40, "Segovia")
        'CMB_Provincias.Items.Insert(41, "Sevilla")
        'CMB_Provincias.Items.Insert(42, "Soria")
        'CMB_Provincias.Items.Insert(43, "Tarragona")
        'CMB_Provincias.Items.Insert(44, "Teruel")
        'CMB_Provincias.Items.Insert(45, "Toledo")
        'CMB_Provincias.Items.Insert(46, "Valencia")
        'CMB_Provincias.Items.Insert(47, "Valladolid")
        'CMB_Provincias.Items.Insert(49, "Zamora")
        'CMB_Provincias.Items.Insert(50, "Zaragoza")
        'CMB_Provincias.Items.Insert(51, "Ceuta")
        'CMB_Provincias.Items.Insert(52, "Melilla")


        'Con esto creamos los Pois en el mapa
        Dim lcentros As List(Of TCENTROS)
        lcentros = conn.Query(Of TCENTROS)("SELECT * FROM TCENTROS")
        For i = 0 To lcentros.Count - 1
            hijos(lcentros(i).des_centro, CDec(lcentros(i).longitud.Replace(".", ",")), CDec(lcentros(i).latitud.Replace(".", ",")))

        Next



    End Sub



    Public Async Function DAMECENTROS() As Task(Of String)
        Dim a As WS_SMARTPHONE.DelegacionesResponse


        a = Await C_PHONE.DelegacionesAsync()
        LimpiarJson(a.Body.DelegacionesResult, "Delegaciones", "TCENTROS")

        Return "ok"

    End Function

    Private Sub BTNlstCentros_Click(sender As Object, e As RoutedEventArgs) Handles BTNlstCentros.Click
        Me.Frame.Navigate(GetType(LST_CENTROS))
    End Sub

    'Public Function hijos(Nombre As String, lon As Decimal, lat As Decimal) As List(Of PointOfInterest)
    '    Dim pois As New List(Of PointOfInterest)()
    '    pois.Add(New PointOfInterest() With {
    '        .DisplayName = Nombre,
    '        .ImageSourceUri = New Uri("ms-appx:///Assets/general_map_icon.png", UriKind.RelativeOrAbsolute),
    '        .Location = New Geopoint(New BasicGeoposition() With {
    '            .Latitude = lat,
    '            .Longitude = lon
    '        })
    '    })

    '    Return pois
    'End Function

    Public Sub hijos(Nombre As String, lon As Decimal, lat As Decimal)
        Dim snPosition As BasicGeoposition
        Dim mapicon As New MapIcon
        Dim snPoint As New Geopoint(snPosition)


        snPosition.Latitude = lat
        snPosition.Longitude = lon
        snPoint = New Geopoint(snPosition)
        mapicon.Image = RandomAccessStreamReference.CreateFromUri(New Uri("ms-appx:///Assets/general_map_icon.png"))
        mapicon.Location = snPoint

        mapa.MapElements.Add(mapicon)

        mapicon.NormalizedAnchorPoint = New Point(0.5, 1.0)
        ' mapicon.Title = Nombre
        mapicon.ZIndex = 0

    End Sub



End Class
