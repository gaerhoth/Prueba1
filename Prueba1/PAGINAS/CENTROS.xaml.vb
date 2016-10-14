Imports Windows.UI.Xaml.Controls.Maps
Imports Windows.Devices.Geolocation
Imports Prueba1.AYUDA
Imports Prueba1.VAR_GLOBALES
Imports Windows.Storage.Streams
Imports Windows.Services.Maps
Imports System.Math
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class CENTROS
    Inherits Page
    ' Dim poiManager As AYUDA.PointOfInterestsManager
    Dim Bcartel As Boolean = False
    Public N_LAT As Decimal
    Public N_LON As Decimal
    Dim lcentros As List(Of TCENTROS)
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
        CMB_Provincias.Items.Insert(1, "Alicante / Alacant")
        CMB_Provincias.Items.Insert(2, "Almería")
        CMB_Provincias.Items.Insert(3, "Álava")
        CMB_Provincias.Items.Insert(4, "Asturias")
        CMB_Provincias.Items.Insert(5, "Ávila")
        CMB_Provincias.Items.Insert(6, "Badajoz")
        CMB_Provincias.Items.Insert(7, "Balears, Illes")
        CMB_Provincias.Items.Insert(8, "Barcelona")
        CMB_Provincias.Items.Insert(9, "Bizkaia")
        CMB_Provincias.Items.Insert(10, "Burgos")
        CMB_Provincias.Items.Insert(11, "Cáceres")
        CMB_Provincias.Items.Insert(12, "Cádiz")
        CMB_Provincias.Items.Insert(13, "Cantabria")
        CMB_Provincias.Items.Insert(14, "Castellón / Castelló")
        CMB_Provincias.Items.Insert(15, "Ciudad Real")
        CMB_Provincias.Items.Insert(16, "Córdoba")
        CMB_Provincias.Items.Insert(17, "Coruña, A")
        CMB_Provincias.Items.Insert(18, "Cuenca")
        CMB_Provincias.Items.Insert(19, "Gipuzkoa")
        CMB_Provincias.Items.Insert(20, "Girona")
        CMB_Provincias.Items.Insert(21, "Granada")
        CMB_Provincias.Items.Insert(22, "Guadalajara")
        CMB_Provincias.Items.Insert(23, "Huelva")
        CMB_Provincias.Items.Insert(24, "Huesca")
        CMB_Provincias.Items.Insert(25, "Jaén")
        CMB_Provincias.Items.Insert(26, "León")
        CMB_Provincias.Items.Insert(27, "Lleida")
        CMB_Provincias.Items.Insert(28, "Lugo")
        CMB_Provincias.Items.Insert(29, "Madrid")
        CMB_Provincias.Items.Insert(30, "Málaga")
        CMB_Provincias.Items.Insert(31, "Murcia")
        CMB_Provincias.Items.Insert(32, "Navarra")
        CMB_Provincias.Items.Insert(33, "Ourense")
        CMB_Provincias.Items.Insert(34, "Palencia")
        CMB_Provincias.Items.Insert(35, "Palmas, Las")
        CMB_Provincias.Items.Insert(36, "Pontevedra")
        CMB_Provincias.Items.Insert(37, "Rioja, La")
        CMB_Provincias.Items.Insert(38, "Salamanca")
        CMB_Provincias.Items.Insert(39, "Santa Cruz de Tenerife")
        CMB_Provincias.Items.Insert(40, "Segovia")
        CMB_Provincias.Items.Insert(41, "Sevilla")
        CMB_Provincias.Items.Insert(42, "Soria")
        CMB_Provincias.Items.Insert(43, "Tarragona")
        CMB_Provincias.Items.Insert(44, "Teruel")
        CMB_Provincias.Items.Insert(45, "Toledo")
        CMB_Provincias.Items.Insert(46, "Valencia")
        CMB_Provincias.Items.Insert(47, "Valladolid")
        CMB_Provincias.Items.Insert(48, "Zamora")
        CMB_Provincias.Items.Insert(49, "Zaragoza")
        CMB_Provincias.Items.Insert(50, "Ceuta")
        CMB_Provincias.Items.Insert(51, "Melilla")


        'Con esto creamos los Pois en el mapa

        lcentros = conn.Query(Of TCENTROS)("SELECT * FROM TCENTROS")
        For i = 0 To lcentros.Count - 1

            If lcentros(i).longitud <> "" And lcentros(i).latitud <> "" Then
                hijos(lcentros(i).des_centro, CDec(lcentros(i).longitud.Replace(".", ",")), CDec(lcentros(i).latitud.Replace(".", ",")))
            End If

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
        '  mapicon.Title = "Hola"

        mapa.MapElements.Add(mapicon)


        mapicon.NormalizedAnchorPoint = New Point(0.5, 1.0)
        ' mapicon.Title = Nombre
        mapicon.ZIndex = 0



        '        Geopoint snPoint = New Geopoint(snPosition);
        'Grid MyGrid = New Grid();
        'MyGrid.Background = New SolidColorBrush(Windows.UI.Colors.Blue);
        'TextBlock Text = New TextBlock();
        'Text.Text = "Hello";
        'Text.Width = 200;
        'MyGrid.Children.Add(Text);
        'MyMapControl.Center = snPoint;
        'MyMapControl.ZoomLevel = 14;
        '// Get the address from a `Geopoint` location.
        'MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(snPoint);


    End Sub

    Private Sub CMB_Provincias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CMB_Provincias.SelectionChanged

        encuentra(CMB_Provincias.SelectedItem.ToString)

    End Sub

    Private Sub mapa_MapElementClick(sender As MapControl, args As MapElementClickEventArgs)
        'Dim lat As Double
        'Dim lon As Double
        'lat = args.Location.Position.Latitude
        'lon = args.Location.Position.Longitude
        'Dim logo As New BitmapImage
        'logo.UriSource = New Uri("ms-appx:///Assets/Cerca.png")
        'FotoCentro.Source = logo
        'Me.DatosCentro.Text = "calle falsa 28018 Madird"


        Hint(args.Location.Position.Latitude, args.Location.Position.Longitude)



    End Sub

    Private Async Sub Detalles_Click(sender As Object, e As RoutedEventArgs) Handles Detalles.Click
        'aqui hay que pasarle la lon, lar direccion horario(q esta vacio)
        'rame.Navigate(GetType(DET_CENTRO))



        Dim status = Await Geolocator.RequestAccessAsync()
        If status = GeolocationAccessStatus.Allowed Then
            Dim locator = New Geolocator()
            Dim position = Await locator.GetGeopositionAsync()
            Dim lat = position.Coordinate.Point.Position.Latitude
            Dim lon = position.Coordinate.Point.Position.Longitude

        End If






        'Dim acces = Await Geolocator.RequestAccessAsync
        'Dim geolocartor As New Geolocator With {.DesiredAccuracyInMeters = 0}

        'Dim pos As Geoposition = Await geolocartor.GetGeopositionAsync
        'Dim LAT As Decimal = pos.Coordinate.Latitude
        'Dim LON As Decimal = pos.Coordinate.Longitude


        'mapa.Center = New Geopoint(New BasicGeoposition() With {
        '.Latitude = pos.Coordinate.Latitude,
        '.Longitude = pos.Coordinate.Longitude
        '})



    End Sub



    Public Async Sub encuentra(Provincia As String)

        Dim Bprovincias As String
        Bprovincias = Provincia & ", Spain"

        Dim results = Await MapLocationFinder.FindLocationsAsync(Bprovincias, Nothing)


        If results.Status = MapLocationFinderStatus.Success Then
            Dim lat = results.Locations(0).Point.Position.Latitude
            Dim lon = results.Locations(0).Point.Position.Longitude
            mapa.Center = New Geopoint(New BasicGeoposition() With {
               .Latitude = lat,
               .Longitude = lon
               })
            mapa.ZoomLevel = 14
        End If



    End Sub

    Private Async Sub PP2_Click(sender As Object, e As RoutedEventArgs) Handles PP2.Click
        ' encuentra()


        'Hacemos como llegar

        Dim SPuntoA As New BasicGeoposition
        Dim SPuntoB As New BasicGeoposition
        Dim SPuntoC As New BasicGeoposition

        'Dim L_Encontrado As Long
        'Dim LA_Encontrado As Decimal
        'Dim Quest As Decimal
        Dim AuxQuest As Decimal = 100000000

        'mi posicion
        Dim status = Await Geolocator.RequestAccessAsync()

        If status = GeolocationAccessStatus.Allowed Then
            Dim locator = New Geolocator()
            Dim position = Await locator.GetGeopositionAsync()
            SPuntoA.Latitude = position.Coordinate.Point.Position.Latitude
            SPuntoA.Longitude = position.Coordinate.Point.Position.Longitude

        End If


        For i = 0 To lcentros.Count - 1
            ' SPuntoB.Latitude = CDbl(lcentros(i).latitud.ToString.Replace(".", ","))
            'SPuntoB.Longitude = CDbl(lcentros(i).longitud.ToString.Replace(".", ","))



            Dim PuntoA As New Geopoint(SPuntoA)
            Dim PuntoB As New Geopoint(SPuntoB)


            '     Dim Lat1 As Long
            'Dim Lat2 As Long
            'Dim Lon1 As Long
            'Dim Lon2 As Long

            Dim d As Decimal = 0
            Dim Lat1 = SPuntoA.Latitude * PI / 180
            Dim Lon1 = SPuntoA.Longitude * PI / 180

            Dim cetro = lcentros(i).cod_centro

            If lcentros(i).latitud <> "" Then

                Dim Lat2 = lcentros(i).latitud.Replace(".", ",") * PI / 180
                Dim Lon2 = lcentros(i).longitud.Replace(".", ",") * PI / 180

                d = 6378.137 * Acos(Cos(Lat1) * Cos(Lat2) * Cos(Lon2 - Lon1) + Sin(Lat1) * Sin(Lat2))


                If d < AuxQuest Then

                    AuxQuest = d


                    SPuntoC.Latitude = CDec(lcentros(i).latitud.Replace(".", ","))
                    SPuntoC.Longitude = CDec(lcentros(i).longitud.Replace(".", ","))
                End If
            End If
        Next



        mapa.Center = New Geopoint(New BasicGeoposition() With {
     .Latitude = SPuntoC.Latitude,
     .Longitude = SPuntoC.Longitude
 })
        mapa.ZoomLevel = 15


    End Sub



    Public Async Sub Hint(lat As Double, lon As Double)
        Dim snPosition As New BasicGeoposition() With {
    .Latitude = lat,
    .Longitude = lon
}
        N_LAT = lat
        N_LON = lon
        Dim MyGrid As New Grid()
        Dim MyGrid2 As New Grid()



        If Bcartel = False Then


