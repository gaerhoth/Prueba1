Imports Prueba1.VAR_GLOBALES
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class TUTORIAL2
    Inherits Page
    Public M_parametros As Object
    Private Async Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click
        Dim IND As String = "S"
        Dim diab As String
        If Me.DIABETES.IsOn Then
            diab = "S"
        Else
            diab = "N"
        End If

        Dim usuario As TUSUARIO

        usuario = (From z In conn.Table(Of TUSUARIO)() Where z.cod_identificador.Contains(M_parametros) Select z).FirstOrDefault

        R_IRM = Await C_WAH.IRMAsync(Me.TXTCM.Text, IND, Me.TXTKG.Text, IND, 0, "N", diab, IND, USU_ALTA, M_parametros, Date.Now)
        AYUDA.LimpiarJson(R_IRM.Body.IRMResult, "DameResMetas", "TRESMETAS")
        CAL_META = Await C_WAH.DameCalMetasAsync(usuario.id_trabajador, IND_ENVIADO)
        AYUDA.LimpiarJson(CAL_META.Body.DameCalMetasResult, "DameCalMetas", "TCALMETAS")

        M_parametros = M_parametros & ";" & diab

        Me.Frame.Navigate(GetType(TUTORIAL3), M_parametros)
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        M_Parametros = e.Parameter.ToString

    End Sub
End Class
