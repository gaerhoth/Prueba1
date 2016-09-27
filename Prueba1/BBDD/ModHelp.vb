Module ModHelp


#Region "[metodos extensores]"

    ''' <summary>
    ''' Metodo extensor para obtener una lista de hijos en el arbol visual del objeto especificado.
    ''' </summary>
    ''' <typeparam name="T">Tipo de control que quiere obtenerse</typeparam>
    ''' <param name="_obj">objeto de dependencia en el cual se buscara</param>
    ''' <param name="_name">nombre del control/controles a buscar</param>
    ''' <returns>
    ''' lista del tipo de control a buscar con todos los controles coincidentes con el nombre y tipo. 
    ''' null en caso de no encontrar ninguno
    ''' </returns>
    <System.Runtime.CompilerServices.Extension>
    Public Function GetChildObjects(Of T)(_obj As DependencyObject, _name As String) As List(Of T)
        Dim retVal = New List(Of T)()
        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(_obj) - 1
            Dim c As Object = VisualTreeHelper.GetChild(_obj, i)
            If c.[GetType]().FullName = GetType(T).FullName AndAlso ([String].IsNullOrEmpty(_name) OrElse DirectCast(c, FrameworkElement).Name = _name) Then
                retVal.Add(DirectCast(c, T))
            End If
            Dim gc = DirectCast(c, DependencyObject).GetChildObjects(Of T)(_name)
            If gc IsNot Nothing Then
                retVal.AddRange(gc)
            End If
        Next

        Return retVal
    End Function

    ''' <summary>
    ''' Metodo extensor para obtener un hijo en el arbol visual del objeto especificado.
    ''' </summary>
    ''' <typeparam name="T">Tipo de control que quiere obtenerse</typeparam>
    ''' <param name="_obj">objeto de dependencia en el cual se buscara</param>
    ''' <param name="_name">nombre del control a buscar</param>
    ''' <returns>control coincidentes con el nombre y tipo. null en caso de no encontrarlo</returns>
    <System.Runtime.CompilerServices.Extension>
    Public Function GetChildObject(Of T As DependencyObject)(_obj As DependencyObject, _name As String) As T
        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(_obj) - 1
            Dim c As Object = VisualTreeHelper.GetChild(_obj, i)
            If c.[GetType]().FullName = GetType(T).FullName AndAlso ([String].IsNullOrEmpty(_name) OrElse DirectCast(c, FrameworkElement).Name = _name) Then
                Return DirectCast(c, T)
            End If
            Dim gc As Object = DirectCast(c, DependencyObject).GetChildObject(Of T)(_name)
            If gc IsNot Nothing Then
                Return DirectCast(gc, T)
            End If
        Next

        Return Nothing
    End Function

#End Region

End Module
