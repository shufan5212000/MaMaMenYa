var Product;
if (!Product) {
    Product = {};
}


Product.Uploader = function () {
    $('#UploaderContent').dialog({
        title: "【上传图片】",
        autoOpen: false,
        modal: true,
        width: 500,
        heigh: 250,
        //sresizable: true,
        buttons: {
            "取消": function () {
                $(this).dialog("close");
            },
            "保存": function () {
                $('#frmSave').submit();
            }
        }
    });


    $('#btnUPloadPic').click(function () {
        var file = $('#idFile').val();
        //开始提交
        $("#form1").ajaxSubmit({
            beforeSubmit: function () {
                //                $("#out" + tid).hide();
                //                $("#bar" + tid).html("正在上传中请稍候...");
            },
            success: function (data) {
//                alert(data);
                $('input[realName="picUrl"]').val(data);
                //                if (data.success) {
                //                    var txturl = sReplace(data.text, "%3A", ":");
                //                    $("#" + tid).val(txturl);
                //                    $("#bar" + tid).html("<a target='_blank' href='" + txturl + "'>预览</a>");
                //                } else {
                //                    $("#bar" + tid).html(data.error);
                //                }
                //                $("#out" + tid).show();
            },
            error: function (httpRequest, textStatus) {
                //                alert("上传异常：" + httpRequest.status + httpRequest.responseText);
                //                $("#bar" + tid).html("上传失败，服务器端文件异常！"); ;
                //                $("#out" + tid).show();
            },
            url: "/AjaxHandler/Attachment.aspx?fileid=idFile",
            type: "post",
            dataType: "text"
        });

    });
};

Product.Manage = function () {
    $('.Del').live('click', function () {
//        var id = $(this).attr('name');

//        var re = confirm("确定删除这条记录吗？");
//        if (re) {
//            $.get("/AjaxHandler/BalaAjax.aspx?action=DelProduct&ObjectId="+id, function (data) {
//                alert(data);
//                window.location.reload();
//            });

//        }

        var objId = $(this).attr("name");
        $('body').alert(
            { type: 'confirm',
                buttons: [
                    { id: 'yes', name: '确定', callback: function () {

                        $.get("/AjaxHandler/BalaAjax.aspx?action=DelProduct&ObjectId=" + objId, function (data) {
                            alert(data);
                            window.location.reload();
                        });
                    }
                    },
                    { id: 'no', name: '取消' }
                ]
            });


    });


};

Product.InitData = function () {
    


};