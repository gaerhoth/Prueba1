﻿Imports Prueba1.VAR_GLOBALES
Imports System.Text
Imports System.Text.RegularExpressions
Imports Windows.UI.Xaml.Controls.Maps
Imports Windows.Devices.Geolocation
Imports Prueba1.IUD
'Imports Windows.System.Runtime.CompilerServices.Extension
Public NotInheritable Class AYUDA
    Private Sub New()

    End Sub
    Public Shared Sub LimpiarJson(json As String, funcion As String, TABLA As String)
        Dim JsonOK As String() = Nothing

        If funcion = "DameCampaña" Then
            json = json.Replace("Ñ", "N")
        End If


        If json <> "SIN CAMBIOS" Then

            If TABLA = "TRECOMENDACIONES" Then
                While json.IndexOf("<body>") <> -1
                    Dim aux1 As String = ""
                    Dim aux2 As String = ""
                    Dim aux3 As String = ""
                    aux1 = json.Substring(json.IndexOf("<body>"))
                'En aux2 tendria lo que es el html
                aux2 = aux1.Substring(0, aux1.IndexOf("</body>") + 7)
                    aux3 = aux2.Replace("body>", "body.>")
                    aux3 = aux3.Replace("""", "¨")
                json = json.Replace(aux2, aux3)
                End While
            End If

            Dim jsonlimpio As String
                jsonlimpio = json.Replace(""",""ID_COMUNICACION"":""0""", "")

                'jsonlimpio = json
                If funcion = "Delegaciones" Then
                    jsonlimpio = jsonlimpio.Replace("http://", "$$")
                End If

                jsonlimpio = jsonlimpio.Replace(""":""", """ç""")
                jsonlimpio = jsonlimpio.Replace(""",""", """ç""")

                jsonlimpio = jsonlimpio.Replace("""", "")

                If funcion = "Delegaciones" Then
                    jsonlimpio = jsonlimpio.Replace("{datos : [{", "")
                Else
                    jsonlimpio = jsonlimpio.Replace("{datos:{" & funcion & ":", "")
                End If

                jsonlimpio = jsonlimpio.Replace("}}", "")
                jsonlimpio = jsonlimpio.Replace("[", "")
                jsonlimpio = jsonlimpio.Replace("]", "")
                If funcion = "Delegaciones" Then
                    jsonlimpio = jsonlimpio.Replace("},{", "^")
                Else
                    jsonlimpio = jsonlimpio.Replace("},{", "@")
                End If
                jsonlimpio = jsonlimpio.Replace("{", "")
                jsonlimpio = jsonlimpio.Replace("}", "")

                If funcion = "Delegaciones" Then
                    JsonOK = jsonlimpio.Split("^")
                Else
                    JsonOK = jsonlimpio.Split("@")
                End If


                For i = 0 To JsonOK.Count - 1
                    If funcion = "Delegaciones" Then

                        JsonOK(i) = JsonOK(i).Replace(",", "ç")
                        JsonOK(i) = JsonOK(i).Replace(":", "ç")
                        JsonOK(i) = JsonOK(i).Replace("$$", "http://")
                    End If
                    CrearInsert(JsonOK(i), TABLA)
                Next


            End If
    End Sub



    Public Shared Sub CrearInsert(Valores As String, Tabla As String)

        Dim ARRi As String()
        Dim INSERT_BBDD As String
        Dim CAMPOS As String = ""
        Dim VAL_CAMPOS As String = ""

        Dim stotal As Object = Nothing

        Dim rec As String = ""
        Dim ana As String = ""

        ARRi = Valores.Split("ç")


        For i = 0 To ARRi.Count - 1 Step 2
            If i = 0 Then
                CAMPOS = ARRi(i)
            Else
                CAMPOS = CAMPOS & " , " & ARRi(i)
            End If
        Next
        For i = 1 To ARRi.Count - 1 Step 2
            If i = 1 Then
                VAL_CAMPOS = "'" & ARRi(i) & "'"

                rec = ARRi(5)

            Else
                VAL_CAMPOS = VAL_CAMPOS & " , '" & ARRi(i) & "'"

                ana = ARRi(7)

            End If
        Next

        'For i = 0 To ARRi.Count - 1

        '    If i = 0 Then
        '        stotal = "{." & ARRi(i) & " = '" & ARRi(i + 1) & "', "
        '        i = i + 1
        '    ElseIf i + 1 <> ARRi.Count - 1 Then
        '        stotal = stotal & "." & ARRi(i) & " = '" & ARRi(i + 1) & "', "
        '            i = i + 1
        '        Else
        '            stotal = stotal & "." & ARRi(i) & " = '" & ARRi(i + 1) & "'} "
        '            i = i + 1
        '        End If
        'Next


        INSERT_BBDD = "INSERT INTO " & Tabla & "(" & CAMPOS & ") VALUES(" & VAL_CAMPOS & ")"

        Try

            Select Case Tabla
                Case "TDOCUMENTOS2"
                    G_TDOCUMENTOS2(ARRi)
                Case "TRECOMENDACIONES"
                    G_RECOMENDACIONES(ARRi)
                Case "TTIPOCAFE"
                    G_TTIPOCAFE(ARRi)
                Case "TTIPOSUENO"
                    G_TTIPOSUENO(ARRi)
                Case "TTIPOEJER"
                    G_TTIPOEJER(ARRi)
                Case "TTIPOALIMENTA"
                    G_TTIPOALIMENTA(ARRi)
                Case "TTIPOALCOHOL"
                    G_TTIPOALCOHOL(ARRi)
                Case "TTIPOTABACO"
                    G_TTIPOTABACO(ARRi)
                Case "TTIPOAGUA"
                    G_TTIPOAGUA(ARRi)
                Case "TCAMPANAS"
                    G_TCAMPANAS(ARRi)
                Case Else

                    conn.Execute(INSERT_BBDD)
            End Select




            'conn.Insert(New TAVISOS() With
            '{.COD_AVISO = "2718632",
            '.ID_TRABAJADOR = "0",
            ' .ID_TIPO_AVISO = "1",
            '.COD_CLAVE_ORIGEN = "5478792",
            '.FEC_ALTA = "10/06/2016 0:00:00",
            '.FEC_DESDE = "",
            ' .FEC_HASTA = "10/06/2017 0:00:00",
            '.IND_ENVIADO = "N",
            '.FEC_ENVIADO = "10/06/2016 0:00:00",
            '.FEC_BAJA = "",
            '.USUARIO_BAJA = "",
            '.USUARIO_ALTA = "01/01/2016",
            '.DES_TITULO = "",
            '.DES_TEXTO = "",
            '.DES_IMAGEN = "",
            '.DES_URL = "",
            '.IND_DESTACADO = ""})

            'stotal = stotal.Replace("'", """")

            '  Dim stotal2 As Object
            '  stotal2 = New TAVISOS() With {.COD_AVISO = "2718632", .ID_TRABAJADOR = "0", .ID_TIPO_AVISO = "1", .COD_CLAVE_ORIGEN = "5478792", .FEC_ALTA = "10/06/2016 0:00:00", .FEC_DESDE = "", .FEC_HASTA = "10/06/2017 0:00:00", .IND_ENVIADO = "N", .FEC_ENVIADO = "10/06/2016 0:00:00", .FEC_BAJA = "", .USUARIO_BAJA = "", .USUARIO_ALTA = "01/01/2016", .DES_TITULO = "", .DES_TEXTO = "", .DES_IMAGEN = "", .DES_URL = "", .IND_DESTACADO = ""}

            'G_TAVISOS()


            '  conn.Insert(stotal2)

        Catch ex As Exception

        End Try


        ' conn.Insert(New TTIPOCAFE() With {.ID_TIPO_CAFE = 50, .COD_IDIOMA = 1, .DES_CAFE = "á"})

    End Sub


    Public Shared Function JsonToDatos(json As String, funcion As String) As String()
        Dim JsonOK As String() = Nothing

        Dim jsonlimpio As String
        Dim J1 As String = ""
        Dim J2 As String = ""
        jsonlimpio = json


        jsonlimpio = jsonlimpio.Replace(""":""", """ç""")
        jsonlimpio = jsonlimpio.Replace(""",""", """ç""")

        jsonlimpio = jsonlimpio.Replace("""", "")
        J1 = jsonlimpio

        jsonlimpio = jsonlimpio.Replace("{datos:{" & funcion & ":", "")
        J2 = jsonlimpio

        If J1 = J2 Then
            jsonlimpio = jsonlimpio.Replace("{datos:{" & funcion & "ç", "")
        End If
        jsonlimpio = jsonlimpio.Replace("}}", "")
        jsonlimpio = jsonlimpio.Replace("[", "")
        jsonlimpio = jsonlimpio.Replace("]", "")
        jsonlimpio = jsonlimpio.Replace("},{", "@")
        jsonlimpio = jsonlimpio.Replace("{", "")
        jsonlimpio = jsonlimpio.Replace("}", "")

        JsonOK = jsonlimpio.Split("@")
        JsonOK = jsonlimpio.Split("ç")
        Return JsonOK


    End Function


    Public Shared Sub Mostrar(Gr As Grid, Pr As ProgressBar, Pa As Page)

        Gr.Visibility = Visibility.Visible
        Pr.Visibility = Visibility.Visible
        '  Pa.IsHitTestVisible = False


    End Sub

    Public Shared Sub Ocualtar(Gr As Grid, Pr As ProgressBar, Pa As Page)
        Gr.Visibility = Visibility.Collapsed
        Pr.Visibility = Visibility.Collapsed
        '  Pa.IsHitTestVisible = True

    End Sub

    Public Shared Sub Mostrar2(Gr As Grid, Pr As ProgressBar, Pa As Page, sp As SplitView)

        Gr.Visibility = Visibility.Visible
        Pr.Visibility = Visibility.Visible
        '  Pa.IsHitTestVisible = False
        sp.Visibility = Visibility.Visible

    End Sub
    Public Shared Sub Ocualtar2(Gr As Grid, Pr As ProgressBar, Pa As Page, sp As SplitView)
        Gr.Visibility = Visibility.Collapsed
        Pr.Visibility = Visibility.Collapsed
        '  Pa.IsHitTestVisible = True
        sp.Visibility = Visibility.Collapsed

    End Sub

    Public Shared Function CreaColores(COD_COLOR As String) As String()
        Dim Col As String
        Dim ArrCol As String()
        Col = COD_COLOR.Replace("(", "")
        Col = Col.Replace(")", "")
        ArrCol = Col.Split(",")

        'For i = 0 To ArrCol.Count - 1
        '    Color(i) = CInt(ArrCol(i).Trim)
        'Next

        'Colo2(0) = CInt(ArrCol(0).Trim)
        'Colo2(1) = CInt(ArrCol(1).Trim)
        'Colo2(2) = CInt(ArrCol(2).Trim)

        Return ArrCol
    End Function






End Class

'Clase para cargar la listview de recomendaciones
Class CLASERECOM
    Public Property TIT() As String
        Get
            Return m_TIT
        End Get
        Set
            m_TIT = Value
        End Set
    End Property
    Private m_TIT As String


    Public Property HTML() As String
        Get
            Return m_HTML
        End Get
        Set
            m_HTML = Value
        End Set
    End Property
    Private m_HTML As String

End Class

Class CLASECENTROS
    Public Property CNT() As String
        Get
            Return m_CNT
        End Get
        Set
            m_CNT = Value
        End Set
    End Property
    Private m_CNT As String

    Public Property DAT() As String
        Get
            Return m_DAT
        End Get
        Set
            m_DAT = Value
        End Set
    End Property
    Private m_DAT As String

    Public Property IMAG() As String
        Get
            Return m_IMAG
        End Get
        Set
            m_IMAG = Value
        End Set
    End Property
    Private m_IMAG As String

    Public Property LON() As Decimal
        Get
            Return m_LON
        End Get
        Set
            m_LON = Value
        End Set
    End Property
    Private m_LON As Decimal


    Public Property LAT() As Decimal
        Get
            Return m_LAT
        End Get
        Set
            m_LAT = Value
        End Set
    End Property
    Private m_LAT As Decimal
End Class


Class CLASEOBJCAMP

    Public Property IMAG() As String
        Get
            Return m_IMAG
        End Get
        Set
            m_IMAG = Value
        End Set
    End Property
    Private m_IMAG As String
    Public Property EST() As String
        Get
            Return m_EST
        End Get
        Set
            m_EST = Value
        End Set
    End Property
    Private m_EST As String

    Public Property TEXTO() As String
        Get
            Return m_TEXTO
        End Get
        Set
            m_TEXTO = Value
        End Set
    End Property
    Private m_TEXTO As String

    Public Property MHTML() As String
        Get
            Return m_MHTML
        End Get
        Set
            m_MHTML = Value
        End Set
    End Property
    Private m_MHTML As String
    Public Property HTML() As String
        Get
            Return m_HTML
        End Get
        Set
            m_HTML = Value
        End Set
    End Property
    Private m_HTML As String

End Class
