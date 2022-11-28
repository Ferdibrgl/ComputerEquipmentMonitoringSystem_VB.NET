Public Class frmDamage
    Private Sub frmTranferItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sql = "SELECT ItemID, `Parts`,`Location`, `ComputerSet` FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND Status='Good'"
        reloadDtg(sql, dtgList)
        dtgList.Columns(0).Visible = False
    End Sub


    Private Sub dtgList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgList.Click
        Try
            sql = "SELECT *,i.Description as ItemDesc " & _
            " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " _
             & "WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` " _
             & "AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND Status='Good' AND ItemID=" & dtgList.CurrentRow.Cells(0).Value
            reloadtxt(sql)

            With dt.Rows(0)
                txtBarcode.Text = .Item("Barcode")
                txtBrand.Text = .Item("Brand")
                txtItems.Text = .Item("ItemDesc")
                txtParts.Text = .Item("Parts")
                txtLocated.Text = .Item("Location")
                txtCompSet.Text = .Item("ComputerSet")
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click


        If txtBarcode.Text = "" Then
            MsgBox("Select the computer parts you want to transfer.", MsgBoxStyle.Exclamation)
            Return
        End If



        sql = "UPDATE `tblitems` SET `Status`='Damaged',RecievedDate = Now() WHERE `ItemID`=" & dtgList.CurrentRow.Cells(0).Value
        updates(sql)

        sql = "SELECT ItemID, `Parts`,`Location`, `ComputerSet` FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND Status='Good'"
        reloadDtg(sql, dtgList)
        dtgList.Columns(0).Visible = False
        MsgBox("Computer parts has been damaged.")
        cleartext(GroupBox1)

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = "SELECT ItemID, `Parts`,`Location`, `ComputerSet` " _
        & "FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " _
        & "WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " _
        & "AND i.CompSetID=c.CompSetID AND Status='Good' AND (Parts Like '%" & txtSearch.Text _
        & "%' OR Location Like '%" & txtSearch.Text & "%' OR ComputerSet Like '%" & txtSearch.Text _
        & "%' OR CONCAT(Parts,' ',ComputerSet,' ', Location) LIKE '%" & txtSearch.Text & "%')"
        reloadDtg(sql, dtgList)
        dtgList.Columns(0).Visible = False
    End Sub
End Class