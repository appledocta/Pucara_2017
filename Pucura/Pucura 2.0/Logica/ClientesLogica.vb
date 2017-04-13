Public Class ClientesLogica

    Public _nroDoc As String
    Public Property Nro_Doc() As String
        Get
            Return _nroDoc
        End Get
        Set(ByVal value As String)
            _nroDoc = value
        End Set
    End Property

    Public _Tipo_dni As Integer
    Public Property Tipo_dni() As Integer
        Get
            Return _Tipo_dni
        End Get
        Set(ByVal value As Integer)
            _Tipo_dni = value
        End Set
    End Property

    Public _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Public _fecha_nac As Date
    Public Property Fecha_nac() As Date
        Get
            Return _fecha_nac
        End Get
        Set(ByVal value As Date)
            _fecha_nac = value
        End Set
    End Property

    Public _fecha_alta As Date
    Public Property Fecha_alta() As Date
        Get
            Return _fecha_alta
        End Get
        Set(ByVal value As Date)
            _fecha_alta = value
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

    Public _habilitado As Integer
    Public Property Habilitado() As Integer
        Get
            Return _habilitado
        End Get
        Set(ByVal value As Integer)
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

    'constructores 1 en blanco y otro con los datos
    Public Sub New()

    End Sub

    Public Sub New(ByVal Nro_Doc As String, ByVal Nombre As String, ByVal Apellido As String, ByVal Fecha_nac As Date, ByVal Fecha_alta As Date, ByVal Direccion As String, ByVal Telefono As Integer, ByVal Celular As Integer, ByVal Mail As String, ByVal Observacion As String)
        _nroDoc = Nro_Doc
        _nombre = Nombre
        _apellido = Apellido
        _direccion = Direccion
        _telefono = Telefono
        _celular = Celular
        _mail = Mail
        _fecha_nac = Fecha_nac
        _fecha_alta = Fecha_alta
        _observacion = Observacion

    End Sub
End Class
