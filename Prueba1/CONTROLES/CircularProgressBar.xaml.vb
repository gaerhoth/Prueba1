Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Data
'Imports Windows.System.Windows.Documents
Imports Windows.UI.Xaml.Documents
Imports System.Windows.Input
'Imports System.Windows.Media
Imports Windows.UI.Xaml.Media
'Imports System.Windows.Media.Imaging
Imports Windows.UI.Xaml.Media.Imaging
'Imports System.Windows.Navigation
Imports Windows.UI.Xaml.Navigation
'Imports System.Windows.Shapes
Imports Windows.UI.Xaml.Shapes
'Imports System.Windows.Markup
Imports Windows.UI.Xaml.Markup


Namespace DesignInControl
    ''' <summary>
    ''' Interaction logic for CircularProgressBar.xaml
    ''' </summary>
    Partial Public Class CircularProgressBar
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
            Angle = (Percentage * 360) / 100
            RenderArc()
        End Sub

        Public Property Radius() As Integer
            Get
                Return CInt(GetValue(RadiusProperty))
            End Get
            Set(value As Integer)
                SetValue(RadiusProperty, value)
            End Set
        End Property

        Public Property SegmentColor() As Brush
            Get
                Return DirectCast(GetValue(SegmentColorProperty), Brush)
            End Get
            Set(value As Brush)
                SetValue(SegmentColorProperty, value)
            End Set
        End Property

        Public Property StrokeThickness() As Integer
            Get
                Return CInt(GetValue(StrokeThicknessProperty))
            End Get
            Set(value As Integer)
                SetValue(StrokeThicknessProperty, value)
            End Set
        End Property

        Public Property Percentage() As Double
            Get
                Return CDbl(GetValue(PercentageProperty))
            End Get
            Set(value As Double)
                SetValue(PercentageProperty, value)
            End Set
        End Property

        Public Property Angle() As Double
            Get
                Return CDbl(GetValue(AngleProperty))
            End Get
            Set(value As Double)
                SetValue(AngleProperty, value)
            End Set
        End Property

        ' Using a DependencyProperty as the backing store for Percentage.  This enables animation, styling, binding, etc...
        Public Shared ReadOnly PercentageProperty As DependencyProperty = DependencyProperty.Register("Percentage", GetType(Double), GetType(CircularProgressBar), New PropertyMetadata(65.0, New PropertyChangedCallback(AddressOf OnPercentageChanged)))

        ' Using a DependencyProperty as the backing store for StrokeThickness.  This enables animation, styling, binding, etc...
        Public Shared ReadOnly StrokeThicknessProperty As DependencyProperty = DependencyProperty.Register("StrokeThickness", GetType(Integer), GetType(CircularProgressBar), New PropertyMetadata(5))

        ' Using a DependencyProperty as the backing store for SegmentColor.  This enables animation, styling, binding, etc...
        Public Shared ReadOnly SegmentColorProperty As DependencyProperty = DependencyProperty.Register("SegmentColor", GetType(Brush), GetType(CircularProgressBar), New PropertyMetadata(New SolidColorBrush(Windows.UI.Colors.Red)))

        ' Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        Public Shared ReadOnly RadiusProperty As DependencyProperty = DependencyProperty.Register("Radius", GetType(Integer), GetType(CircularProgressBar), New PropertyMetadata(25, New PropertyChangedCallback(AddressOf OnPropertyChanged)))

        ' Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        Public Shared ReadOnly AngleProperty As DependencyProperty = DependencyProperty.Register("Angle", GetType(Double), GetType(CircularProgressBar), New PropertyMetadata(120.0, New PropertyChangedCallback(AddressOf OnPropertyChanged)))

        Private Shared Sub OnPercentageChanged(sender As DependencyObject, args As DependencyPropertyChangedEventArgs)
            Dim circle As CircularProgressBar = TryCast(sender, CircularProgressBar)
            circle.Angle = (circle.Percentage * 360) / 100
        End Sub

        Private Shared Sub OnPropertyChanged(sender As DependencyObject, args As DependencyPropertyChangedEventArgs)
            Dim circle As CircularProgressBar = TryCast(sender, CircularProgressBar)
            circle.RenderArc()
        End Sub

        Public Sub RenderArc()

            Dim startPoint As New Point(Radius, 0)
            Dim endPoint As Point = ComputeCartesianCoordinate(Angle, Radius)
            endPoint.X += Radius
            endPoint.Y += Radius

            pathRoot.Width = Radius * 2 + StrokeThickness
            pathRoot.Height = Radius * 2 + StrokeThickness
            pathRoot.Margin = New Thickness(StrokeThickness, StrokeThickness, 0, 0)

            Dim largeArc As Boolean = Angle > 180.0

            Dim outerArcSize As New Size(Radius, Radius)

            PathFigure.StartPoint = startPoint

            If startPoint.X = Math.Round(endPoint.X) AndAlso startPoint.Y = Math.Round(endPoint.Y) Then
                endPoint.X -= 0.01
            End If

            ArcSegment.Point = endPoint
            ArcSegment.Size = outerArcSize
            ArcSegment.IsLargeArc = largeArc
        End Sub

        Private Function ComputeCartesianCoordinate(angle As Double, radius As Double) As Point
            ' convert to radians
            Dim angleRad As Double = (Math.PI / 180.0) * (angle - 90)

            Dim x As Double = radius * Math.Cos(angleRad)
            Dim y As Double = radius * Math.Sin(angleRad)

            Return New Point(x, y)
        End Function
    End Class
End Namespace

