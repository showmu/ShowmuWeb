

$().ready(function () {

    $("#shopPhtoOut").on("change", function() {
        var imgFile = this.files[0];
        var i = imgFile.size / 1024;
        if (i > 800) {
            alert("文件太大！");
            $("#ShopPhtoOut").val("");
            return;
        }
        if (this.files && imgFile) {
            var reader = new FileReader();
            reader.onload=function(e) {
                $("#ShopPhtoOutImg").attr("src", e.target.result);
            }
            reader.readAsDataURL(imgFile );
        }

    });
    $("#shopPhtoIn").on("change", function () {
        var imgFile = this.files[0];
        var i = imgFile.size / 1024;
        if (i > 800) {
            alert("文件太大！");
            $("#ShopPhtoOut").val("");
            return;
        }
        if (this.files && imgFile) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $("#ShopPhtoInImg").attr("src", e.target.result);
            }
            reader.readAsDataURL(imgFile);
           
        }

    });
   

    $.getJSON("http://api.map.baidu.com/location/ip?ak=GKOAzA5v930DrG28VwGQKHI0&callback=?", function (d) {
        $("#shopAddres").val(d.content.address);
    });


    $("#newShopForm").validate({
        onsubmit: true,// 是否在提交是验证
   
     
        rules: {
            shopName: {
                required: true,
                minlength: 6
            },
            shopAddres: {
                required: true,
                minlength: 6
            },
            ShopTel: {
                required: true,
                isPhone: true
            }
        },
        submitHandler: function(form) {  //通过之后回调
            var data = {
                "ShopName": $("#shopName").val(),
                "ShopAddres": $("#shopAddres").val(),
                "ShopTel": $("#ShopTel").val(),
                "ShopPhtoOut": $("#ShopPhtoOutImg").attr('src'),
                "ShopPhtoIn": $("#ShopPhtoInImg").attr('src')

            };
            var d = $.toJSON(data);
            var url = "/ShopSet/AddShop";
            $.ajax({
                url: url, //请求的url地址
                dataType: "html", //返回格式为html
                async: false, //请求是否异步，默认为异步，这也是ajax重要特性
                type: "POST", //请求方式
                data: d,
                contentType: "application/octet-stream",

                beforeSend: function () {
                    Pace.start();
                },
                success: function (req) {
                    $.messager.alert('成功', req);
                },
                complete: function () {
                    Pace.stop();
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