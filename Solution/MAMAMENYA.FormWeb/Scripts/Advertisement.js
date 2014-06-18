var Advertisement;
if (!Advertisement) {
    Advertisement = {};
}


Advertisement.Init = function () {

    $('#AddClass').click(function () {
        $('#AdsClassAdd').dialog('open');
    });

    $('#AdsClassAdd').dialog({
        title: "【添加广告分类】",
        autoOpen: false,
        modal: true,
        width: 300,
        heigh: 250,
        //sresizable: true,
        buttons: {
            "关闭": function () {
                $(this).dialog("close");
            },
            "保存": function () {
                $('#form1').submit();
            }
        }
    });


    $('#formAdd').ajaxForm({
        // dataType: 'text',
        success: function (data) {
            if (data == "success") {
                alert("成功！");
                //$.ActionResponse('success', '提示', "职权申请已提交，请敬候佳音！");
                $('#ApplicatForm').dialog('close');
                //window.location.reload(true);
            } else {
                alert(data);
                // $.ActionResponse('error', '提示', '保存出错' + data.data);
            }
        }
    });
};