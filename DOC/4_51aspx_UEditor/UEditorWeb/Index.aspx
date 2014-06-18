<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UEditorWeb.Index" %>
<%@ Register Assembly="UEditorControl" Namespace="UEditorControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowContent() {
            var msg = UEditor1.getContent();
            alert(msg);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>获取内容操作</legend>
        <input id="Button1" type="button" value="JS获取内容" onclick="ShowContent()" />
        <asp:Button ID="Button2" runat="server" Text="后台获取内容" OnClick="Button2_Click" />
    </fieldset>
    <fieldset>
        <legend>后台获取到的HTML内容</legend>
        <div id="divHtml" runat="server">
        </div>
    </fieldset>
    <br />
    <cc1:UEditor ID="UEditor1" runat="server" Width="100%">
    </cc1:UEditor>
</asp:Content>
