Imports Prueba1.AYUDA
Imports Prueba1.VAR_GLOBALES
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class RECOMENDACIONES
    Inherits Page



#Region "Menu"


    Private Sub BTN_MISALUD_Click(sender As Object, e As RoutedEventArgs) Handles BTN_MISALUD.Click
        Me.Frame.Navigate(GetType(HOME))
    End Sub

    Private Sub BTN_INFO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_INFO.Click
        Me.Frame.Navigate(GetType(INFO))
    End Sub

    Private Sub BTN_DOC_Click(sender As Object, e As RoutedEventArgs) Handles BTN_DOC.Click
        Me.Frame.Navigate(GetType(DOCUMENTOS))
    End Sub

    Private Sub BTN_OBJ_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OBJ.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_OBJ.Content)
    End Sub

    Private Sub BTN_CENTROS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CENTROS.Click
        Me.Frame.Navigate(GetType(CENTROS))
    End Sub

    Private Sub BTN_CITAS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CITAS.Click
        Me.Frame.Navigate(GetType(CITAS))
    End Sub

    Private Sub BTN_RECOM_Click(sender As Object, e As RoutedEventArgs) Handles BTN_RECOM.Click
        Me.Frame.Navigate(GetType(RECOMENDACIONES), Me.BTN_RECOM.Content)

    End Sub

    Private Sub PERFIL_Click(sender As Object, e As RoutedEventArgs) Handles PERFIL.Click
        Me.Frame.Navigate(GetType(PERFIL))
    End Sub
    Private Sub BTN_CAMPA_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CAMPA.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_CAMPA.Content)
    End Sub


#End Region


    Private Async Sub RECOMENDACIONES_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading


        Dim LS_RECOM As List(Of TRECOMENDACIONES)
        RECOM = Await C_WAH.DameRecomendacionAsync(48)
        AYUDA.LimpiarJson(RECOM.Body.DameRecomendacionResult, "DameRecomendacion", "TRECOMENDACIONES")
        LS_RECOM = conn.Query(Of TRECOMENDACIONES)("SELECT * FROM TRECOMENDACIONES")


        For i = 0 To LS_RECOM.Count - 1
            Me.PL.Items.Add(New CLASERECOM With
                      {.TIT = LS_RECOM(i).DES_TIPO_RECOM,
                      .HTML = LS_RECOM(i).DES_PAGINA_ESTANDAR
                                            })
        Next
    End Sub

    Private Sub PL_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles PL.Tapped
        Frame.Navigate(GetType(VISTAHTML), DirectCast(PL.SelectedItem, Prueba1.CLASERECOM).HTML)
    End Sub
End Class



