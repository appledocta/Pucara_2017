Public Class ProveedoresLogica

    Public _id_proveedores As Integer
    Public Property Id_proveedores() As Integer
        Get
            Return _id_proveedores
        End Get
        Set(ByVal value As Integer)
            _id_proveedores = value
        End Set
    End Property

    Public _cuit As String
    Public Property Cuit() As String
        Get
            Return _cuit
        End Get
        Set(ByVal value As String)
            _cuit = value
        End Set
    End Property

    Public _razon_social As String
    Public Property Razon_social() As String
        Get
            Return _razon_social
        End Get
        Set(ByVal value As String)
            _razon_social = value
        End Set
    End Property

    Public _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Public _telefono As Integer
    Public Property Telefono() As Integer
        Get
            Return _telefono
        End Get
        Set(ByVal value As Integer)
            _telefono = value
        End Set
    End Property

    Public _celular As Integer
    Public Property Celular() As Integer
        Get
            Return _celular
        End Get
        Set(ByVal value As Integer)
            _celular = value
        End Set
    End Property

    Public _mail As String
    Public Property Mail() As String
        Get
            Return _mail
        End Get
        Set(ByVal value As String)
            _mail = value
        End Set
    End Property

    Public _cod_postal As Integer
    Public Property Cod_postal() As Integer
        Get
            Return _cod_postal
        End Get
        Set(ByVal value As Integer)
            _cod_postal = value
        End Set
    End Property

    Public _habilitado As String
    Public Property Habilitado() As String
        Get
            Return _habilitado
        End Get
        Set(ByVal value As String)
            _habilitado = value
        End Set
    End Property

    Public _observacion As String
    Public Property Observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal value As String)
            _observacion = value
        End Set
    End Property

End Class
