//if (!!window.ActiveXObject || "ActiveXObject" in window)
//{
//    window.top.document.write('请使用非IE浏览器');
//}

var TopWin = window.top,
    baseConst = {
        odata:"/odata/"
    };

(function ($) {
    /********配置，枚举 开始***************/
    $.Cm_Setting = {
        entityState: {
            Deteached: "1&",
            Unchanged: "2&",
            Added: "4&",
            Deleted: "8&",
            Modified: "16&"
        },
        //编辑状态
        editMode: {
            "view": "view",   //默认无
            "add": "add",    //新增
            "edit": "edit",   //修改
            "delete": 3  //删除
        },
        //odata操作符
        odataOper: {
            ">": "gt",
            ">=": "ge",
            "<": "lt",
            "<=": "le",
            "=": "eq",
            "!=": "ne"
        },
        //上传配置参数
        bizData: {
            RelevanceId: "",
            FromModuleName: "",
            FromTableName: "",
            DocName: "",
            ExpandOne: "",
            ExpandTwo: "",
            ExpandThree: "",
            ExpandFour: "",
            ExpandFive: ""
        }
    };
    /********配置，枚举 结束***************/


    $.Cm_DateTime = {
        //时间戳
        TimeTicks: function () {
            return new Date().getTime();
        },
        //获取今日日期
        today: function () {
            return this.dateFormat(new Date(), "yyyy-MM-dd");
        },
        //获取当前时间
        Now: function (format) {
            return this.dateFormat(new Date(), format || "yyyy-MM-dd HH:mm:ss");
        },
        //当月第一天，默认为本月第一天 
        MonthFirstDay: function (date) {
            var _date = (!date ? this.today() : this.dateFormat(date, "yyyy-MM-dd")).replace(/\-/g, "\/");
            return this.dateAddDays(_date, -(new Date(_date).getDate() - 1));
        },
        //当月最后一天，默认为本月最后一天 
        MonthLastDay: function (date) {
            var _date = this.MonthFirstDay(date).replace(/\-/, "\/");
            return this.dateAddDays(this.dateAddMonths(_date, 1), -1);
        },
        //当年第一天
        YearFirstDay: function (date) {
            var _date = (date ? date : this.today()).replace(/\-/g, "\/");
            return this.dateFormat(new Date(_date), "yyyy") + "-01-01";
        },
        //当年最后一天
        YearLastDay: function (date) {
            var _date = (date ? date : this.today()).replace(/\-/g, "\/");
            return this.dateFormat(new Date(_date), "yyyy") + "-12-31";
        },
        //指定时间增加小时
        dateAddHours: function (date, hours, format) {
            if (arguments.length < 2) {
                console.warn("参数数目不合法");
                return;
            }
            if (typeof date !== "string") {
                console.warn("日期类型应为string类型");
                return;
            }
            //ie中 转换 会报错，不支持  - 所以要将 -替换成 /
            var _date = new Date(date.replace(/\-/g, "/")), hh = _date.getHours();
            _date.setHours(hh + hours);
            return this.dateFormat(_date, format || "yyyy-MM-dd HH:mm");
        },
        ///在现有时间上加上指定的天数，返回新的时间字符串
        dateAddDays: function (date, days, format) {
            if (arguments.length < 2) {
                console.warn("参数数目不合法");
                return;
            }
            if (typeof date !== "string") {
                console.warn("日期类型应为string类型");
                return;
            }
            //ie中 转换 会报错，不支持  - 所以要将 -替换成 /
            var _date = new Date(date.replace(/\-/g, "/")), dd = _date.getDate();
            _date.setDate(dd + days);
            return this.dateFormat(_date, format || "yyyy-MM-dd");
        },
        //指定时间增加月份
        dateAddMonths: function (date, months, format) {
            if (arguments.length < 2) {
                console.warn("参数数目不合法");
                return;
            }
            //ie中 转换 会报错，不支持  - 所以要将 -替换成 /
            var _date = new Date(date.replace(/\-/g, "/")), mm = _date.getMonth();
            _date.setMonth(mm + months);
            return this.dateFormat(_date, format || "yyyy-MM-dd");
        },
        //日期格式化，但是安保项目 时间存在问题， 格式化后的时间 会相差8小时
        dateFormat: function (dataValue, fmtOpts) {
            //格式化选项匹配正则
            var formatOptions = {
                numeric: /N\d{1}/ig,
                percent: /P\d{1}/ig,
                currency: /C/ig,
                datetime: /yy(yy{0,1})|M{2}|dd|HH{1}|mm{1}|ss{1}/ig
            };
            //格式化日期
            if (fmtOpts.match(formatOptions.datetime) !== null) {
                var _dataValue = dataValue;
                var _dateParse = {
                    msJsonDate: /^\/Date\((\-)?\d*(|\+?\d*)\)\/$/ig,
                    stringDate: /^\d{4}[\/-][0-1]\d[\/-][0-3]\d($|\s\d{2}(:\d{2}){1,2})$/ig, ///^\d{4}[\.\/-]?[0-1]{1}[0-9]{1}(|[\.\/-]?[0-3]{1}[0-9]{1}[\.\/-]?|\s?[0-1]{1}[0-9]{1}|:?[0-1]{1}[0-9]{1}|:?[0-1]{1}[0-9]{1}|:?\d*)$/ig,
                    dtData: /^\d{8}\s\d{2}:\d{2}:\d{2}$/,
                    cludeTDate: /^\d{4}-\d{2}-\d{2}(T|t)\d{2}:\d{2}:\d{2}/
                }
                //判断是否为日期格式，不是需要转换成日期格式
                if (dataValue instanceof Date === false) {
                    //微软JSON日期格式，可带时区可不带
                    if (_dateParse.msJsonDate.test(dataValue)) {
                        var _regex = /^\/Date\(|\)\/$/ig;
                        var _dates = (dataValue + "").replace(_regex, "").split("+");
                        if (_dates.length > 1) {
                            _dataValue = new Date(parseInt(_dates[0]) + parseInt(_dates[1]));
                        }
                        else {
                            //添加本地时区
                            var d = new Date();
                            var localOffset = d.getTimezoneOffset() * 60000;
                            localOffset = 0;
                            _dataValue = new Date(parseInt(_dates[0]) + localOffset);
                        }
                    }
                        //判断是否为数字格式如：20101010101010
                    else if (_dateParse.stringDate.test(dataValue)) {
                        if ($.isNumeric(dataValue) === true) {
                            var _yy = (dataValue + "").substr(0, 4);
                            var _mm = (dataValue + "").substr(4, 2);
                            var _dd = (dataValue + "").substr(6, 2);
                            var _hh = (dataValue + "").substr(8, 2);
                            var _mi = (dataValue + "").substr(10, 2);
                            var _ss = (dataValue + "").substr(12, 2);
                            _dataValue = new Date(
                            _yy + "/"
                            + _mm + "/"
                            + (_dd === "" ? "01" : _dd) + " "
                            + (_hh === "" ? "00" : _hh) + ":"
                            + (_mi === "" ? "00" : _mi) + ":"
                            + (_ss === "" ? "00" : _ss));
                        }
                        else {
                            _dataValue = (dataValue + "").replace(/[-\.]/g, "/");
                            _dataValue = new Date(_dataValue);
                        }
                    } else if (_dateParse.dtData.test(dataValue)) {
                        var _yy = (dataValue + "").substr(0, 4);
                        var _mm = (dataValue + "").substr(4, 2);
                        var _dd = (dataValue + "").substr(6, 2);
                        var _hh = (dataValue + "").substr(8);
                        _dataValue = new Date(
                            _yy + "/"
                            + _mm + "/" + _dd + _hh);
                    } else if (_dateParse.cludeTDate.test(dataValue)) {
                        var _yy = (dataValue + "").substr(0, 4);
                        var _mm = (dataValue + "").substr(5, 2);
                        var _dd = (dataValue + "").substr(8, 2);
                        var _hh = (dataValue + "").substr(11);
                        _dataValue = new Date(
                            _yy + "/"
                            + _mm + "/" + _dd + " " + _hh);
                    }
                }
                //补零
                var zeroize = function (value, length) {
                    if (!length) {
                        length = 2;
                    }
                    value = new String(value);
                    for (var i = 0, zeros = ''; i < (length - value.length) ; i++) {
                        zeros += '0';
                    }
                    return zeros + value;
                };
                //是否已转成日期
                if (_dataValue instanceof Date) {
                    return fmtOpts.replace(formatOptions.datetime, function ($0) {
                        switch ($0) {
                            case 'dd': return zeroize(_dataValue.getDate());
                            case 'MM': return zeroize(_dataValue.getMonth() + 1);
                            case 'yy': return new String(_dataValue.getFullYear()).substr(2);
                            case 'yyyy': return _dataValue.getFullYear();
                            case 'HH': return zeroize(_dataValue.getHours());
                            case 'mm': return zeroize(_dataValue.getMinutes());
                            case 'ss': return zeroize(_dataValue.getSeconds());
                        }
                    });
                }
                else { return dataValue; }
            }
            else { return dataValue; }
        },
        //将时间格式化成  yyyy-MM-dd     安保项目 时间存在问题， 该方法会更正误差的8小时
        dateFormatAnbao: function (dataValue) {
            if (!dataValue) return "";
            var that = this;
            return that.dateFormat(new Date(that.dateFormathmsAnbao(dataValue).replace(/\-/g, "/")), "yyyy-MM-dd"); //调用了dateFormathmsAnbao该方法会更正误差的8小时
        },
        //将时间格式化成  yyyy-MM-dd HH:mm     安保项目 时间存在问题， 该方法会将转换后的时间+8小时
        dateFormathmAnbao: function (dataValue) {
            if (!dataValue) { return ""; }
            var that = this;
            return that.dateFormat(new Date(that.dateFormathmsAnbao(dataValue).replace(/\-/g, "/")), "yyyy-MM-dd HH:mm"); //调用了dateFormathmsAnbao，该方法会更正误差的8小时
        },
        //将时间格式化成  yyyy-MM-dd HH:mm:ss    安保项目 时间存在问题， 该方法会将转换后的时间+8小时
        dateFormathmsAnbao: function (dataValue) {
            if (!dataValue) { return ""; }
            var RegDate = {
                msJsonDate: /^\/Date\((\-)?\d*(|\+?\d*)\)\/$/ig,
                stringDate: /^\d{4}[\/-][0-1]\d[\/-][0-3]\d($|(T|\s)\d{2}(:\d{2}){1,2}(\.\d{3})?Z?)$/ig
            };
            var that = this, _dataValue = null;
            if (RegDate.msJsonDate.test(dataValue)) {
                var localOffset = new Date().getTimezoneOffset() * 60 * 1000; //时区 东八区
                _dataValue = new Date(parseInt(dataValue.replace(/[^\d\-]/g, ""), 10) + localOffset);
            }
            else if (RegDate.stringDate.test(dataValue)) {
                _dataValue = new Date(dataValue.replace(/\-/g, "/").replace(/^([^T]+)T([^Z]+)Z?$/, "$1 $2"));
            }
            else {
                return dataValue;
            }
            return that.dateFormat(_dataValue, "yyyy-MM-dd HH:mm:ss"); //该方法会更正误差的8小时
        },
        //时间差
        dateDiff: function (dtb, dte) {
            try {
                var dateB = new Date(this.dateFormat(dtb, "yyyy/MM/dd")), //开始时间
                dateE = new Date(this.dateFormat(dte, "yyyy/MM/dd")); //结束时间
                return (dateB.getTime() - dateE.getTime()) / 864E5;
            }
            catch (e) {
                console.error(e.message);
            }
        },
        //获取当前周的周几的日期
        getWeekday: function (weekday) {
            var d = new Date();
            return new Date(d - ((d.getDay() || 7) - weekday) * 864E5); //864E5=1000(毫秒)*60*60*24  1天的时间
        }
    };


    $.Cm_Ajax = {
        get: function (_option, _data) {
            try {
                var ajaxconfig =
                                {
                                    type: "GET",
                                    contentType: "application/json",
                                    dataType: 'json',
                                    async: false
                                };
                if (!_option) { console.warn("参数不可为空！"); return; }
                switch (typeof _option) {
                    case "string":
                        ajaxconfig.url = encodeURI(_option); //地址栏里转码
                        ajaxconfig.data = _data || {};
                        break;
                    case "object":
                        _option.url = encodeURI(_option.url); //地址栏里转码
                        $.extend(ajaxconfig, _option);
                        break;
                    default:
                        console.warn("参数类型不正确，必须是string,或者object");
                        return;

                }

                return $.ajax(ajaxconfig);
            }
            catch (e) {
                console.error(e.message);
            }

        },
        //异步
        getAsync: function (_option, _data) {
            try {
                var ajaxconfig =
                                {
                                    type: "GET",
                                    contentType: "application/json",
                                    dataType: 'json'
                                };
                if (!_option) { console.warn("参数不可为空！"); return; }
                switch (typeof _option) {
                    case "string":
                        ajaxconfig.url = encodeURI(_option); //地址栏里转码
                        ajaxconfig.data = _data || {};
                        break;
                    case "object":
                        _option.url = encodeURI(_option.url); //地址栏里转码
                        $.extend(ajaxconfig, _option);
                        break;
                    default:
                        console.warn("参数类型不正确，必须是string,或者object");
                        return;

                }
                return $.ajax(ajaxconfig);
            }
            catch (e) {
                console.error(e.message);
            }

        },
        //put
        put: function (_option, _data) {
            try {
                if (!_option) { console.warn("参数不可为空！"); return; }
                var ajaxconfig =
                {
                    type: "PATCH",
                    async: false,
                    contentType: "application/json",
                    dataType: 'json'
                };

                switch (typeof _option) {
                    case "object":
                        $.extend(ajaxconfig, _option);
                        break;
                    case "string":
                        ajaxconfig.data = _data || {};
                        ajaxconfig.url = _option;
                        break;
                    default:
                        console.warn("参数类型不合法");
                        return;
                }

                ajaxconfig.url = encodeURI(ajaxconfig.url); //地址栏里转码
                ajaxconfig.data = JSON.stringify(ajaxconfig.data); //序列化
                return $.ajax(ajaxconfig);
            }
            catch (e) {
                console.error(e.message);
            }
        },
        //异步
        putAsync: function (_option, _data) {
            try {
                if (!_option) { console.warn("参数不可为空！"); return; }
                var ajaxconfig =
                {
                    type: "PATCH",
                    contentType: "application/json",
                    dataType: 'json'
                };

                switch (typeof _option) {
                    case "object":
                        $.extend(ajaxconfig, _option);
                        break;
                    case "string":
                        ajaxconfig.data = _data || {};
                        ajaxconfig.url = _option;
                        break;
                    default:
                        console.warn("参数类型不合法");
                        return;
                }

                ajaxconfig.url = encodeURI(ajaxconfig.url); //地址栏里转码
                ajaxconfig.data = JSON.stringify(ajaxconfig.data); //序列化
                return $.ajax(ajaxconfig);
            }
            catch (e) {
                console.error(e.message);
            }
        },
        //ajax post方法 默认为同步，若使用异步，则可以通过传参 async: true
        //方法使用：
        //同 get方法
        post: function (_option, _data) {
            try {
                if (!_option) { console.warn("参数不可为空！"); return; }
                var ajaxconfig =
                {
                    type: "POST",
                    async: false,
                    contentType: "application/json",
                    dataType: 'json'
                };

                switch (typeof _option) {
                    case "object":
                        $.extend(ajaxconfig, _option);
                        break;
                    case "string":
                        ajaxconfig.data = _data || {};
                        ajaxconfig.url = _option;
                        break;
                    default:
                        console.warn("参数类型不合法");
                        return;
                }

                ajaxconfig.url = encodeURI(ajaxconfig.url); //地址栏里转码
                ajaxconfig.data = JSON.stringify(ajaxconfig.data); //序列化
                return $.ajax(ajaxconfig);
            }
            catch (e) {
                console.error(e.message);
            }
        },
        //异步
        postAsync: function (_option, _data) {
            try {
                if (!_option) { console.warn("参数不可为空！"); return; }
                var ajaxconfig =
                {
                    type: "POST",
                    contentType: "application/json",
                    dataType: 'json'
                };

                switch (typeof _option) {
                    case "object":
                        $.extend(ajaxconfig, _option);
                        break;
                    case "string":
                        ajaxconfig.data = _data || {};
                        ajaxconfig.url = _option;
                        break;
                    default:
                        console.warn("参数类型不合法");
                        return;
                }

                ajaxconfig.url = encodeURI(ajaxconfig.url); //地址栏里转码
                ajaxconfig.data = JSON.stringify(ajaxconfig.data); //序列化
                return $.ajax(ajaxconfig);
            }
            catch (e) {
                console.error(e.message);
            }
        }
    };


    /*******其他公共调用 开始**********/
    $.Cm_Common = {
        //字符串截取
        Substr: function (_str, _len, _t) {
            if (_str && _len) {
                return _str.length > _len ? _str.substr(0, _len) + (_t || "") : _str;
            }
            return "";
        },
        //获取guid
        getGuid: function () {
            var ret = null;
            $.Cm_Ajax.get("/XT/GetGUID").done(function (xhr) {
                ret = xhr;
            });
            return ret;
        },
        //检查数据是否为当前登录人创建
        checkDataOwer: function (data, prop) {
            if (!data) {
                console.log("请传入data");
                return;
            }
            var user = Cm_Auth.userInfo();
            if (!user) { Cm_Dialogs.normalBox("未能获取到当前用户信息！"); return; }
            var realEmp;
            if (prop) {
                realEmp = data[prop];
            }
            else {
                realEmp = data.CreateBy || data.CreateByEmpCode;
            }
            return realEmp == user.EmpCode;
        },
        getDeviceType: function () {
            var browser = {
                versions: function () {
                    var u = navigator.userAgent,
                        app = navigator.appVersion;
                    return {//移动终端浏览器版本信息   
                        trident: u.indexOf('Trident') > -1, //IE内核  
                        presto: u.indexOf('Presto') > -1, //opera内核  
                        webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核  
                        gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核  
                        mobile: !!u.match(/AppleWebKit.*Mobile.*/), //是否为移动终端  
                        ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端  
                        android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器  
                        iPhone: u.indexOf('iPhone') > -1, //是否为iPhone或者QQHD浏览器  
                        iPad: u.indexOf('iPad') > -1, //是否iPad    
                        webApp: u.indexOf('Safari') == -1, //是否web应该程序，没有头部与底部  
                        weixin: u.indexOf('MicroMessenger') > -1, //是否微信   
                        qq: u.match(/\sQQ/i) == " qq" //是否QQ  
                    };
                }(),
                language: (navigator.browserLanguage || navigator.language).toLowerCase()
            };

            var ret = browser.versions;
            ret.type="";
            if (ret.mobile || ret.ios || ret.android || ret.iPhone || ret.iPad)
            {
                ret.type = "mobile";
            }
            return ret;
        }
    };
    /*******其他公共调用 结束**********/

    /*******窗口调用 开始**********/
    $.Cm_Dialog =
    {
        //上传文件列表封装
        UploadFileList: function (options)
        {
            var defaults =
            {
                title: "附件上传",
                area: ['800px', '520px'],
                IsReadOnly:true,
                RootUrl:"/",
                container: null,
                maxmin: false,
                callBack: function () { },
                setting: {
                    accept: 'file', //允许上传的文件类型：images/file/video/audio
                    multiple: true,//是否允许多文件上传，不支持ie8-9
                    auto: false,//是否选完文件后自动上传
                    exts: '',//允许上传的文件后缀名
                    size: 51200,//文件限制大小，默认不限制（单位 kb）限制 50M
                    data: {}
                }
            };

            $.extend(true,defaults, options);
            if (!(TopWin.layer)) { console.log("TopWin.layer为空"); return; }
            if (!defaults.container) { console.log("container为空，请传入参数！"); return; }
            try
            {
                var $btn = $("<button>",
                    {
                        "class": "layui-btn layui-btn-sm layui-btn-normal",
                        "type": "button"
                    }).text("添加附件").click(function() {
                        var _frm;
                        TopWin.layer.open({
                            type: 2,
                            title: defaults.title,
                            area: defaults.area,
                            fixed: true, //不固定
                            maxmin: defaults.maxmin,
                            content: defaults.RootUrl + "XT/FileList",
                            success: function (frm) {
                                _frm = frm.find("iframe").get(0).contentWindow;
                                if (typeof _frm.pageLoad == "function") {
                                    _frm.pageLoad(defaults.setting);
                                }
                            },
                            close: function (index) {
                                
                            },
                            end: function (index) {
                                if (_frm) {
                                    if (typeof _frm.postBack == "function" && defaults.callBack)
                                    {
                                        var callBackData = _frm.postBack();

                                        if (callBackData && callBackData.length > 0)
                                        {

                                            $.each(callBackData, function (_i, _t) {

                                                var size = "";
                                                if (_t.Size / 1024 > 1024) {
                                                    size = Math.round((_t.Size / 1048576) * Math.pow(10, 2)) / Math.pow(10, 2);
                                                    size += " MB";
                                                }
                                                else {
                                                    size = Math.round((_t.Size / 1024) * Math.pow(10, 2)) / Math.pow(10, 2);
                                                    size += " KB";
                                                }
                                                var $op_td = $("<td>").append($("<a>", { "href": "javascript:;", "title": "下载", "class": "layui-btn layui-btn-xs layui-btn-normal" }).click(function () {

                                                }).append($("<i>", { "class": "fa fa-download" }))).append($("<a>", { "href": "javascript:;", "title": "删除", "class": "layui-btn layui-btn-xs layui-btn-danger" }).click(function () {
                                                    var $that = $(this);
                                                    TopWin.layer.confirm('确认删除选择文件？', {
                                                        btn: ['是', '否'] //按钮
                                                    }, function () {
                                                        var _index = TopWin.layer.load(0, { shade: false });
                                                        $.Cm_Ajax.postAsync(defaults.RootUrl + "XT/FilesDelete", { docIds: [_t.DocId] }).done(function (xhr) {
                                                            if (xhr.Ret) {
                                                                TopWin.layer.msg("删除成功");
                                                                $that.closest("tr").remove();
                                                            }
                                                            else {
                                                                TopWin.layer.alert(xhr.Msg, {
                                                                    icon: 2,
                                                                    skin: 'layer-ext-moon'
                                                                });
                                                            }
                                                        }).always(function () {
                                                            TopWin.layer.close(_index);
                                                        });
                                                    }, function () { });
                                                }).append($("<i>", {"class":"fa fa-remove"})));

                                                $tbody.append($(['<tr>'
                                                , '<td><div title=\"' + _t.DocName + '\">' + $.Cm_Common.Substr(_t.DocName, 30, "...") + '</div></td>'
                                                , '<td class=\"text-center\">' + size + '</td>'
                                                , '<td class=\"text-center\">' + $.Cm_DateTime.dateFormat(_t.CreateTime, "yyyy-MM-dd HH:mm:ss") + '</td>'
                                              , '</tr>'].join('')).append($op_td));
                                            });
                                        }

                                        defaults.callBack(callBackData);
                                    }
                                }
                            
                        }
                    });
                    }),
                    $list = $("<div>", {
                        "class": "layui-upload-list"
                    }),
                    $tb = $("<table>", { "class": "layui-table layui-table-fileList" }).append("<thead><tr><th>文件名</th><th>大小</th><th>上传时间</th><th>操作</th></tr></thead>"),
                    $tbody = $("<tbody>");

                $(defaults.container).append(defaults.IsReadOnly ? "" : $btn)
                                     .append($list)
                                     .append($tb.append($tbody));


                //加载附件
                var filters = [], _docInfo = defaults.setting.data;
                filters.push("(IsDeleted eq false)");
                _docInfo.RelevanceId ? filters.push("(RelevanceId eq '" + _docInfo.RelevanceId + "')"):"";
                _docInfo.FromModuleName ? filters.push("(FromModuleName eq '" + _docInfo.FromModuleName + "')") : "";
                _docInfo.FromTableName ? filters.push("(FromTableName eq '" + _docInfo.FromTableName + "')") : "";
                _docInfo.ExpandOne ? filters.push("(ExpandOne eq '" + _docInfo.ExpandOne + "')") : "";
                _docInfo.ExpandTwo ? filters.push("(ExpandTwo eq '" + _docInfo.ExpandTwo + "')") : "";
                _docInfo.ExpandThree ? filters.push("(ExpandThree eq '" + _docInfo.ExpandThree + "')") : "";
                _docInfo.ExpandFour ? filters.push("(ExpandFour eq '" + _docInfo.ExpandFour + "')") : "";
                _docInfo.ExpandFive ? filters.push("(ExpandFive eq '" + _docInfo.ExpandFive + "')") : "";

                $.Cm_Ajax.getAsync(baseConst.odata + "T_XT_Doc_Entity?$filter=" + filters.join(" and ")+"&$orderby=CreateTime").done(function (xhr) {
                    $.each(xhr.value, function (_i, _t) {

                        var size = "";
                        if (_t.DocSize / 1024 > 1024) {
                            size = Math.round((_t.DocSize / 1048576) * Math.pow(10, 2)) / Math.pow(10, 2);
                            size += " MB";
                        }
                        else {
                            size = Math.round((_t.DocSize / 1024) * Math.pow(10, 2)) / Math.pow(10, 2);
                            size += " KB";
                        }

                        var $op_td = $("<td>", {"class":"text-center"}).append($("<a>", { "href": "javascript:;", "title": "下载", "class": "layui-btn layui-btn-xs layui-btn-normal","style":"margin-right:3px;" }).click(function () {

                        }).append($("<i>", { "class": "fa fa-download" }))).append(defaults.IsReadOnly?"":($("<a>", { "href": "javascript:;", "title": "删除", "class": "layui-btn layui-btn-xs layui-btn-danger" }).click(function () {
                            var $that = $(this);
  
                            TopWin.layer.confirm('是否确认删除（不可恢复）？', {
                                btn: ['是', '否'] //按钮
                            }, function () {
                                var _index = TopWin.layer.load(0, { shade: false });
                                $.Cm_Ajax.postAsync(defaults.RootUrl + "XT/FilesDelete", { docIds: [_t.DocId] }).done(function (xhr) {
                                    if (xhr.Ret) {
                                        TopWin.layer.msg("删除成功");
                                        $that.closest("tr").remove();
                                    }
                                    else {
                                        TopWin.layer.alert(xhr.Msg, {
                                            icon: 2,
                                            skin: 'layer-ext-moon'
                                        });
                                    }
                                }).always(function () {
                                    TopWin.layer.close(_index);
                                });
                            }, function () { });

                        }).append($("<i>", { "class": "fa fa-remove" }))));

                        $tbody.append($(['<tr>'
                        , '<td><div title=\"' + _t.DocName + '\">' + $.Cm_Common.Substr(_t.DocName, 30, "...") + '</div></td>'
                        , '<td class=\"text-center\">' + size + '</td>'
                        , '<td class=\"text-center\">' + $.Cm_DateTime.dateFormat(_t.CreateTime, "yyyy-MM-dd HH:mm:ss") + '</td>'
                        , '</tr>'].join('')).append($op_td));

                    });

                });

            }
            catch (e)
            {
                console.error(e);
            }

        },
        UploadFiles: function (options)
        {
            var defaults =
            {
                title: "附件上传",
                Toplayer: null,
                callBack:function(){},
                setting: {
                    accept: 'file', //允许上传的文件类型：images/file/video/audio
                    multiple: false,//是否允许多文件上传，不支持ie8-9
                    auto: false,//是否选完文件后自动上传
                    exts: '',//允许上传的文件后缀名
                    size: 0,//文件限制大小，默认不限制
                    data: {}
                },
                
            };
            $.extend(defaults, options);

            if (defaults.Toplayer)
            {

            }
        },
        showImgScan: function (options)
        {
            var defaults =
            {
                title: "图片上传",
                area: ['800px', '520px'],
                IsReadOnly: true,
                RootUrl: "/",
                container: null,
                maxmin: false,
                callBack: function () { },
                setting: {
                    accept: 'images', //允许上传的文件类型：images/file/video/audio
                    multiple: true,//是否允许多文件上传，不支持ie8-9
                    auto: false,//是否选完文件后自动上传
                    exts: '',//允许上传的文件后缀名
                    size: 10240,//文件限制大小，默认不限制(单位 kb) 限制 10M
                    data: {}
                }
            };

            $.extend(true,defaults, options);
            if (!(TopWin.layer)) { console.log("TopWin.layer为空"); return; }
            if (!defaults.container) { console.log("container为空，请传入参数！"); return; }
            try
            {
                var $btn = $("<button>",
                    {
                        "class": "layui-btn layui-btn-sm layui-btn-normal",
                        "type": "button"
                    }).text("添加图片").click(function () {
                        var _frm;
                        TopWin.layer.open({
                            type: 2,
                            title: defaults.title,
                            area: defaults.area,
                            fixed: true, //不固定
                            maxmin: defaults.maxmin,
                            content: defaults.RootUrl + "XT/FileList",
                            success: function (frm) {
                                _frm = frm.find("iframe").get(0).contentWindow;
                                if (typeof _frm.pageLoad == "function") {
                                    _frm.pageLoad(defaults.setting);
                                }
                            },
                            close: function (index) {

                            },
                            end: function (index) {
                                if (_frm) {
                                    if (typeof _frm.postBack == "function" && defaults.callBack) {
                                        var callBackData = _frm.postBack();

                                        if (callBackData && callBackData.length > 0) {
                                            var _layIndex = TopWin.layer.load();
                                            $Imglist.remove();
                                            loadImglist();//重加载
                                            TopWin.layer.close(_layIndex);
                                        }
                                        defaults.callBack(callBackData);
                                    }
                                }

                            }
                        });
                    }),
                    $blockquote = $("<blockquote>", {
                        "class": "layui-elem-quote layui-quote-nm margin_tb_5"
                    }).text("预览图：(点击图片放大)"),
                    $Imglist;

                $(defaults.container).append(defaults.IsReadOnly ? "" : $btn)
                                     .append($blockquote);

                var loadImglist = function ()
                {
                    $Imglist = $("<div>", { "class": "layui-upload-list layui-img-scan" });

                    $blockquote.append($Imglist);

                    //加载附件
                    var filters = [], _docInfo = defaults.setting.data;
                    filters.push("(IsDeleted eq false)");
                    _docInfo.RelevanceId ? filters.push("(RelevanceId eq '" + _docInfo.RelevanceId + "')") : "";
                    _docInfo.FromModuleName ? filters.push("(FromModuleName eq '" + _docInfo.FromModuleName + "')") : "";
                    _docInfo.FromTableName ? filters.push("(FromTableName eq '" + _docInfo.FromTableName + "')") : "";
                    _docInfo.ExpandOne ? filters.push("(ExpandOne eq '" + _docInfo.ExpandOne + "')") : "";
                    _docInfo.ExpandTwo ? filters.push("(ExpandTwo eq '" + _docInfo.ExpandTwo + "')") : "";
                    _docInfo.ExpandThree ? filters.push("(ExpandThree eq '" + _docInfo.ExpandThree + "')") : "";
                    _docInfo.ExpandFour ? filters.push("(ExpandFour eq '" + _docInfo.ExpandFour + "')") : "";
                    _docInfo.ExpandFive ? filters.push("(ExpandFive eq '" + _docInfo.ExpandFive + "')") : "";

                    $.Cm_Ajax.getAsync(baseConst.odata + "T_XT_Doc_Entity?$filter=" + filters.join(" and ") + "&$orderby=CreateTime").done(function (xhr) {
                        $.each(xhr.value, function (_i, _t) {
                            var _imgsrc = defaults.RootUrl + "DocLib/" + _t.SubDirectory + "/" + _t.InternalName,
                               $liItem = $("<li>"),
                               $closebtn = $("<a>", { "class": "layui-btn layui-btn-xs layui-btn-radius layui-btn-danger btn-close" }).append($("<i>", { "class": "fa fa-close" })).click(function () {
                                   var $that = $(this);
                                   TopWin.layer.confirm('是否确认删除该图片（不可恢复）？', {
                                       btn: ['是', '否'] //按钮
                                   }, function () {
                                       var _index = TopWin.layer.load(0, { shade: false });
                                       $.Cm_Ajax.postAsync(defaults.RootUrl + "XT/FilesDelete", { docIds: [_t.DocId] }).done(function (xhr) {
                                           if (xhr.Ret) {
                                               TopWin.layer.msg("删除成功");
                                               $that.closest("li").remove();
                                           }
                                           else {
                                               TopWin.layer.alert(xhr.Msg, {
                                                   icon: 2,
                                                   skin: 'layer-ext-moon'
                                               });
                                           }
                                       }).always(function () {
                                           TopWin.layer.close(_index);
                                       });
                                   }, function () { });
                               }),
                               $ImgItem = $("<img>", { "src": _imgsrc, "layer-src": _imgsrc, "layer-index": _i, "alt": _t.DocName, "class": "layui-upload-img" });
                            
                            $Imglist.append($liItem.append($ImgItem).append(defaults.IsReadOnly?"":$closebtn));

                        });

                        TopWin.layer.photos({
                            photos: $Imglist, //格式见API文档手册页
                            //shadeClose: true,
                            img:"li>img",
                            closeBtn: true,
                            moveOut: false,
                            anim: 5 //0-6的选择，指定弹出图片动画类型，默认随机
                        });

                    });
                }

                loadImglist();//初始化

            }
            catch (e)
            {
                console.error(e);
            }

        }
    };
    /*******窗口调用 结束**********/

    /*******用户权限 开始**********/
    $.Cm_Auth = {
        //当前用户个人信息
        userInfo: function ()
        {
            return window.top.userInfo || {};
        },
        //授权机构
        PowerOrgs: function () {
            var AuthorOrg = [], curuser = this.userInfo();
            if (!curuser) return;
            new WebAjax().get("/Wcf/ZJ.svc/T_XT_OrganizationHierarchy()?$filter=T_XT_Auth/any(item:item/T_XT_Role/T_XT_RoleUser/any(temp:temp/EmpCode eq '" + curuser.EmpCode + "'))").done(function (data) {
                $.each(data.d, function (index, item) {
                    AuthorOrg.push({
                        HierarchyCode: item.HierarchyCode,
                        OrgCode: item.OrgCode,
                        InternalHierarchyCode: item.InternalHierarchyCode,
                        InternalHierarchyName: item.InternalHierarchyName
                    });
                });
                var orglength = AuthorOrg.length;
                //移除授权机构的子机构
                for (var i = 0; i < orglength; i++) {
                    var temp = AuthorOrg.pop(); //从数组尾部移出一个元素
                    var flag = true; //默认不是子机构
                    //如果剩下的机构是temp的父一级的机构,移除temp
                    for (var j = 0; j < AuthorOrg.length; j++) {
                        if (temp.HierarchyCode.indexOf(AuthorOrg[j].HierarchyCode) != -1) {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) {
                        AuthorOrg.unshift(temp); //在数组头部加入一个元素
                    }
                }

            });
            //如果没有授权默认为当前用户二级厂部
            if (AuthorOrg.length == 0) {
                try {
                    AuthorOrg.push({ OrgCode: curuser.DefaultOrg.OrgCode, InternalHierarchyCode: curuser.DefaultOrg.InternalHierarchyCode, InternalHierarchyName: curuser.DefaultOrg.InternalHierarchyName, HierarchyCode: curuser.DefaultOrg.HierarchyCode });
                }
                catch (e) {
                    console.error(e.message);
                }
            }
            return AuthorOrg;
        }
    };
    /*******用户权限 结束**********/

})(jQuery)


//兼容写法，防止ie版本过低console报错
window.console = window.console || (function () {
    var c = {}; c.log = c.warn = c.debug = c.info = c.error = c.time = c.dir = c.profile
    = c.clear = c.exception = c.trace = c.assert = function () { };
    return c;
})();