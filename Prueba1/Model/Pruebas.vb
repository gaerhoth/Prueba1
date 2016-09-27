Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace Model
    Partial Public Class Contact

        Private Shared random As New Random()

#Region "Properties"
        Private m_initials As String
        Public ReadOnly Property Initials() As String
            Get
                If m_initials = String.Empty AndAlso FirstName <> String.Empty AndAlso LastName <> String.Empty Then
                    m_initials = FirstName(0).ToString() + LastName(0).ToString()
                End If
                Return m_initials
            End Get
        End Property
        Private m_name As String
        Public ReadOnly Property Name() As String
            Get
                If m_name = String.Empty AndAlso FirstName <> String.Empty AndAlso LastName <> String.Empty Then
                    m_name = Convert.ToString(FirstName & Convert.ToString(" ")) & LastName
                End If
                Return m_name
            End Get
        End Property
        Private m_lastName As String
        Public Property LastName() As String
            Get
                Return m_lastName
            End Get
            Set
                m_lastName = Value
                m_initials = String.Empty
                ' force to recalculate the value 
                ' force to recalculate the value 
                m_name = String.Empty
            End Set
        End Property
        Private m_firstName As String
        Public Property FirstName() As String
            Get
                Return m_firstName
            End Get
            Set
                m_firstName = Value
                m_initials = String.Empty
                ' force to recalculate the value 
                ' force to recalculate the value 
                m_name = String.Empty
            End Set
        End Property
        Public Property Position() As String
            Get
                Return m_Position
            End Get
            Set
                m_Position = Value
            End Set
        End Property
        Private m_Position As String
        Public Property PhoneNumber() As String
            Get
                Return m_PhoneNumber
            End Get
            Set
                m_PhoneNumber = Value
            End Set
        End Property
        Private m_PhoneNumber As String
        Public Property Biography() As String
            Get
                Return m_Biography
            End Get
            Set
                m_Biography = Value
            End Set
        End Property
        Private m_Biography As String
#End Region

        Public Sub New()
            ' default values for each property.
            m_initials = String.Empty
            m_name = String.Empty
            LastName = String.Empty
            FirstName = String.Empty
            Position = String.Empty
            PhoneNumber = String.Empty
            Biography = String.Empty
        End Sub

#Region "Public Methods"
        Public Shared Function GetNewContact() As Contact
            Return New Contact() With {
        .FirstName = 1,
        .LastName = 1,
        .Biography = 1,
        .PhoneNumber = 1,
        .Position = 1
    }
        End Function
        Public Shared Function GetContacts(numberOfContacts As Integer) As ObservableCollection(Of Contact)
            Dim contacts As New ObservableCollection(Of Contact)()

            For i As Integer = 0 To numberOfContacts - 1
                contacts.Add(GetNewContact())
            Next
            Return contacts
        End Function
        '       Public Shared Function GetContactsGrouped(numberOfContacts As Integer) As ObservableCollection(Of GroupInfoList)
        '           Dim groups As New ObservableCollection(Of GroupInfoList)()

        '           Dim query = From g In From item In GetContacts(numberOfContacts) Group item By item.LastName(0)Order By g.KeyNew With { _
        '	Key .GroupName = g.Key,
        '       Key .Items = g _
        '}

        'For Each g As var In query
        '               Dim info As New GroupInfoList()
        '               info.Key = g.GroupName
        '               For Each item As var In g.Items
        '                   info.Add(item)
        '               Next
        '               groups.Add(info)
        '           Next

        '           Return groups
        '       End Function

        Public Overrides Function ToString() As String
            Return Name
        End Function
#End Region
    End Class
End Namespace