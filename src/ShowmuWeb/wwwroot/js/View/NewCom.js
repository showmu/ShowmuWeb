
$().ready(function () {

    $.getJSON("http://api.map.baidu.com/location/ip?ak=GKOAzA5v930DrG28VwGQKHI0&callback=?", function (d) {
        $("#DetailAddress").val(d.content.address);
    });
    $("#newComForm").validate({
        onsubmit:true,// 是否在提交是验证
    
        errorClass: "error",
        errorElement: "span",
        rules: {
            ComName: {
                required: true,
                minlength: 6
            },
            ComAddres: {
                required: true,
                minlength: 6
            },
            ComTel: {
                required: true,
                isPhone: true
            },
            Supervisor: {
                required: true,
                minlength: 2
            },
            Supervisor_PID: {
                isIdCardNo: true
            }

        },
        submitHandler: function(form) {  //通过之后回调
            var data = {
                "ComName": $("#ComName").val(),
                "ComAddres": $("#ComAddres").val(),
                "ComTel": $("#ComTel").val(),
                "Supervisor": $("#Supervisor").val(),
                "Supervisor_PID": $("#Supervisor_PID").val()

            };
            var d = $.toJSON(data);
            var url = "/Company/NewCom";
            $.ajax({
                url: url, //请求的url地址
                dataType: "html", //返回格式为html
                async: true, //请求是否异步，默认为异步，这也是ajax重要特性
                type: "POST", //请求方式
                data: d,
                contentType: "application/json",

                beforeSend: function () {
                    Pace.start();
                },
                success: function (req) {
                    $.messager.alert('成功', req);
                },
                complete: function () {
                    Pace.stop();
                }
            });
        },

        invalidHandler: function (form, validator) {  //不通过回调
            return false;
        }
    });
   
});