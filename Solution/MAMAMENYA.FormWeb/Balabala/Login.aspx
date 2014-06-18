<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MAMAMENYA.FormWeb.Baba.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>妈妈们丫管理后台</title>
      <link rel="stylesheet" type="text/css" href="/Styles/base.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/admin-all.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/bootstrap.min.css" />
    <script type="text/javascript" src="/Scripts/jquery-1.7.2.js"></script>
<!--    <script type="text/javascript" src="Scripts/jquery.spritely-0.6.js"></script> -->
    <!--<script type="text/javascript" src="Scripts/chur.min.js"></script> -->
    <link rel="stylesheet" type="text/css" href="/Styles/login.css" />
     <script type="text/javascript" src="/Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="/Styles/chur.css" />
  <%--  <script type="text/javascript">
        $(function () {
            $('#clouds').pan({ fps: 20, speed: 0.7, dir: 'right', depth: 10 });
            $('.login').click(function() {
                if ($('#uid').val() == "" || $('#pwd').val() == "" || $('#code').val() == "") {
                    $('.tip').html('用户名或密码不可为空！')
                } else {
                    location.href = 'index.html';
                }
            });
        })
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div class="loginmain">
    </div>

    <div class="row-fluid">
        <h1>MAMAMENYA后台管理系统</h1>
        <p>
            <label>帐&nbsp;&nbsp;&nbsp;号：<asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox></label>
        </p>
        <p>
            <label>密&nbsp;&nbsp;&nbsp;码：<asp:TextBox ID="txtPwd" runat="server"></asp:TextBox></label>
        </p>
        <p class="pcode">
            <label>效验码：<asp:TextBox ID="txtcode" CssClass="code" runat="server"></asp:TextBox>
            <img src="/AjaxHandler/VerifyCode.ashx" alt="" id="i1" onclick="return change();" /><a href="#">下一张</a></label>
        </p>
        <p class="tip">&nbsp;</p>
        <hr />
        <asp:Button ID="btnLogin" runat="server" OnClick="OnBtnLogin_Click"  CssClass="btn btn-primary btn-large login" Text=" 登 录 " />
       
        &nbsp;&nbsp;&nbsp;<input type="button" value=" 取 消 " class="btn btn-large" />
    </div>
    </form>
</body>
</html>
