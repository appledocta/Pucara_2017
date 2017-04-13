Imports System.Data.SqlClient
Imports System.Text.RegularExpressions


Public Class ProveedoresDatos
    Inherits conexion 'Incluimos la clase conexion 
    Dim cmd As New SqlCommand 'Variable para enviar peticiones a la BD

    Public Function mostrar() As DataTable
        Try
            conectado()

            cmd = New SqlCommand("select id_proveedor,cuit ,razon_social,direccion,telefono,celular,mail,cod_postal,habilitado,observacion from Proveedor")
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

    Public Function insertar(ByVal dts As ProveedoresLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insert into Proveedor(id_proveedor,cuit ,razon_social,direccion,telefono,celular,mail,cod_postal,habilitado,observacion)values (@id_proveedor,@cuit ,@razon_social,@direccion,@telefono,@celular,@mail,@cod_postal,@habilitado,@observacion)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@id_proveedor", dts.Id_proveedores)
            cmd.Parameters.AddWithValue("@cuit", dts.Cuit)
            cmd.Parameters.AddWithValue("@razon_social", dts.Razon_social)
            cmd.Parameters.AddWithValue("@direccion", dts.Direccion)
            cmd.Parameters.AddWithValue("@telefono", dts.Telefono)
            cmd.Parameters.AddWithValue("@celular", dts.Celular)
            cmd.Parameters.AddWithValue("@mail", dts.Mail)
            cmd.Parameters.AddWithValue("@cod_postal", dts.Cod_postal)
            cmd.Parameters.AddWithValue("@habilitado", dts.Habilitado)
            cmd.Parameters.AddWithValue("@observacion", dts.Observacion)

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

    Public Function editar(ByVal dts As ProveedoresLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("update Proveedor(id_proveedor,cuit ,razon_social,direccion,telefono,celular,mail,cod_postal,habilitado,observacion)values (@id_proveedor,@cuit ,@razon_social,@direccion,@telefono,@celular,@mail,@cod_postal,@habilitado,@observacion)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@id_proveedor", dts.Id_proveedores)
            cmd.Parameters.AddWithValue("@cuit", dts.Cuit)
            cmd.Parameters.AddWithValue("@razon_social", dts.Razon_social)
            cmd.Parameters.AddWithValue("@direccion", dts.Direccion)
            cmd.Parameters.AddWithValue("@telefono", dts.Telefono)
            cmd.Parameters.AddWithValue("@celular", dts.Celular)
            cmd.Parameters.AddWithValue("@mail", dts.Mail)
            cmd.Parameters.AddWithValue("@cod_postal", dts.Cod_postal)
            cmd.Parameters.AddWithValue("@habilitado", dts.Habilitado)
            cmd.Parameters.AddWithValue("@observacion", dts.Observacion)

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

    Public Function eliminar(ByVal dts As ProveedoresLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("delete Proveedor(id_proveedor,cuit ,razon_social,direccion,telefono,celular,mail,cod_postal,habilitado,observacion)values (@id_proveedor,@cuit ,@razon_social,@direccion,@telefono,@celular,@mail,@cod_postal,@habilitado,@observacion)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.Add("@id_proveedor", SqlDbType.Int).Value = dts.Id_proveedores
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

    Public Function validar_Mail(ByVal Mail As String) As Boolean
        ' retorna true o false   
        Return Regex.IsMatch(Mail, _
                  "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function
End Class
