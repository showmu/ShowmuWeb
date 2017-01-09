$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    oButtonInit.Init();
    //添加
    $('#btn_add').click(function (e) {
        var a= { UserName: "Jerry", Password: "123" };
        var post = JSON.stringify(a);
        $.ajax({
            type: "POST",
            url: "/Home/Add",
            contentType: "application/json",//必须有
            dataType: "json", //表示返回值类型，不必须
            data: post,//相当于 //data: "{'str1':'foovalue', 'str2':'barvalue'}",
            success: function (data) {
                //获取数据ok
                alert(data.Password + "--" + data.UserName);
            }
        });

    });
    //修改
    $('#btn_edit').click(function (e) {
        var a = $('#tb_departments').bootstrapTable('getSelections').fi;
        var post = JSON.stringify(a);
        $.ajax({
            type: "POST",
            url: "/Web/Edit",
            contentType: "application/x-www-form-urlencoded",//必须有
            dataType: "json", //表示返回值类型，不必须
            data: post,//相当于 //data: "{[{'str1':'foovalue', 'str2':'barvalue'}]}",
            success: function (data) {
                //获取数据ok
              alert(data.id + "--" +data.userName);
            }
        });
    });
    //删除
    $('#btn_delete').click(function (e) {
        var a = $('#tb_departments').bootstrapTable('getSelections');
        var post = JSON.stringify(a);// JSON.stringify(a);
        $.ajax({
            type: "POST",
            url: "/Web/Delete",
            contentType: "application/json",//必须有
            dataType: "json", //表示返回值类型，不必须
            data: post,//相当于 //data: "{'str1':'foovalue', 'str2':'barvalue'}",
            success: function (data) {
                $('#tb_departments').bootstrapTable('refresh');   //获取数据ok
           alert(JSON.toString(data));
            }
        });
    });

});
var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_departments').bootstrapTable({
            url: '/Web/GetUserList',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: true,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            queryParams: oTableInit.queryParams,//传递参数（*）
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize:10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            toolbarAlign:'left',
            search: true,                       //是否显示表格搜索，此搜索是客户端搜索，不会进服务端，所以，个人感觉意义不大
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "ID",                     //每一行的唯一标识，一般为主键列
            showToggle: true,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            showExport: true,                     //是否显示导出
            exportDataType: "basic",              //basic', 'all', 'selected'.
            columns: [{
                checkbox: true
            }, {
                field: 'userName',
                title: '用户名',
                sortable: true                     //是否启用排序
                         
            }, {
                field: 'roleName',
                title: '组名'
            }, {
                field: 'phoneNumber',
                title: '电话'
            }, {
                field: 'eMail',
                title: 'EMail'
            }, ]
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            limit: params.limit,   //页面大小
            offset: params.offset,  //页码
            userName: $("div.search .form-control").val(),
            sortOrder: this.sortOrder,
            sortName: this.sortName
        };
        return  temp;
    };
    return oTableInit;

};


var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
        //初始化页面上面的按钮事件
    };

    return oInit;
};

