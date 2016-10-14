Imports Windows.UI.Xaml.Controls.Maps
Imports Windows.Devices.Geolocation
Imports Prueba1.AYUDA
Imports Prueba1.VAR_GLOBALES
Imports Windows.Storage.Streams
Imports Windows.Services.Maps
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class DET_CENTRO
    Inherits Page
    Public Parametros As String()

    Private Sub DET_CENTRO_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading

        Dim snPosition As BasicGeoposition
        Dim mapicon As New MapIcon
        Dim snPoint As New Geopoint(snPosition)


        snPosition.Latitude = Parametros(0)
        snPosition.Longitude = Parametros(1)
        snPoint = New Geopoint(snPosition)
        mapicon.Image = RandomAccessStreamReference.CreateFromUri(New Uri("ms-appx:///Assets/general_map_icon.png"))
        mapicon.Location = snPoint

        mapa.MapElements.Add(mapicon)


        mapicon.NormalizedAnchorPoint = New Point(0.5, 1.0)

        mapicon.ZIndex = 0

    End Sub



    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter.ToString.Split(";")

    End Sub

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Frame.Navigate(GetType(CENTROS))
    End Sub

    Private Async Sub BTN_SOL_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SOL.Click
        'Frame.Navigate(GetType(CITAS))


        'Dim uriNewYork = New Uri("bingmaps:?cp=40.726966~-74.006076")

        Dim status = Await Geolocator.RequestAccessAsync()

        If status = GeolocationAccessStatus.Allowed Then
            Dim locator = New Geolocator()
            Dim position = Await locator.GetGeopositionAsync()

            Dim str As String

            str = "bingmaps:?rtp=pos." & position.Coordinate.Point.Position.Latitude & "_" & position.Coordinate.Point.Position.Longitude & "~pos." & Parametros(0) & "_" & Parametros(1) & ""
            str = str.Replace(",", ".")


            Dim Uri2 = New Uri(str)
            Dim launcherOptions = New Windows.System.LauncherOptions()

            launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe"


            Dim success = Await Windows.System.Launcher.LaunchUriAsync(Uri2, launcherOptions)

        End If








    End Sub

    Private Async Sub BTN_llegar_Click(sender As Object, e As RoutedEventArgs) Handles BTN_llegar.Click
        'Hacemos como llegar

        Dim SPuntoA As New BasicGeoposition
        Dim SPuntoB As New BasicGeoposition




        Dim status = Await Geolocator.RequestAccessAsync()
        If status = GeolocationAccessStatus.Allowed Then
            Dim locator = New Geolocator()
            Dim position = Await locator.GetGeopositionAsync()
            SPuntoA.Latitude = position.Coordinate.Point.Position.Latitude
            SPuntoA.Longitude = position.Coordinate.Point.Position.Longitude

        End If



        SPuntoB.Latitude = Parametros(0)
        SPuntoB.Longitude = Parametros(1)



        Dim PuntoA As New Geopoint(SPuntoA)
        Dim PuntoB As New Geopoint(SPuntoB)

        Dim result = Await MapRouteFinder.GetDrivingRouteAsync(PuntoA, PuntoB)


        If result.Status = MapRouteFinderStatus.Success Then
            'put route in a map route view object
            Dim routeView = New MapRouteView(result.Route)
            routeView.RouteColor = Windows.UI.Colors.Yellow
            routeView.OutlineColor = Windows.UI.Colors.Black

            mapa.Routes.Add(routeView)

            Await mapa.TrySetViewBoundsAsync(result.Route.BoundingBox, Nothing, Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None)



        End If


    End Sub
End Class
