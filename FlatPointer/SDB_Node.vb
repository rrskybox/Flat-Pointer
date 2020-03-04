Imports System.Text

Public Class SDB_Node

#Region "SDB_Field_Definitions"

    Const labelOrSearch_Index = 0
    Const labelOrSearch_Len = 20
  
    Const raHours_Index = 32
    Const raHours_Len = 8
  
    Const decDegrees_Index = 42
    Const decDegrees_Len = 8
 
    Const objectType_Index = 52
    Const objectType_Len = 20
 
    Const maximumFOV_Index = 98
    Const maximumFOV_len = 8

    Const minimumFOV_Index = 108
    Const minimumFOV_len = 8
 
#End Region

    Private SDB_label As String
    Private SDB_raHours As String
    Private SDB_decDegrees As String
    Private SDB_objType As String
    Private SDB_MaxFOV As String
    Private SDB_MinFOV As String

    Public Sub New()

        Return
    End Sub

    Public Function Entry() As String
        Return (MakeNode())
    End Function

    Private Function MakeNode() As String
        'Construct a string entry for the SDB text file defintion from the publics
        Dim SDB_String = SDB_label
        SDB_String = SDB_String.PadRight(raHours_Index)
        SDB_String = SDB_String + SDB_raHours
        SDB_String = SDB_String.PadRight(decDegrees_Index)
        SDB_String = SDB_String + SDB_decDegrees
        SDB_String = SDB_String.PadRight(objectType_Index)
        SDB_String = SDB_String + SDB_objType
        SDB_String = SDB_String.PadRight(maximumFOV_Index)
        SDB_String = SDB_String + SDB_MaxFOV
        SDB_String = SDB_String.PadRight(minimumFOV_Index)
        SDB_String = SDB_String + SDB_MinFOV

        Return (SDB_String.ToCharArray)
    End Function

#Region "Field Properties"
    Public Property Label As String
        Get
            Return (SDB_label)
        End Get
        Set(value As String)
            value = value.TrimStart
            Dim slen = labelOrSearch_Len
            If value.Length > slen Then
                SDB_label = value.Remove(slen)
            End If
            If value.Length < slen Then
                SDB_label = value.PadRight(slen)
            End If
        End Set
    End Property

    Public Property raHours As String
        Get
            Return (SDB_raHours)
        End Get
        Set(value As String)
            value = value.TrimStart
            Dim slen = raHours_Len
            If value.Length > slen Then
                SDB_raHours = value.Remove(slen)
            End If
            If value.Length < slen Then
                SDB_raHours = value.PadRight(slen)
            End If
        End Set
    End Property

    Public Property decDegrees As String
        Get
            Return (SDB_decDegrees)
        End Get
        Set(value As String)
            value = value.TrimStart
            Dim slen = decDegrees_Len
            If value.Length > slen Then
                SDB_decDegrees = value.Remove(slen)
            End If
            If value.Length < slen Then
                SDB_decDegrees = value.PadRight(slen)
            End If
        End Set
    End Property

    Public Property ObjType As String
        Get
            Return (SDB_objType)
        End Get
        Set(value As String)
            value = value.TrimStart
            Dim slen = objectType_Len
            If value.Length > slen Then
                SDB_objType = value.Remove(slen)
            End If
            If value.Length < slen Then
                SDB_objType = value.PadRight(slen)
            End If
        End Set
    End Property

    Public Property MaxFOV As String
        Get
            Return (SDB_MaxFOV)
        End Get
        Set(value As String)
            value = value.TrimStart
            Dim slen = maximumFOV_len
            If value.Length > slen Then
                SDB_MaxFOV = value.Remove(slen)
            End If
            If value.Length < slen Then
                SDB_MaxFOV = value.PadRight(slen)
            End If
        End Set
    End Property

    Public Property MinFOV As String
        Get
            Return (SDB_MinFOV)
        End Get
        Set(value As String)
            value = value.TrimStart
            Dim slen = minimumFOV_len
            If value.Length > slen Then
                SDB_MinFOV = value.Remove(slen)
            End If
            If value.Length < slen Then
                SDB_MinFOV = value.PadRight(slen)
            End If
        End Set
    End Property


#End Region

End Class
