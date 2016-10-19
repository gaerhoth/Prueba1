Imports Prueba1.VAR_GLOBALES
Imports System.Text
Imports System.Text.RegularExpressions
Imports Windows.UI.Xaml.Controls.Maps
Imports Windows.Devices.Geolocation
'Imports Windows.System.Runtime.CompilerServices.Extension
Public NotInheritable Class AYUDA
    Private Sub New()

    End Sub
    Public Shared Sub LimpiarJson(json As String, funcion As String, TABLA As String)
        Dim JsonOK As String() = Nothing

        If json <> "SIN CAMBIOS" Then

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


        INSERT_BBDD = "INSERT INTO " & Tabla & "(" & CAMPOS & ") VALUES(" & VAL_CAMPOS & ")"

        Try
            conn.Execute(INSERT_BBDD)
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

End Class



