Imports System.ComponentModel.DataAnnotations.Schema
Imports SQLite.Net.Attributes

'EN ESTA CLASE ESTAN DEFINIDAS TODAS LAS TABLAS PARA LA CREACION DE LA BBDD
'EN EJEPLOS ESTAN HECHOS COMO SE PUEDEN DECLARAR PRIAMRY FOREING...
'LAS TABLAS SE CREAN CUANDO SE LANZA LA APP

#Region "EJEMPLOS"

Public Class TABLAS
    Public Shared TTIPOTABACO As String
    Public Shared TTIPOEJER As String
    Public Shared Sub CrearTablas()
        TTIPOTABACO = "CREATE TABLE TTIPOTABACO ( 
        ID_TIPO_TABACO Integer PRIMARY KEY AUTOINCREMENT,
        COD_IDIOMA INTEGER,
        DES_TABACO TEXT,
        FEC_ALTA DATE,
        NUM_ORDEN INTEGER)"


        TTIPOEJER = "CREATE TABLE TTIPOEJER( 
        ID_TIPO_EJERCICI TEXT PRIMARY KEY,
        COD_IDIOMA TEXT,
        DES_EJERCICI TEXT,
        FEC_ALTA DATE,
        FEC_BAJA DATE,
        NUM_ORDEN TEXT)"


    End Sub



End Class

Public Class Project
    <PrimaryKey, AutoIncrement>
    Public Property ProjectId() As Integer
        Get
            Return m_ProjectId
        End Get
        Set
            m_ProjectId = Value
        End Set
    End Property
    Private m_ProjectId As Integer

    <Unique, MaxLength(50)>
    Public Property ProjectName() As [String]
        Get
            Return m_ProjectName
        End Get
        Set
            m_ProjectName = Value
        End Set
    End Property
    Private m_ProjectName As [String]

    <ForeignKey("TRESPULMONA_PROJECT")>
    Public Property ProjectCustomerId() As Integer
        Get
            Return m_ProjectCustomerId
        End Get
        Set
            m_ProjectCustomerId = Value
        End Set
    End Property
    Private m_ProjectCustomerId As Integer
End Class
#End Region

#Region "TABLAS BBDD"


Public Class TTIPOEJER
    <PrimaryKey>
    Public Property ID_TIPO_EJERCICI As String
    Public Property COD_IDIOMA As String
    Public Property DES_EJERCICI As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property NUM_ORDEN As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String


End Class
Public Class TTIPOCAFE
    <PrimaryKey>
    Public Property ID_TIPO_CAFE As String
    Public Property COD_IDIOMA As String
    Public Property DES_CAFE As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property NUM_ORDEN As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String

End Class
Public Class TTIPOSUENO
    <PrimaryKey>
    Public Property ID_TIPO_SUENO As String
    Public Property COD_IDIOMA As String
    Public Property DES_SUENO As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property NUM_ORDEN As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String

End Class
Public Class TTIPOALIMENTA
    <PrimaryKey>
    Public Property ID_TIPO_ALIMENTA As String
    Public Property COD_IDIOMA As String
    Public Property DES_ALIMENTA As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property NUM_ORDEN As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String

End Class
Public Class TTIPOALCOHOL
    <PrimaryKey>
    Public Property ID_TIPO_ALCOHOL As String
    Public Property COD_IDIOMA As String
    Public Property DES_ALCOHOL As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property NUM_ORDEN As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String

End Class
Public Class TTIPOAGUA
    <PrimaryKey>
    Public Property ID_TIPO_AGUA As String
    Public Property COD_IDIOMA As String
    Public Property DES_AGUA As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property NUM_ORDEN As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String

End Class
Public Class TTIPOTABACO
    <PrimaryKey>
    Public Property ID_TIPO_TABACO As String
    Public Property COD_IDIOMA As String
    Public Property DES_TABACO As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property NUM_ORDEN As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String

End Class

Public Class TUSUARIO
    <PrimaryKey>
    Public Property id_trabajador As String
    Public Property cod_trab_spa As String
    Public Property cod_identificador As String
    Public Property nom_trabajador As String
    Public Property fecha_nacimiento As String
    Public Property sexo As String
    Public Property ind_cambio_pend As String
    Public Property fec_alta As String
    Public Property usuario_alta As String
    Public Property num_cif As String
    Public Property des_razon_social As String
    Public Property des_email As String
    Public Property num_telefono As String
    Public Property blood_type As String
    Public Property emergency_name As String
    Public Property emergency_phone As String
    Public Property organ_donor As String
    Public Property share_salud As String
    Public Property active As String
    Public Property password As String
    Public Property cod_contrato As String
    Public Property ind_tutorial As String

End Class
Public Class TCOLOR
    <PrimaryKey>
    Public Property ID_COLOR As String
    Public Property DES_COLOR As String
    Public Property NOM_COLOR As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
End Class
Public Class TUNIDADES
    <PrimaryKey>
    Public Property COD_UNIDAD As String
    Public Property DES_UNIDAD As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
