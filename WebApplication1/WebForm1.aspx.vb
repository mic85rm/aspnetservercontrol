Imports System.Data.SqlClient

Public Class WebForm1
  Inherits System.Web.UI.Page
  ReadOnly conString As SqlConnection = New SqlConnection(ConfigurationManager.AppSettings("db"))
  Private Const K_SP_MENU As String = "BSP_sysGetMenuFunzioni"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    speriamodino.Checked = False
    provaIDboh.CheckedInterno = True



    Dim parametri() As SqlParameter = New SqlParameter() _
  {
    New SqlParameter("@IDSysProfilo", SqlDbType.Int) With {.Value = 1}}
        'New SqlParameter("@developer", SqlDbType.Bit) With {.Value = False}

        Dim dt As DataTable = New DataTable()
      Dim ds As DataSet = New DataSet()
    ' dt = SelectQuery(conString, K_SP_MENU, parametri)
    'Mtmenu1.Idmenu = "Menu"
    'Mtmenu1.MenuCss = "MenuBArts"
    'Mtmenu1.StaticMenuStyleCssClass = "MenuBArts-Node"
    'Mtmenu1.DynamicMenuStyleCssClass = "MenuBArts-ChildNode"
    'Mtmenu1.MTDatatable = dt
    'Mtmenu1.BindMenuData()
    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
            ds.Tables.Add(dt)
            ds.DataSetName = "Menus"
            ds.Tables(0).TableName = "Menu"
            Dim relation As New DataRelation("ParentChild", dt.Columns("ID"), dt.Columns("IDPadre"), False)
            ds.Relations.Add(relation)
            'Menu.Items.Clear()
            Me.CaricaMenu(ds)

        Else

        End If



    End Sub

#Region "Private Sub CaricaMenu(ByVal ds As DataSet)"
    Private Sub CaricaMenu(ByVal ds As DataSet)
        Dim drs() As DataRow
        Dim mi As MenuItem = Nothing
        Dim mf As MenuItem = Nothing
        drs = ds.Tables(0).Select("IDPadre is null")

        For Each dr As DataRow In drs
            mi = New MenuItem(dr("Descrizione"))
            mi.NavigateUrl = "~/" & dr("Comando")
            mi.ToolTip = dr("ToolTip") & ""

            mi = CaricaFigli(ds, mi, dr("ID"))

            'Menu.Items.Add(mi)
        Next

    End Sub
#End Region
#Region "Private Function CaricaFigli(ByVal ds As DataSet, ByVal nodo As MenuItem, ByVal menuID As Integer) As MenuItem"
    Private Function CaricaFigli(ByVal ds As DataSet, ByVal nodo As MenuItem, ByVal menuID As Integer) As MenuItem
        Dim drs() As DataRow
        Dim mi As MenuItem
        drs = ds.Tables(0).Select("IDPadre = " & menuID)

        For Each dr As DataRow In drs
            mi = New MenuItem(dr("Descrizione"))
            mi.NavigateUrl = "~/" & dr("Comando")
            mi.ToolTip = dr("ToolTip") & ""
            mi = CaricaFigli(ds, mi, dr("ID"))

            nodo.ChildItems.Add(mi)
        Next
        Return nodo
    End Function
#End Region


  'Public Sub provacheck() Handles provaIDboh.
  '  provaIDboh.ID = "dacodice"
  'End Sub

  Public Function SelectQuery(ByVal conn As SqlConnection, ByVal commandText As String, ParamArray commandParameters As SqlParameter()) As DataTable
    Using sda As SqlDataAdapter = New SqlDataAdapter()

      Using command = New SqlCommand(commandText, conn)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddRange(commandParameters)
        sda.SelectCommand = command

        Using dt As DataTable = New DataTable()
          sda.Fill(dt)
          Return dt
        End Using
      End Using
    End Using
  End Function

  Protected Sub ciao_CheckBoxClicked(sender As Object, e As EventArgs)

  End Sub

  Protected Sub provaIDboh_ValoreRestituito(sender As Object, e As MTCheckbox.MTCheckboxEventArgs)
    Dim valore = e.ValoreRestituito
  End Sub
End Class