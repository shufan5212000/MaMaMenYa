<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true"
    CodeBehind="ActivityList.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Articles.ActivityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-striped table-bordered table-condensed" id="list" pageindex='<%=PageIndex %>'
        pagecount="<%=PageCount %>" pagesize='<%=PageSize %>' recordcount='<%=RecordCount %>'>
        <thead>
            <tr class="tr_detail">
                <td>
                    标题
                </td>
                <td>
                    活动时间
                </td>
                <td>
                    报名人数/招募人数
                </td>
                <td>
                    报名时间
                </td>
                <td>
                    费用
                </td>
                <td>
                    点击量
                </td>
                <td>
                    报名电话
                </td>
                <td>
                    是否推荐
                </td>
                <td>
                    更新时间
                </td>
                <td>
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
            <%
                int i = 0;
                foreach (var product in PageData)
                {
                    i += 1;
            %>
            <tr <% if (i%2 == 0)
           { %>class="even" <% } %>>
                <td>
                    <%=product.Title%>
                </td>
                <td>
                    <%=product.StartDate%>
                </td>
                <td>
                    <%=product.CurrentCount%>/<%=product.TotleUser%>
                </td>
                <td>
                    <%=product.SignInStartTime%>--<%=product.SignInEndTime%>
                </td>
                <td>
                    <%=string.Format("{0:C2}",product.Price)%>
                </td>
                <td>
                    <%=product.ClickRate%>
                </td>
                <td>
                    <%=product.Tel%>
                </td>
                <td>
                    <%=product.Recommend%>
                </td>
                <td>
                    <%=product.AddTime%>
                </td>
                <td>
                    <input class="btn btn-inverse Del" type="button" id="btnDel<%=product.Id %>" name="<%=product.Id %>"
                        value="删除" />
                    <input class="btn btn-inverse Modify" type="button" id="btnModify<%=product.Id %>"
                        name="<%=product.Id %>" value="修改" />
                    <input class="btn btn-inverse Recommend" type="button" id="btnRecommend<%=product.Id %>"
                        name="<%=product.Id %>" value="推荐" />
                </td>
            </tr>
            <%
} %>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