End Class
Public Class TIPORECOMENDACION
    <PrimaryKey>
    Public Property ID_TTIPORECOM As String
    Public Property COD_IDIOMA As String
    Public Property ID_GRUPORECOM As String
    Public Property ID_ORIGEN As String
    Public Property DES_TIPO_RECOM As String
    Public Property NUM_JERARQUIA As String
    Public Property COD_PAGINADESCRIPTIVAS As String
End Class
Public Class TIPOPRUEBA
    <PrimaryKey>
    Public Property ID_TIPO_PRUEBA As String
    Public Property DES_TIPO_PRUEBA As String
    Public Property ID_PRUEBA As String
    Public Property COD_IDIOMA As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
End Class
Public Class TTIPOCITA
    <PrimaryKey>
    Public Property COD_TIPO_CITA As String
    Public Property DES_CITA As String
    Public Property COD_IDIOMA As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property DES_URL_CITA As String
    Public Property IND_PUSH As String
End Class
Public Class TTIPOAVISO
    <PrimaryKey>
    Public Property ID_TIPO_AVISO As String
    Public Property DES_TIPO_AVISO As String
    Public Property COD_ORIGEN As String
    Public Property NUM_JERARQUIA As String
    Public Property IRAPP As String
End Class
Public Class THEXAGONO
    <PrimaryKey>
    Public Property ID_HEXAGONO As String
    Public Property ID_PRUEBA As String
    Public Property NUM_ORDEN As String
End Class
Public Class TPRUEBA
    <PrimaryKey>
    Public Property ID_PRUEBA As String
    Public Property COD_IDIOMA As String
    Public Property DES_PRUEBA As String
    Public Property COD_UNIDAD As String
    Public Property DES_UNIDAD As String
    Public Property CAN_MIN As String
    Public Property CAN_MAX As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property ID_TIPO_UNIDAD As String
    Public Property DES_TIPO_UNIDAD As String
    Public Property VAL_MAX As String
    Public Property COD_HK As String
    Public Property COD_FIT As String

End Class


Public Class TDOCUMENTOS2
    <PrimaryKey>
    Public Property ID_DOCUMENTO As String
    Public Property ID_TRABAJADOR As String
    Public Property DOC_RECO_INFO As String
    Public Property DOC_ANALI_INFO As String
    Public Property FEC_DOC As String
    Public Property IND_ENVIADO As String
    Public Property COD_RECO As String
    Public Property FEC_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property USUARIO_BAJA As String
End Class


Public Class TRESANALI
    <PrimaryKey>
    Public Property ID_RESANAL As String
    Public Property ID_PRUEBA As String
    Public Property ID_TRABAJADOR As String
    Public Property ID_ORIGEN As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property ID_COLOR As String
    Public Property CAN_RESULTADO As String
    Public Property FEC_HISTORICO As String
    Public Property FEC_MEDICION As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property IND_CAMBIO_HISTORICO As String
End Class


Public Class TRECOMENDACIONES
    <PrimaryKey>
    Public Property COD_RECOMENDACION As String
    Public Property ID_TRABAJADOR As String
    Public Property ID_TTIPORECOM As String
    Public Property DES_TIPO_RECOM As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property FEC_ALTA As String
    Public Property COD_PAGINA_ESTANDAR As String
    Public Property COD_PAGINA_PARTICULAR As String
    Public Property FEC_DESDE As String
    Public Property FEC_HASTA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property FEC_BAJA As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property DES_PAGINA_ESTANDAR As String
End Class



Public Class TRESSENTIDOS
    <PrimaryKey>
    Public Property ID_RESSENTIDOS As String
    Public Property ID_PRUEBA As String
    Public Property ID_ORIGEN As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property ID_COLOR As String
    Public Property CAN_RESULTADO As String
    Public Property ID_CALSENTIDOS As String
    Public Property FEC_HISTORICO As String
    Public Property FEC_MEDICION As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property IND_CAMBIO_HISTORICO As String
    Public Property NUM_ORDEN As String
End Class


Public Class TCALSENTIDOS
    <PrimaryKey>
    Public Property ID_CALSENTIDOS As String
    Public Property CAN_SENTIDOS As String
    Public Property COD_COL_SENTIDOS As String
    Public Property CAN_AUDIO As String
    Public Property CAN_VISION As String
    Public Property COD_COL_AUDIO As String
    Public Property COD_COL_VISION As String
    Public Property FEC_MEDICION As String
End Class

Public Class TCONSTANT
    <PrimaryKey>
    Public Property ID_CONSTANTE As Integer
    Public Property DES_CONSTANTE As String
    Public Property VAL_CONSTANTE As String

End Class


Public Class TRESPULMONAR
    <PrimaryKey>
    Public Property ID_RESPULMONAR As String
    Public Property ID_PRUEBA As String
    Public Property ID_ORIGEN As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property ID_COLOR As String
    Public Property CAN_RESULTADO As String
    Public Property ID_CALPULMONAR As String
    Public Property FEC_HISTORICO As String
    Public Property FEC_MEDICION As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property IND_CAMBIO_HISTORICO As String
    Public Property NUM_ORDEN As String
