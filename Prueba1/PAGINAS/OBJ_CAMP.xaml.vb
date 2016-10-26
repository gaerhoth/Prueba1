
Imports Prueba1.VAR_GLOBALES
Imports Prueba1.AYUDA
Public NotInheritable Class OBJ_CAMP
    Inherits Page
    Public Parametros As String()
    Public ima As String = ""
    Public titulo As String = ""
    Public parrafo As String = ""
#Region "Menu"


    Private Sub BTN_MISALUD_Click(sender As Object, e As RoutedEventArgs) Handles BTN_MISALUD.Click
        Me.Frame.Navigate(GetType(HOME))
    End Sub

    Private Sub BTN_INFO_Click(sender As Object, e As RoutedEventArgs) Handles BTN_INFO.Click
        Me.Frame.Navigate(GetType(INFO))
    End Sub

    Private Sub BTN_DOC_Click(sender As Object, e As RoutedEventArgs) Handles BTN_DOC.Click
        Me.Frame.Navigate(GetType(DOCUMENTOS))
    End Sub

    Private Sub BTN_OBJ_Click(sender As Object, e As RoutedEventArgs) Handles BTN_OBJ.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_OBJ.Content)
    End Sub

    Private Sub BTN_CENTROS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CENTROS.Click
        Me.Frame.Navigate(GetType(CENTROS))
    End Sub

    Private Sub BTN_CITAS_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CITAS.Click
        Me.Frame.Navigate(GetType(CITAS))
    End Sub

    Private Sub BTN_RECOM_Click(sender As Object, e As RoutedEventArgs) Handles BTN_RECOM.Click
        Me.Frame.Navigate(GetType(RECOMENDACIONES), Me.BTN_RECOM.Content)

    End Sub

    Private Sub PERFIL_Click(sender As Object, e As RoutedEventArgs) Handles PERFIL.Click
        Me.Frame.Navigate(GetType(PERFIL))
    End Sub
    Private Sub BTN_CAMPA_Click(sender As Object, e As RoutedEventArgs) Handles BTN_CAMPA.Click
        Me.Frame.Navigate(GetType(OBJ_CAMP), Me.BTN_CAMPA.Content)
    End Sub
#End Region


    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)

        Parametros = e.Parameter.ToString.Split(";")

    End Sub

    Private Async Sub OBJ_CAMP_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading

        '  descompon("<body><div Class="" main-list""><div class="" list-group onrun""><div class="" item objetivo""><img class="" item-image"" src="" http://213.0.19.28:1248/Repositorio/documentos/WAH/Objetivos/images/list_4.png""/><div class="" item-text""><h1>CONTROL DE COLON</h1><p>La dieta y más concretamente la Sal, contribuye a cómo se manifiesta tu Tensión. Te decimos qué alimentos son saludables y cuáles deberías moderar.</p></div></div></div></div></body>")

        Dim LS_CAMPAÑAS As List(Of TCAMPANAS)
        Me.Tit.Text = Parametros(0)
        '2 campañas
        '1 objetivos

#Region "comentado"
        'If Me.Parametros(1) = "1" Then

        '    CAMPAÑAS = Await C_WAH.DameCampañaAsync(48, Date.Now)
        '    AYUDA.LimpiarJson(CAMPAÑAS.Body.DameCampañaResult, "DameCampaña", "TRESMETAS")

        '    'hay que llamar al webservice que nos da las campañas
        '    'guardar en BBDD local
        '    'hacer lista con los datos que hemos obtenido
        '    'hacer el binding 


        '    Me.PL.Items.Add(New CIRCO2)
        '    Me.PL2.Items.Add(New CIRCO2)

        '    If PL.Items.Count > 1 Then
        '    Else
        '        ND1.Visibility = Visibility.Visible
        '    End If

        '    If PL2.Items.Count > 1 Then
        '    Else
        '        ND2.Visibility = Visibility.Visible
        '    End If




        'Else


        '    Me.OBJ_PL.Items.Add(New CIRCO2)
        '    Me.OBJ_PL2.Items.Add(New CIRCO2)

        '    If OBJ_PL.Items.Count > 1 Then
        '    Else
        '        ND1.Visibility = Visibility.Visible
        '    End If

        '    If OBJ_PL2.Items.Count > 1 Then
        '    Else
        '        ND2.Visibility = Visibility.Visible
        '    End If




        'End If
