Public Class frmParts

    Dim PartsID = 0
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtParts.Text = "" Then
            MsgBox("Field is required.", MsgBoxStyle.Exclamation)
        Else
            sql = "Select * From tblparts WHERE PartsID = " & PartsID

            sqladd = "INSERT INTO `tblparts` (`Parts` ) VALUES ('" & txtParts.Text & "' )"

            sqledit = "UPDATE `tblparts` SET `Parts`='" & txtParts.Text & "' WHERE PartsID=" & PartsID

            save_or_update(sql, sqladd, sqledit, "Parts has been updated in the database.", "New Parts has been saved in the database.")

            Call frmParts_Load(sender, e)

        End If
    End Sub

    Private Sub frmParts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "Select PartsID,`Parts`   From tblparts"
        reloadDtg(sql, dtglist)

        txtParts.Text = ""
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try
            With dtglist
                PartsID = .CurrentRow.Cells(0).Value
                txtParts.Text = .CurrentRow.Cells(1).Value
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        PartsID = 0
        txtParts.Clear()
        sql = "Select PartsID,`Parts`  From tblparts"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = "Select PartsID,`Parts`  From tblparts WHERE Parts Like '%" & txtSearch.Text & "%'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub dtglist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.Click
        Try
            With dtglist
                PartsID = .CurrentRow.Cells(0).Value
                txtParts.Text = .CurrentRow.Cells(1).Value
            End With
        Catch ex As Exception

        End Try
    End Sub

  
End Class