' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class GridVW
    Inherits Page

    Private Sub GridVW_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        For i = 0 To 10
            Me.LT.Items.Add(New CIRCO2 With
                      {.NP = "Nombre anónimo" & i.ToString,
                       .Col = "blue"
                      })
        Next

    End Sub
End Class
Class CIRCO3
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