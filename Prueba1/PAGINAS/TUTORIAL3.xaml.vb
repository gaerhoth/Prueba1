Imports Prueba1.VAR_GLOBALES
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class TUTORIAL3
    Inherits Page
    Public M_Parametros As String()
    Public M_Parametros2 As String

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(TUTORIAL2))
    End Sub

    Private Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click

        M_Parametros2 = M_Parametros(0) & ";" & M_Parametros(1) & ";" & Me.TXTPERO.Text

        Me.Frame.Navigate(GetType(TUTORIAL4), M_Parametros2)
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        M_Parametros = e.Parameter.ToString.Split(";")

    End Sub
End Class
