Public Class frmItem
    Public ItemID As Integer = 0
    Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        If ItemID = 0 Then
            cleartext(Me)

            cbo_fill(cboBrand, "Brand", "BrandID", "tblbrand")
            cbo_fill(cboParts, "Parts", "PartsID", "tblparts")
            cbo_fill(cboLocation, "Location", "LocationID", "tbllocation")
            cbo_fill(cboCompSet, "ComputerSet", "CompSetID", "tblcompset")
        End If
      

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtBarcode.Text = "" Or txtDescription.Text = "" Then
                MsgBox("Fields are required.", MsgBoxStyle.Exclamation)
            Else
                sql = "SELECT * FROM `tblitems` " & _
                    " WHERE `PartsID`=" & cboParts.SelectedValue & " AND `LocationID`=" & cboLocation.SelectedValue & " AND `CompSetID`=" & cboCompSet.SelectedValue & ""
                reloadtxt(sql)

                If dt.Rows.Count > 0 Then
                    MsgBox(cboParts.Text & " is already exist in the computer ", MsgBoxStyle.Exclamation)
                Else
                    sql = "Select * From tblitems WHERE ItemID = " & ItemID

                    sqladd = "INSERT INTO `tblitems` (`Barcode`, `BrandID`, `Description`, `PartsID`, `RecievedDate`, `Quantity`, `Price`, `LocationID`, `CompSetID`, `Status`) " & _
                             " VALUES ('" & txtBarcode.Text & "'," & cboBrand.SelectedValue & ",'" & txtDescription.Text & "'," & cboParts.SelectedValue & ",Date(Now()),1,0," & cboLocation.SelectedValue & "," & cboCompSet.SelectedValue & ",'Good')"

                    sqledit = "UPDATE `tblitems` SET  `BrandID`='" & cboBrand.SelectedValue & "', `Description`='" & txtDescription.Text & "', `PartsID`=" & cboParts.SelectedValue & ", `LocationID`=" & cboLocation.SelectedValue & ", `CompSetID`=" & cboCompSet.SelectedValue & " WHERE  `Barcode`='" & txtBarcode.Text & "'"

                    save_or_update(sql, sqladd, sqledit, "Item has been updated in the database.", "New Item has been saved in the database.")

                    Call frmItem_Load(sender, e)

                End If 
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        cleartext(Me)

        cbo_fill(cboParts, "Parts", "PartsID", "tblparts")
        cbo_fill(cboBrand, "Brand", "BrandID", "tblbrand")
        cbo_fill(cboLocation, "Location", "LocationID", "tbllocation")
        cbo_fill(cboCompSet, "ComputerSet", "CompSetID", "tblcompset")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class