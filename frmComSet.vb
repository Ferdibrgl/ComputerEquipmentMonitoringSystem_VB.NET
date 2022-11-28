Public Class frmComSet
    Dim CompSetID = 0
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtComputerSet.Text = "" Then
            MsgBox("Field is required.", MsgBoxStyle.Exclamation)
        Else
            sql = "Select * From tblcompset WHERE CompSetID = " & CompSetID

            sqladd = "INSERT INTO `tblcompset` (`ComputerSet` ) VALUES ('" & txtComputerSet.Text & "' )"

            sqledit = "UPDATE `tblcompset` SET `ComputerSet`='" & txtComputerSet.Text & "' WHERE CompSetID=" & CompSetID

            save_or_update(sql, sqladd, sqledit, "ComputerSet has been updated in the database.", "New ComputerSet has been saved in the database.")

            Call frmComputerSet_Load(sender, e)

        End If
    End Sub

    Private Sub frmComputerSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "Select CompSetID,`ComputerSet` From tblcompset"
        reloadDtg(sql, dtglist)

        txtComputerSet.Text = ""
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try
            With dtglist
                CompSetID = .CurrentRow.Cells(0).Value
                txtComputerSet.Text = .CurrentRow.Cells(1).Value
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        CompSetID = 0
        txtComputerSet.Clear()
        sql = "Select CompSetID,`ComputerSet`  From tblcompset"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = "Select CompSetID,`ComputerSet`  From tblcompset WHERE ComputerSet Like '%" & txtSearch.Text & "%'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub dtglist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.Click
        Try
            With dtglist
                CompSetID = .CurrentRow.Cells(0).Value
                txtComputerSet.Text = .CurrentRow.Cells(1).Value
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class