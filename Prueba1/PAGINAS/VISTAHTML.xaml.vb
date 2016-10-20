' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238
Imports Windows.Web
Imports Windows.Storage
Imports Windows.Storage.Streams

Namespace WindwsCsharpvsJavascript
    Public NotInheritable Class StreamUriWinRTResolver
        Implements IUriToStreamResolver
        Public Function UriToStreamAsync(uri As Uri) As IAsyncOperation(Of IInputStream)
            If uri Is Nothing Then
                Throw New Exception()
            End If
            Dim path As String = uri.AbsolutePath

            ' Because of the signature of the this method, it can't use await, so we 
            ' call into a seperate helper method that can use the C# await pattern.
            Return GetContent(path).AsAsyncOperation()
        End Function

        Private Async Function GetContent(path As String) As Task(Of IInputStream)
            'ms-appx:///Assets
            'aqui es donde tengo que pasar la ruta del archivo
            'Dim localUri As New Uri(Convert.ToString(ppath & path))

            'mi forma
            'Dim ppath As String = Convert.ToString(ApplicationData.Current.LocalFolder.Path)
            'Dim AA As StorageFile = Await StorageFile.GetFileFromPathAsync(Convert.ToString(ppath & path))
            'Dim stream As IRandomAccessStream = Await AA.OpenAsync(FileAccessMode.Read)


            Dim localUri As New Uri(Convert.ToString("ms-appx:///PAGINAS/HTML") & path)
            Dim f As StorageFile = Await StorageFile.GetFileFromApplicationUriAsync(localUri)
            Dim stream As IRandomAccessStream = Await f.OpenAsync(FileAccessMode.Read)




            Return stream

        End Function

        Private Function IUriToStreamResolver_UriToStreamAsync(uri As Uri) As IAsyncOperation(Of IInputStream) Implements IUriToStreamResolver.UriToStreamAsync

            Return UriToStreamAsync(uri)
        End Function
    End Class
End Namespace
Public NotInheritable Class VISTAHTML
    Inherits Page
    Public Parametros As String

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter

    End Sub
    Private Sub VISTAHTML_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading

#Region "Otra manera de cargar HTML"


        'De esta manera cargamos un HTML Guardado en la app

        'Dim ruta As String
        'ruta = ApplicationData.Current.LocalFolder.Path & "\1.html".ToString

        'Dim URL As Uri = WV.BuildLocalStreamUri("MyTag", "PAG_HTML.html")


        'Dim resolver As New WindwsCsharpvsJavascript.StreamUriWinRTResolver

        'WV.NavigateToLocalStreamUri(URL, resolver)
#End Region

        Dim recom = "<!DOCTYPE html>

            <html lang=""es"" xmlns=""http://www.w3.org/1999/xhtml"">
            <head>
                <meta charset=""utf-8"" />
                <link rel=""stylesheet"" href=""ms-appx-web:///PAGINAS/HTML/css/EstilosHTML.css"" type=""text/css"" />
                <title></title>
            </head>
            <body>
              <header><h1>CÓMO REDUCIR EL COLESTEROL</h1></header><section><h1>RECOMENDACIONES PARA <br>PREVENIR SU APARICIÓN</h1><article><div class=""list varices""><div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_16.png"" /><div class=""item-text""><p>Evita las grasas saturadas como carnes de vaca y cerdo, manteca, queso, mantequilla, leche entera y aceite hidrogenado. Reemplaza estos alimentos por pescado, aves, productos lácteos bajos en grasa y aceite de oliva.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_17.png"" /><div class=""item-text""><p>Come frutas, ya que, al contener pectina, tienen un efecto reductor del colesterol.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_18.png"" /><div class=""item-text""><p>Come productos integrales.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_19.png"" /><div class=""item-text""><p>Consume huevos con moderación. El huevo tiene 275 miligramos de colesterol. Sin embargo, se han realizado estudios que demuestran que un consumo de tres huevos a la semana no conlleva riesgos. También puedes eliminar la yema, que es la parte que contiene el colesterol. Por ejemplo, elabora las tortillas o huevos revueltos utilizando sólo una yema y las claras de varios huevos.</p><div class=""separator""></div> </div><div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_20.png"" /><div class=""item-text""><p>Evita las bebidas alcohólicas y carbonatadas, té, café, dulces, pan blanco y otros azúcares refinados.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_21.png"" /><div class=""item-text""><p>Evita alimentos formadores de gas, como las coles, frijoles, coles de Bruselas o la coliflor.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_22.png"" /><div class=""item-text""><p>Evita el sobrepeso, ya que la obesidad está vinculada con niveles altos de colesterol y triglicéridos.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_23.png"" /><div class=""item-text""><p>Intenta no estar de pie durante tiempos prolongados.</p></div></div><div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_24.png"" /><div class=""item-text""><p>Controla el estrés y la tensión. Es recomendable practicar técnicas de relajación.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_25.png"" /><div class=""item-text""><p>Evita el consumo de tabaco.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_26.png"" /><div class=""item-text""><p>Adopta un programa de ejercicios bajo supervisión médica y camina diariamente al aire libre de 15 a 20 minutos.</p><div class=""separator""></div></div></div> <div class=""item""><img class=""item-image"" src=""http://213.0.19.28:1248/repositorio/documentos/WAH/Recomendaciones/images/list_27.png"" /><div class=""item-text""><p>Si tienes un cuadro de colesterol alto, debes tratar de medirlo cada tres a cuatro meses para llevar un adecuado control.</p></div></div></div></article></section>
             </body>
            </html>"

        WV.NavigateToString(recom)

    End Sub







End Class
