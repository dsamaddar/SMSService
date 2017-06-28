Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class clsSMSHistory

    Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("SMSCon").ConnectionString)
    Dim _SMSHistoryID, _UniqueID, _ReceiverName, _ReceiverNo, _SMSBody, _ApprovedBy, _ReferenceNo, _RejectedBy, _
    _LOGIN, _CSMSID, _REFERENCEID, _EntryBy As String

    Public Property SMSHistoryID() As String
        Get
            Return _SMSHistoryID
        End Get
        Set(ByVal value As String)
            _SMSHistoryID = value
        End Set
    End Property

    Public Property UniqueID() As String
        Get
            Return _UniqueID
        End Get
        Set(ByVal value As String)
            _UniqueID = value
        End Set
    End Property

    Public Property ReceiverName() As String
        Get
            Return _ReceiverName
        End Get
        Set(ByVal value As String)
            _ReceiverName = value
        End Set
    End Property

    Public Property ReceiverNo() As String
        Get
            Return _ReceiverNo
        End Get
        Set(ByVal value As String)
            _ReceiverNo = value
        End Set
    End Property

    Public Property SMSBody() As String
        Get
            Return _SMSBody
        End Get
        Set(ByVal value As String)
            _SMSBody = value
        End Set
    End Property

    Public Property ApprovedBy() As String
        Get
            Return _ApprovedBy
        End Get
        Set(ByVal value As String)
            _ApprovedBy = value
        End Set
    End Property

    Public Property ReferenceNo() As String
        Get
            Return _ReferenceNo
        End Get
        Set(ByVal value As String)
            _ReferenceNo = value
        End Set
    End Property

    Public Property RejectedBy() As String
        Get
            Return _RejectedBy
        End Get
        Set(ByVal value As String)
            _RejectedBy = value
        End Set
    End Property

    Public Property LOGIN() As String
        Get
            Return _LOGIN
        End Get
        Set(ByVal value As String)
            _LOGIN = value
        End Set
    End Property

    Public Property CSMSID() As String
        Get
            Return _CSMSID
        End Get
        Set(ByVal value As String)
            _CSMSID = value
        End Set
    End Property

    Public Property REFERENCEID() As String
        Get
            Return _REFERENCEID
        End Get
        Set(ByVal value As String)
            _REFERENCEID = value
        End Set
    End Property

    Public Property EntryBy() As String
        Get
            Return _EntryBy
        End Get
        Set(ByVal value As String)
            _EntryBy = value
        End Set
    End Property

    Dim _IsApproved, _IsSent, _IsRejected As Boolean

    Public Property IsApproved() As Boolean
        Get
            Return _IsApproved
        End Get
        Set(ByVal value As Boolean)
            _IsApproved = value
        End Set
    End Property

    Public Property IsSent() As Boolean
        Get
            Return _IsSent
        End Get
        Set(ByVal value As Boolean)
            _IsSent = value
        End Set
    End Property

    Public Property IsRejected() As Boolean
        Get
            Return _IsRejected
        End Get
        Set(ByVal value As Boolean)
            _IsRejected = value
        End Set
    End Property

    Dim _ApprovalDate, _SentOn, _RejectionDate, _EntryDate As DateTime

    Public Property ApprovalDate() As DateTime
        Get
            Return _ApprovalDate
        End Get
        Set(ByVal value As DateTime)
            _ApprovalDate = value
        End Set
    End Property

    Public Property SentOn() As DateTime
        Get
            Return _SentOn
        End Get
        Set(ByVal value As DateTime)
            _SentOn = value
        End Set
    End Property

    Public Property RejectionDate() As DateTime
        Get
            Return _RejectionDate
        End Get
        Set(ByVal value As DateTime)
            _RejectionDate = value
        End Set
    End Property

    Public Property EntryDate() As DateTime
        Get
            Return _EntryDate
        End Get
        Set(ByVal value As DateTime)
            _EntryDate = value
        End Set
    End Property

    Public Function fnInsertSMSHistory(ByVal SMS As clsSMSHistory) As Integer
        Try
            Dim cmd As SqlCommand = New SqlCommand("spInsertSMSHistory", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@UniqueID", SMS.UniqueID)
            cmd.Parameters.AddWithValue("@ReceiverName", SMS.ReceiverName)
            cmd.Parameters.AddWithValue("@ReceiverNo", SMS.ReceiverNo)
            cmd.Parameters.AddWithValue("@SMSBody", SMS.SMSBody)
            cmd.Parameters.AddWithValue("@EntryBy", SMS.EntryBy)
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

    Public Function fnGetPendingSMSForApproval() As DataSet
        Dim sp As String = "spGetPendingSMSForApproval"
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        Try
            con.Open()
            Using cmd As SqlCommand = New SqlCommand(sp, con)
                cmd.CommandType = CommandType.StoredProcedure
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

    Public Function fnGetPendingSMSForSending() As DataSet
        Dim sp As String = "spGetPendingSMSForSending"
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        Try
            con.Open()
            Using cmd As SqlCommand = New SqlCommand(sp, con)
                cmd.CommandType = CommandType.StoredProcedure
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

    Public Function fnGetSMSReport(ByVal DateFrom As DateTime, ByVal DateTo As DateTime) As DataSet
        Dim sp As String = "spGetSMSReport"
        Dim da As SqlDataAdapter = New SqlDataAdapter()
        Dim ds As DataSet = New DataSet()
        Try
            con.Open()
            Using cmd As SqlCommand = New SqlCommand(sp, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@DateFrom", DateFrom)
                cmd.Parameters.AddWithValue("@DateTo", DateTo)
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

    Public Function fnApproveSMS(ByVal SMS As clsSMSHistory) As Integer
        Try
            Dim cmd As SqlCommand = New SqlCommand("spApproveSMS", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SMSHistoryID", SMS.SMSHistoryID)
            cmd.Parameters.AddWithValue("@ApprovedBy", SMS.ApprovedBy)
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

    Public Function fnRejectSMS(ByVal SMS As clsSMSHistory) As Integer
        Try
            Dim cmd As SqlCommand = New SqlCommand("spRejectSMS", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@SMSHistoryID", SMS.SMSHistoryID)
            cmd.Parameters.AddWithValue("@RejectedBy", SMS.RejectedBy)
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

    Public Function fnSMSSentConfirmation(ByVal SMS As clsSMSHistory) As Integer
        Try
            Dim cmd As SqlCommand = New SqlCommand("spSMSSentConfirmation", con)
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@UniqueID", SMS.UniqueID)
            cmd.Parameters.AddWithValue("@ReferenceNo", SMS.ReferenceNo)
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
