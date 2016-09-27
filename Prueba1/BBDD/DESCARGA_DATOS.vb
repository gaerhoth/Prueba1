Imports Prueba1.VAR_GLOBALES
Imports Prueba1.AYUDA
Public Class DESCARGA_DATOS

    Public Shared Async Function DESCARGA_MAESTROS(ULT_CONEX As String) As Task(Of String)
        Dim respuesta As Object
        'deshacemos el json
        'grabamos 
        'limipamos respuesta



        Dim a As WS_WAH_PRODUCCION.DameTiposAguaResponse
        'Agua
        a = Await C_WAH.DameTiposAguaAsync(ULT_CONEX, 1)
        LimpiarJson(a.Body.DameTiposAguaResult, "DameTiposAgua", "TTIPOAGUA")

        ' LimpiarJson(DirectCast(a.Body.DameTiposAguaResult, Prueba1.WS_WAH_PRODUCCION.DameTiposAguaResponse).Body.DameTiposAguaResult, "DameTiposAgua", "TTIPOAGUA")
        respuesta = Nothing

        'Ejercicio
        respuesta = Await C_WAH.DameTiposEjerAsync(ULT_CONEX, 1)
        LimpiarJson(DirectCast(respuesta, Prueba1.WS_WAH_PRODUCCION.DameTiposEjerResponse).Body.DameTiposEjerResult, "DameTiposEjer", "TTIPOEJER")
        respuesta = Nothing


        'Tabaco
        respuesta = Await C_WAH.DameTiposTabacoAsync(ULT_CONEX, 1)
        LimpiarJson(DirectCast(respuesta, Prueba1.WS_WAH_PRODUCCION.DameTiposTabacoResponse).Body.DameTiposTabacoResult, "DameTiposTabaco", "TTIPOTABACO")
        respuesta = Nothing


        'Alimentacion
        respuesta = Await C_WAH.DameTiposAlimentaAsync(ULT_CONEX, 1)
        LimpiarJson(DirectCast(respuesta, Prueba1.WS_WAH_PRODUCCION.DameTiposAlimentaResponse).Body.DameTiposAlimentaResult, "DameTiposAlimenta", "TTIPOALIMENTA")
        respuesta = Nothing

        'Cafe
        respuesta = Await C_WAH.DameTiposCafeAsync(ULT_CONEX, 1)
        LimpiarJson(DirectCast(respuesta, Prueba1.WS_WAH_PRODUCCION.DameTiposCafeResponse).Body.DameTiposCafeResult, "DameTiposCafe", "TTIPOCAFE")
        respuesta = Nothing



        'Sueño
        respuesta = Await C_WAH.DameTiposSuenoAsync(ULT_CONEX, 1)
        LimpiarJson(DirectCast(respuesta, Prueba1.WS_WAH_PRODUCCION.DameTiposSuenoResponse).Body.DameTiposSuenoResult, "DameTiposSueño", "TTIPOSUENO")
        respuesta = Nothing


        'Alcohol
        respuesta = Await C_WAH.DameTiposAlcoholAsync(ULT_CONEX, 1)
        LimpiarJson(DirectCast(respuesta, Prueba1.WS_WAH_PRODUCCION.DameTiposAlcoholResponse).Body.DameTiposAlcoholResult, "DameTiposAlcohol", "TTIPOALCOHOL")
        respuesta = Nothing



        'colores
        Dim Rcolor As WS_WAH_PRODUCCION.DameColorResponse
        Rcolor = Await C_WAH.DameColorAsync(ULT_CONEX)
        LimpiarJson(Rcolor.Body.DameColorResult, "DameColor", "TCOLOR")
        respuesta = Nothing


        Dim RPrueba As WS_WAH_PRODUCCION.DamePruebaResponse
        RPrueba = Await C_WAH.DamePruebaAsync(ULT_CONEX, "V")
        LimpiarJson(RPrueba.Body.DamePruebaResult, "DamePrueba", "TPRUEBA")
        respuesta = Nothing



        conn.Execute("UPDATE TCONSTANT SET VAL_CONSTANTE ='" & Date.Now.ToString.Substring(0, 10) & "' WHERE DES_CONSTANTE= 'FEC_ULT_CONEX'")



        Return ""
    End Function

    Public Shared Async Function WaitAsynchronouslyAsync() As Task(Of String)
        Await Task.Delay(10000)
        Return "Finished"
    End Function

End Class
