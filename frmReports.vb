Public Class frmReports

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cboLocation.Text = "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID"
        ElseIf cboLocation.Text = "Select" And cboParts.Text <> "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
            " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
            " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
            " AND i.CompSetID=c.CompSetID AND Parts Like '%" & cboParts.Text & "%'"

        ElseIf cboLocation.Text <> "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
            " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
            " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
            " AND i.CompSetID=c.CompSetID AND Location Like '%" & cboLocation.Text & "%'"
        Else
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
         " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
         " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
         " AND i.CompSetID=c.CompSetID AND Location Like '%" & cboLocation.Text & "%' AND Parts Like '%" & cboParts.Text & "%'"
        End If

        reports(sql, "listofitems", CrystalReportViewer1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cboLocation.Text = "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
            " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
            " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
            " AND i.CompSetID=c.CompSetID AND Status='Lost'"

        ElseIf cboLocation.Text = "Select" And cboParts.Text <> "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
                    " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
                    " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
                    " AND i.CompSetID=c.CompSetID AND Status='Lost' AND Parts Like '%" & cboParts.Text & "%'"
        ElseIf cboLocation.Text <> "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
                  " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
                  " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
                  " AND i.CompSetID=c.CompSetID AND Status='Lost' AND Location Like '%" & cboLocation.Text & "%'"
        Else
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
                 " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
                 " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
                 " AND i.CompSetID=c.CompSetID AND Status='Lost' AND Location Like '%" & cboLocation.Text & "%' AND Parts Like '%" & cboParts.Text & "%'"
        End If

       reports(sql, "lostitems", CrystalReportViewer1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If cboLocation.Text = "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND Status='Maintenance'"

        ElseIf cboLocation.Text = "Select" And cboParts.Text <> "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
            " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
            " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
            " AND i.CompSetID=c.CompSetID AND Status='Maintenance' AND Parts Like '%" & cboParts.Text & "%'"

        ElseIf cboLocation.Text <> "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
           " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
           " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
           " AND i.CompSetID=c.CompSetID AND Status='Maintenance' AND Location Like '%" & cboLocation.Text & "%'"
        Else
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
       " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
       " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
       " AND i.CompSetID=c.CompSetID AND Status='Maintenance' AND Location Like '%" & cboLocation.Text & "%' AND Parts Like '%" & cboParts.Text & "%'"
        End If
         reports(sql, "maintenanceitems", CrystalReportViewer1)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If cboLocation.Text = "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` AND i.CompSetID=c.CompSetID AND Status='Damaged'"

        ElseIf cboLocation.Text = "Select" And cboParts.Text <> "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
             " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
             " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
             " AND i.CompSetID=c.CompSetID AND Status='Damaged' AND Parts Like '%" & cboParts.Text & "%'"

        ElseIf cboLocation.Text <> "Select" And cboParts.Text = "Select" Then
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
          " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
          " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
          " AND i.CompSetID=c.CompSetID AND Status='Damaged' AND Location Like '%" & cboLocation.Text & "%'"
        Else
            sql = "SELECT ItemID, `Barcode`,`Parts`,`Brand`, i.`Description`,`Location`, `ComputerSet`,Status,RecievedDate " & _
      " FROM `tblbrand` b,`tblitems` i, `tblparts` p, `tbllocation` l,tblcompset c " & _
      " WHERE b.`BrandID`=i.`BrandID` AND i.`PartsID`=p.`PartsID` AND i.`LocationID`=l.`LocationID` " & _
      " AND i.CompSetID=c.CompSetID AND Status='Damaged' AND Location Like '%" & cboLocation.Text & "%' AND Parts Like '%" & cboParts.Text & "%'"
        End If

       reports(sql, "damageitems", CrystalReportViewer1)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If cboLocation.Text = "Select" And cboParts.Text = "Select" Then

            sql = "SELECT * FROM `tbltransfer` "

        ElseIf cboLocation.Text = "Select" And cboParts.Text <> "Select" Then
            sql = "SELECT * FROM `tbltransfer` WHERE Parts Like '%" & cboParts.Text & "%'"

        ElseIf cboLocation.Text <> "Select" And cboParts.Text = "Select" Then

            sql = "SELECT * FROM `tbltransfer` WHERE LocationTO Like '%" & cboLocation.Text & "%'"
        Else
            sql = "SELECT * FROM `tbltransfer` WHERE LocationTO Like '%" & cboLocation.Text & "%' AND Parts Like '%" & cboParts.Text & "%'"

        End If

       reports(sql, "transfereditems", CrystalReportViewer1)
    End Sub

    Private Sub frmReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 
        cbo_fill(cboParts, "Parts", "PartsID", "tblparts")
        cbo_fill(cboLocation, "Location", "LocationID", "tbllocation")

        cboParts.Text = "Select"
        cboLocation.Text = "Select"

    End Sub
End Class