#Region "CArtel1"

            MyGrid2.Visibility = Visibility.Collapsed
            Dim logo As New BitmapImage
            logo.UriSource = New Uri("ms-appx:///Assets/health_popup_calendar_icon.png")

            Dim snPoint As New Geopoint(snPosition)
            ' Dim MyGrid As New Grid()



            Dim c1 As New ColumnDefinition
            Dim c2 As New ColumnDefinition
            Dim c3 As New ColumnDefinition
            c1.Width = New GridLength(50, GridUnitType.Pixel)
            c2.Width = New GridLength(150, GridUnitType.Pixel)
            c3.Width = New GridLength(50, GridUnitType.Pixel)

            MyGrid.ColumnDefinitions.Add(c1)
            MyGrid.ColumnDefinitions.Add(c2)
            MyGrid.ColumnDefinitions.Add(c3)


            MyGrid.Height = 50
            MyGrid.Width = 250
            MyGrid.CornerRadius = New CornerRadius(15)
            MyGrid.Background = New SolidColorBrush(Windows.UI.Colors.LightGray)


            Dim text As New TextBlock()
            Dim ima As New Image
            Dim Bot As New Button
            text.FontSize = 12

            '  Bot.FontFamily = New FontFamily("Segoe MDL2 Assets")
            Bot.FontSize = 15
            Bot.Height = 50
            Bot.Width = 50
            'Bot.ClickMode = Frame.Navigate(GetType(DET_CENTRO))

            Bot.Content = "i"
            Bot.Background = New SolidColorBrush(Windows.UI.Colors.Transparent)
            AddHandler Bot.Click, AddressOf Bot_Click

            ima.Source = logo
            text.TextWrapping = TextWrapping.Wrap
            ima.HorizontalAlignment = HorizontalAlignment.Left
            ima.SetValue(Grid.RowProperty, 0)

            Grid.SetColumn(ima, 0)
            Grid.SetColumn(text, 1)
            Grid.SetColumn(Bot, 2)

            MyGrid.Children.Add(ima)
            MyGrid.Children.Add(text)
            MyGrid.Children.Add(Bot)

            mapa.Center = snPoint

            Dim result As MapLocationFinderResult = Await MapLocationFinder.FindLocationsAtAsync(snPoint)

            If result.Status = MapLocationFinderStatus.Success Then
                text.Text = "CALLE Falsa de Madrid 28018 Madrid"
            End If
            mapa.Children.Add(MyGrid)
            MapControl.SetLocation(MyGrid, snPoint)
            MapControl.SetNormalizedAnchorPoint(MyGrid, New Point(0.5, 0.5))

