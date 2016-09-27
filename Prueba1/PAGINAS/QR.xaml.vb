' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238
Imports ZXing
''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class QR
    Inherits Page
    Public Parametros As String()
    Public COD_QR As String

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(PERFIL))
    End Sub

    Private Sub QR_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading

        'Con esto generamos el QR
        Dim write = New BarcodeWriter()
        write.Format = ZXing.BarcodeFormat.QR_CODE
        write.Options.Height = 300
        write.Options.Width = 300
        write.Options.Margin = 1
        'pasar los datos del usuario
        Dim wb = write.Write(COD_QR)
        Me.qr.Source = wb.ToBitmap

        Dim Cnombre As String()
        Cnombre = Parametros(0).Split("|")


        Me.txtdni.Text = txtdni.Text & Parametros(1)
        Me.txtemail.Text = txtemail.Text & Parametros(3)
        Me.txtnombre.Text = txtnombre.Text & Cnombre(2) & " " & Cnombre(0) & " " & Cnombre(1)
        Me.txtsex.Text = txtsex.Text & Parametros(5)
        Me.txttel.Text = txttel.Text & Parametros(4)
        Me.txtfnaci.Text = txtfnaci.Text & Parametros(2)

    End Sub


    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        COD_QR = e.Parameter.ToString
        Parametros = e.Parameter.ToString.Split(";")

    End Sub
End Class
