<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnComplete.aspx.cs" Inherits="OnComplete" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
    <title>无标题页</title>  
  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
  <%--    <asp:GridView ID="GridView1" runat="server" BackColor="White"    
          BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4"    
          ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False"    
            EmptyDataText="错误：没有文件">  
          <RowStyle BackColor="#F7F7DE" />  
          <Columns>  
  
              <asp:TemplateField HeaderText="文件名称">  
                  <ItemTemplate>  
                      <asp:Label ID="Label1" runat="server"    
                          Font-Size="Small" ToolTip='<%# Eval("Name") %>'></asp:Label>  
                  </ItemTemplate>  
                  <EditItemTemplate>  
                      <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>  
                  </EditItemTemplate>  
              </asp:TemplateField>  
              <asp:BoundField DataField="Type" HeaderText="类型" />  
              <asp:BoundField DataField="Size" HeaderText="文件大小" />  
              <asp:BoundField DataField="Speed" HeaderText="上传速度" />  
              <asp:BoundField DataField="Res" HeaderText="结果" />  
              
              
          </Columns>  
          
          <FooterStyle BackColor="#CCCC99" />  
          <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />  
          <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />  
          <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />  
          <AlternatingRowStyle BackColor="White" />  
      </asp:GridView>  --%>
      

        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>  
      
        <br />  
       
          
         </div>  
    </form>  
</body>  
</html>  