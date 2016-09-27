' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class OBJ_CAMP
    Inherits Page
    Public Parametros As String()
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


    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter.ToString.Split(";")

    End Sub

    Private Sub OBJ_CAMP_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        Me.Tit.Text = Parametros(0)



        If Me.Parametros(1) = "1" Then


            Me.PL.Items.Add(New CIRCO2)
            Me.PL2.Items.Add(New CIRCO2)

            If PL.Items.Count > 1 Then
            Else
                ND1.Visibility = Visibility.Visible
            End If

            If PL2.Items.Count > 1 Then
            Else
                ND2.Visibility = Visibility.Visible
            End If




        Else


            Me.OBJ_PL.Items.Add(New CIRCO2)
            Me.OBJ_PL2.Items.Add(New CIRCO2)

            If OBJ_PL.Items.Count > 1 Then
            Else
                ND1.Visibility = Visibility.Visible
            End If

            If OBJ_PL2.Items.Count > 1 Then
            Else
                ND2.Visibility = Visibility.Visible
            End If




        End If


        'For i = 0 To 10
        '    Me.PL.Items.Add(New CIRCO2)
        'Next


    End Sub

    Private Sub Menu_Checked(sender As Object, e As RoutedEventArgs) Handles Menu.Checked

        If Me.MySplitView.IsPaneOpen = False Then
            MySplitView.IsPaneOpen = True
        Else
            MySplitView.IsPaneOpen = False
        End If

    End Sub
End Class
