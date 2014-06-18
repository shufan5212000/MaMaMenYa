<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
    <title>Uploadify</title>  
    <link href="JS/jquery.uploadify-v2.1.0/example/css/default.css" mce_href="JS/jquery.uploadify-v2.1.0/example/css/default.css" rel="stylesheet" type="text/css" />  
    <link href="JS/jquery.uploadify-v2.1.0/uploadify.css" mce_href="JS/jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet" type="text/css" />  
    <script type="text/javascript" src="JS/jquery.uploadify-v2.1.0/jquery-1.3.2.min.js" mce_src="JS/jquery.uploadify-v2.1.0/jquery-1.3.2.min.js"></script>  
    <script type="text/javascript" src="JS/jquery.uploadify-v2.1.0/swfobject.js" mce_src="JS/jquery.uploadify-v2.1.0/swfobject.js"></script>  
    <script type="text/javascript" src="JS/jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js" mce_src="JS/jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js"></script>  
    <script type="text/javascript" src="JS/dialog.js" mce_src="JS/dialog.js"></script>  
    <link href="CSS/dialog.css" mce_href="CSS/dialog.css" rel="stylesheet" type="text/css" />  
    <script type="text/javascript"><!--   
        $(document).ready(function()   
        {   
            $("#uploadify").uploadify({   
                'uploader': 'JS/jquery.uploadify-v2.1.0/uploadify.swf',  //指定上传控件的主体文件，默认‘uploader.swf’   
                'script': 'UploadHandler.ashx',                          //指定服务器端上传处理文件   
                'cancelImg': 'JS/jquery.uploadify-v2.1.0/cancel.png',    //指定取消上传的图片，   
                'folder': 'UploadFile',                                  //要上传到的服务器路径，默认‘/’   
                'queueID': 'fileQueue',   
                'auto': false,                                           //选定文件后是否自动上传，默认false   
                'multi': true,                                           //是否允许同时上传多文件
                'fileDesc': '允许的类型:doc;ppt;xsl;rar;zip;bmp',                         //出现在上传对话框中的文件类型描述
                'fileExt': '*.rar;*.zip;*.doc;*.ppt;*.xsl;*.bmp',                             //控制可上传文件的扩展名，启用本项时需同时声明fileDesc   
                'sizeLimit': 31457280 ,                                     //控制上传文件的大小，单位byte  30mb   
                'queueSizeLimit' :10,                                    //当允许多文件生成时，设置选择文件的个数，默认值：999    
                'simUploadLimit' :1 ,                                    //多文件上传时，同时上传文件数目限制   
                'buttonText': 'LiuLan' ,                                   // 浏览按钮的文本，默认值：BROWSE 。    
               // 'buttonImg': 浏览按钮的图片的路径 。    
               // 'hideButton': 设置为true则隐藏浏览按钮的图片 。    
               //  'rollover':true,                                      // 值为true和false，设置为true时当鼠标移到浏览按钮上时有反转效果。    
                'width':110,                                  // 设置浏览按钮的宽度 ，默认值：110。    
                'height':30,                                   // 设置浏览按钮的高度 ，默认值：30。    
               // 'wmode': 设置该项为transparent 可以使浏览按钮的flash背景文件透明，并且flash文件会被置为页面的最高层。 默认值：opaque 。    
                   /*   上传出错 执行  --针对单个文件  */   
                 'onError' : function (event,queueId,fileObj,errorObj)      
                   {     
                   var iframe=document.getElementById("fileres");   
                   iframe.src="onComplete.aspx?name="+encodeURIComponent(fileObj.name)+"&size="+fileObj.size+"&info="+errorObj.info+"&type="+errorObj.type+"&status="+errorObj.status;   
                   iframe.height=0;   
                   iframe.width=0;   
               },  /* --注意这的 , 不能忘了，不然出错*/   
  
  
                 /*       单个文件上传完成  执行  */   
                 'onComplete':function(event,queueId,fileObj,response,data)   
                 {   
  
                 var iframe=document.getElementById("fileres");   
                 iframe.src="onComplete.aspx?name="+encodeURIComponent(fileObj.name)+"&size="+fileObj.size+"&speed="+data.speed+"&filecount="+data.fileCount+"&res="+response;   
                 iframe.height=0;   
                 iframe.width=0;   
  
                 },   
                 /*       全部上传完 执行   */   
                 'onAllComplete' : function(e,data)   
                 {   
//                    var iframe=document.getElementById("fileres");   
//                 iframe.src="OnComplete.aspx?finish=true&succeed="+data.filesUploaded +"&error="+data.errors +"&average="+data.speed +"&allBytes="+data.allBytesLoaded ;   
//                 iframe.height=400;   
//                 iframe.width=600;   
                // dialog("Welcome Back","iframe:OnComplete.aspx?finish=true&succeed="+data.filesUploaded +"&error="+data.errors +"&average="+data.speed +"&allBytes="+data.allBytesLoaded ,"800px","400px","iframe");    
               // window.opener("OnComplete.aspx?finish=true&succeed="+data.filesUploaded +"&error="+data.errors +"&average="+data.speed +"&allBytes="+data.allBytesLoaded);   
                 window.location.href="OnComplete.aspx?finish=true&succeed="+data.filesUploaded +"&error="+data.errors +"&average="+data.speed +"&allBytes="+data.allBytesLoaded ;   
                 }   
            });   
        });     
       
// --></script>  
</head>  
<body>  
    <form id="form1" runat="server">  
       
    <div id="fileQueue"></div>  
    <input type="file" name="uploadify" id="uploadify" />          
    <p>  
      <a href="javascript:$('#uploadify').uploadifyUpload()" mce_href="javascript:$('#uploadify').uploadifyUpload()">开始上传</a>|    
      <a href="javascript:$('#uploadify').uploadifyClearQueue()" mce_href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>  
           
    </p>  
</form>  
<iframe id="fileres" name="fileres" width=0 height=0 ></iframe>  
</body>  
</html>  
