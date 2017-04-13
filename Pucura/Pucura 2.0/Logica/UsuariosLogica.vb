Public Class UsuariosLogica

    Public _idusuario As Integer
    Public Property Id_usuario() As Integer
        Get
            Return _idusuario
        End Get
        Set(ByVal value As Integer)
            _idusuario = value
        End Set
    End Property

    Public _nomusuario As String
    Public Property Nom_usuario() As String
        Get
            Return _nomusuario
        End Get
        Set(ByVal value As String)
            _nomusuario = value
        End Set
    End Property

    Public _password As String
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Public _categoria As String
    Public Property Categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
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

    Public _id_permiso As Integer
    Public Property Id_permiso() As Integer
        Get
            Return _id_permiso
        End Get
        Set(ByVal value As Integer)
            _id_permiso = value
        End Set
    End Property

    'constructores 1 en blanco y otro con los datos
    Public Sub New()

    End Sub

    Public Sub New(ByVal Id_usuario As Integer, ByVal Nom_usuario As String, ByVal Password As String, ByVal Categoria As String, ByVal Habilitado As Integer)
        _idusuario = Id_usuario
        _nomusuario = Nom_usuario
        _password = Password
        _categoria = Categoria
        _habilitado = Habilitado


    End Sub

End Class
