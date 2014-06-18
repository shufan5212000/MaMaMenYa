<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploadder.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Uploadder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Scripts/js/CJL.0.1.min.js"></script>
<script src="/Scripts/js/ImagePreview.js"></script>
<script src="/Scripts/js/jquery-1.5.js"></script>
<script type="text/javascript" src="/Scripts/js/jquery.form.js"></script>
<SCRIPT>
    //清空File控件的值，并且预览处显示默认的图片
    function clearFileInput() {
        var form = document.createElement('form');
        document.body.appendChild(form);
        //记住file在旧表单中的的位置
        var file = document.getElementById("idFile");
        var pos = file.nextSibling;
        form.appendChild(file);
        form.reset(); //通过reset来清空File控件的值
        document.getElementById("colspan").appendChild(file);
        document.body.removeChild(form);
        //在预览处显示图片 这是在浏览器支持滤镜的情况使用的
        document.getElementById("idImg").style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod='scale',src='images/abshiu.jpg'";
        //这是是火狐里面显示默认图片的
        if (navigator.userAgent.indexOf('Firefox') >= 0) {
            $("#idImg").attr('src', 'images/abshiu.jpg');
        }
    }
    function upLoadFile() {
        var options = {
            type: "POST",
            url: 'Files.ashx',
            success: showResponse
        };

        // 将options传给ajaxForm
        $('#myForm').ajaxSubmit(options);

    }
    function showResponse(data) {
        alert(data);
    } 
</SCRIPT>

</head>
<body>
 <form id="myForm" runat="server">
                    
    <input id="idFile" runat="server" name="pic" type="file" /><input type="button" name="resets" value="上传图片" onclick="upLoadFile()" />         
     
  </form>
</body>
</html>
