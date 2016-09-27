Public Class VAR_GLOBALES
    'Public Shared SEGURIDAD As WS_SEGURIDAD.WS_SeguridadSoap
    'Public Shared SPFM As WS_SPFM.WS_SPFMSoap
    'Public Shared WAH As WS_WAH.WebService1Soap
    'Public Shared PHONE As WS_SMARTPHONE.SmartphoneSoap

    'RESPUESTAS COMUNES
    '-----------------------------------------------------------------------------------------------------------------------------------------

    Public Shared LS As List(Of TCALSENTIDOS) = Nothing
    Public Shared LM As List(Of TCALMETAS) = Nothing
    Public Shared LA As List(Of TCALACTIVIDAD) = Nothing
    Public Shared LC As List(Of TCALCARDIO) = Nothing
    Public Shared LH As List(Of TCALHABITOS) = Nothing
    Public Shared LP As List(Of TCALPULMONAR) = Nothing

    Public Shared LSR As List(Of TRESSENTIDOS) = Nothing
    Public Shared LMR As List(Of TRESMETAS) = Nothing
    Public Shared LAR As List(Of TRESACTIVIDAD) = Nothing
    Public Shared LCR As List(Of TRESCARDIO) = Nothing
    Public Shared LHR As List(Of TRESHABITOS) = Nothing
    Public Shared LPR As List(Of TRESPULMONAR) = Nothing

    '---------------------
    'Colores
    Public Shared listaColores As List(Of TCOLOR) = Nothing
    Public Shared Color As Integer()
    'Public Shared Col_1 As Integer() = Nothing
    'Public Shared Col_2 As Integer() = Nothing
    'Public Shared Col_3 As Integer() = Nothing
    'Public Shared Col_4 As Integer() = Nothing
    'Public Shared Col_5 As Integer() = Nothing
    'Public Shared Col_6 As Integer() = Nothing
    'Public Shared Col_7 As Integer() = Nothing
    'Public Shared Col_8 As Integer() = Nothing
    'Public Shared Col_9 As Integer() = Nothing
    'Public Shared Col_10 As Integer() = Nothing
    'Public Shared Col_11 As Integer() = Nothing
    'Public Shared Col_12 As Integer() = Nothing
    'Public Shared Col_13 As Integer() = Nothing
    'Public Shared Col_14 As Integer() = Nothing
    'Public Shared Col_15 As Integer() = Nothing



    Public Shared MaxActividad As Decimal
    Public Shared MaxMeta As Decimal
    Public Shared MaxHabitos As Decimal
    Public Shared MaxPulmonar As Decimal
    Public Shared MaxCardio As Decimal
    Public Shared MaxSentidos As Decimal


    Public Shared R_IRH As WS_WAH_PRODUCCION.IRHResponse = Nothing
    Public Shared R_IRM As WS_WAH_PRODUCCION.IRMResponse = Nothing
    Public Shared R_IRA As WS_WAH_PRODUCCION.IRAResponse = Nothing
    Public Shared R_IRS As WS_WAH_PRODUCCION.IRSResponse = Nothing
    Public Shared R_IRP As WS_WAH_PRODUCCION.IRPResponse = Nothing
    Public Shared R_IRC As WS_WAH_PRODUCCION.IRCResponse = Nothing

    Public Shared RES_CARIDIO As WS_WAH_PRODUCCION.DameResCardiosResponse = Nothing
    Public Shared RES_HABITOS As WS_WAH_PRODUCCION.DameResHabitosResponse = Nothing
    Public Shared RES_META As WS_WAH_PRODUCCION.DameResMetasResponse = Nothing
    Public Shared RES_ACTIVIDAD As WS_WAH_PRODUCCION.DameResActividadesResponse = Nothing
    Public Shared RES_SENTIDOS As WS_WAH_PRODUCCION.DameResSentidosResponse = Nothing
    Public Shared RES_PULMONAR As WS_WAH_PRODUCCION.DameResPulmonaresResponse = Nothing

    Public Shared CAL_CARIDIO As WS_WAH_PRODUCCION.DameCalCardiosResponse = Nothing
    Public Shared CAL_HABITOS As WS_WAH_PRODUCCION.DameCalHabitosResponse = Nothing
    Public Shared CAL_META As WS_WAH_PRODUCCION.DameCalMetasResponse = Nothing
    Public Shared CAL_ACTIVIDAD As WS_WAH_PRODUCCION.DameCalActividadesResponse = Nothing
    Public Shared CAL_SENTIDOS As WS_WAH_PRODUCCION.DameCalSentidosResponse = Nothing
    Public Shared CAL_PULMONAR As WS_WAH_PRODUCCION.DameCalPulmonaresResponse = Nothing

    '-----------------------------------------------------------------------------------------------------------------------------------------
    Public Shared IND_ENVIADO = "N"
    Public Shared USU_ALTA As String = "WINDOWS"
    Public Shared CH_S As String = "S"
    Public Shared CH_N As String = "N"

    Public Shared DEFAULT_ALC As Integer = 8
    Public Shared DEFAULT_CAFE As Integer = 5
    Public Shared DEFAULT_TAB As Integer = 12
    Public Shared DEFAULT_ALM As Integer = 9
    Public Shared DEFAULT_SUENO As Integer = 6
    Public Shared DEFAULT_EJER As Integer = 7


    'Produccion
    Public Shared C_SEGURIDAD As New WS_SEGURIDAD_PRODUCCION.WS_SeguridadSoapClient
    Public Shared C_SPFM As New WS_SPFM_PRODUCCION.WS_SPFMSoapClient
    Public Shared C_WAH As New WS_WAH_PRODUCCION.WebService1SoapClient
    Public Shared C_PHONE As New WS_SMARTPHONE.SmartphoneSoapClient

    'Mantenimiento
    ' Public Shared C_SEGURIDAD As New WS_SEGURIDAD_MANTENIMIENTO.WS_SeguridadSoapClient
    ' Public Shared C_SPFM As New WS_SPFM_MANTENIMIENTO.WS_SPFMSoapClient
    'Public Shared C_WAH As New WS_WAH.WebService1SoapClient
    'Public Shared C_PHONE As New WS_SMARTPHONE.SmartphoneSoapClient

    Public Shared conn As SQLite.Net.SQLiteConnection


    Public Shared Function CalculaNIF(sDNI As String) As String
        'Revisamos que el DNI es correcto.  
        Try


            Dim miNIE As String
            Dim miDNI As String
            Dim NIEsinletra As String
            Dim NIFsinletra As String
            Dim mivar, mivar1 As Integer

            miNIE = LEFT(sDNI, 1)
            mivar1 = Strings.AscW(miNIE)
            miDNI = RIGHT(sDNI, 1)
            mivar = Strings.AscW((miDNI))
            NIEsinletra = LEFT(sDNI, 8)
            NIFsinletra = LEFT(sDNI, 8)

            If mivar1 > 47 And mivar < 58 Then 'Si el primer caracter es un número 
                'Si el último carácter no es una letra  
                CalculaNIF = sDNI + letra_dni(NIEsinletra)
                'CalculaNIF = NIFsinletra + letra_dni(NIEsinletra)
            Else
                'Si el último carácter es una letra  
                If miDNI = letra_dni(NIEsinletra) Then
                    'Si el último carácter es una letra y la letra es correcta  
                    CalculaNIF = sDNI
                Else
                    'Si el último carácter es una letra y la letra no es correcta  
                    'MsgBox("La letra del DNI introducida es errónea. Debería ser " & letra_dni(NIEsinletra), vbInformation)

                    CalculaNIF = NIEsinletra + letra_dni(NIEsinletra)
                End If
            End If
            Return CalculaNIF
        Catch ex As Exception
            CalculaNIF = ""


        End Try
    End Function

    Public Shared Function letra_dni(DNI As String)
        Dim cadena As String = "TRWAGMYFPDXBNJZSQVHLCKE"


        Select Case LEFT(DNI, 1) 'Orden EHA/451/2008, de 20 de febrero  
            Case Is = "X"

                letra_dni = cadena.Substring(CInt((DNI.Replace("X", "0")) Mod 23), 1)
            Case Is = "Y"

                letra_dni = cadena.Substring(CInt((DNI.Replace("Y", "1")) Mod 23), 1)
            Case Is = "Z"

                letra_dni = cadena.Substring(CInt((DNI.Replace("Z", "2")) Mod 23), 1)
            Case Else

                letra_dni = cadena.Substring((CInt(DNI) Mod 23), 1)
        End Select

    End Function


    Public Shared Function LEFT(Dni As String, nume As Integer)
        Return Dni.Substring(0, Math.Min(Dni.Length, nume))
    End Function
    Public Shared Function RIGHT(Dni As String, nume As Integer)
        Return Dni.Substring(Dni.Length - 1, nume)
    End Function




    Private scenarios As New List(Of Scenario)() From {
        New Scenario() With {
            .Title = "Mi Salud",
            .ClassType = GetType(HOME)
        },
        New Scenario() With {
            .Title = "Citas",
            .ClassType = GetType(CITAS)
        },
        New Scenario() With {
            .Title = "Analíticas",
            .ClassType = GetType(ANALITICAS)
        },
        New Scenario() With {
            .Title = "Informes y Documentos",
            .ClassType = GetType(DOCUMENTOS)
        },
        New Scenario() With {
            .Title = "Recomendaciones y Consejos",
            .ClassType = GetType(RECOMENDACIONES)
        },
        New Scenario() With {
            .Title = "Objetivos",
            .ClassType = GetType(OBJ_CAMP)
        },
           New Scenario() With {
            .Title = "Campañas",
            .ClassType = GetType(OBJ_CAMP)
        },
           New Scenario() With {
            .Title = "Localizador de Centros",
            .ClassType = GetType(CENTROS)
        },
           New Scenario() With {
            .Title = "Información",
            .ClassType = GetType(INFO)
        }
    }

End Class

Public Class Scenario
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    Public Property ClassType() As Type
        Get
            Return m_ClassType
        End Get
        Set
            m_ClassType = Value
        End Set
    End Property
    Private m_ClassType As Type





End Class
