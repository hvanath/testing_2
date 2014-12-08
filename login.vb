Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting
Public Class login

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd As New OleDbCommand
        ' Dim DR As OleDbDataReader
        con = Helper.AccessConnectionWithoutPassword("db_sticky.accdb")
        con.Open()

        Dim frm_cate As New frm_category()
        frm_cate.Show()
        Hide()


        Dim sqlProducts As String = "SELECT * from tbl_user"
        Dim da As New OleDbDataAdapter(sqlProducts, con)
        Dim ds As New DataSet()
        da.Fill(ds, "tbl_user")

        Dim ChartArea1 As ChartArea = New ChartArea()
        Dim Legend1 As Legend = New Legend()
        Dim Series1 As Series = New Series()
        Dim Chart1 = New Chart()
        Me.Controls.Add(Chart1)

        ChartArea1.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Chart1.Legends.Add(Legend1)
        Chart1.Location = New System.Drawing.Point(13, 13)
        Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Chart1.Series.Add(Series1)
        Chart1.Size = New System.Drawing.Size(800, 400)
        Chart1.TabIndex = 0
        Chart1.Text = "Chart1"

        Chart1.Series("Series1").XValueMember = "name"
        Chart1.Series("Series1").YValueMembers = "password"

        Chart1.DataSource = ds.Tables("tbladmin")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
