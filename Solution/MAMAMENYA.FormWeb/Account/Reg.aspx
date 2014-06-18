<%@ Page Title="" Language="C#" MasterPageFile="~/UiPage.Master" AutoEventWireup="true"
    CodeBehind="Reg.aspx.cs" Inherits="MAMAMENYA.FormWeb.Account.Reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Style/reg.css" />
    <script src="/Scripts/User.js" language="javascript" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="container" class="noXtips cf">
        <div class="main">
            <h2>
                欢迎注册妈妈们呀</h2>
            <form id="formReg" action="reg.php" method="post" class="reg-form">
            <p>
                <label for="email">
                    <em>*</em>电子邮箱：</label>
                <input name="email" type="text" class="input-txt" id="email" size="43">
            </p>
            <p>
                <label for="password">
                    <em>*</em>密码：</label>
                <input name="password" type="password" class="input-txt" id="password" autocomplete="off"
                    size="43" />
            </p>
            <p>
                <label for="nickname">
                    <em>*</em>昵称：</label>
                <input name="nickname" type="text" class="input-txt" id="nickname" autocomplete="off"
                    size="43" />
            </p>
            <p class="checkcode">
                <label for="checkcode">
                    <em>*</em>验证码：</label>
                <input name="checkcode" type="text" class="input-txt" id="checkcode" autocomplete="off"><img
                    height="26" align="absmiddle" width="105" onclick="this.src=this.src+'?'" title="看不清？点击更换"
                    src="pages/user/checkcode.php?" id="checkcodeimg"><span onclick="changeCheckCodeImg();"
                        class="refresh">换一换</span>
            </p>
            <p class="chcek-rule">
                <input name="agree" type="checkbox" value="1" checked />
                <span class="fl">我同意</span><a href="pages/user/term.htm" target="_blank">《路趣网服务公约》</a></p>
            <a class="regbtn" id="submit" href="javascript:void(0);" hidefocus="true">立即注册</a>
            </form>
            <div class="reg-notes">
                <p>
                    如果你已注册，请直接登录</p>
                <a href="javascript:needLogin();" class="reg-login">登录</a>
                <dl class="login-option">
                    <dt>你也可以用以下方式登录</dt>
                    <dd class="sina-ico">
                        <a href="trd/sina2/index.php">新浪微博</a></dd>
                    <dd>
                        <a href="trd/tencent/index.php">腾讯微博</a></dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
