Imports Prueba1.VAR_GLOBALES
Public Class IUD

    'Public Shared Sub G_TAVISOS()

    '    conn.Insert(New TAVISOS() With {.COD_AVISO = "2718632",
    '                 .ID_TRABAJADOR = "0",
    '                 .ID_TIPO_AVISO = "1",
    '                 .COD_CLAVE_ORIGEN = "5478792",
    '                 .FEC_ALTA = "10/06/2016 0:00:00",
    '                 .FEC_DESDE = "",
    '                 .FEC_HASTA = "10/06/2017 0:00:00",
    '                 .IND_ENVIADO = "N", .FEC_ENVIADO = "10/06/2016 0:00:00",
    '                .FEC_BAJA = "", .USUARIO_BAJA = "",
    '                .USUARIO_ALTA = "01/01/2016",
    '                .DES_TITULO = "", .DES_TEXTO = "",
    '                .DES_IMAGEN = "",
    '                .DES_URL = "",
    '                .IND_DESTACADO = ""}

    'End Sub


    Public Shared Sub G_RECOMENDACIONES(ARRi() As String)

        Dim COD_RECOMENDACION As String = ""
        Dim ID_TRABAJADOR As String = ""
        Dim ID_TTIPORECOM As String = ""
        Dim DES_TIPO_RECOM As String = ""
        Dim COD_CLAVE_ORIGEN As String = ""
        Dim FEC_ALTA As String = ""
        Dim COD_PAGINA_ESTANDAR As String = ""
        Dim COD_PAGINA_PARTICULAR As String = ""
        Dim FEC_DESDE As String = ""
        Dim FEC_HASTA As String = ""
        Dim IND_ENVIADO As String = ""
        Dim FEC_ENVIADO As String = ""
        Dim FEC_BAJA As String = ""
        Dim USUARIO_BAJA As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim DES_PAGINA_ESTANDAR As String = ""

        For i = 0 To ARRi.Count - 1
            'ARRi(i) = ARRi(i + 1)

            If ARRi(i) = "COD_RECOMENDACION" Then COD_RECOMENDACION = ARRi(i + 1)
            If ARRi(i) = "ID_TRABAJADOR" Then ID_TRABAJADOR = ARRi(i + 1)
            If ARRi(i) = "ID_TTIPORECOM" Then ID_TTIPORECOM = ARRi(i + 1)
            If ARRi(i) = "DES_TIPO_RECOM" Then DES_TIPO_RECOM = ARRi(i + 1)
            If ARRi(i) = "COD_CLAVE_ORIGEN" Then COD_CLAVE_ORIGEN = ARRi(i + 1)
            If ARRi(i) = "FEC_ALTA" Then FEC_ALTA = ARRi(i + 1)
            If ARRi(i) = "COD_PAGINA_ESTANDAR" Then COD_PAGINA_ESTANDAR = ARRi(i + 1)
            If ARRi(i) = "COD_PAGINA_PARTICULAR" Then COD_PAGINA_PARTICULAR = ARRi(i + 1)
            If ARRi(i) = "FEC_DESDE" Then FEC_DESDE = ARRi(i + 1)
            If ARRi(i) = "FEC_HASTA" Then FEC_HASTA = ARRi(i + 1)
            If ARRi(i) = "IND_ENVIADO" Then IND_ENVIADO = ARRi(i + 1)
            If ARRi(i) = "FEC_ENVIADO" Then FEC_ENVIADO = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA" Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA" Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "DES_PAGINA_ESTANDAR" Then DES_PAGINA_ESTANDAR = ARRi(i + 1)

            i = i + 1
        Next

        DES_PAGINA_ESTANDAR = DES_PAGINA_ESTANDAR.Replace("¨", """")
        DES_PAGINA_ESTANDAR = DES_PAGINA_ESTANDAR.Replace("body.>", "body>")


        conn.Insert(New TRECOMENDACIONES() With {
         .COD_RECOMENDACION = COD_RECOMENDACION,
        .ID_TRABAJADOR = ID_TRABAJADOR,
        .ID_TTIPORECOM = ID_TTIPORECOM,
        .DES_TIPO_RECOM = DES_TIPO_RECOM,
        .COD_CLAVE_ORIGEN = COD_CLAVE_ORIGEN,
        .FEC_ALTA = FEC_ALTA,
        .COD_PAGINA_ESTANDAR = COD_PAGINA_ESTANDAR,
        .COD_PAGINA_PARTICULAR = COD_PAGINA_PARTICULAR,
        .FEC_DESDE = FEC_DESDE,
        .FEC_HASTA = FEC_HASTA,
        .IND_ENVIADO = IND_ENVIADO,
        .FEC_ENVIADO = FEC_ENVIADO,
        .FEC_BAJA = FEC_BAJA,
        .USUARIO_BAJA = USUARIO_BAJA,
        .USUARIO_ALTA = USUARIO_ALTA,
        .DES_PAGINA_ESTANDAR = DES_PAGINA_ESTANDAR
        })
    End Sub



    Public Shared Sub G_TTIPOEJER(ARRi() As String)


        Dim ID_TIPO_EJERCICI As String = ""

        Dim COD_IDIOMA As String = ""

        Dim DES_EJERCICI As String = ""

        Dim FEC_ALTA As String = ""

        Dim FEC_BAJA As String = ""

        Dim NUM_ORDEN As String = ""

        Dim USUARIO_ALTA As String = ""

        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1


            If ARRi(i) = "ID_TIPO_EJERCICI" Then ID_TIPO_EJERCICI = ARRi(i + 1)

            If ARRi(i) = "COD_IDIOMA" Then COD_IDIOMA = ARRi(i + 1)

            If ARRi(i) = " DES_EJERCICI" Then DES_EJERCICI = ARRi(i + 1)

            If ARRi(i) = "FEC_ALTA" Then FEC_ALTA = ARRi(i + 1)

            If ARRi(i) = " FEC_BAJA" Then FEC_BAJA = ARRi(i + 1)

            If ARRi(i) = " NUM_ORDEN" Then NUM_ORDEN = ARRi(i + 1)

            If ARRi(i) = "USUARIO_ALTA" Then USUARIO_ALTA = ARRi(i + 1)

            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)

        Next

        conn.Insert(New TTIPOEJER() With
        {
.ID_TIPO_EJERCICI = ID_TIPO_EJERCICI,
.COD_IDIOMA = COD_IDIOMA,
.DES_EJERCICI = DES_EJERCICI,
.FEC_ALTA = FEC_ALTA,
.FEC_BAJA = FEC_BAJA,
.NUM_ORDEN = NUM_ORDEN,
.USUARIO_ALTA = USUARIO_ALTA,
.USUARIO_BAJA = USUARIO_BAJA
})

    End Sub



    Public Shared Sub G_TTIPOCAFE(ARRi() As String)

        Dim ID_TIPO_CAFE As String = ""
        Dim COD_IDIOMA As String = ""
        Dim DES_CAFE As String = ""
        Dim FEC_ALTA As String = ""
        Dim FEC_BAJA As String = ""
        Dim NUM_ORDEN As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "ID_TIPO_CAFE " Then ID_TIPO_CAFE = ARRi(i + 1)
            If ARRi(i) = "COD_IDIOMA " Then COD_IDIOMA = ARRi(i + 1)
            If ARRi(i) = "DES_CAFE " Then DES_CAFE = ARRi(i + 1)
            If ARRi(i) = "FEC_ALTA " Then FEC_ALTA = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA " Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "NUM_ORDEN " Then NUM_ORDEN = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA " Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
        Next

        conn.Insert(New TTIPOCAFE() With {
        .ID_TIPO_CAFE = ID_TIPO_CAFE,
        .COD_IDIOMA = COD_IDIOMA,
        .DES_CAFE = DES_CAFE,
        .FEC_ALTA = FEC_ALTA,
        .FEC_BAJA = FEC_BAJA,
        .NUM_ORDEN = NUM_ORDEN,
        .USUARIO_ALTA = USUARIO_ALTA})
    End Sub



    Public Shared Sub G_TTIPOSUENO(ARRi() As String)

        Dim ID_TIPO_SUENO As String = ""
        Dim COD_IDIOMA As String = ""
        Dim DES_SUENO As String = ""
        Dim FEC_ALTA As String = ""
        Dim FEC_BAJA As String = ""
        Dim NUM_ORDEN As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "ID_TIPO_SUENO " Then ID_TIPO_SUENO = ARRi(i + 1)
            If ARRi(i) = "COD_IDIOMA " Then COD_IDIOMA = ARRi(i + 1)
            If ARRi(i) = "DES_SUENO " Then DES_SUENO = ARRi(i + 1)
            If ARRi(i) = "FEC_ALTA " Then FEC_ALTA = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA " Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "NUM_ORDEN " Then NUM_ORDEN = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA " Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
        Next

        conn.Insert(New TTIPOSUENO() With {
        .ID_TIPO_SUENO = ID_TIPO_SUENO,
        .COD_IDIOMA = COD_IDIOMA,
        .DES_SUENO = DES_SUENO,
        .FEC_ALTA = FEC_ALTA,
        .FEC_BAJA = FEC_BAJA,
        .NUM_ORDEN = NUM_ORDEN,
        .USUARIO_ALTA = USUARIO_ALTA,
        .USUARIO_BAJA = USUARIO_BAJA})
    End Sub

    Public Shared Sub G_TTIPOTABACO(ARRi() As String)

        Dim ID_TIPO_TABACO As String = ""
        Dim COD_IDIOMA As String = ""
        Dim DES_TABACO As String = ""
        Dim FEC_ALTA As String = ""
        Dim FEC_BAJA As String = ""
        Dim NUM_ORDEN As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "ID_TIPO_TABACO " Then ID_TIPO_TABACO = ARRi(i + 1)
            If ARRi(i) = "COD_IDIOMA " Then COD_IDIOMA = ARRi(i + 1)
            If ARRi(i) = "DES_TABACO " Then DES_TABACO = ARRi(i + 1)
            If ARRi(i) = "FEC_ALTA " Then FEC_ALTA = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA " Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "NUM_ORDEN " Then NUM_ORDEN = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA " Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
        Next

        conn.Insert(New TTIPOTABACO() With {
.ID_TIPO_TABACO = ID_TIPO_TABACO,
.COD_IDIOMA = COD_IDIOMA,
.DES_TABACO = DES_TABACO,
.FEC_ALTA = FEC_ALTA,
.FEC_BAJA = FEC_BAJA,
.NUM_ORDEN = NUM_ORDEN,
.USUARIO_ALTA = USUARIO_ALTA,
.USUARIO_BAJA = USUARIO_BAJA})
    End Sub

    Public Shared Sub G_TTIPOAGUA(ARRi() As String)

        Dim ID_TIPO_AGUA As String = ""
        Dim COD_IDIOMA As String = ""
        Dim DES_AGUA As String = ""
        Dim FEC_ALTA As String = ""
        Dim FEC_BAJA As String = ""
        Dim NUM_ORDEN As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "ID_TIPO_AGUA " Then ID_TIPO_AGUA = ARRi(i + 1)
            If ARRi(i) = "COD_IDIOMA " Then COD_IDIOMA = ARRi(i + 1)
            If ARRi(i) = "DES_AGUA " Then DES_AGUA = ARRi(i + 1)
            If ARRi(i) = "FEC_ALTA " Then FEC_ALTA = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA " Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "NUM_ORDEN " Then NUM_ORDEN = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA " Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
        Next

        conn.Insert(New TTIPOAGUA() With {
.ID_TIPO_AGUA = ID_TIPO_AGUA,
.COD_IDIOMA = COD_IDIOMA,
.DES_AGUA = DES_AGUA,
.FEC_ALTA = FEC_ALTA,
.FEC_BAJA = FEC_BAJA,
.NUM_ORDEN = NUM_ORDEN,
.USUARIO_ALTA = USUARIO_ALTA,
.USUARIO_BAJA = USUARIO_BAJA})
    End Sub

    Public Shared Sub G_TTIPOALCOHOL(ARRi() As String)

        Dim ID_TIPO_ALCOHOL As String = ""
        Dim COD_IDIOMA As String = ""
        Dim DES_ALCOHOL As String = ""
        Dim FEC_ALTA As String = ""
        Dim FEC_BAJA As String = ""
        Dim NUM_ORDEN As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "ID_TIPO_ALCOHOL " Then ID_TIPO_ALCOHOL = ARRi(i + 1)
            If ARRi(i) = "COD_IDIOMA " Then COD_IDIOMA = ARRi(i + 1)
            If ARRi(i) = "DES_ALCOHOL " Then DES_ALCOHOL = ARRi(i + 1)
            If ARRi(i) = "FEC_ALTA " Then FEC_ALTA = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA " Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "NUM_ORDEN " Then NUM_ORDEN = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA " Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
        Next

        conn.Insert(New TTIPOALCOHOL() With {
.ID_TIPO_ALCOHOL = ID_TIPO_ALCOHOL,
.COD_IDIOMA = COD_IDIOMA,
.DES_ALCOHOL = DES_ALCOHOL,
.FEC_ALTA = FEC_ALTA,
.FEC_BAJA = FEC_BAJA,
.NUM_ORDEN = NUM_ORDEN,
.USUARIO_ALTA = USUARIO_ALTA,
.USUARIO_BAJA = USUARIO_BAJA})
    End Sub

    Public Shared Sub G_TTIPOALIMENTA(ARRi() As String)

        Dim ID_TIPO_ALIMENTA As String = ""
        Dim COD_IDIOMA As String = ""
        Dim DES_ALIMENTA As String = ""
        Dim FEC_ALTA As String = ""
        Dim FEC_BAJA As String = ""
        Dim NUM_ORDEN As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "ID_TIPO_ALIMENTA " Then ID_TIPO_ALIMENTA = ARRi(i + 1)
            If ARRi(i) = "COD_IDIOMA " Then COD_IDIOMA = ARRi(i + 1)
            If ARRi(i) = "DES_ALIMENTA " Then DES_ALIMENTA = ARRi(i + 1)
            If ARRi(i) = "FEC_ALTA " Then FEC_ALTA = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA " Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "NUM_ORDEN " Then NUM_ORDEN = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA " Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
        Next

        conn.Insert(New TTIPOALIMENTA() With {
        .ID_TIPO_ALIMENTA = ID_TIPO_ALIMENTA,
        .COD_IDIOMA = COD_IDIOMA,
        .DES_ALIMENTA = DES_ALIMENTA,
        .FEC_ALTA = FEC_ALTA,
        .FEC_BAJA = FEC_BAJA,
        .NUM_ORDEN = NUM_ORDEN,
        .USUARIO_ALTA = USUARIO_ALTA,
        .USUARIO_BAJA = USUARIO_BAJA})
    End Sub


    Public Shared Sub G_TCAMPANAS(ARRi() As String)

        Dim COD_CAMPANA As String = ""
        Dim COD_ESTADO_CAMPANA As String = ""
        Dim FEC_FIN_CAMPANA As String = ""
        Dim IND_DESTACADO As String = ""
        Dim DES_HTML_MINIATURA As String = ""
        Dim DES_HTML As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "COD_CAMPANA " Then COD_CAMPANA = ARRi(i + 1)
            If ARRi(i) = "COD_ESTADO_CAMPANA " Then COD_ESTADO_CAMPANA = ARRi(i + 1)
            If ARRi(i) = "FEC_FIN_CAMPANA " Then FEC_FIN_CAMPANA = ARRi(i + 1)
            If ARRi(i) = "IND_DESTACADO " Then IND_DESTACADO = ARRi(i + 1)
            If ARRi(i) = "DES_HTML_MINIATURA " Then DES_HTML_MINIATURA = ARRi(i + 1)
            If ARRi(i) = "DES_HTML" Then DES_HTML = ARRi(i + 1)
        Next


        DES_HTML_MINIATURA = DES_HTML_MINIATURA.Replace("¨", """")
        DES_HTML_MINIATURA = DES_HTML_MINIATURA.Replace("body.>", "body>")
        DES_HTML = DES_HTML.Replace("¨", """")
        DES_HTML = DES_HTML.Replace("body.>", "body>")


        conn.Insert(New TCAMPANAS() With {
        .COD_CAMPANA = COD_CAMPANA,
        .COD_ESTADO_CAMPANA = COD_ESTADO_CAMPANA,
        .FEC_FIN_CAMPANA = FEC_FIN_CAMPANA,
        .IND_DESTACADO = IND_DESTACADO,
        .DES_HTML_MINIATURA = DES_HTML_MINIATURA,
        .DES_HTML = DES_HTML})
    End Sub


    Public Shared Sub G_TDOCUMENTOS2(ARRi() As String)

        Dim ID_DOCUMENTO As String = ""
        Dim ID_TRABAJADOR As String = ""
        Dim DOC_RECO_INFO As String = ""
        Dim DOC_ANALI_INFO As String = ""
        Dim FEC_DOC As String = ""
        Dim IND_ENVIADO As String = ""
        Dim COD_RECO As String = ""
        Dim FEC_BAJA As String = ""
        Dim USUARIO_ALTA As String = ""
        Dim USUARIO_BAJA As String = ""

        For i = 0 To ARRi.Count - 1
            If ARRi(i) = "ID_DOCUMENTO" Then ID_DOCUMENTO = ARRi(i + 1)
            If ARRi(i) = "ID_TRABAJADOR" Then ID_TRABAJADOR = ARRi(i + 1)
            If ARRi(i) = "DOC_RECO_INFO" Then DOC_RECO_INFO = ARRi(i + 1)
            If ARRi(i) = "DOC_ANALI_INFO" Then DOC_ANALI_INFO = ARRi(i + 1)
            If ARRi(i) = "FEC_DOC" Then FEC_DOC = ARRi(i + 1)
            If ARRi(i) = "IND_ENVIADO" Then IND_ENVIADO = ARRi(i + 1)
            If ARRi(i) = "COD_RECO" Then COD_RECO = ARRi(i + 1)
            If ARRi(i) = "FEC_BAJA" Then FEC_BAJA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_ALTA" Then USUARIO_ALTA = ARRi(i + 1)
            If ARRi(i) = "USUARIO_BAJA" Then USUARIO_BAJA = ARRi(i + 1)
        Next

        conn.Insert(New TDOCUMENTOS2() With {
        .ID_DOCUMENTO = ID_DOCUMENTO,
        .ID_TRABAJADOR = ID_TRABAJADOR,
        .DOC_RECO_INFO = DOC_RECO_INFO,
        .DOC_ANALI_INFO = DOC_ANALI_INFO,
        .FEC_DOC = FEC_DOC,
        .IND_ENVIADO = IND_ENVIADO,
        .COD_RECO = COD_RECO,
        .FEC_BAJA = FEC_BAJA,
        .USUARIO_ALTA = USUARIO_ALTA,
        .USUARIO_BAJA = USUARIO_BAJA})
    End Sub
End Class
