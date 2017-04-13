Public Class frmCliente

    Private dt As New DataTable

    Private Sub frmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mostrar()


    End Sub
    Public Sub limpiar()
        btnGuardar.Visible = True
        btnEditar.Visible = False
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
        txtNroDoc.Text = ""
        txtTelefono.Text = ""
        txtCelular.Text = ""
        txtMail.Text = ""
        txtDescripcion.Text = ""


    End Sub
    Private Sub mostrar()
        Try
            Dim func As New clientes
            dt = func.mostrar 'dt llama al procedimiento mostrar
            dgvListado.Columns.Item("Eliminar").Visible = False 'desabilito la columna listado, la ocultamos

            If dt.Rows.Count <> 0 Then
                dgvListado.DataSource = dt
                txtBuscar.Enabled = True
                dgvListado.ColumnHeadersVisible = True
                lkNoexiste.Visible = False

            Else

                dgvListado.DataSource = Nothing
                txtBuscar.Enabled = False
                dgvListado.ColumnHeadersVisible = False
                lkNoexiste.Visible = True


            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        btnNuevo.Visible = True
        btnEditar.Visible = False

        buscar()
    End Sub

    Private Sub buscar()
        Try
            Dim ds As New DataSet 'variable como dataset copia el datatable
            ds.Tables.Add(dt.Copy)
            Dim dv As New DataView(ds.Tables(0))

            dv.RowFilter = cmbTipo.Text & "like'% " & txtBuscar.Text & "%"



            If dv.Count <> 0 Then
                lkNoexiste.Visible = False
                dgvListado.DataSource = dv
                ocultar_columnas()

            Else

                lkNoexiste.Visible = True
                dgvListado.DataSource = Nothing

            End If
        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub ocultar_columnas()
        dgvListado.Columns(1).Visible = False

    End Sub

  
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar()
        mostrar()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If dtpFechaAlta.Value.Date <= dtpFechaNac.Value.Date Then
            MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha de alta!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Me.ValidateChildren = True And txtNroDoc.Text <> "" And txtNombre.Text <> "" And txtApellido.Text <> "" And txtTelefono.Text <> "" And txtCelular.Text <> "" And txtMail.Text <> "" Then
            Try
                Dim dts As New ClientesLogica
                Dim func As New clientes

                dts._nroDoc = txtNroDoc.Text

                dts._nombre = txtNombre.Text
                dts._apellido = txtApellido.Text
                dts._direccion = txtDireccion.Text
                dts._telefono = txtTelefono.Text
                dts._celular = txtCelular.Text
                dts._mail = txtMail.Text
                dts._fecha_nac = dtpFechaNac.Value
                dts._fecha_alta = dtpFechaAlta.Value
                dts._observacion = txtDescripcion.Text

                dts._habilitado = 0

                If func.insertar(dts) Then
                    MessageBox.Show("Cliente cargado correctamente!", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    mostrar()
                    limpiar()
                Else
                    MessageBox.Show("Cliente no fue registrado, intente nuevamente!", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    mostrar()
                    limpiar()

                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Falta ingresar algunos datos!", "Guardando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub dgvListado_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellClick
        txtNroDoc.Text = dgvListado.SelectedCells.Item(1).Value
        txtNombre.Text = dgvListado.SelectedCells.Item(2).Value
        txtApellido.Text = dgvListado.SelectedCells.Item(3).Value
        txtDireccion.Text = dgvListado.SelectedCells.Item(4).Value
        txtTelefono.Text = dgvListado.SelectedCells.Item(5).Value
        txtCelular.Text = dgvListado.SelectedCells.Item(6).Value
        txtMail.Text = dgvListado.SelectedCells.Item(7).Value

        txtDescripcion.Text = dgvListado.SelectedCells.Item(8).Value

        btnEditar.Visible = True
        btnGuardar.Visible = False

    End Sub

   Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click

        Dim result As DialogResult

        result = MessageBox.Show("Relmente desea editar los datos del cliente", "Modificando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

        If result = DialogResult.OK Then


            If dtpFechaAlta.Value.Date <= dtpFechaNac.Value.Date Then
                MessageBox.Show("La fecha de nacimiento no puede ser mayor a la fecha de alta!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If Me.ValidateChildren = True And txtNroDoc.Text <> "" And txtNombre.Text <> "" And txtApellido.Text <> "" And txtTelefono.Text <> "" And txtCelular.Text <> "" And txtMail.Text <> "" Then
                Try
                    Dim dts As New ClientesLogica
                    Dim func As New clientes

                    dts._nroDoc = txtNroDoc.Text
                    dts._nombre = txtNombre.Text
                    dts._apellido = txtApellido.Text
                    dts._direccion = txtDireccion.Text
                    dts._telefono = txtTelefono.Text
                    dts._celular = txtCelular.Text
                    dts._mail = txtMail.Text
                    dts._fecha_nac = dtpFechaNac.Value
                    dts._fecha_alta = dtpFechaAlta.Value
                    dts._observacion = txtDescripcion.Text

                    dts._habilitado = 0

                    If func.editar(dts) Then
                        MessageBox.Show("Cliente modificado correctamente!", "Modificando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        mostrar()
                        limpiar()
                    Else
                        MessageBox.Show("Cliente no fue modificado, intente nuevamente!", "Modificando registros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        mostrar()
                        limpiar()

                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MessageBox.Show("Falta ingresar algunos datos!", "Modificando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        Dim result As DialogResult

        result = MessageBox.Show("Realmente desea eliminar los clientes seleccionados?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        If result = DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In dgvListado.Rows
                    Dim marcado As Boolean = Convert.ToBoolean(row.Cells("Eliminar").Value)
                    If marcado Then
                        Dim onekey As Integer = Convert.ToInt32(row.Cells("nro_doc").Value)
                        Dim vdb As New ClientesLogica
                        Dim func As New clientes
                        vdb.Nro_Doc = onekey

                        If func.eliminar(vdb) Then
                        Else
                            MessageBox.Show("Cliente no fue eliminado", "Eliminando Registros", MessageBoxButtons.OK, MessageBoxIcon.Question)
                        End If
                    End If
                Next
                Call mostrar()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MessageBox.Show("Cancelando eliminacion de registros", "Eliminando Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call mostrar()

        End If
        Call limpiar()

    End Sub

    Private Sub dgvListado_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListado.CellContentClick
        If e.ColumnIndex = Me.dgvListado.Columns.Item("Eliminar").Index Then
            Dim chkcell As DataGridViewCheckBoxCell = Me.dgvListado.Rows(e.RowIndex).Cells("Eliminar")
            chkcell.Value = Not chkcell.Value


        End If
    End Sub

    Private Sub cbeliminar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbeliminar.CheckedChanged
        If cbeliminar.CheckState = CheckState.Checked Then
            dgvListado.Columns.Item("Eliminar").Visible = True
        Else
            dgvListado.Columns.Item("Eliminar").Visible = False
        End If
    End Sub
End Class