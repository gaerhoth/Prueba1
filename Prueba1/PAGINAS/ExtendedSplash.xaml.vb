Imports System
Imports Windows.ApplicationModel.Activation
Imports Windows.Foundation
Imports Windows.UI.Core
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls

Partial Class ExtendedSplash
    ' Rect to store splash screen image coordinates. 
    Friend splashImageRect As Rect
    ' Variable to track splash screen dismissal status. 
    Friend dismissed As Boolean = False
    ' Variable to hold the splash screen object. 
    Private splash As SplashScreen

    Friend rootFrame As Frame


    Private showWindowTimer As DispatcherTimer
    Private showWindowTimerNum As Integer = 0

    Private Sub OnShowWindowTimer(sender As Object, e As Object)
        showWindowTimerNum += 1

        If showWindowTimerNum = 1 Then
            ' Activate/show the window, now that the splash image has rendered
            Window.Current.Activate()

            ' aquí hacemos un pequeño descanso antes de mostrar
            ' la página principal
        ElseIf showWindowTimerNum >= 50 Then
            showWindowTimer.Stop()
            cargarMainPage()
        End If

    End Sub

    Private Sub extendedSplashImage_ImageOpened(sender As Object, e As RoutedEventArgs)
        ' ImageOpened means the file has been read, but the image hasn't been painted yet.
        ' Start a short timer to give the image a chance to render, before showing the window
        ' and starting the animation.
        showWindowTimer = New DispatcherTimer()
        showWindowTimer.Interval = TimeSpan.FromMilliseconds(50)
        AddHandler showWindowTimer.Tick, AddressOf OnShowWindowTimer
        showWindowTimer.Start()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <summary> 
    ''' Constructor with splash screen information 
    ''' </summary> 
    Public Sub New(splashscreen As SplashScreen, loadState As Boolean)
        InitializeComponent()



        ' Listen for window resize events to reposition the extended splash screen image accordingly. 
        ' This is important to ensure that the extended splash screen is formatted properly in response to
        ' snapping, unsnapping, rotation, etc... 
        AddHandler Window.Current.SizeChanged, AddressOf ExtendedSplash_OnResize

        splash = splashscreen

        If splash IsNot Nothing Then
            ' Register an event handler to be executed when the splash screen has been dismissed. 
            AddHandler splash.Dismissed, AddressOf DismissedEventHandler

            ' Retrieve the window coordinates of the splash screen image. 
            splashImageRect = splash.ImageLocation
            PositionImage()
        End If

        ' Create a Frame to act as the navigation context  
        rootFrame = New Frame()

        '' Restore the saved session state if necessary 
        'RestoreStateAsync(loadState)


    End Sub

    'Public Async Sub RestoreStateAsync(loadState As Boolean)
    '    If loadState Then
    '        Await SuspensionManager.RestoreAsync()
    '    End If
    '    ' Normally you should start the time consuming task asynchronously here and  
    '    ' dismiss the extended splash screen in the completed handler of that task 
    '    ' This sample dismisses extended splash screen in the handler for "Learn More" button for demonstration 
    'End Sub

    ' Position the extended splash screen image in the same location as the system splash screen image. 
    Private Sub PositionImage()
        extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X)
        extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y)

        extendedSplashImage.Height = splashImageRect.Height
        extendedSplashImage.Width = splashImageRect.Width
    End Sub

    Private Sub Ring()
        PRE.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width * 0.5) - (splashImageRect.Width * 0.5))
        PRE.SetValue(Canvas.TopProperty, splashImageRect.Y + (splashImageRect.Height * 0.1) - (splashImageRect.Height * 0.1))
    End Sub
    Private Sub ExtendedSplash_OnResize(sender As Object, e As WindowSizeChangedEventArgs)
        ' Safely update the extended splash screen image coordinates.
        ' This function will be fired in response to snapping, unsnapping, rotation, etc... 
        If splash IsNot Nothing Then
            ' Update the coordinates of the splash screen image. 
            splashImageRect = splash.ImageLocation
            PositionImage()
            Ring()
        End If
    End Sub

    Private Sub cargarMainPage()
        ' Navigate to MainPage 
        rootFrame.Navigate(GetType(MainPage))

        '' Set extended splash info on Main Page 
        'DirectCast(rootFrame.Content, MainPage).SetExtendedSplashInfo(splashImageRect, dismissed)

        ' Place the frame in the currrent window 
        Window.Current.Content = rootFrame

    End Sub

    ' Include code to be executed when the system has transitioned from the splash screen to the extended splash screen (application's first view). 
    Private Sub DismissedEventHandler(sender As SplashScreen, e As Object)
        dismissed = True

        ' Navigate away from the app's extended splash screen after completing setup operations here... 
        ' This sample navigates away from the extended splash screen when the "Learn More" button is clicked. 
    End Sub
End Class