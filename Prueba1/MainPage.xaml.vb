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
    End Sub

    Private Sub BTN_NO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_NO.Click
        Me.Frame.Navigate(GetType(UNETE1))
    End Sub
End Class
