<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" ValidateRequest="false" Inherits="UEditorWeb.Default" %>

<%@ Register Assembly="UEditorControl" Namespace="UEditorControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UEditor示例</title>
    <script type="text/javascript">
        function ShowContent() {
            var msg = UEditor1.getContent();
            alert(msg);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