#End Region
            Bcartel = True
        Else

#Region "Cartel2"

            MyGrid.Visibility = Visibility.Collapsed
            Dim logo2 As New BitmapImage
            logo2.UriSource = New Uri("ms-appx:///Assets/health_popup_calendar_icon.png")

            Dim snPoint2 As New Geopoint(snPosition)
            '  Dim MyGrid2 As New Grid()

            ' If MyGrid.Visibility = Visibility.Visible Then

            '   End If


            Dim c12 As New ColumnDefinition
            Dim c22 As New ColumnDefinition
            Dim c32 As New ColumnDefinition
            c12.Width = New GridLength(50, GridUnitType.Pixel)
            c22.Width = New GridLength(150, GridUnitType.Pixel)
            c32.Width = New GridLength(50, GridUnitType.Pixel)

            MyGrid.ColumnDefinitions.Add(c12)
            MyGrid.ColumnDefinitions.Add(c22)
            MyGrid.ColumnDefinitions.Add(c32)


            MyGrid2.Height = 50
            MyGrid2.Width = 250
            MyGrid2.CornerRadius = New CornerRadius(15)
            MyGrid2.Background = New SolidColorBrush(Windows.UI.Colors.LightGray)


            Dim text2 As New TextBlock()
            Dim ima2 As New Image
            Dim Bot2 As New Button
            text2.FontSize = 12

            '  Bot.FontFamily = New FontFamily("Segoe MDL2 Assets")
            Bot2.FontSize = 15
            Bot2.Height = 50
            Bot2.Width = 50
            'Bot.ClickMode = Frame.Navigate(GetType(DET_CENTRO))

            Bot2.Content = "i"
            Bot2.Background = New SolidColorBrush(Windows.UI.Colors.Transparent)

            AddHandler Bot2.Click, AddressOf Bot2_Click

            ima2.Source = logo2
            text2.TextWrapping = TextWrapping.Wrap
            ima2.HorizontalAlignment = HorizontalAlignment.Left
            ima2.SetValue(Grid.RowProperty, 0)

            Grid.SetColumn(ima2, 0)
            Grid.SetColumn(text2, 1)
            Grid.SetColumn(Bot2, 2)

            MyGrid2.Children.Add(ima2)
            MyGrid2.Children.Add(text2)
            MyGrid2.Children.Add(Bot2)

            mapa.Center = snPoint2

            Dim result2 As MapLocationFinderResult = Await MapLocationFinder.FindLocationsAtAsync(snPoint2)

            If result2.Status = MapLocationFinderStatus.Success Then
                text2.Text = "CALLE Falsa de Madrid 28018 Madrid"
            End If
            mapa.Children.Add(MyGrid)
            MapControl.SetLocation(MyGrid, snPoint2)
            MapControl.SetNormalizedAnchorPoint(MyGrid, New Point(0.5, 0.5))

#End Region

            Bcartel = False
        End If

    End Sub



    Private Sub Bot_Click(sender As Object, e As RoutedEventArgs)
        Me.Frame.Navigate(GetType(DET_CENTRO), N_LAT & ";" & N_LON)
    End Sub

    Private Sub Bot2_Click(sender As Object, e As RoutedEventArgs)
        Me.Frame.Navigate(GetType(DET_CENTRO), N_LAT & ";" & N_LON)
    End Sub


End Class
