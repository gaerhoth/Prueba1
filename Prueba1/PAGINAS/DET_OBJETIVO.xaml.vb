' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class DET_OBJETIVO
    Inherits Page
    Public Parametros As String

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter

    End Sub

    Private Sub DET_OBJETIVO_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        Dim recom = "<!DOCTYPE html>

            <html lang=""es"" xmlns=""http://www.w3.org/1999/xhtml"">
            <head>
                <meta charset=""utf-8"" />
                <link rel=""stylesheet"" href=""ms-appx-web:///PAGINAS/HTML/css/EstilosHTML.css"" type=""text/css"" />
                <title></title>
            </head> 
                " & Parametros & "
            </html>"

        WV.NavigateToString(recom)
    End Sub

    Private Sub minfo_Click(sender As Object, e As RoutedEventArgs) Handles minfo.Click
        Me.Frame.Navigate(GetType(VISTAHTML))
    End Sub
End Class
