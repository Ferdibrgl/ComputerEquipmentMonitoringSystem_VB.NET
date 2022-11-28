Public Class frmTranferItems

    Private Sub frmTranferItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cbo_fill(cboLocation, "Location", "LocationID", "tbllocation")
        cbo_fill(cboCompSet, "ComputerSet", "CompSetID", "tblcompset")

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

        sql = "SELECT * " & _
          " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " _
           & "WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` " _
           & "AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND Status='Good' " _
           & "AND  i.`LocationID`=" & cboLocation.SelectedValue & " AND i.CompSetID=" & cboCompSet.SelectedValue & " AND Parts='" & txtParts.Text & "'"
        reloadtxt(sql)
        If dt.Rows.Count > 0 Then
            MsgBox(txtParts.Text & " already exist in the competer", MsgBoxStyle.Exclamation)
        Else 
            sql = "INSERT INTO  `tbltransfer` (`ItemID`, `Item`, `Parts`, `LocationFROM`, `LocationTO`, `PCFrom`, `PCTo`, `TransferDate`) " & _
            " VALUES (" & dtgList.CurrentRow.Cells(0).Value & ",'" & txtItems.Text & "','" & txtParts.Text & "','" & txtLocated.Text & "','" & cboLocation.Text & "','" & txtCompSet.Text & "','" & cboCompSet.Text & "',DATE(NOW()))"
            result = create(sql) 
            If result = True Then
                sql = "UPDATE `tblitems` SET `LocationID`=" & cboLocation.SelectedValue & ",`CompSetID`=" & cboCompSet.SelectedValue & ",`Remarks`='Transfered' WHERE `ItemID`=" & dtgList.CurrentRow.Cells(0).Value
                updates(sql)


                cbo_fill(cboLocation, "Location", "LocationID", "tbllocation")
                cbo_fill(cboCompSet, "ComputerSet", "CompSetID", "tblcompset")

                sql = "SELECT ItemID, `Parts`,`Location`, `ComputerSet` FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND Status='Good'"
                reloadDtg(sql, dtgList)
                dtgList.Columns(0).Visible = False
                MsgBox("Computer parts has been transferred.")
                cleartext(GroupBox1)
            End If
        End If
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