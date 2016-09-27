Imports WinRTXamlToolkit.Controls.DataVisualization.Charting
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class DET_HEXAGONO
    Inherits Page

    Private Sub DET_HEXAGONO_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading



    End Sub


    Private Sub LoadChartContents()
        Dim rand As New Random()
        Dim financialStuffList As New List(Of FinancialStuff)()
        financialStuffList.Add(New FinancialStuff() With {
        .Name = "MSFT",
        .Amount = rand.[Next](0, 200)
    })
        financialStuffList.Add(New FinancialStuff() With {
        .Name = "AAPL",
        .Amount = rand.[Next](0, 200)
    })
        financialStuffList.Add(New FinancialStuff() With {
        .Name = "GOOG",
        .Amount = rand.[Next](0, 200)
    })
        financialStuffList.Add(New FinancialStuff() With {
        .Name = "BBRY",
        .Amount = rand.[Next](0, 200)
    })





        'TryCast(PieChart.Series(0), PieSeries).ItemsSource = financialStuffList
        'TryCast(ColumnChart.Series(0), ColumnSeries).ItemsSource = financialStuffList
        'TryCast(lineChart.iSeries(0), LineSeries).ItemsSource = financialStuffList

        '        DirectCast(lineChart.Series(0), LineSeries).IndependentAxis = New LinearAxis() With {
        '    .Minimum = 1,
        '    .Maximum = 6,
        '    .Orientation = AxisOrientation.X,
        '    .Interval = 1
        '}

        '        DirectCast(lineChart.Series(0), LineSeries).DependentRangeAxis = New LinearAxis() With {
        '    .Orientation = AxisOrientation.Y,
        '    .ShowGridLines = True
        '}


        '  lineChart2.ItemsSource = financialStuffList
        '     TryCast(lineChart.Series(0), LineSeries).ItemsSource = financialStuffList

        'TryCast(BarChart.Series(0), BarSeries).ItemsSource = financialStuffList
        'TryCast(BubbleChart.Series(0), BubbleSeries).ItemsSource = financialStuffList
    End Sub

    'Private Sub ButtonRefresh_Click(sender As Object, e As RoutedEventArgs)
    '    LoadChartContents()
    'End Sub

    Private Sub DET_HEXAGONO_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        '  LoadChartContents()
        LoadLineChartData()
    End Sub

    Public Sub LoadLineChartData()


        'DirectCast(Nueva.Series(0), LineSeries).IndependentAxis = New LinearAxis() With {
        '    .Minimum = 0,
        '    .Maximum = 100,
        '    .Orientation = AxisOrientation.Y,
        '    .Interval = 25,
        '    .DataContext = New KeyValuePair(Of DateTime, Integer)() _
        '    {New KeyValuePair(Of DateTime, Integer)(Nothing, 100),
        '    New KeyValuePair(Of DateTime, Integer)(DateTime.Now.AddMonths(1), 130),
        '    New KeyValuePair(Of DateTime, Integer)(DateTime.Now.AddMonths(2), 85),
        '    New KeyValuePair(Of DateTime, Integer)(DateTime.Now.AddMonths(3), 55),
        '    New KeyValuePair(Of DateTime, Integer)(DateTime.Now.AddMonths(4), 20)}}





        DirectCast(Nueva.Series(0), LineSeries).ItemsSource = New KeyValuePair(Of String, Integer)() _
            {New KeyValuePair(Of String, Integer)(DateTime.Now, 100),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(1), 40),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(2), 85),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(3), 55),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(4), 20),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(5), 85),
            New KeyValuePair(Of String, Integer)(DateTime.Now.AddMonths(6), 55)}

        LOAD_CIRCULOS()

    End Sub

    Public Sub LOAD_CIRCULOS()
        'Dim Lst As List(Of PL)
        'Lst.Add(New PL With {.Nombre = "azucar", .valor = "15%"})


        Dim Lst2 As New List(Of CIRCO)
        Lst2.Add(New CIRCO With {.NP = "azucar", .Col = "red"})

    End Sub



End Class

Public Class FinancialStuff
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Amount() As Integer
        Get
            Return m_Amount
        End Get
        Set
            m_Amount = Value
        End Set
    End Property
    Private m_Amount As Integer







End Class


Class CIRCO
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

Class PL
    Public Property Nombre() As String
        Get
            Return m_Nombre
        End Get
        Set
            m_Nombre = Value
        End Set
    End Property
    Private m_Nombre As String
    Public Property valor() As String
        Get
            Return m_valor
        End Get
        Set
            m_valor = Value
        End Set
    End Property
    Private m_valor As String
    Public Property Ima() As Image
        Get
            Return m_Ima
        End Get
        Set
            m_Ima = Value
        End Set
    End Property
    Private m_Ima As Image
End Class