Imports Prueba1.VAR_GLOBALES
Public Class AYUDA

    Public Shared Sub LimpiarJson(json As String, funcion As String, TABLA As String)
        Dim JsonOK As String() = Nothing

        Dim jsonlimpio As String

        jsonlimpio = json


        jsonlimpio = jsonlimpio.Replace(""":""", """ç""")
        jsonlimpio = jsonlimpio.Replace(""",""", """ç""")

        jsonlimpio = jsonlimpio.Replace("""", "")

        jsonlimpio = jsonlimpio.Replace("{datos:{" & funcion & ":", "")
        jsonlimpio = jsonlimpio.Replace("}}", "")
        jsonlimpio = jsonlimpio.Replace("[", "")
        jsonlimpio = jsonlimpio.Replace("]", "")
        jsonlimpio = jsonlimpio.Replace("},{", "@")
        jsonlimpio = jsonlimpio.Replace("{", "")
        jsonlimpio = jsonlimpio.Replace("}", "")

        JsonOK = jsonlimpio.Split("@")

        For i = 0 To JsonOK.Count - 1
            CrearInsert(JsonOK(i), TABLA)
        Next



    End Sub



    Public Shared Sub CrearInsert(Valores As String, Tabla As String)

        Dim ARRi As String()
        Dim INSERT_BBDD As String
        Dim CAMPOS As String = ""
        Dim VAL_CAMPOS As String = ""


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
            Else
                VAL_CAMPOS = VAL_CAMPOS & " , '" & ARRi(i) & "'"
            End If
        Next


        INSERT_BBDD = "INSERT INTO " & Tabla & "(" & CAMPOS & ") VALUES(" & VAL_CAMPOS & ")"
        conn.Execute(INSERT_BBDD)

    End Sub

End Class
