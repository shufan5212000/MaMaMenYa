<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandList.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Products.BrandList" %>

 <table class="table table-striped table-bordered table-condensed" id="list" pageindex='<%=PageIndex %>'
pageCount="<%=PageCount %>" pagesize='<%=PageSize %>' recordcount='<%=RecordCount %>'>
        <thead>
            <tr class="tr_detail">
                <td>品牌名称 </td>
                <td>产品数量</td>
                 <td>图片</td>
                <td>描述</td>
                <td>最后更新时间 </td>
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
                <td><%=article.Name%></td>
                <td><%=article.ProductCount%></td>
              
                <td> </td>
                <td><%=article.Description%></td>
                <td><%=article.UpdateTime%></td>
              
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