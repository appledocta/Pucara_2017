Imports System.Data.SqlClient
Imports CapaNE

Public Class CanchaDA
    Inherits ConexionDA
    Dim cmd As New SqlCommand

    '************************ FUNCION MOSTRAR Cancha*******************
    Public Function Mostrar_cancha() As DataTable
        Try
            Conectado()
            cmd = New SqlCommand("select C.id_cancha, C.Habilitado 'Habilitado',C.Precio_cancha 'Precio de Cancha',C.FechaActPrecio() 'Fecha de ultima actualizacion',T.Descripcion  from Cancha as C,TipoCancha as T where C.id_cancha=T.Id_Cancha")
            cmd.CommandType = CommandType.Text

            cmd.Connection = conn

            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd) ''adaptador con bd
                da.Fill(dt)
                Return dt
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            Desconectado()
        End Try
    End Function

    '****************************FUNCION INSERTAR CANCHA **************************************
    Public Function Insertar_Cancha(ByVal dts As CanchaNE) As Boolean
        Try
            Conectado()
            cmd = New SqlCommand("insert into cancha (id_cancha,habilitado,precio_cancha,fechaActPrecio,descripcion) values(@id_cancha,@habilitado,@precio_cancha,@fechaActPrecio,@descripcion)")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            'cmd.Parameters.AddWithValue("@Id_cancha", dts.id_cancha)
            cmd.Parameters.AddWithValue("@Habilitado", dts.Habilitado)
            cmd.Parameters.AddWithValue("@precio_cancha", dts.Precio_cancha)
            cmd.Parameters.AddWithValue("@FechaActPrecio", dts.FechaActPrecio)
            cmd.Parameters.AddWithValue("@Descripcion", dts.Descripcion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            Desconectado()
        End Try

    End Function

    '******************************FUNCION EDITAR CANCHA*****************************************
    Public Function Editar_Cancha(ByVal dts As CanchaNE) As Boolean
        Try
            Conectado()
            cmd = New SqlCommand("update cancha set habilitado=@habilitado,precio_cancha=@precio_cancha,fechaActPrecio=fechaActPrecio,descripcion=@descripcion")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            cmd.Parameters.AddWithValue("@habilitado", dts.Habilitado)
            cmd.Parameters.AddWithValue("precio_cancha", dts.Precio_cancha)
            cmd.Parameters.AddWithValue("@fechaActPrecio", dts.FechaActPrecio)
            cmd.Parameters.AddWithValue("@Descripcion", dts.Descripcion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            Desconectado()
        End Try
    End Function

    '************************************FUNCION INHABILITAR CANCHA ***********************
    Public Function Inhabilitar_cancha(ByVal dts As CanchaNE) As Boolean
        Try
            Conectado()
            cmd = New SqlCommand("update cancha set habilitado=0 where id_cancha=@id_cancha")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            cmd.Parameters.AddWithValue("@Id_cancha", SqlDbType.Int).Value = dts.Id_Cancha
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            Desconectado()
        End Try
    End Function

    '*************************************FUNCION HABILITAR CANCHA***************************
    Public Function Habilitar_cancha(ByVal dts As CanchaNE) As Boolean
        Try
            Conectado()
            cmd = New SqlCommand("update cancha set habilitado=1 where id_cancha=@id_cancha")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            cmd.Parameters.AddWithValue("@id_cancha", SqlDbType.Int).Value = dts.Id_Cancha

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            Desconectado()
        End Try
    End Function
    '****************************************FUNCION BUSCAR CANCHA*******************************
    Public Function Buscar_cancha(ByVal dts As CanchaNE) As Boolean
        Try
            Conectado()
            cmd = New SqlCommand("select * from cancha where id_cancha=@id_cancha")
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            cmd.Parameters.AddWithValue("@Id_cancha", dts.Id_Cancha)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            Desconectado()
        End Try
    End Function
End Class

