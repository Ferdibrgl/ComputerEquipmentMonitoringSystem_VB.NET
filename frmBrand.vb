Public Class frmBrand
    Dim BrandID = 0
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtBrand.Text = "" Then
            MsgBox("Field is required.", MsgBoxStyle.Exclamation)
        Else
            sql = "Select * From tblbrand WHERE BrandID = " & BrandID

            sqladd = "INSERT INTO `tblBrand` (`Brand`,`Description`) VALUES ('" & txtBrand.Text & "','" & txtDesc.Text & "')"

            sqledit = "UPDATE `tblBrand` SET `Brand`='" & txtBrand.Text & "',`Description`='" & txtDesc.Text & "' WHERE BrandID=" & BrandID

            save_or_update(sql, sqladd, sqledit, "Brand has been updated in the database.", "New brand has been saved in the database.")

            Call frmBrand_Load(sender, e)

        End If
    End Sub

    Private Sub frmBrand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "Select BrandID,`Brand`,`Description`  From tblbrand"
        reloadDtg(sql, dtglist)

        txtBrand.Text = ""
    End Sub

    Private Sub dtglist_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.DoubleClick
        Try
            With dtglist
                BrandID = .CurrentRow.Cells(0).Value
                txtBrand.Text = .CurrentRow.Cells(1).Value
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        BrandID = 0
        txtBrand.Clear()
        txtDesc.Clear()
        sql = "Select BrandID,`Brand`,`Description` From tblbrand"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = "Select BrandID,`Brand`,`Description`  From tblbrand WHERE Brand Like '%" & txtSearch.Text & "%'"
        reloadDtg(sql, dtglist)
    End Sub

    Private Sub dtglist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtglist.Click
        Try
            With dtglist
                BrandID = .CurrentRow.Cells(0).Value
                txtBrand.Text = .CurrentRow.Cells(1).Value
                txtDesc.Text = .CurrentRow.Cells(2).Value
            End With
        Catch ex As Exception

        End Try
    End Sub

End Class