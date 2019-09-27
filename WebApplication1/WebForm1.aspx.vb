Imports System.Data.SqlClient

Public Class WebForm1
  Inherits System.Web.UI.Page
  ReadOnly conString As SqlConnection = New SqlConnection(ConfigurationManager.AppSettings("db"))
  Private Const K_SP_MENU As String = "BSP_sysGetMenuFunzioni"
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    Dim parametri() As SqlParameter = New SqlParameter() _
  {
    New SqlParameter("@IDSysProfilo", SqlDbType.Int) With {.Value = 1}}
    'New SqlParameter("@developer", SqlDbType.Bit) With {.Value = False}

    Dim dt As DataTable = New DataTable()
      Dim ds As DataSet = New DataSet()
      dt = SelectQuery(conString, K_SP_MENU, parametri)

      Mtmenu1.MenuCss = "menu.css"
      Mtmenu1.MTDatatable = dt
      Dim prova = Mtmenu1.BindMenuData()




  End Sub






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

End Class