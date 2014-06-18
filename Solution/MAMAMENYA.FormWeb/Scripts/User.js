var User;
if (!User) {
    User = {};
}

User.Reg = function () {

    $('.txtEmail').blur(function () {
        $.get("/ajaxHandler/UserValid.ashx?loginName=" + $('.txtEmail').val(), function (data) {

            if (data != "Success") {
                alert("该账户已被注册，请换一个试试");
            }
        });
    });

    $('#formReg').ajaxForm({
        dataType: 'json',
        success: function (data) {
            if (data.success) {
                window.location.reload(true);

            } else {
                $.ActionResponse('error', '提示', "保存出错：" + data.data);
            }
        }
    });


    $('#submit').click(function () {
        $('#formReg').submit();
    });
};