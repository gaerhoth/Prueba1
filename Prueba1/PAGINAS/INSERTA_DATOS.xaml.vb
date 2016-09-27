' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class INSERTA_DATOS
    Inherits Page

    Private Sub INSERTA_DATOS_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        Me.calFecha.MinDate = "01/01/2016"
        Me.calFecha.MaxDate = Date.Now
        Me.calFecha.Date = Date.Now
    End Sub
End Class
