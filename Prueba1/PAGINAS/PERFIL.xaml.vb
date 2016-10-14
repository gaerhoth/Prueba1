Imports Prueba1.VAR_GLOBALES
Imports System.Windows
'Imports Windows.UI.Xaml.Media.
Imports Windows.UI.Xaml.Media.Imaging
Imports ZXing
Imports ZXing.Rendering
Imports Windows.Storage
Imports Windows.Graphics.Imaging
Imports Windows.Storage.Streams
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.Media.MediaProperties
Imports Windows.Storage.FileProperties
Imports Windows.Media.Capture
Imports Windows.Storage.Pickers

' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class PERFIL
    Inherits Page
    Private id As Object
    Public Cadenas As String
    Public MediaCapture As New MediaCapture
    Public PW As Boolean
    Public captureFolder As StorageFolder = Nothing


    Private Sub BTN_CERRAR_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CERRAR.Click
        Dim UPDATE As String = ""


        UPDATE = "UPDATE TUSUARIO SET ACTIVE ='N' WHERE ID_TRABAJADOR =" & id


        conn.Execute(UPDATE)
        Me.Frame.Navigate((GetType(LOGIN1)))
    End Sub

    Private Sub PERFIL_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        'TENEMOS QUE CARGAR LA INFORMACION DE TUSUARIO
        Me.CMB_SAN.Items.Add("A+")
        Me.CMB_SAN.Items.Add("A-")
        Me.CMB_SAN.Items.Add("B+")
        Me.CMB_SAN.Items.Add("B-")
        Me.CMB_SAN.Items.Add("AB+")
        Me.CMB_SAN.Items.Add("AB-")
        Me.CMB_SAN.Items.Add("O+")
        Me.CMB_SAN.Items.Add("O-")


        Dim USUARIO As TUSUARIO
        Dim NOMBRE As String()

        ' USUARIO = conn.ExecuteScalar(Of TUSUARIO)("SELECT * FROM TUSUARIO WHERE ACTIVE ='S'")
        USUARIO = (From p In conn.Table(Of TUSUARIO) Where p.active.Contains("S") Select p).FirstOrDefault

        id = USUARIO.id_trabajador

        NOMBRE = USUARIO.nom_trabajador.Split("|")
        Me.TXTNOMBRE.Text = NOMBRE(2)
        Me.TXTAPE.Text = NOMBRE(0) & " " & NOMBRE(0)
        Me.TXTnif.Text = USUARIO.cod_identificador.ToString
        Me.TXTNACI.Text = USUARIO.fecha_nacimiento.ToString
        Me.TXTEMAIL.Text = USUARIO.des_email

        If USUARIO.emergency_name IsNot Nothing Then
            Me.AANombre.Text = USUARIO.emergency_name
        End If
        If USUARIO.emergency_phone IsNot Nothing Then
            Me.AATelefono.Text = USUARIO.emergency_phone
        End If
        If USUARIO.num_telefono IsNot Nothing Then
            Me.TXTTEL.Text = USUARIO.num_telefono
        End If

        If USUARIO.share_salud = "S" Then
            Me.Salud.IsOn = True
        Else
            Me.Salud.IsOn = False
        End If

        If USUARIO.organ_donor = "S" Then
            Me.Organos.IsOn = True
        Else
            Me.Organos.IsOn = False
        End If

        If USUARIO.blood_type Is Nothing Then
            Me.CMB_SAN.SelectedIndex = 0
        Else

            Me.CMB_SAN.SelectedIndex = USUARIO.blood_type
        End If

        If USUARIO.sexo = "V" Then

            Me.B_HOMBRE_V.Visibility = Visibility.Visible
            Me.B_MUJER_V.Visibility = Visibility.Collapsed
        Else
            Me.B_HOMBRE_V.Visibility = Visibility.Collapsed
            Me.B_MUJER_V.Visibility = Visibility.Visible
        End If

        Cadenas = USUARIO.nom_trabajador & ";" & USUARIO.cod_identificador & ";" & USUARIO.fecha_nacimiento & ";" & USUARIO.des_email & ";" & USUARIO.num_telefono & ";" & USUARIO.sexo
    End Sub

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(HOME), id)
    End Sub

    Private Sub BTN_OK_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OK.Click
        Dim UPDATE As String
        Dim DONANTE As String
        Dim IND_SALUD As String
        Dim SANGRE As String

        If Salud.IsOn Then
            IND_SALUD = "S"
        Else
            IND_SALUD = "N"
        End If

        If Organos.IsOn Then
            DONANTE = "S"
        Else
            DONANTE = "N"
        End If

        SANGRE = CMB_SAN.SelectedIndex

        UPDATE = "UPDATE TUSUARIO SET organ_donor ='" & DONANTE & "', emergency_name='" & Me.AANombre.Text & "',
                 emergency_phone ='" & AATelefono.Text & "', NUM_TELEFONO='" & Me.TXTTEL.Text & "',share_salud ='" & IND_SALUD & "' 
                 WHERE ACTIVE='S'"

        conn.Execute(UPDATE)



    End Sub

    Private Async Sub PERFIL_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        'Con esto generamos el QR
        Dim write = New BarcodeWriter()
        write.Format = ZXing.BarcodeFormat.QR_CODE
        write.Options.Height = 300
        write.Options.Width = 300
        'pasar los datos del usuario
        Dim wb = write.Write(Cadenas)
        Me.QR.Source = wb.ToBitmap

        'If ApplicationData.Current.LocalFolder Then

        'End If

        '  Dim fot = Await captureFolder.GetFileAsync("MI_Foto.jpg") 'CreateFileAsync("Mi_Foto.jpg", CreationCollisionOption.OpenIfExists)

        ' Await captureFolder.("MI_Foto.jpg",)

        If File.Exists(ApplicationData.Current.LocalFolder.Path & "\Mi_foto.jpg") Then



            Dim BM As New BitmapImage(New Uri(ApplicationData.Current.LocalFolder.Path & "\Mi_foto.jpg"))
            C.Source = BM
        End If

    End Sub



    Public Async Function IFB(BYTESS As Byte()) As Task(Of BitmapImage)

        Dim STREAM As New Windows.Storage.Streams.InMemoryRandomAccessStream
        Using STREAM
            Using WRITER As New Windows.Storage.Streams.DataWriter(STREAM.GetOutputStreamAt(0))
                WRITER.WriteBytes(BYTESS)
                Await WRITER.StoreAsync()
            End Using
        End Using

        Dim IMAGE = New BitmapImage()
        Await IMAGE.SetSourceAsync(STREAM.AsStream)
        Return IMAGE
    End Function






    Public Async Function SaveToImageSource(imageBuffer As Byte()) As Task(Of ImageSource)
        Dim imageSource As ImageSource = Nothing
        Using stream As New MemoryStream(imageBuffer)
            Dim ras = stream.AsRandomAccessStream()
            ras.Seek(0)
            Dim decoder As BitmapDecoder = Await BitmapDecoder.CreateAsync(BitmapDecoder.PngDecoderId, ras)
            Dim provider = Await decoder.GetPixelDataAsync()
            Dim buffer As Byte() = provider.DetachPixelData()
            Dim bitmap As New WriteableBitmap(CInt(decoder.PixelWidth), CInt(decoder.PixelHeight))
            Await bitmap.PixelBuffer.AsStream().WriteAsync(buffer, 0, buffer.Length)
            imageSource = bitmap
        End Using
        Return imageSource
    End Function


    Public Async Function ImageFromBytes(bytes As [Byte]()) As Task(Of BitmapImage)
        Dim image As New BitmapImage()
        Using stream As New InMemoryRandomAccessStream()
            Await stream.WriteAsync(bytes.AsBuffer())
            stream.Seek(0)
            Await image.SetSourceAsync(stream)
        End Using
        Return image
    End Function

    Private Sub B_QR_Click(sender As Object, e As RoutedEventArgs) Handles B_QR.Click
        Me.Frame.Navigate(GetType(QR), Cadenas)
    End Sub

    Private Sub AANombre_GotFocus(sender As Object, e As RoutedEventArgs) Handles AANombre.GotFocus
        AANombre.Text = ""
    End Sub

    Private Sub AATelefono_GotFocus(sender As Object, e As RoutedEventArgs) Handles AATelefono.GotFocus
        AATelefono.Text = ""
    End Sub

    Private Sub TXTTEL_GotFocus(sender As Object, e As RoutedEventArgs) Handles TXTTEL.GotFocus
        TXTTEL.Text = ""
    End Sub

    Private Async Sub cambiar_Click(sender As Object, e As RoutedEventArgs) Handles cambiar.Click


        Frame.Navigate(GetType(PHOTO))


        'Await MediaCapture.InitializeAsync




        'Dim myPictures = Await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures)
        'Dim file As StorageFile = Await myPictures.SaveFolder.CreateFileAsync("Mi_foto.jpg", CreationCollisionOption.GenerateUniqueName)

        'Using captureStream = New InMemoryRandomAccessStream()
        '    Await MediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), captureStream)

        '    Using fileStream = Await file.OpenAsync(FileAccessMode.ReadWrite)
        '        Dim decoder = Await BitmapDecoder.CreateAsync(captureStream)
        '        Dim encoder = Await BitmapEncoder.CreateForTranscodingAsync(fileStream, decoder)

        '        Dim properties = New BitmapPropertySet() From {
        '    {"System.Photo.Orientation", New BitmapTypedValue(PhotoOrientation.Normal, PropertyType.UInt16)}
        '}
        '        Await encoder.BitmapProperties.SetPropertiesAsync(properties)

        '        Await encoder.FlushAsync()
        '    End Using
        'End Using

        '    C.Source = myPictures & "Mi_foto.jpg"


    End Sub
End Class
