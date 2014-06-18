<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Users.UserList" %>
 <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td>用户名 </td>
                <td>性别</td>
                <td>联系电话</td>
                <td>邮箱</td>
                <td>宝宝年龄</td>
                <td>注册时间 </td>
                <td>昵称 </td>
                <td>当前积分 </td>
                 <td>邮箱验证用户 </td>
                <td>操作 </td>
            </tr>
        </thead>
        <tbody>
            
            <%
                int i = 0;
                foreach (var user in PageData)
                {
                    i += 1;
            %>
    <tr <% if (i%2 == 0)
           { %>class="even"<% } %>>
                <td><%=user.LoginName %></td>
                <td><%=user.Gender %></td>
                <td><%=user.Tel %></td>
                <td><%=user.Email %> </td>
                <td><%=user.BabyAge %> </td>
                <td><%=user.RegData %></td>
                <td><%=user.NickName %></td>
                <td><%=user.Integral %></td>
                <td><%=user.EmailAuthenticate %></td>
                <td>
                    <a  class="btn btn-inverse Modify" href="ArticleAddBaLa.aspx?Id=<%=user.Id %>">禁用</a>
                    <a  class="btn btn-inverse Modify" href="ArticleAddBaLa.aspx?Id=<%=user.Id %>">修改密码</a>
                    <a  class="btn btn-inverse Detail" href="UserDetail.aspx?Id=<%=user.Id %>">详细</a>
                </td>
                
            </tr>
  <%
                } %>
          
            
        </tbody>
    </table>