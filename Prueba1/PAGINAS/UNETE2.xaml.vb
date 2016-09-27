Imports Windows.UI.Popups
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class UNETE2
    Inherits Page
    Public Parametros As Object

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(UNETE1))
    End Sub

    Private Sub legal_Click(sender As Object, e As RoutedEventArgs) Handles legal.Click
        Me.Frame.Navigate(GetType(TEXTOLEGAL))
    End Sub

    Private Async Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click
        Dim datos As String

        datos = Parametros & ";" & Me.TxtApe1.Text & "|" & Me.TxtApe2.Text & "|" & Me.TxtNombre.Text & ";" & Me.CMB_SEX.SelectedItem & ";" & Me.FNACI.Date.ToString.Substring(0, 10)

        If OK.IsOn Then
            Me.Frame.Navigate(GetType(UNETE3), datos)
        Else

            Dim mensaje As MessageDialog
            mensaje = New MessageDialog("Debe aceptar las condiciones para continuar")
            Await mensaje.ShowAsync()

        End If
    End Sub


    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter

        'If e.Parameter <> "" Then
        '    Dim mensaje As MessageDialog
        '    mensaje = New MessageDialog(e.Parameter)
        '    Await mensaje.ShowAsync()
        'End If
    End Sub

    Private Sub UNETE2_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Me.CMB_SEX.Items.Add("HOMBRE")
        Me.CMB_SEX.Items.Add("MUJER")
    End Sub
End Class
