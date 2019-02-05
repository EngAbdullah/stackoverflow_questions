<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication5._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 502px">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Searching Tag"></asp:Label>
         <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px">
                <asp:ListItem Value="creation">Newest </asp:ListItem>
                <asp:ListItem Value="votes">Most Voted </asp:ListItem>
            </asp:DropDownList>
         <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Height="25px" Width="76px" />
            <br />
              <asp:GridView ID="GridView1" runat="server" Height="183px" Width="634px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                  <Columns>
                      <asp:HyperLinkField DataNavigateUrlFields="link" Text="hyperlink" />
                  </Columns>
                  <EditRowStyle BackColor="#999999" />
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                  <SortedAscendingCellStyle BackColor="#E9E7E2" />
                  <SortedAscendingHeaderStyle BackColor="#506C8C" />
                  <SortedDescendingCellStyle BackColor="#FFFDF8" />
                  <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                  
            </asp:GridView>

            <br />
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
            </asp:DetailsView>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