#End Region

        If Me.Parametros(1) = "2" Then
            CAMPAÑAS = Await C_WAH.DameCampañaAsync(48, Date.Now)

            conn.DeleteAll(Of TCAMPANAS)()
            AYUDA.LimpiarJson(CAMPAÑAS.Body.DameCampañaResult, "DameCampaña", "TCAMPANAS")
            LS_CAMPAÑAS = conn.Query(Of TCAMPANAS)("SELECT * FROM TCAMPANAS")


            For i = 0 To LS_CAMPAÑAS.Count - 1

                Select Case LS_CAMPAÑAS(i).COD_ESTADO_CAMPANA
                    Case "1"
                        'Me.PL2.Items.Add(New CLASEOBJCAMP With
                        '       {.MHTML = LS_CAMPAÑAS(i).DES_HTML_MINIATURA,
                        '       .HTML = LS_CAMPAÑAS(i).DES_HTML_MINIATURA})

                    Case "2"

                        Dim h As String
                        h = ActHTML(LS_CAMPAÑAS(i).DES_HTML_MINIATURA)

                        ' descompon(LS_CAMPAÑAS(i).DES_HTML_MINIATURA.Replace("""", """"""))

                        descompon(h)

                        Me.PL.Items.Add(New CLASEOBJCAMP With
                             {.IMAG = ima,
                             .TEXTO = titulo,
                             .HTML = LS_CAMPAÑAS(i).DES_HTML,
                             .MHTML = LS_CAMPAÑAS(i).DES_HTML_MINIATURA})








                End Select



            Next




        Else
            OBJET = Await C_WAH.DameObjetivoTrabajAsync(48, "N")
            AYUDA.LimpiarJson(OBJET.Body.DameObjetivoTrabajResult, "DameObjetivoTrabaj", "TRESMETAS")
        End If




        'For i = 0 To 10
        '    Me.PL.Items.Add(New CIRCO2)
        'Next


    End Sub

    Public Sub descompon(html As String)
        Dim auxima As String = ""
        Dim auxtitulo As String = ""
        Dim pa As String = ""
        Dim a As Integer
        Dim b As Integer
        If html.Contains("src=") = True Then

            a = html.IndexOf("src=")
            auxima = html.Substring(a + 4)
            b = auxima.IndexOf(".png")
            auxima = auxima.Substring(0, b + 4)
            ima = auxima.Replace("\http", "http")
        End If


        If html.Contains("<h1>") = True Then
            a = html.IndexOf("<h1>")
            auxtitulo = html.Substring(a + 4)
            b = auxtitulo.IndexOf("</h1>")
            auxtitulo = auxtitulo.Substring(0, b)
            titulo = auxtitulo
        End If


        If html.Contains("<p>") = True Then
            a = html.IndexOf("<p>")
            pa = html.Substring(a + 3)
            b = pa.IndexOf("</p>")
            pa = pa.Substring(0, b)
            parrafo = pa
        End If

    End Sub

    Private Sub Menu_Checked(sender As Object, e As RoutedEventArgs) Handles Menu.Checked

        If Me.MySplitView.IsPaneOpen = False Then
            MySplitView.IsPaneOpen = True
        Else
            MySplitView.IsPaneOpen = False
        End If

    End Sub

    Private Sub PL_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles PL.Tapped
        If Parametros(1) = 2 Then
            Dim p As String
            p = "< body <> header <> h1 Class=""initicalc"">Reducción de Riesgo Cardiovascular</h1></header><section><article><img src=""http://213.0.19.26/Repositorio/documentos/WAH/IMAGENES_WAH/Cardio_shutterstock_147231050_132x132.png""/><p>Las enfermedades cardiovasculares son las que afectan al corazón y los vasos sanguíneos (Of como angina de pecho, infarto de miocardio, infarto cerebral, etc). Estas enfermedades suponen la primera causa de muerte en nuestro país; sin embargo, estas patologías son prevenibles si se actúa a tiempo sobre sus factores de riesgo con unos hábitos de vida saludables.</p><p class=""noSpace"">Los factores de riesgo son:</p><ul><li>La hipertensión arterial</li><li>La diabetes</li><li>El sedentarismo</li><li>El colesterol elevado</li><li>El sobrepeso y la obesidad</li><li>Consumo de tabaco y alcohol</li></ul></article></section><section><h1>OBJETIVO PRINCIPAL <br> <span class=""initicalc"">Mejorar</span> <span class=""initicalc"">su salud </span></h1><article><p>El objetivo es ayudarte mediante esta herramienta informática a tomar el control sobre tu salud y eliminar o controlar el riesgo,  mediante la adquisición de los hábitos de vida sanos para ello periódicamente te informaremos  de los avances que consigas con los objetivos que te marques en la campaña con el asesoramiento del personal sanitario de Correos.</p><p>El programa va dirigido a todas aquellas personas interesadas en mejorar su salud, y especialmente  recomendable en caso de presentar los factores de riesgo: Tensión Arterial elevada, Colesterol elevado, Personas con sobrepeso/obesidad, antecedentes de enfermedad cardiovascular...etc</p></article></section><div Class=""detail""><div Class=""detail-title""><h1>OBJETIVOS ASOCIADOS</h1></div><div Class=""detail-subtitle""><img src=""http: //213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo1.png""/><p>ALIMENTACIÓN CARDIOSALUDABLE</p></div><div Class=""detail-text""><p>Una dieta cardiosaludable  da importancia al consumo de alimentos que reducen los factores de riesgo cardiovascular, como la Dieta Mediterránea.</p></div><div Class=""detail-subtitle""><img src=""http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo2.png""/><p>ACTIVIDAD FÍSICA</p></div><div Class=""detail-text""><p>Cómo realizar actividad física adecuada para combatir el sedentarismo y mejorar y controlar los factores de riesgo cardiovascular y mejorar el estado de salud general.</p></div><div Class=""detail-subtitle""><img src=""http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo3.png""/><p>CONTROL DE CONSUMO DE TABACO</p></div><div Class=""detail-text""><p>Informando de los efectos  beneficiosos que se obtienen al dejarlo y cómo conseguirlo.</p></div><div Class=""detail-subtitle""><img src=""http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo4.png""/><p>CONTROL DE LA HIPERTENSIÓN ARTERIAL</p></div><div Class=""detail-text""><p>La hipertensión supone un riesgo de padecer enfermedades cardiovasculares si no está controlada. Te ayudamos a realizar un seguimiento para mejorarla.</p></div><div Class=""detail-subtitle""><img src=""http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo5.png""/><p>CONTROL DE LA HIPERCOLESTEROLEMIA</p></div><div Class=""detail-text""><p>Para disminuir el daño que puede provocar el exceso de colesterol en tus arterias.</p></div><div Class=""detail-subtitle""><img src=""http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo6.png""/><p>CONTROL DEL SOBREPESO</p></div><div Class=""detail-text""><p>Con un índice de masa corporal elevado es aconsejable mejorar la dieta y realizar actividad física.</p></div><div Class=""detail-subtitle""><img src=""http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo7.png""/><p>CONTROL DE GLUCOSA</p></div><div Class=""detail-text""><p>Para evitar la Diabetes recomendamos: dieta equilibrada, actividad física moderada y control de glucosa. Si eres diabético y te cuidas evitarás las complicaciones que puede ocasionar la enfermedad.</p></div></div></body>"
            Frame.Navigate(GetType(VISTAHTML), p)


            ' Frame.Navigate(GetType(VISTAHTML), DirectCast(PL.SelectedItem, Prueba1.CLASEOBJCAMP).HTML)

        Else
            Frame.Navigate(GetType(DET_OBJETIVO))

        End If

    End Sub

    Public Function ActHTML(html As String) As String

        html = html.Replace("&aacute;", "á")
        html = html.Replace("&eacute;", "é")
        html = html.Replace("&iacute;", "í")
        html = html.Replace("&oacute;", "ó")
        html = html.Replace("&uacute;", "ú")

        html = html.Replace("&Aacute;", "Á")
        html = html.Replace("&Eacute;", "É")
        html = html.Replace("&Iacute;", "Í")
        html = html.Replace("&Oacute;", "Ó")
        html = html.Replace("&Uacute;", "Ú")

        html = html.Replace("&Ntilde;", "Ñ")
        html = html.Replace("&ntilde;", "ñ")

        html = html.Replace("&#33;", "!")
        html = html.Replace("&#161;", "¡")

        html = html.Replace("&iquest;", "¿")
        html = html.Replace("&#63;", "?")

        html = html.Replace("&#39;", "'")

        Return html

    End Function



