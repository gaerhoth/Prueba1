﻿' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class UNETE3
    Inherits Page

    Private Sub BTN_SIG_Click(sender As Object, e As RoutedEventArgs) Handles BTN_SIG.Click
        'sacamos el mensaje de que pronto recibira el correo con un boton que pone aceptar

        Me.Frame.Navigate(GetType(LOGIN1))
    End Sub
End Class