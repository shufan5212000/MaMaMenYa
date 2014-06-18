<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QandAList.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.QandA.QandAList" %>

<table class="table table-striped table-bordered table-condensed" id="list" pageindex='<%=PageIndex %>'
    pagecount="<%=PageCount %>" pagesize='<%=PageSize %>' recordcount='<%=RecordCount %>'>
    <thead>
        <tr class="tr_detail">
            <td>
                标题
            </td>
            <td>
                类别
            </td>
            <td>
                用户
            </td>
            <td>
                审核状态
            </td>
            <td>
                添加时间
            </td>
            <td>
                是否为精华
            </td>
            <td>
                操作
            </td>
        </tr>
    </thead>
    <tbody>
        <%
            int i = 0;
            foreach (var article in PageData)
            {
                i += 1;
        %>
        <tr <% if (i%2 == 0)
           { %>class="even" <% } %>>
            <td>
                <%=article.Title%>
            </td>
            <td>
                <%if (article.QuestionClass != null)
                      Response.Write(article.QuestionClass.Name);%>
            </td>
            <td>
                <%=article.User.LoginName%>
            </td>
            <td>
                <%=article.AuditStatus%>
            </td>
            <td>
                <%=article.AddTime%>
            </td>
            <td>
               <%=article.IsNice%> 
            </td>
            <td>
                <input class="btn btn-inverse Del" type="button" style="info2" id="btnDel<%=article.Id %>"
                    name="<%=article.Id %>" value="删除" />
                <a class="btn btn-inverse Modify" href="ArticleAddBaLa.aspx?Id=<%=article.Id %>">修改</a>
                <input class="btn btn-inverse Recommend" type="button" id="btnRecommend<%=article.Id %>"
                    name="<%=article.Id %>" value="推荐" />
            </td>
        </tr>
        <%
} %>
    </tbody>
</table>
