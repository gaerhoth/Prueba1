Imports System
Imports Windows.Foundation
Imports Windows.Storage
Imports Windows.Storage.Streams
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Automation
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Controls.Primitives
Imports System.Threading.Tasks
Imports Windows.Data.Pdf
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma  o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class Documentos2
    Inherits Page
    Public num_hojas As Integer
    Public ppag As Integer = 0
    Private PdfDocument As PdfDocument
    Public X As Double

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Frame.Navigate(GetType(DOCUMENTOS))
    End Sub


    Public Async Function DisplayImageFileAsync(file As StorageFile) As Task
        ' Display the image in the UI.
        Dim src As New BitmapImage()
        src.SetSource(Await file.OpenAsync(FileAccessMode.Read))
        Documento.Source = src
    End Function

    Enum RENDEROPTIONS
        NORMAL = 0
        ZOOM = 1
        PORTION = 2
    End Enum

    Dim PDF_PAGE_INDEX As UInteger = 0
    'first page
    Dim ZOOM_FACTOR As UInteger = 3
    '300% zoom
    Dim PDF_PORTION_RECT As New Rect(100, 100, 300, 400)
    'portion of a page
    Dim PDFFILENAME As String = "Assets\Windows_7_Product_Guide.pdf"
    'Pdf file


    Public Async Sub Render(n_pag As Integer)

        '   Dim pdfFile As StorageFile = Await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(PDFFILENAME)

        Dim storageFolder As StorageFolder = Windows.Storage.ApplicationData.Current.LocalFolder
        Dim pdffile As StorageFile = Await storageFolder.CreateFileAsync("Windows_7_Product_Guide.pdf", CreationCollisionOption.OpenIfExists)


        PdfDocument = Await PdfDocument.LoadFromFileAsync(pdffile)



        If PdfDocument IsNot Nothing AndAlso PdfDocument.PageCount > 0 Then
            num_hojas = PdfDocument.PageCount
            'Get Pdf page
            If n_pag > num_hojas Or n_pag >= 0 Then
                Dim pdfPage = PdfDocument.GetPage(n_pag)

                If pdfPage IsNot Nothing Then
                    ' next, generate a bitmap of the page
                    Dim tempFolder As StorageFolder = ApplicationData.Current.TemporaryFolder

                    Dim jpgFile As StorageFile = Await tempFolder.CreateFileAsync(Guid.NewGuid().ToString() + ".png", CreationCollisionOption.ReplaceExisting)

                    If jpgFile IsNot Nothing Then
                        Dim randomStream As IRandomAccessStream = Await jpgFile.OpenAsync(FileAccessMode.ReadWrite)

                        Dim pdfPageRenderOptions As New PdfPageRenderOptions()

                        ' If RENDEROPTIONS.NORMAL Then
                        'Render Pdf page with default options
                        Await pdfPage.RenderToStreamAsync(randomStream)
                        '  End If
                        '    Exit Select
                        '    Case RENDEROPTIONS.ZOOM
                        '    'set PDFPageRenderOptions.DestinationWidth or DestinationHeight with expected zoom value
                        '    Dim pdfPageSize As Size = pdfPage.Size
                        '    pdfPageRenderOptions.DestinationHeight = CUInt(pdfPageSize.Height) * ZOOM_FACTOR
                        '    'Render pdf page at a zoom level by passing pdfpageRenderOptions with DestinationLength set to the zoomed in length 
                        '    Await pdfPage.RenderToStreamAsync(randomStream, pdfPageRenderOptions)
                        '    Exit Select
                        '    Case RENDEROPTIONS.PORTION
                        '    'Set PDFPageRenderOptions.SourceRect to render portion of a page
                        '    pdfPageRenderOptions.SourceRect = PDF_PORTION_RECT
                        '    'Render portion of a page
                        '    Await pdfPage.RenderToStreamAsync(randomStream, pdfPageRenderOptions)
                        '    Exit Select

                        Await randomStream.FlushAsync()

                        randomStream.Dispose()
                        pdfPage.Dispose()

                        Await DisplayImageFileAsync(jpgFile)

                        Me.IT.TranslateX = 0
                        Me.IT.TranslateY = 0
                        IT.ScaleX = 1
                        IT.ScaleY = 1
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Documentos2_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        Render(ppag)
    End Sub

    Private Sub Documento_ManipulationStarted(sender As Object, e As ManipulationStartedRoutedEventArgs)
        Me.Documento.Opacity = 0.4
    End Sub

    Private Sub Documento_ManipulationDelta(sender As Object, e As ManipulationDeltaRoutedEventArgs)
        Me.IT.TranslateX += e.Delta.Translation.X

        X = e.Delta.Translation.X
        Dim lado As Decimal

        If IT.ScaleX <> 1 Then
            Me.IT.TranslateY += e.Delta.Translation.Y
        End If


        'If e.Delta.Translation.X > 50 Or e.Delta.Translation.X < -50 Then
        '      If FlowDirection = FlowDirection.LeftToRight Then

        'lado = e.Delta.Translation.X

        '    If lado < 0 Then
        '        ppag = ppag + 1
        '        If ppag < num_hojas Then
        '            Render(ppag)
        '        Else
        '            ppag = ppag - 1
        '            Me.IT.TranslateX = 0
        '            Me.IT.TranslateY = 0
        '            IT.ScaleX = 1
        '            IT.ScaleY = 1
        '        End If
        '        'End If
        '    End If

        '    If lado > 0 Then
        '        ppag = ppag - 1
        '        If ppag >= 0 Then
        '            Render(ppag)
        '        Else
        '            ppag = ppag + 1
        '            Me.IT.TranslateX = 0
        '            Me.IT.TranslateY = 0
        '            IT.ScaleX = 1
        '            IT.ScaleY = 1
        '        End If
        '    End If


        ' Else
        ' Me.IT.TranslateX = 0
        ' End If



    End Sub

    Public Sub Pagina_mas()

    End Sub

    Private Sub Documento_PointerWheelChanged(sender As Object, e As PointerRoutedEventArgs)

        Dim dbdelta As Double
        dbdelta = -1 * e.GetCurrentPoint(Documento).Properties.MouseWheelDelta

        dbdelta = If((dbdelta > 0), 1.2, 0.8)

        Dim Sx As Double
        Dim Sy As Double

        Sx = Me.IT.ScaleX * dbdelta
        Sy = Me.IT.ScaleY * dbdelta

        If Sx > 1 And Sx <= 5 Then
            Me.IT.ScaleX = Sx
            Me.IT.ScaleY = Sy
        Else
            If Sx < 1 Then
                Me.IT.TranslateX = 0
                Me.IT.TranslateY = 0
                IT.ScaleX = 1
                IT.ScaleY = 1
            End If

        End If


    End Sub


    Private Sub Documento_ManipulationCompleted(sender As Object, e As ManipulationCompletedRoutedEventArgs)
        Documento.Opacity = 1

        If IT.ScaleX = 1 Then
            If X < 0 Then

                If X < -1 Then
                    ppag = ppag + 1
                    If ppag < num_hojas Then
                        Render(ppag)
                    Else
                        ppag = ppag - 1
                        Me.IT.TranslateX = 0
                        Me.IT.TranslateY = 0
                        IT.ScaleX = 1
                        IT.ScaleY = 1
                    End If
                Else
                    Me.IT.TranslateX = 0
                    Me.IT.TranslateY = 0
                    IT.ScaleX = 1
                    IT.ScaleY = 1

                End If
            End If

            If X > 0 Then
                If X > 1 Then
                    ppag = ppag - 1
                    If ppag >= 0 Then
                        Render(ppag)
                    Else
                        ppag = ppag + 1
                        Me.IT.TranslateX = 0
                        Me.IT.TranslateY = 0
                        IT.ScaleX = 1
                        IT.ScaleY = 1
                    End If
                Else
                    Me.IT.TranslateX = 0
                    Me.IT.TranslateY = 0
                    IT.ScaleX = 1
                    IT.ScaleY = 1
                End If
            End If
        End If
    End Sub

    Private Sub Documento_DoubleTapped(sender As Object, e As DoubleTappedRoutedEventArgs) Handles Documento.DoubleTapped
        Me.IT.TranslateX = 0
        Me.IT.TranslateY = 0
        IT.ScaleX = 1
        IT.ScaleY = 1
    End Sub
End Class
