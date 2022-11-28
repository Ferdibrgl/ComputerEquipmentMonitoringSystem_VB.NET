Public Class frmLocation


    Dim LocationID = 0
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtLocation.Text = "" Then
            MsgBox("Field is required.", MsgBoxStyle.Exclamation)
        Else
            sql = "Select * From tbllocation WHERE LocationID = " & LocationID

            sqladd = "INSERT INTO `tbllocation` (`Location` ) VALUES ('" & txtLocation.Text & "' )"

            sqledit = "UPDATE `tbllocation` SET `Location`='" & txtLocation.Text & "' WHERE LocationID=" & LocationID

            save_or_update(sql, sqladd, sqledit, "Location has been updated in the database.", "New Location has been saved in the database.")

            Call frmLocation_Load(sender, e)

        End If
    End Sub

    Private Sub frmLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "Select LocationID,`Location`   From tbllocation"
        reloadDtg(sql, dtglist)

        txtLocation.Text = ""
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try
            With dtglist
                LocationID = .CurrentRow.Cells(0).Value
                txtLocation.Text = .CurrentRow.Cells(1).Value
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        LocationID = 0
        txtLocation.Clear()
        sql = "Select LocationID,`Location`  From tbllocation"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = "Select LocationID,`Location`  From tbllocation WHERE Location Like '%" & txtSearch.Text & "%'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub dtglist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.Click
        Try
            With dtglist
                LocationID = .CurrentRow.Cells(0).Value
                txtLocation.Text = .CurrentRow.Cells(1).Value
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class