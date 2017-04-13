Imports System.Data.SqlClient

Public Class conexion

    Protected cnn As New SqlConnection
    Public id_usuario As Integer

    'Funcion para conectarme a la BD
    Protected Function conectado()

        Try
            cnn = New SqlConnection("data source=DESKTOP-RA5UK2L\SQLSERVER;initial catalog= Pucara; integrated security = true")
            cnn.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    'Funcion para desconectarme de la BD
    Protected Function desconectado()
        Try
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function
End Class
