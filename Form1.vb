Public Class Form1

    Private Sub PartsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartsToolStripMenuItem.Click
        With frmParts
            .Show()
            .Focus()

        End With
    End Sub

    Private Sub BrandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrandToolStripMenuItem.Click
        With frmBrand
            .Show()
            .Focus()

        End With
    End Sub

    Private Sub LocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationToolStripMenuItem.Click
        With frmLocation
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub ManageUsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageUsersToolStripMenuItem.Click
        With frmUser
            .Show()
            .Focus()

        End With
    End Sub

    Private Sub ItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsToolStripMenuItem.Click
        With frmItem
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub ListOfItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListOfItemsToolStripMenuItem.Click
        With frmListItems
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        With LoginForm1
            .Show()
            .Focus()
            .UsernameTextBox.Clear()
            .PasswordTextBox.Clear()
            .UsernameTextBox.Focus()


        End With
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComputerSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComputerSetToolStripMenuItem.Click
        With frmComSet
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub TransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferToolStripMenuItem.Click
        With frmTranferItems
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub RepairingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepairingToolStripMenuItem.Click
        With frmMaintenance
            .Show()
            .Focus()

        End With
    End Sub

    Private Sub LostItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LostItemsToolStripMenuItem.Click
        With frmLost
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub DamageItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DamageItemsToolStripMenuItem.Click
        With frmDamage
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportsToolStripMenuItem.Click
        With frmReports
            .Show()
            .Focus()
        End With
    End Sub
End Class
