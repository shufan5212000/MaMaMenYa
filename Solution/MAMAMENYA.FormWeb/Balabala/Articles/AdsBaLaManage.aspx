<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true"
    CodeBehind="AdsBaLaManage.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Articles.AdsBaLaManage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <div id="AdsClassAdd">
            <form action="AdsBaLaManage.aspx?action=Add" method="POST" id="formAdd">
            <input name="Name" id="Name" />
            </form>
        </div>
        <tbody>
            <tr>
                <td>
                    广告标题
                </td>
                <td class="td_detail">
                    <input id="txtTitle" name="txtTitle" />
                </td>
                <td>
                    广告类别
                </td>
                <td class="detail">
                    <select size="1" name="ENTPdept" id="bumen">
                        <option value="">----请选择----</option>
                        <% foreach (var articleClass in AllAdsClass)
                           {
                        %>
                        <option value="<%=articleClass.Id %>">
                            <%=articleClass.Name %></option>
                        <%
                            } %>
                    </select>
                </td>
                <td>
                    <a class="btn btn-inverse " id="AddClass" href="#">添加类别</a> <a class="btnsearch btn btn-inverse "
                        href="ArticleList.aspx">查询</a>
                </td>
                <td>
                </td>
            </tr>
        </tbody>
    </table>
    <div id="PageContent">
    </div>
    <div id="Pager">
    </div>
    <script src="/Scripts/Advertisement.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            Advertisement.Init();
        });
    </script>
</asp:Content>
