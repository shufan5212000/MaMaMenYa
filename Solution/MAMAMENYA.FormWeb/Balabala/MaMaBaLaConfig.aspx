<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" CodeBehind="MaMaBaLaConfig.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.MaMaBaLaConfig" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="table table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">&nbsp;网站设置 </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>网站名称</td>
                <td class="detail">
                    
                    <asp:TextBox ID="txtWebName" Width="200" runat="server"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td>关键词 </td>
                <td>
                    <div class="input-append">
                       <asp:TextBox ID="txtKeywords" Width="200" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
             <tr>
                 <td>网站描述：</td>
                  <td><asp:TextBox TextMode="MultiLine" Rows="4" ID="txtDesc" Width="200" runat="server"></asp:TextBox></td>
             </tr>
               <tr>
                 <td>网站域名：</td>
                  <td><asp:TextBox ID="txtDomain" Width="200" runat="server"></asp:TextBox></td>
             </tr>
               <tr>
                 <td>备案信息：</td>
                  <td><asp:TextBox ID="txtICP" Width="200" runat="server"></asp:TextBox></td>
             </tr>
               <tr>
                 <td>二维码图片：</td>
                  <td><asp:TextBox ID="txtErWeiMa" Width="200" runat="server"></asp:TextBox></td>
             </tr>
               <tr>
                 <td>在线QQ：</td>
                  <td><asp:TextBox ID="txtQq" Width="200" runat="server"></asp:TextBox></td>
             </tr>
               <tr>
                 <td>电子邮箱：</td>
                  <td><asp:TextBox ID="txtEmail" Width="200" runat="server"></asp:TextBox></td>
             </tr>
              <tr>
                 <td>腾讯微博地址：</td>
                  <td><asp:TextBox ID="txtWebBo" Width="200" runat="server"></asp:TextBox></td>
             </tr>
               <tr>
                 <td>微信公众账号：</td>
                  <td><asp:TextBox ID="txtWeiXin" Width="200" runat="server"></asp:TextBox></td>
             </tr>
               <tr>
                 <td>阿里旺旺：</td>
                  <td><asp:TextBox ID="txtWangWang" Width="200" runat="server"></asp:TextBox></td>
             </tr>
            <tr>
                <td  align="right">
                    <asp:Button ID="btnSave" CssClass="btn btn-inverse" OnClick="OnbtnSave_Click" runat="server" Text="保存设置" />

                    </td>
                    <td></td>
            </tr>
        </tbody>
    </table>
</asp:Content>
