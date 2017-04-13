Imports System.Data.SqlClient

Public Class UsuariosDatos
    Inherits conexion 'Incluimos la clase conexion 
    Dim cmd As New SqlCommand 'Variable para enviar peticiones a la BD
    Public Function mostrar() As DataTable
        Try
            conectado()

            cmd = New SqlCommand("select Id_usuario,usuario,contrasena,Categoria,Habilitado,Id_permiso from Usuario")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable 'Crea una tabla en memoria 
                Dim da As New SqlDataAdapter(cmd) 'Nexo para conectar BD y mostrar en la App 
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function

    Public Function insertar(ByVal dts As UsuariosLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insert into usuario(id_usuario,usuario,contrasena,categoria,habilitado)values (@id_usuario,@usuario,@contrasena,@categoria,@habilitado)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@id_usuario", dts.Id_usuario)
            cmd.Parameters.AddWithValue("@usuario", dts.Nom_usuario)
            cmd.Parameters.AddWithValue("@contrasena", dts.Password)
            cmd.Parameters.AddWithValue("@categoria", dts.Categoria)
            cmd.Parameters.AddWithValue("@habilitado", dts.Habilitado)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function editar(ByVal dts As UsuariosLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand(" update usuario(id_usuario,usuario,contrasena,categoria,habilitado)values (@id_usuario,@usuario,@contrasena,@categoria,@habilitado)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@id_usuario", dts.Id_usuario)
            cmd.Parameters.AddWithValue("@usuario", dts.Nom_usuario)
            cmd.Parameters.AddWithValue("@contrasena", dts.Password)
            cmd.Parameters.AddWithValue("@categoria", dts.Categoria)
            cmd.Parameters.AddWithValue("@habilitado", dts.Habilitado)


            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function eliminar(ByVal dts As UsuariosLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("delete usuario(id_usuario,usuario,contrasena,categoria,habilitado,id_permiso)values (@id_usuario,@usuario,@contrasena,@categoria,@habilitado,@id_permiso)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = dts.Id_usuario
            If cmd.ExecuteNonQuery Then
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
