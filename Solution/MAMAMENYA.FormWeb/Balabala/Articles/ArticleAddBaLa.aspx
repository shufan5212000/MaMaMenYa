<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/MAMAYA.Master"
    AutoEventWireup="true" CodeBehind="ArticleAddBaLa.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Articles.ArticleAddBaLa" %>

<%@ Register Assembly="UEditorControl" Namespace="UEditorControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;添加文章信息
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="100">
                    标题：
                </td>
                <td class="detail">
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
                <td>
                    类别：
                </td>
                <td class="td_detail">
                    <asp:DropDownList ID="drpArticleClass" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    来源：
                </td>
                <td>
                    <div class="input-append">
                        <asp:DropDownList ID="drpFrom" runat="server">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    置顶：
                </td>
                <td>
                    <asp:CheckBox ID="chkIsTop" runat="server" />
                </td>
                <td>
                    推荐：
                </td>
                <td>
                    <asp:CheckBox ID="chkIsNice" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    页面关键词：
                </td>
                <td colspan="6" align="left">
                    <div class="input-append">
                        <asp:TextBox ID="txtKeyword" Width="60%" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    页面描述：
                </td>
                <td colspan="6" align="left">
                    <div class="input-append">
                        <asp:TextBox ID="txtSummary" TextMode="MultiLine" Rows="5" Width="80%" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    图片：
                </td>
                <td colspan="6" align="left">
                    <div class="input-append">
                        <asp:FileUpload ID="fileUploadPic" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    内容：
                </td>
                <td colspan="6" align="left" style="height: 320px" valign="top">
                    <cc1:UEditor ID="txtArticleContent" runat="server" Width="80%">
                    </cc1:UEditor>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="left">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="确认保存" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
