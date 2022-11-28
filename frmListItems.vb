Public Class frmListItems

    Private Sub frmListItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID"
        reloadDtg(sql, DataGridView1)
        DataGridView1.Columns(0).Visible = False
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        sql = "SELECT  ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status " _
        & " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID " _
        & "AND (Barcode Like '%" & txtSearch.Text & "%' OR Parts Like '%" _
        & txtSearch.Text & "%' OR Brand Like '%" & txtSearch.Text & "%' OR i.Description Like '%" _
        & txtSearch.Text & "%' OR Location Like '%" & txtSearch.Text & "%')"
        reloadDtg(sql, DataGridView1)
        DataGridView1.Columns(0).Visible = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        With frmItem
            .ItemID = DataGridView1.CurrentRow.Cells(0).Value
            sql = "SELECT *,i.Description as 'Desc'  FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " _
            & "WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND ItemID=" & DataGridView1.CurrentRow.Cells(0).Value
            reloadtxt(sql)
            .txtBarcode.Text = dt.Rows(0).Item("Barcode")
            .cboParts.Text = dt.Rows(0).Item("Parts")
            .cboBrand.Text = dt.Rows(0).Item("Brand")
            .txtDescription.Text = dt.Rows(0).Item("Desc")
            .cboLocation.Text = dt.Rows(0).Item("Location")
            .cboCompSet.Text = dt.Rows(0).Item("ComputerSet")

            .Show()
            .Focus()

        End With
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        sql = "SELECT  ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status " _
    & "FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l ,tblcompset c " _
    & "WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID " _
    & "AND (Barcode Like '%" & txtSearch.Text & "%' OR Parts Like '%" _
    & txtSearch.Text & "%' OR Brand Like '%" & txtSearch.Text & "%' OR i.Description Like '%" _
    & txtSearch.Text & "%' OR Location Like '%" & txtSearch.Text & "%') AND Status='" & ComboBox1.Text & "'"
        reloadDtg(sql, DataGridView1)
        DataGridView1.Columns(0).Visible = False
    End Sub
End Class