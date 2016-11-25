Imports Prueba1.AYUDA
Imports Prueba1.VAR_GLOBALES
Imports Windows.UI.Xaml.Data
Imports System.Collections.Generic
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class RECOMENDACIONES
    Inherits Page
    '  Dim LS_RECOM As List(Of TRECOMENDACIONES)


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



        RECOM = Await C_WAH.DameRecomendacionAsync(48)
        AYUDA.LimpiarJson(RECOM.Body.DameRecomendacionResult, "DameRecomendacion", "TRECOMENDACIONES")
        LS_RECOM = conn.Query(Of TRECOMENDACIONES)("SELECT * FROM TRECOMENDACIONES")


        For i = 0 To LS_RECOM.Count - 1
            Me.PL.Items.Add(New CLASERECOM With
                      {.TIT = LS_RECOM(i).DES_TIPO_RECOM,
                      .HTML = LS_RECOM(i).DES_PAGINA_ESTANDAR
                                            })
        Next







        'Dim view As New ObservableCollection(Of CLASERECOM)()
        'LS_RECOM.
        'PL.ItemsSource = PL.Items
        'PL.Items.Clear()

        'PL.Items.Contains("Campa")

    End Sub

    Private Sub PL_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles PL.Tapped
        Frame.Navigate(GetType(VISTAHTML), DirectCast(PL.SelectedItem, Prueba1.CLASERECOM).HTML & "|Recomendaciones")
    End Sub

    Private Sub filtro_TextChanged(sender As Object, e As TextChangedEventArgs) Handles filtro.TextChanged

        'Dim a As IEnumerable(Of TRECOMENDACIONES) = Nothing
        Dim lsf As List(Of TRECOMENDACIONES) = Nothing
        Dim auxlsf As List(Of TRECOMENDACIONES) = Nothing

        'If lsf IsNot Nothing Then
        '    a = lsf.Where(Function(n) Not auxlsf.Contains(n))
        'End If


        'If a IsNot Nothing Then



        PL.Items.Clear()
            lsf = LS_RECOM.Where(Function(x) x.DES_TIPO_RECOM.Contains(filtro.Text.ToUpper)).ToList

            For i = 0 To lsf.Count - 1
                Me.PL.Items.Add(New CLASERECOM With
                          {.TIT = lsf(i).DES_TIPO_RECOM,
                          .HTML = lsf(i).DES_PAGINA_ESTANDAR
                                                })
            Next
        ' End If
    End Sub
End Class



