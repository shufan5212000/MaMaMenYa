<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Articles.ArticleList" %>

    <table class="table table-striped table-bordered table-condensed" id="list" pageindex='<%=PageIndex %>'
pageCount="<%=PageCount %>" pagesize='<%=PageSize %>' recordcount='<%=RecordCount %>'>
        <thead>
            <tr class="tr_detail">
                <td>标题 </td>
                <td>类别</td>
                <td>浏览数</td>
                <td>添加时间</td>
                <td>是否推荐 </td>
                <td>是否置顶</td>
                <td>操作 </td>
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
           { %>class="even"<% } %>>
                <td><%=article.Title%></td>
                <td><%if (article.ArticleClass != null)
                          Response.Write(article.ArticleClass.Name);%></td>
              
                <td><%=article.ClickCount%> </td>
                <td><%=article.UpdateTime%></td>
                <td><%=article.IsNice%></td>
                <td><%=article.IsTop%></td>
                <td>
                 <input class="btn btn-inverse Del" type="button" style="info2" id="btnDel<%=article.Id %>" name="<%=article.Id %>" value="删除" />
                  <a  class="btn btn-inverse Modify" href="ArticleAddBaLa.aspx?Id=<%=article.Id %>">修改</a>
                 <%--<input class="" type="button"  id="btnModify<%=article.Id %>" name="<%=article.Id %>" value="修改" />--%>
                 <input class="btn btn-inverse Recommend" type="button"  id="btnRecommend<%=article.Id %>" name="<%=article.Id %>" value="推荐" />
                </td>
                
            </tr>
  <%
                } %>
         
        </tbody>
    </table>