<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Products.ProductList1" %>


<table class="table table-striped table-bordered table-condensed" id="list" pageindex='<%=PageIndex %>'
pageCount="<%=PageCount %>" pagesize='<%=PageSize %>' recordcount='<%=RecordCount %>'>
        <thead>
            <tr class="tr_detail">
                <td>
                    产品名称
                </td>
                <td>
                    产品类别
                </td>
                <td>
                    图片
                </td>
                <td>
                    价格
                </td>
                <td>
                    浏览数
                </td>
                <td>
                    购买数量 /库存
                </td>
                <td>
                    好品数
                </td>
                <td>
                    商家名称
                </td>
                <td>
                    商家信用等级
                </td>
                <td>
                    是否推荐
                </td>
                <td>
                    所属平台
                </td>
                <td>
                    产品状态
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
                    <%=product.ProductName%>
                </td>
                <td>
                    <%if (product.ProductClass != null)
                          Response.Write(product.ProductClass.Name);%>
                </td>
                <td>
                    <img src="<%=product.Pic%>" width="50" />
                </td>
                <td>
                    <%=string.Format("{0:C2}",product.Price)%>
                </td>
                <td>
                    <%=product.ClickCount%>
                </td>
                <td>
                    <%=product.BuyCount%>/<%=product.Inventory %>
                </td>
                <td>
                    <%=product.FavorableCount%>
                </td>
                <td>
                    <%=product.ShopName%>
                </td>
                <td>
                    <%=product.CreditRating%>
                </td>
                <td>
                    <%=product.Recommend%>
                </td>
                <td>
                    <%=product.PlantformName%>
                </td>
                <td>
                    <%=product.Status%>
                </td>
                <td>
                    <%=product.UpdateTime%>
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