End Class

Public NotInheritable Class WebViewExtensions
    Private Sub New()
    End Sub
    Public Shared Function GetUriSource(view As WebView) As String
        Return DirectCast(view.GetValue(UriSourceProperty), String)
    End Function

    Public Shared Sub SetUriSource(view As WebView, value As String)
        view.SetValue(UriSourceProperty, value)
    End Sub

    Public Shared ReadOnly UriSourceProperty As DependencyProperty = DependencyProperty.RegisterAttached("UriSource", GetType(String), GetType(WebViewExtensions), New PropertyMetadata(Nothing, AddressOf OnUriSourcePropertyChanged))

    Private Shared Sub OnUriSourcePropertyChanged(sender As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim webView = TryCast(sender, WebView)
        If webView Is Nothing Then
            Throw New NotSupportedException()
        End If

        If e.NewValue IsNot Nothing Then
            Dim uri = New Uri(e.NewValue.ToString())
            webView.Navigate(uri)
        End If
    End Sub




End Class
'para ver como quedarian

'Ojetivos
'Mini
'<body> <div Class="main-list"><div class="list-group onrun"><div class="item objetivo"><img class="item-image" src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Objetivos/images/list_4.png"/><div class="item-text"><h1>CONTROL DE COLON</h1><p>La dieta y más concretamente la Sal, contribuye a cómo se manifiesta tu Tensión. Te decimos qué alimentos son saludables y cuáles deberías moderar.</p></div></div></div></div></body>

'Grande
'<body> <img Class="headerimg" src="http://213.0.19.28:1248/repositorio/documentos/WAH/Objetivos/images/list_5.png"/><section><article><p>La dieta y más concretamente la Sal, contribuye a cómo se manifiesta tu Tensión. Te decimos qué alimentos son saludables y cuáles deberías moderar.</p></article></section></body></html>


'campáñas
'Mini
'<body> <div Class="main-list"><div class="list-group onrun"><div class="item"><img class="item-image" src="http://213.0.19.26/Repositorio/documentos/WAH/IMAGENES_WAH/Cardio_shutterstock_147231050_132x132.png"/><div class="item-text"><h1>REDUCCIÓN DE RIESGO CARDIOVASCULAR</h1><p>Para reducir la probabilidad de muerte por enfermedad cardiovascular.</p></div></div></div></div></body>

'Grande
'<body> <header> <h1 Class="initicalc">Reducción de Riesgo Cardiovascular</h1></header><section><article><img src="http://213.0.19.26/Repositorio/documentos/WAH/IMAGENES_WAH/Cardio_shutterstock_147231050_132x132.png"/><p>Las enfermedades cardiovasculares son las que afectan al corazón y los vasos sanguíneos (Of como angina de pecho, infarto de miocardio, infarto cerebral, etc). Estas enfermedades suponen la primera causa de muerte en nuestro país; sin embargo, estas patologías son prevenibles si se actúa a tiempo sobre sus factores de riesgo con unos hábitos de vida saludables.</p><p class="noSpace">Los factores de riesgo son:</p><ul><li>La hipertensión arterial</li><li>La diabetes</li><li>El sedentarismo</li><li>El colesterol elevado</li><li>El sobrepeso y la obesidad</li><li>Consumo de tabaco y alcohol</li></ul></article></section><section><h1>OBJETIVO PRINCIPAL <br> <span class="initicalc">Mejorar</span> <span class="initicalc">su salud </span></h1><article><p>El objetivo es ayudarte mediante esta herramienta informática a tomar el control sobre tu salud y eliminar o controlar el riesgo,  mediante la adquisición de los hábitos de vida sanos para ello periódicamente te informaremos  de los avances que consigas con los objetivos que te marques en la campaña con el asesoramiento del personal sanitario de Correos.</p><p>El programa va dirigido a todas aquellas personas interesadas en mejorar su salud, y especialmente  recomendable en caso de presentar los factores de riesgo: Tensión Arterial elevada, Colesterol elevado, Personas con sobrepeso/obesidad, antecedentes de enfermedad cardiovascular...etc</p></article></section><div Class="detail"><div Class="detail-title"><h1>OBJETIVOS ASOCIADOS</h1></div><div Class="detail-subtitle"><img src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo1.png"/><p>ALIMENTACIÓN CARDIOSALUDABLE</p></div><div Class="detail-text"><p>Una dieta cardiosaludable  da importancia al consumo de alimentos que reducen los factores de riesgo cardiovascular, como la Dieta Mediterránea.</p></div><div Class="detail-subtitle"><img src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo2.png"/><p>ACTIVIDAD FÍSICA</p></div><div Class="detail-text"><p>Cómo realizar actividad física adecuada para combatir el sedentarismo y mejorar y controlar los factores de riesgo cardiovascular y mejorar el estado de salud general.</p></div><div Class="detail-subtitle"><img src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo3.png"/><p>CONTROL DE CONSUMO DE TABACO</p></div><div Class="detail-text"><p>Informando de los efectos  beneficiosos que se obtienen al dejarlo y cómo conseguirlo.</p></div><div Class="detail-subtitle"><img src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo4.png"/><p>CONTROL DE LA HIPERTENSIÓN ARTERIAL</p></div><div Class="detail-text"><p>La hipertensión supone un riesgo de padecer enfermedades cardiovasculares si no está controlada. Te ayudamos a realizar un seguimiento para mejorarla.</p></div><div Class="detail-subtitle"><img src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo5.png"/><p>CONTROL DE LA HIPERCOLESTEROLEMIA</p></div><div Class="detail-text"><p>Para disminuir el daño que puede provocar el exceso de colesterol en tus arterias.</p></div><div Class="detail-subtitle"><img src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo6.png"/><p>CONTROL DEL SOBREPESO</p></div><div Class="detail-text"><p>Con un índice de masa corporal elevado es aconsejable mejorar la dieta y realizar actividad física.</p></div><div Class="detail-subtitle"><img src="http://213.0.19.28:1248/Repositorio/documentos/WAH/Campanas/CORREOS/images/image_objetivo7.png"/><p>CONTROL DE GLUCOSA</p></div><div Class="detail-text"><p>Para evitar la Diabetes recomendamos: dieta equilibrada, actividad física moderada y control de glucosa. Si eres diabético y te cuidas evitarás las complicaciones que puede ocasionar la enfermedad.</p></div></div></body>

