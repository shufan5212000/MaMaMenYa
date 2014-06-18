<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MAMAMENYA</title>
      <link rel="stylesheet" type="text/css" href="/Styles/admin-all.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/base.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="/Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <script type="text/javascript" src="/Scripts/index.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="warp">
        <!--头部开始-->
        <div class="top_c">
            <div class="top-menu">
                <ul class="top-menu-nav">
                    <li><a href="#">首页</a></li>
                    <li><a href="#">系统设置<i class="tip-up"></i></a>
                        <ul class="kidc">
                            <li><a target="Conframe" href="Template/find-form.html">系统设置</a></li>
                            <li><a target="Conframe" href="Template/find-alert.html">管理员管理</a></li>
                            <li><a target="Conframe" href="Users/UserBaLaManage.aspx">用户管理</a></li>
                            <li><a target="Conframe" href="Template/find-1.html">管理员日志</a></li>
                            <li><a target="Conframe" href="Template/find-2.html">查询结果二</a></li>
                        </ul>
                    </li>
                    <li><a href="#">业务中心<i class="tip-up"></i></a>
                        <ul class="kidc">
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-add.html">产品管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-edit.html">添加产品</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-del.html">产品分类管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-del.html">订单管理</a></li>
                            
                        </ul>
                    </li>
                    <li><a href="#">新闻中心<i class="tip-up"></i></a>
                        <ul class="kidc">
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-Master-slave.html">新闻分类</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-collapse.html">文章列表</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-tabs.html">标签式表单</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-tree.html">树+表单</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-guide.html">向导</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-tabs-list.html">标签页+列表</a></li>
                        </ul>
                    </li>
                    <li><a href="#">提示<i class="tip-up"></i></a>
                        <ul class="kidc">
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">权限提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">出错提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">警告提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">询问提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框一</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框二</a></li>
                    </ul>
                    </li>
                    <li><a href="#">财务中心<i class="tip-up"></i></a>
                        <ul class="kidc">
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">寻访记录</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">数据说明</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">操作记录</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">提示</a></li>
                    </ul>
                    </li>
                </ul>
            </div>
            <div class="top-nav">上午好，欢迎您，邱秋！&nbsp;&nbsp;<a href="#">修改密码</a> | <a href="?Action=Logout" id="Logout">安全退出</a></div>
        </div>
        <!--头部结束-->
        <!--左边菜单开始-->
        <div class="left_c left">
            <h1>系统操作菜单</h1>
            <div class="acc">
                <div>
                    <a class="one">系统数据</a>
                    <ul class="kid">
                        <li><b class="tip"></b><a target="Conframe" href="Users/BaLaManage.aspx">管理员管理</a></li>
                        
                        <li><b class="tip"></b><a target="Conframe" href="MaMaBaLaConfig.aspx">系统设置</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Articles/AdsBaLaManage.aspx">广告及幻灯片</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="OnePageManage.aspx">系统介绍单页</a></li>
                    </ul>
                </div>
                <div>
                    <a class="one">业务中心</a>
                    <ul class="kid">
                        <li><b class="tip"></b><a target="Conframe" href="Products/ProductBaLaManage.aspx">产品管理</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Products/ProductAddBal.aspx">添加产品</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Products/ProductClassBaLaManage.aspx">产品分类管理</a></li>
                         <li><b class="tip"></b><a target="Conframe" href="Products/BrandBaLaManage.aspx">产品品牌管理</a></li>
                         <li><b class="tip"></b><a target="Conframe" href="Products/OrderBaLaManage.aspx">订单管理</a></li>
                    </ul>
                </div>
                <div>
                    <a class="one">文章中心</a>
                    <ul class="kid">
                        <li><b class="tip"></b><a target="Conframe" href="Articles/ArticleBaLaManage.aspx">文章列表</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Articles/ArticleAddBaLa.aspx">添加文章</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Articles/ArticleClassBaLaManage.aspx">文章分类管理</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Articles/ActivityBaLaManage.aspx">亲子活动管理</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Articles/ActivityAdd.aspx">添加亲子活动</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-guide.html">向导</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-tabs-list.html">标签页+列表</a></li>
                    </ul>
                </div>
                <div>
                    <a class="one">用户中心</a>
                    <ul class="kid">
                       <li><b class="tip"></b><a target="Conframe" href="Users/UserBaLaManage.aspx">用户管理</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">用户评论管理</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">用户积分变动</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">询问提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框一</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框二</a></li>
                    </ul>
                </div>
                <div>
                    <a class="one">问答管理</a>
                    <ul class="kid">
                        <li><b class="tip"></b><a target="Conframe" href="QandA/QuestionManage.aspx">全部问题管理</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="QandA/QuestionClassManage.aspx">问题分类管理</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">操作记录</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">提示</a></li>
                    </ul>
                </div>
                <div id="datepicker"></div>
            </div>

        </div>
        <!--左边菜单结束-->
        <!--右边框架开始-->
        <div class="right_c">
            <div class="nav-tip" onClick="javascript:void(0)">&nbsp;</div>

        </div>
        <div class="Conframe">
            <iframe name="Conframe" id="Conframe"></iframe>
        </div>
        <!--右边框架结束-->

        <!--底部开始-->
        <div class="bottom_c">Copyright &copy;2005-2011 深圳艺谷发展科技有限公司 版权所有</div>
        <!--底部结束-->
    </div>
    </form>
</body>
</html>
