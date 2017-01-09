var newshoperval = (function () {

    $("#newShoperForm").validate({
        onsubmit: true,// 是否在提交是验证


        rules: {
            Admin_Name: {
                required: true,
                minlength: 6
            },
            DisplayName: {
                required: true,
                minlength: 2
            },
            Admin_PassWord: {
                required: true,
                minlength: 5
            },
            Admin_PassWord1: {
                required: true,
                equalTo: "#Admin_PassWord"
            },
            Email: {
                required: true,
                email: true
            }
        },
        submitHandler: function (form) {  //通过之后回调
            var data = {
                "Admin_Name": $("#Admin_Name").val(),
                "DisplayName": $("#DisplayName").val(),
                "Admin_PassWord": $("#Admin_PassWord").val(),
                "Email": $("#Email").val(),
                "Shop_ID": $("#Shop_ID").val()

            };
            var d = $.toJSON(data);
            var url = "/Shoper/Newshoper";
            $.ajax({
                url: url, //请求的url地址
                dataType: "json", //返回格式为html
                async: false, //请求是否异步，默认为异步，这也是ajax重要特性
                type: "POST", //请求方式
                data: d,
                contentType: "application/octet-stream",

                beforeSend: function () {
                    Pace.start();
                },
                success: function (req) {
                    if (req.Sate === 0) {
                        $('#myModal .modal-body').html('');
                        $('#myModal .modal-body').html('<h2>添加成功！</h2>');
                        $("#SavaDelShop").addClass("hidden");
                    } else {
                        $('#myModal .modal-body').html('');
                        $('#myModal .modal-body').html('<h2>添加失败！</h2><p>错误：' + req.Massge + '</p>');
                        $("#SavaDelShop").addClass("hidden");
                    }
                },
                complete: function (req) {
                   
                },
                error: function () {
                    Pace.stop();
                }
            });
        },

        invalidHandler: function (form, validator) {  //不通过回调
            return false;
        }
    });

});
