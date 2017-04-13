Imports System.Data.SqlClient

Public Class clientes
    Inherits conexion 'Incluimos la clase conexion 
    Dim cmd As New SqlCommand 'Variable para enviar peticiones a la BD
    Public Function mostrar() As DataTable
        Try
            conectado()

            cmd = New SqlCommand("select Nro_doc, id_tipo_dni ,Nombre,Apellido,Fecha_nac,Fecha_alta 'Fecha de Alta',direccion,telefono,mail,Habilitado,observacion  from Cliente")
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

    Public Function insertar(ByVal dts As ClientesLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insert into cliente(nro_doc,nombre,apellido,fecha_nac,fecha_alta,direccion,telefono,celular,mail,habilitado,observacion)values (@nro_doc,@nombre,@apellido,@fecha_nac,@fecha_alta,@direccion,@telefono,@celular,@mail,@habilitado,@observacion)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@nro_doc", dts.Nro_Doc)
            cmd.Parameters.AddWithValue("@nombre", dts.Nombre)

            cmd.Parameters.AddWithValue("@apellido", dts.Apellido)
            cmd.Parameters.AddWithValue("@fecha_nac", dts.Fecha_nac)

            cmd.Parameters.AddWithValue("@fecha_alta", dts.Fecha_alta)
            cmd.Parameters.AddWithValue("@direccion", dts.Direccion)
            cmd.Parameters.AddWithValue("@telefono", dts.Telefono)
            cmd.Parameters.AddWithValue("@celular", dts.Celular)
            cmd.Parameters.AddWithValue("@mail", dts.Mail)
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

    Public Function editar(ByVal dts As ClientesLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("update cliente(nro_doc,nombre,apellido,fecha_nac,fecha_alta,direccion,telefono,celular,mail,habilitado,observacion)values (@nro_doc,@nombre,@apellido,@fecha_nac,@fecha_alta,@direccion,@telefono,@celular,@mail,@habilitado,@observacion)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.AddWithValue("@nro_doc", dts.Nro_Doc)
            cmd.Parameters.AddWithValue("@nombre", dts.Nombre)

            cmd.Parameters.AddWithValue("@apellido", dts.Apellido)
            cmd.Parameters.AddWithValue("@fecha_nac", dts.Fecha_nac)

            cmd.Parameters.AddWithValue("@fecha_alta", dts.Fecha_alta)
            cmd.Parameters.AddWithValue("@direccion", dts.Direccion)
            cmd.Parameters.AddWithValue("@telefono", dts.Telefono)
            cmd.Parameters.AddWithValue("@celular", dts.Celular)
            cmd.Parameters.AddWithValue("@mail", dts.Mail)
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

    Public Function eliminar(ByVal dts As ClientesLogica) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("delete cliente(nro_doc,nombre,apellido,fecha_nac,fecha_alta,direccion,telefono,celular,mail,habilitado,observacion)values (@nro_doc,@nombre,@apellido,@fecha_nac,@fecha_alta,@direccion,@telefono,@celular,@mail,@habilitado,@observacion)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = cnn

            cmd.Parameters.Add("@nro_doc", SqlDbType.VarChar, 8).Value = dts.Nro_Doc
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