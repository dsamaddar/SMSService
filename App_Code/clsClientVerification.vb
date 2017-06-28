Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class clsClientVerification

    Dim _SearchText, _AgreementNo, _VerifiedMobileNo As String

    Public Property SearchText() As String
        Get
            Return _SearchText
        End Get
        Set(ByVal value As String)
            _SearchText = value
        End Set
    End Property

    Public Property AgreementNo() As String
        Get
            Return _AgreementNo
        End Get
        Set(ByVal value As String)
            _AgreementNo = value
        End Set
    End Property

    Public Property VerifiedMobileNo() As String
        Get
            Return _VerifiedMobileNo
        End Get
        Set(ByVal value As String)
            _VerifiedMobileNo = value
        End Set
    End Property

    Public Function fnSearchForMobileVerificaiton(ByVal SearchText As String, ByVal con As SqlConnection) As DataSet
        Dim sp As String = "spSearchForMobileVerificaiton"
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        Try
            con.Open()
            Using cmd As SqlCommand = New SqlCommand(sp, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@SearchText", SearchText)
                da.SelectCommand = cmd
                da.Fill(ds)
                con.Close()
                Return ds
            End Using
        Catch ex As Exception
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Return Nothing
        End Try
    End Function

    Public Function fnUpdateVerifiedMobileNo(ByVal AgreementNo As String, ByVal VerifiedMobileNo As String, ByVal con As SqlConnection) As Integer
        Try
            Dim cmd As SqlCommand = New SqlCommand("spUpdateVerifiedMobileNo", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AgreementNo", AgreementNo)
            cmd.Parameters.AddWithValue("@VerifiedMobileNo", VerifiedMobileNo)
            cmd.ExecuteNonQuery()
            con.Close()
            Return 1
        Catch ex As Exception
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Return 0
        End Try
    End Function

End Class
