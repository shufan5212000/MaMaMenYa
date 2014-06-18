<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" CodeBehind="CommentBalaManage.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Users.CommentBalaManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $(".datepicker").datepicker();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    评论类型
                </td>
                <td class="detail">
                    <input id="formid" />
                </td>
                 <td>
                    评论时间
                </td>
                <td>
                    <div class="input-append">
                        <asp:TextBox ID="TextBox1" CssClass="span2 datepicker" runat="server"></asp:TextBox>
                        <span class="add-on"><i
                            class="icon-calendar"></i></span>至<asp:TextBox ID="TextBox2" CssClass="span2 datepicker" runat="server"></asp:TextBox><span class="add-on"><i class="icon-calendar"></i></span>
                    </div>
                </td>
                <td>
                 <input class="btn btn-inverse" id="Button1" type="button" value="查询" />
                </td>
                <td>
                   
                </td>
            </tr>
        </tbody>
    </table>
    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td>
                    用户账户
                </td>
                <td>
                    评论类型
                </td>
                <td>
                    评论对象Id
                </td>
                <td>
                    评论内容
                </td>
                <td>
                    评论时间
                </td>
                <td>
                    审核状态
                </td>
                <td>
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
            <%
                int i = 0;
                foreach (var comment in PageData)
                {
                    i += 1;
            %>
            <tr <% if (i%2 == 0)
           { %>class="even" <% } %>>
                <td>
                    <%=comment.User.LoginName%>
                </td>
                <td>
                    <%=comment.CommentType%>
                </td>

                <td>
                    <%=comment.ItemId%>
                </td>
                <td><%=comment.Content %></td>
                <td>
                    <%=comment.AddTime%>
                </td>
                <td>
                    <%=comment.AuditStatus%>
                </td>
               
                <td>
                    <input class="btn btn-inverse Del" type="button" id="btnDel<%=comment.Id %>" name="<%=comment.Id %>"
                        value="删除" />
                    <input class="btn btn-inverse Pass" type="button" id="btnModify<%=comment.Id %>"
                        name="<%=comment.Id %>" value="通过审核" />
                    <input class="btn btn-inverse UnPass" type="button" id="btnRecommend<%=comment.Id %>"
                        name="<%=comment.Id %>" value="拒绝通过" />
                </td>
            </tr>
            <%
} %>
            <tr class="even">
                <tr class="tr_pagenumber">
                    <td colspan="100">
                        <asp:Button ID="btnFirstPage" runat="server" CssClass="badge badge-inverse" OnClick="OnPageChange_Click"
                            Text="首页" />
                        <asp:Button ID="btnPrevious" runat="server" CssClass="badge badge-inverse" OnClick="OnPageChange_Click"
                            Text="上一页" />
                        <asp:Button ID="btnNext" runat="server" CssClass="badge badge-inverse" OnClick="OnPageChange_Click"
                            Text="下一页" />
                        <asp:Button ID="btnLastpage" runat="server" CssClass="badge badge-inverse" OnClick="OnPageChange_Click"
                            Text="尾页" />
                    </td>
                </tr>
        </tbody>
    </table>

</asp:Content>