End Class

Public Class TCALPULMONAR
    <PrimaryKey>
    Public Property ID_CALPULMONAR As String
    Public Property CAN_PULMONAR As String
    Public Property COD_COL_PULMONAR As String
    Public Property FEC_MEDICION As String
End Class


Public Class TRESMETAS
    <PrimaryKey>
    Public Property ID_RESMETA As String
    Public Property ID_PRUEBA As String
    Public Property ID_ORIGEN As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property ID_COLOR As String
    Public Property CAN_RESULTADO As String
    Public Property ID_CALMETA As String
    Public Property FEC_HISTORICO As String
    Public Property FEC_MEDICION As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property IND_CAMBIO_HISTORICO As String
    Public Property NUM_ORDEN As String
End Class



Public Class TCALMETAS
    <PrimaryKey>
    Public Property ID_CALMETA As String
    Public Property CAN_META As String
    Public Property COD_COL_META As String
    Public Property FEC_MEDICION As String
End Class

Public Class TRESHABITOS
    <PrimaryKey>
    Public Property ID_RESHABITOS As String
    Public Property ID_TIPO_TABACO As String
    Public Property COD_COL_TABACO As String
    Public Property ID_TIPO_ALCOHOL As String
    Public Property COD_COL_ALCOHOL As String
    Public Property ID_TIPO_CAFE As String
    Public Property COD_COL_CAFE As String
    Public Property ID_TIPO_ALIMENTA As String
    Public Property COD_COL_ALIMENTA As String
    Public Property ID_TIPO_EJERCICI As String
    Public Property COD_COL_EJERCICIO As String
    Public Property ID_TIPO_SUENO As String
    Public Property COD_COL_SUENO As String
    Public Property ID_ORIGEN As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property ID_CALHABITOS As String
    Public Property FEC_HISTORICO As String
    Public Property FEC_MEDICION As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property IND_CAMBIO_HISTORICO As String
End Class

Public Class TCALHABITOS
    <PrimaryKey>
    Public Property ID_CALHABITOS As String
    Public Property CAN_HABITOS As String
    Public Property COD_COL_HABITOS As String
    Public Property FEC_MEDICION As String
End Class



Public Class TRESCARDIO
    <PrimaryKey>
    Public Property ID_RESCARDIO As String
    Public Property ID_PRUEBA As String
    Public Property ID_ORIGEN As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property ID_COLOR As String
    Public Property CAN_RESULTADO As String
    Public Property ID_CALCARDIO As String
    Public Property FEC_HISTORICO As String
    Public Property FEC_MEDICION As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property IND_CAMBIO_HISTORICO As String
    Public Property NUM_ORDEN As String
End Class

Public Class TCALCARDIO
    <PrimaryKey>
    Public Property ID_CALCARDIO As String
    Public Property CAN_CARDIO As String
    Public Property COD_COL_CARDIO As String
    Public Property FEC_MEDICION As String
End Class


Public Class TRESACTIVIDAD
    <PrimaryKey>
    Public Property ID_RESACTIVIDAD As String
    Public Property ID_PRUEBA As String
    Public Property ID_ORIGEN As String
    Public Property COD_CLAVE_ORIGEN As String
    Public Property ID_COLOR As String
    Public Property CAN_RESULTADO As String
    Public Property ID_CALACTIVIDAD As String
    Public Property FEC_HISTORICO As String
    Public Property FEC_MEDICION As String
    Public Property FEC_ALTA As String
    Public Property FEC_BAJA As String
    Public Property IND_ENVIADO As String
    Public Property FEC_ENVIADO As String
    Public Property USUARIO_BAJA As String
    Public Property USUARIO_ALTA As String
    Public Property IND_CAMBIO_HISTORICO As String
End Class

Public Class TCALACTIVIDAD
    <PrimaryKey>
    Public Property ID_CALACTIVIDAD As String
    Public Property CAN_ACTIVIDAD As String
    Public Property COD_COL_ACTIVIDAD As String
    Public Property FEC_MEDICION As String
End Class



Public Class AUX_PRUEBAS
    <PrimaryKey>
    Public Property ID_PRUBEA As String
    Public Property DES_PRUEBA As String
    Public Property UNID As String
    Public Property VAL_MAX As String
    Public Property VAL_MIN As String


End Class


Public Class TCENTROS
    <PrimaryKey>
    Public Property cod_centro As String
    Public Property cod_centro_fragua As String
    Public Property e_mail As String
    Public Property calle As String
    Public Property numero As String
    Public Property cod_postal As String
    Public Property poblacion As String
    Public Property provincia As String
    Public Property direccion As String
    Public Property telefono As String
    Public Property fax As String
    Public Property des_centro As String
    Public Property latitud As String
    Public Property longitud As String

End Class



#End Region





