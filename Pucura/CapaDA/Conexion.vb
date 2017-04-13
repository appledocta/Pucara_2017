Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Configuration

Public Class ConexionDA
    Public Shared conn As New SqlConnection
    Public Shared Function Conectado()
        Try
            '''''con = New SqlConnection("Server=(local);Database=Proyecto;Trusted_Connection=True")
            ''''' conn = New SqlConnection("Data Source=LJBLANCO\SQLSERVER2008;Initial Catalog=LocalCuadros;Integrated Security=True")            'Lidio
            ''''''conn = New SqlConnection("Data source=DESKTOP-RA5UK2L\SQLSERVER;initial catalog=LocalCuadros;integrated security=true")       'Cristian
            conn = New SqlConnection("Data source=(local);initial catalog=Pucara;integrated security=true") 'Sancho
            conn.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function Desconectado()
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    'Lidio
    Public Function abrir() As SqlConnection
        Dim con As String
        Dim scon As SqlConnection
        'con = "Data Source=PUESTO155;Initial Catalog=EsquemaFisico;Integrated"
        'con = "Data Source=LJBLANCO\SQLSERVER2008;Initial Catalog=LocalCuadros;Integrated Security=True"            'Lidio
        'con = "Data Source=DESKTOP-RA5UK2L\SQLSERVER;Initial Catalog=LocalCuadros;Integrated Security=True"       'Cristian

        con = "Data source=(local);initial catalog=Pucara;integrated security=true" 'Sancho
        scon = New SqlConnection(con)
        scon.Open()
        Return scon
    End Function

End Class

