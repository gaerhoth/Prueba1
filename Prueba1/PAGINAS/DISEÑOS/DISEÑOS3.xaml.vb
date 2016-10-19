Imports WinRTXamlToolkit.Controls.DataVisualization.Charting
Imports Prueba1.VAR_GLOBALES
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
''' 
Public NotInheritable Class DISEÑOS3
    Inherits Page


    Public Parametros As String
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter

    End Sub
    Private Sub DISEÑOS3_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        'Dim Lst2 As New List(Of CIRCO2)
        'Lst2.Add(New CIRCO2 With {.NP = "azucar", .Col = "red"})


        'DirectCast(PL.GetChildObject(Of LineSeries)("Nueva.Series(0)"), LineSeries).ItemsSource =
        '    New KeyValuePair(Of String, Integer)() _
        '    {New KeyValuePair(Of String, Integer)(DateTime.Now.ToString.Substring(0, 10), 100),
        '    New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(1).ToString.Substring(0, 10), 40),
        '    New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(2).ToString.Substring(0, 10), 85),
        '    New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(3).ToString.Substring(0, 10), 55),
        '    New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(4).ToString.Substring(0, 10), 20),
        '    New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(5).ToString.Substring(0, 10), 85),
        '    New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(6).ToString.Substring(0, 10), 55)}


        Me.Tit.Text = Parametros
        gira(MaxSentidos * 100)


        DirectCast(Nueva.Series(0), LineSeries).ItemsSource = New KeyValuePair(Of String, Integer)() _
            {New KeyValuePair(Of String, Integer)(DateTime.Now.ToString.Substring(0, 10), 100),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(1).ToString.Substring(0, 10), 40),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(2).ToString.Substring(0, 10), 85),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(3).ToString.Substring(0, 10), 55),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(4).ToString.Substring(0, 10), 20),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(5).ToString.Substring(0, 10), 85),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(6).ToString.Substring(0, 10), 55)}


        ' hay que hacerlos asi

        'Dim a As List(Of TRESSENTIDOS)
        'a = (From z In LSR Where z.ID_CALSENTIDOS = 5 Select z)
        'a(0).ID_PRUEBA sacamos el codigo y la buscamos
        'saco la unidad tb y el color
        'a(0).can


        For i = 0 To 10
            Me.PL.Items.Add(New CIRCO2 With
                      {.NP = LSR(i).ID_PRUEBA,
                       .Col = LSR(i).CAN_RESULTADO
                      })
        Next


        For i = 0 To 7


            'PL.GetChildObject(Of GridView)("Gr1").Items.Add(New CIRCO2 With
            '       {.NP = "Nombre anónimo" & i.ToString,
            '           .Col = "red"
            '          })

            Me.Gr1.Items.Add(New CIRCO2 With
                      {.NP = "Nombre anónimo" & i.ToString,
                       .Col = "red"
                      })
        Next
    End Sub



    Public Async Sub gira(valor As Integer)
        'For i = 0 To valor Step 0.01
        '    Me.slider.Value = i

        'Next

        Dim i As Decimal

        While i <= valor
            'Me.LA.GradientStops.Clear()
            Await Task.Delay(TimeSpan.FromMilliseconds(10))

            Me.slider.Value = i
            i = i + 1
        End While




    End Sub



    Private Sub PL_ItemClick(sender As Object, e As ItemClickEventArgs) Handles PL.ItemClick
        Me.Frame.Navigate(GetType(DET_PRUEBA), PL.SelectedItem)
    End Sub
End Class
Class CIRCO2
    Public Property NP() As String
        Get
            Return m_NP
        End Get
        Set
            m_NP = Value
        End Set
    End Property
    Private m_NP As String
    Public Property Col() As String
        Get
            Return m_Col
        End Get
        Set
            m_Col = Value
        End Set
    End Property
    Private m_Col As String
End Class

