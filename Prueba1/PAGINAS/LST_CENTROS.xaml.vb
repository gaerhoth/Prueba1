Imports Prueba1.AYUDA
Imports Prueba1.VAR_GLOBALES
' La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
''' </summary>
Public NotInheritable Class LST_CENTROS
    Inherits Page

    Private Sub Atras_Click(sender As Object, e As RoutedEventArgs) Handles Atras.Click
        Me.Frame.Navigate(GetType(CENTROS))
    End Sub

    Private Sub CMB_Provincias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles CMB_Provincias.SelectionChanged
        Dim l_centros As List(Of TCENTROS)
        l_centros = conn.Query(Of TCENTROS)("SELECT * FROM TCENTROS WHERE PROVINCIA = upper('" & CMB_Provincias.SelectedItem & "')")
        'POR_SENTIDOS = LS(0).CAN_SENTIDOS
        'C_Sentidos = AYUDA.CreaColores(listaColores(CInt(LS(0).COD_COL_SENTIDOS) - 1).DES_COLOR)
        LS_CENTROS.Items.Clear()

        For i = 0 To l_centros.Count - 1

            Dim auxL As Decimal = 0
            Dim auxLA As Decimal = 0

            If l_centros(i).latitud <> "" Then
                auxLA = l_centros(i).latitud.ToString.Replace(".", ",")
            Else
                auxLA = 0
            End If

            If l_centros(i).longitud <> "" Then
                auxL = l_centros(i).longitud.ToString.Replace(".", ",")
            Else
                auxL = 0
            End If



            Me.LS_CENTROS.Items.Add(New CLASECENTROS With
                      {.CNT = l_centros(i).calle & " " & l_centros(i).numero,
                      .DAT = l_centros(i).cod_postal & " " & l_centros(i).provincia,
                      .IMAG = l_centros(i).des_centro,
                      .LON = auxL,
                      .LAT = auxLA
                                                                  })
        Next

    End Sub

    Private Sub LS_CENTROS_ItemClick(sender As Object, e As ItemClickEventArgs) Handles LS_CENTROS.ItemClick

    End Sub

    Private Sub LS_CENTROS_Tapped(sender As Object, e As TappedRoutedEventArgs) Handles LS_CENTROS.Tapped
        Dim lat As Decimal
        Dim lon As Decimal
        lat = DirectCast(LS_CENTROS.SelectedItem, Prueba1.CLASECENTROS).LAT
        lon = DirectCast(LS_CENTROS.SelectedItem, Prueba1.CLASECENTROS).LON

        Frame.Navigate(GetType(DET_CENTRO), lat & ";" & lon)
    End Sub

    Private Sub LST_CENTROS_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        CMB_Provincias.Items.Insert(0, "Albacete")
        CMB_Provincias.Items.Insert(1, "Alicante")
        CMB_Provincias.Items.Insert(2, "Almería")
        CMB_Provincias.Items.Insert(3, "Álava")
        CMB_Provincias.Items.Insert(4, "Asturias")
        CMB_Provincias.Items.Insert(5, "Ávila")
        CMB_Provincias.Items.Insert(6, "Badajoz")
        CMB_Provincias.Items.Insert(7, "Balears, Illes")
        CMB_Provincias.Items.Insert(8, "Barcelona")
        CMB_Provincias.Items.Insert(9, "Bizkaia")
        CMB_Provincias.Items.Insert(10, "Burgos")
        CMB_Provincias.Items.Insert(11, "Cáceres")
        CMB_Provincias.Items.Insert(12, "Cádiz")
        CMB_Provincias.Items.Insert(13, "Cantabria")
        CMB_Provincias.Items.Insert(14, "Castellón / Castelló")
        CMB_Provincias.Items.Insert(15, "Ciudad Real")
        CMB_Provincias.Items.Insert(16, "Córdoba")
        CMB_Provincias.Items.Insert(17, "Coruña, A")
        CMB_Provincias.Items.Insert(18, "Cuenca")
        CMB_Provincias.Items.Insert(19, "Gipuzkoa")
        CMB_Provincias.Items.Insert(20, "Girona")
        CMB_Provincias.Items.Insert(21, "Granada")
        CMB_Provincias.Items.Insert(22, "Guadalajara")
        CMB_Provincias.Items.Insert(23, "Huelva")
        CMB_Provincias.Items.Insert(24, "Huesca")
        CMB_Provincias.Items.Insert(25, "Jaén")
        CMB_Provincias.Items.Insert(26, "León")
        CMB_Provincias.Items.Insert(27, "Lleida")
        CMB_Provincias.Items.Insert(28, "Lugo")
        CMB_Provincias.Items.Insert(29, "Madrid")
        CMB_Provincias.Items.Insert(30, "Málaga")
        CMB_Provincias.Items.Insert(31, "Murcia")
        CMB_Provincias.Items.Insert(32, "Navarra")
        CMB_Provincias.Items.Insert(33, "Ourense")
        CMB_Provincias.Items.Insert(34, "Palencia")
        CMB_Provincias.Items.Insert(35, "Palmas, Las")
        CMB_Provincias.Items.Insert(36, "Pontevedra")
        CMB_Provincias.Items.Insert(37, "Rioja, La")
        CMB_Provincias.Items.Insert(38, "Salamanca")
        CMB_Provincias.Items.Insert(39, "Santa Cruz de Tenerife")
        CMB_Provincias.Items.Insert(40, "Segovia")
        CMB_Provincias.Items.Insert(41, "Sevilla")
        CMB_Provincias.Items.Insert(42, "Soria")
        CMB_Provincias.Items.Insert(43, "Tarragona")
        CMB_Provincias.Items.Insert(44, "Teruel")
        CMB_Provincias.Items.Insert(45, "Toledo")
        CMB_Provincias.Items.Insert(46, "Valencia")
        CMB_Provincias.Items.Insert(47, "Valladolid")
        CMB_Provincias.Items.Insert(48, "Zamora")
        CMB_Provincias.Items.Insert(49, "Zaragoza")
        CMB_Provincias.Items.Insert(50, "Ceuta")
        CMB_Provincias.Items.Insert(51, "Melilla")

        Dim l_centros As List(Of TCENTROS)
        l_centros = conn.Query(Of TCENTROS)("SELECT * FROM TCENTROS")
        'POR_SENTIDOS = LS(0).CAN_SENTIDOS
        'C_Sentidos = AYUDA.CreaColores(listaColores(CInt(LS(0).COD_COL_SENTIDOS) - 1).DES_COLOR)


        For i = 0 To l_centros.Count - 1
            Dim auxL As Decimal = 0
            Dim auxLA As Decimal = 0

            If l_centros(i).latitud <> "" Then
                auxLA = l_centros(i).latitud.ToString.Replace(".", ",")
            Else
                auxLA = 0
            End If

            If l_centros(i).longitud <> "" Then
                auxL = l_centros(i).longitud.ToString.Replace(".", ",")
            Else
                auxL = 0
            End If


            Me.LS_CENTROS.Items.Add(New CLASECENTROS With
                      {.CNT = l_centros(i).calle & " " & l_centros(i).numero,
                      .DAT = l_centros(i).cod_postal & " " & l_centros(i).provincia,
                      .IMAG = l_centros(i).des_centro,
                       .LON = auxL,
                                  .LAT = auxLA
                                                                  })


            ' ' .LON = If(l_centros(i).longitud = "", .LON = 0, .LON = l_centros(i).longitud),
        Next

    End Sub

    Private Sub ToMap_Click(sender As Object, e As RoutedEventArgs) Handles ToMap.Click
        Me.Frame.Navigate(GetType(CENTROS))
    End Sub
End Class
