
Imports Windows.UI.Popups
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class DISEÑOSxaml
    Inherits Page

    Private Async Sub p1_Click(sender As Object, e As RoutedEventArgs) Handles p1.Click
        Dim mensaje As MessageDialog
        mensaje = New MessageDialog("Debe proporcionar un email valido")
        Await mensaje.ShowAsync()

        AYUDA.Ocualtar(GrLoad, customIndeterminateProgressBar, pagina)
    End Sub

    Private Sub p1_Copy_Click(sender As Object, e As RoutedEventArgs) Handles p1_Copy.Click
        'GrLoad.Visibility = Visibility.Visible
        'If customIndeterminateProgressBar.Visibility = Visibility.Collapsed Then
        '    customIndeterminateProgressBar.Visibility = Visibility.Visible
        '    'inhabilita la pagina 
        '    ' Me.pagina.IsHitTestVisible = False
        'Else
        '    customIndeterminateProgressBar.Visibility = Visibility.Collapsed
        '    GrLoad.Visibility = Visibility.Collapsed
        'End If
        AYUDA.Mostrar(GrLoad, customIndeterminateProgressBar, pagina)
    End Sub

    'Public Sub Mostrar(Gr As Grid, Pr As ProgressBar, Pa As Page)
    '    Gr.Visibility = Visibility.Visible
    '    Pr.Visibility = Visibility.Visible
    '    Pa.IsHitTestVisible = False
    'End Sub

    'Public Sub Ocualtar(Gr As Grid, Pr As ProgressBar, Pa As Page)
    '    Gr.Visibility = Visibility.Collapsed
    '    Pr.Visibility = Visibility.Collapsed
    '    Pa.IsHitTestVisible = True
    'End Sub

    'Private Sub toggleButton_Click(sender As Object, e As RoutedEventArgs) Handles toggleButton.Click
    '    Me.customIndeterminateProgressBar.IsIndeterminate = Not (customIndeterminateProgressBar.IsIndeterminate)

    '    If customIndeterminateProgressBar.Visibility = Visibility.Collapsed Then
    '        customIndeterminateProgressBar.Visibility = Visibility.Visible
    '    Else
    '        customIndeterminateProgressBar.Visibility = Visibility.Collapsed
    '    End If

    'End Sub





End Class
