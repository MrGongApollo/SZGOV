layui.define(["layer"], function (exports) { var $ = layui.jquery, layer = layui.layer, _modName = "win10", Win10Iframe = function () { this.element = arguments[0], this.cb = arguments[1], this.hasTracked = !1 }, Win10 = { _version: "v1.1.2.4", _debug: !0, _bgs: { main: "", mobile: "" }, _countTask: 0, _newMsgCount: 0, _animated_classes: [], _animated_liveness: 0, _switchMenuTooHurry: !1, _lang: "unknown", _iframeOnClick: { resolution: 200, iframes: [], interval: null, Iframe: function () { var a = Win10._iframeOnClick; a.element = arguments[0], a.cb = arguments[1], a.hasTracked = !1 }, track: function (a, b) { var c = Win10._iframeOnClick; c.iframes.push(new Win10Iframe(a, b)), c.interval || (c.interval = setInterval(function () { c.checkClick() }, c.resolution)) }, checkClick: function () { var a, b, c, d; if (document.activeElement) for (a = document.activeElement, b = Win10._iframeOnClick, c = b.iframes.length - 1; c >= 0 && (d = void 0, b.iframes[c]) ; c--) !(d = b.iframes[c].element.id) || document.getElementById(d) ? a === b.iframes[c].element ? b.iframes[c].hasTracked === !1 && (b.iframes[c].cb.apply(window, []), b.iframes[c].hasTracked = !0) : b.iframes[c].hasTracked = !1 : delete b.iframes[c] } }, _iframe_click_lock_children: {}, _renderBar: function () { if (!(Win10._countTask <= 0)) { var a = $("#win10_btn_group_middle>.btn"); a.css("width", "calc(" + 100 * (1 / Win10._countTask) + "% - 1px )") } }, _handleReady: [], _hideShortcut: function () { var a = $("#win10 #win10-shortcuts .shortcut"); a.removeClass("animated flipInX"), a.addClass("animated flipOutX") }, _showShortcut: function () { var a = $("#win10 #win10-shortcuts .shortcut"); a.removeClass("animated flipOutX"), a.addClass("animated flipInX") }, _checkBgUrls: function () { var c, a = $("#win10>.img-loader"), b = !1; Win10.isSmallScreen() ? Win10._bgs.mobile && (a.each(function () { var a = $(this); a.attr("src") === Win10._bgs.mobile && a.hasClass("loaded") && (Win10._setBackgroundImg(Win10._bgs.mobile), b = !0) }), b || (c = $('<img class="img-loader" src="' + Win10._bgs.mobile + '" />'), $("#win10").append(c), Win10._onImgComplete(c[0], function () { c.addClass("loaded"), Win10._setBackgroundImg(Win10._bgs.mobile) }))) : Win10._bgs.main && (a.each(function () { var a = $(this); a.attr("src") === Win10._bgs.main && a.hasClass("loaded") && (Win10._setBackgroundImg(Win10._bgs.main), b = !0) }), b || (c = $('<img class="img-loader" src="' + Win10._bgs.main + '" />'), $("#win10").append(c), Win10._onImgComplete(c[0], function () { c.addClass("loaded"), Win10._setBackgroundImg(Win10._bgs.main) }))) }, _startAnimate: function () { setInterval(function () { var a = Win10._animated_classes.length, b = Win10._animated_liveness; 0 !== b && 0 !== a && $("#win10-menu").hasClass("opened") && $("#win10-menu>.blocks>.menu_group>.block").each(function () { var c, d; !$(this).hasClass("onAnimate") && Math.random() <= b && (c = $(this), d = Win10._animated_classes[Math.floor(Math.random() * a)], c.addClass("onAnimate"), setTimeout(function () { c.addClass(d), setTimeout(function () { c.removeClass("onAnimate"), c.removeClass(d) }, 3e3) }, 1e3 * 2 * Math.random())) }) }, 1e3) }, _onImgComplete: function (a, b) { if (a) var c = setInterval(function () { a.complete && (b(a), clearInterval(c)) }, 50) }, _setBackgroundImg: function (a) { $("#win10").css("background-image", "url(" + a + ")") }, _settop: function (a) { isNaN(a) || (a = Win10.getLayeroByIndex(a)); var b = 0; $(".win10-open-iframe").each(function () { z = parseInt($(this).css("z-index")), $(this).css("z-index", z - 1), z > b && (b = z) }), a.css("z-index", b + 1) }, _checkTop: function () { var a = 0, b = 0, c = null; $("#win10_btn_group_middle .btn.show").each(function () { var d = $(this).attr("index"), e = Win10.getLayeroByIndex(d), f = e.css("z-index"); f > b && (a = d, b = f, c = $(this)) }), Win10._settop(a), $("#win10_btn_group_middle .btn").removeClass("active"), c && c.addClass("active") }, _renderContextMenu: function (a, b, c, d) { var e, f, g, h, i; if (Win10._removeContextMenu(), c !== !0) { for (e = $("<div class='win10-context-menu'><ul></ul></div>"), $("#win10").append(e), f = e.find("ul"), g = 0; g < c.length; g++) h = c[g], "|" !== h ? "string" != typeof h ? "object" != typeof h || (i = $("<li>" + h[0] + "</li>"), f.append(i), i.click(d, h[1])) : f.append($("<li>" + h + "</li>")) : f.append($("<hr/>")); a + 150 > document.body.clientWidth && (a -= 150), b + e.height() > document.body.clientHeight && (b -= e.height()), e.css({ top: b, left: a }) } }, _removeContextMenu: function () { $(".win10-context-menu").remove() }, _closeWin: function (a) { $("#win10_" + a).remove(), layer.close(a), Win10._checkTop(), Win10._countTask--, Win10._renderBar() }, _fixWindowsHeightAndWidth: function () { var a = $(".win10-open-iframe"), b = document.body.clientHeight; a.each(function () { var a = $(this), c = a.css("height"); c = parseInt(c.replace("px", "")), c + 40 >= b && (a.css("height", b - 40), a.find(".layui-layer-content").css("height", b - 83), a.find(".layui-layer-content iframe").css("height", b - 83)) }) }, _bind_open_windows: function () { $("#win10").on("click", ".win10-open-window", function () { var title, areaAndOffset, bg; $this = $(this), "" !== $this.data("url") && (title = $this.data("title") || "", bg = $this.data("icon-bg") ? $this.data("icon-bg") : "", $this.data("icon-image") && (title = '<img class="icon ' + bg + '" src="' + $this.data("icon-image") + '"/>' + title), $this.data("icon-font") && (title = '<i class="fa fa-fw fa-' + $this.data("icon-font") + " icon " + bg + '"></i>' + title), title || 1 !== $this.children(".icon").length || 1 !== $this.children(".title").length || (title = $this.children(".icon").prop("outerHTML") + $this.children(".title").html()), $this.data("area-offset") && (areaAndOffset = $this.data("area-offset"), -1 !== areaAndOffset.indexOf(",") && (areaAndOffset = eval(areaAndOffset))), Win10.openUrl($this.data("url"), title, areaAndOffset)) }) }, _init: function () { this._lang = (navigator.language || navigator.browserLanguage).toLowerCase(), $("#win10_btn_win").click(function () { Win10.commandCenterClose(), Win10.menuToggle() }), $("#win10_btn_command").click(function () { Win10.menuClose(), Win10.commandCenterToggle() }), $("#win10 .desktop").click(function () { Win10.menuClose(), Win10.commandCenterClose() }), $("#win10").on("click", ".msg .btn_close_msg", function () { var a = $(this).parent(); $(a).addClass("animated slideOutRight"), setTimeout(function () { a.remove() }, 500) }), $("#win10_btn_command_center_clean_all").click(function () { var a = $("#win10_command_center .msg"); a.addClass("animated slideOutRight"), setTimeout(function () { a.remove() }, 1500), setTimeout(function () { Win10.commandCenterClose() }, 1e3) }), $("#win10_btn_show_desktop").click(function () { $("#win10 .desktop").click(), Win10.hideWins() }), $("#win10-menu-switcher").click(function () { var a, b, c, d; Win10._switchMenuTooHurry || (Win10._switchMenuTooHurry = !0, a = "win10-menu-hidden", b = $("#win10-menu>.list"), c = $("#win10-menu>.blocks"), d = function (b) { b.hasClass(a) ? (b.addClass("animated slideInLeft"), b.removeClass("animated slideOutLeft"), b.removeClass(a)) : (setTimeout(function () { b.addClass(a) }, 450), b.addClass("animated slideOutLeft"), b.removeClass("animated slideInLeft")) }, d(b), d(c), setTimeout(function () { Win10._switchMenuTooHurry = !1 }, 520)) }), $("#win10_btn_group_middle").click(function () { $("#win10 .desktop").click() }), $(document).on("click", ".win10-btn-refresh", function () { var a = $(this).attr("index"), b = Win10.getLayeroByIndex(a).find("iframe"); b.attr("src", b.attr("src")) }), $(document).on("click", ".win10-btn-change-url", function () { var a = $(this).attr("index"), b = Win10.getLayeroByIndex(a).find("iframe"); layer.prompt({ title: Win10.lang("编辑网址", "Edit URL"), formType: 2, skin: "win10-layer-open-browser", value: b.attr("src"), area: ["500px", "200px"], zIndex: 99999999999 }, function (a, c) { layer.close(c), layer.msg(Win10.lang("请稍候...", "Hold on please..."), { time: 1500 }, function () { b.attr("src", a) }) }) }), $(document).on("mousedown", ".win10-open-iframe", function () { var a = $(this); Win10._settop(a), Win10._checkTop() }), $("#win10_btn_group_middle").on("click", ".btn_close", function () { var a = $(this).parent().attr("index"); Win10._closeWin(a) }), $("#win10-menu .list").on("click", ".item", function () { var a = $(this); for (a.hasClass("has-sub-down") && ($("#win10-menu .list .item.has-sub-up").toggleClass("has-sub-down").toggleClass("has-sub-up"), $("#win10-menu .list .sub-item").slideUp()), a.next().hasClass("sub-item") && a.toggleClass("has-sub-down").toggleClass("has-sub-up") ; a.next().hasClass("sub-item") ;) a.next().slideToggle(), a = a.next() }), $("#win10-btn-browser").click(function () { layer.prompt({ title: Win10.lang("访问网址", "Visit URL"), formType: 2, value: "", skin: "win10-layer-open-browser", area: ["300px", "150px"], zIndex: 99999999999 }, function (a, b) { layer.close(b), layer.msg(Win10.lang("请稍候...", "Hold on please..."), { time: 1500 }, function () { Win10.openUrl(a, a) }) }) }), setInterval(function () { var a = new Date, b = a.getFullYear(), c = a.getMonth() + 1, d = a.getDate(), e = a.getHours(), f = a.getMinutes(); 10 > f && (f = "0" + f), $("#win10_btn_time").html(e + ":" + f + "<br/>" + b + "/" + c + "/" + d) }, 1e3), Win10.buildList(), Win10._startAnimate(), Win10.renderShortcuts(), $("#win10-shortcuts").removeClass("shortcuts-hidden"), Win10._showShortcut(), Win10.renderMenuBlocks(), $(window).resize(function () { Win10.renderShortcuts(), Win10._checkBgUrls(), Win10.isSmallScreen() || Win10._fixWindowsHeightAndWidth() }), $(document).on("focus", ".win10-layer-open-browser textarea", function () { $(this).attr("spellcheck", "false") }), $(document).on("keyup", ".win10-layer-open-browser textarea", function (a) { 13 === a.keyCode && $(this).parent().parent().find(".layui-layer-btn0").click() }), $(document).click(function (a) { a.button || Win10._removeContextMenu() }), $(document).on("contextmenu", ".win10-context-menu", function (a) { a.preventDefault(), a.stopPropagation() }), Win10.setContextMenu("#win10", !0), Win10.setContextMenu("#win10>.desktop", [['<i class="fa fa-fw fa-star"></i> 收藏本页', function () { var a = window.location, b = document.title, c = navigator.userAgent.toLowerCase(); if (c.indexOf("360se") > -1) layer.alert(Win10.lang("您的浏览器不支持,请按 Ctrl+D 手动收藏!", "Your browser does not support, please press Ctrl+D to manual collection!")); else if (c.indexOf("msie 8") > -1) window.external.AddToFavoritesBar(a, b); else if (document.all) try { window.external.addFavorite(a, b) } catch (d) { layer.alert(Win10.lang("您的浏览器不支持,请按 Ctrl+D 手动收藏!", "Your browser does not support, please press Ctrl+D to manual collection!")) } else window.sidebar ? window.sidebar.addPanel(b, a, "") : layer.alert(Win10.lang("您的浏览器不支持,请按 Ctrl+D 手动收藏!", "Your browser does not support, please press Ctrl+D to manual collection!")) }], ['<i class="fa fa-fw fa-window-maximize"></i> ' + Win10.lang("进入全屏", "Enable Full Screen"), function () { Win10.enableFullScreen() }], ['<i class="fa fa-fw fa-window-restore"></i> ' + Win10.lang("退出全屏", "Disable Full Screen"), function () { Win10.disableFullScreen() }], "|"]), Win10.setContextMenu("#win10_btn_group_middle", [['<i class="fa fa-fw fa-window-maximize"></i> ' + Win10.lang("全部显示", "Show All Windows"), function () { Win10.showWins() }], ['<i class="fa fa-fw fa-window-minimize"></i> ' + Win10.lang("全部隐藏", "Hide All Windows"), function () { Win10.hideWins() }], ['<i class="fa fa-fw fa-window-close"></i> ' + Win10.lang("全部关闭", "Close All Windows"), function () { Win10.closeAll() }]]), setInterval(function () { var a = $("#win10-msg-nof.on-new-msg"); a.length > 0 && a.toggleClass("fa-commenting-o") }, 600), $("body").keyup(function (a) { if (a.ctrlKey) switch (a.keyCode) { case 37: $("#win10_btn_win").click(); break; case 38: Win10.showWins(); break; case 39: $("#win10_btn_command").click(); break; case 40: Win10.hideWins() } }), $("#win10-desktop-scene").length < 1 && ($("#win10-shortcuts").css({ position: "absolute", left: 0, top: 0, "z-index": 100 }), $("#win10 .desktop").append("<div id='win10-desktop-scene' style='width: 100%;height: calc(100% - 40px);position: absolute;left: 0;top: 0; z-index: 0;background-color: transparent;'></div>")), Win10._bind_open_windows() }, setBgUrl: function (a) { Win10._bgs = a, Win10._checkBgUrls() }, menuClose: function () { $("#win10-menu").removeClass("opened"), $("#win10-menu").addClass("hidden"), Win10._showShortcut(), $(".win10-open-iframe").removeClass("hide") }, menuOpen: function () { $("#win10-menu").addClass("opened"), $("#win10-menu").removeClass("hidden"), Win10._hideShortcut(), $(".win10-open-iframe").addClass("hide") }, menuToggle: function () { $("#win10-menu").hasClass("opened") ? Win10.menuClose() : Win10.menuOpen() }, commandCenterClose: function () { $("#win10_command_center").addClass("hidden_right"), Win10._showShortcut(), $(".win10-open-iframe").removeClass("hide") }, commandCenterOpen: function () { $("#win10_command_center").removeClass("hidden_right"), Win10._hideShortcut(), $(".win10-open-iframe").addClass("hide"), $("#win10-msg-nof").removeClass("on-new-msg fa-commenting-o") }, renderShortcuts: function () { var a = parseInt($("#win10 #win10-shortcuts")[0].offsetHeight / 100), b = 0, c = 0; $("#win10 #win10-shortcuts .shortcut").each(function () { $(this).css({ left: 82 * b + 10, top: 100 * c + 10 }), c++, c >= a && (c = 0, b++) }) }, renderMenuBlocks: function () { var a = 44, b = $("#win10-menu .menu_group"); b.each(function () { var b = $(this), c = b.children(".block"), d = 0; c.each(function () { var b = $(this), c = b.attr("loc").split(","), e = b.attr("size").split(","), f = (c[1] - 1) * a + 40, g = e[1] * a, h = f + g; h > d && (d = h), b.css({ top: f, left: (c[0] - 1) * a, width: e[0] * a, height: g }) }), b.css("height", d) }) }, commandCenterToggle: function () { $("#win10_command_center").hasClass("hidden_right") ? Win10.commandCenterOpen() : Win10.commandCenterClose() }, newMsg: function (a, b, c) { var d = $('<div class="msg"><div class="title">' + a + "</div>" + '<div class="content">' + b + "</div>" + '<span class="btn_close_msg fa fa-close"></span>' + "</div>"); $("#win10_command_center .msgs").prepend(d), d.find(".content:first,.title:first").click(function () { c && c(d) }), layer.tips(Win10.lang("新消息:", "New message:") + a, "#win10_btn_command", { tips: [1, "#3c6a4a"], time: 3e3 }), $("#win10_command_center").hasClass("hidden_right") && $("#win10-msg-nof").addClass("on-new-msg") }, getLayeroByIndex: function (a) { return $("#layui-layer" + a) }, isSmallScreen: function (a) { a || (a = 768); var b = document.body.clientWidth; return a > b }, enableFullScreen: function () { var a = document.documentElement; a.requestFullscreen ? a.requestFullscreen() : a.mozRequestFullScreen ? a.mozRequestFullScreen() : a.webkitRequestFullScreen ? a.webkitRequestFullScreen() : a.msRequestFullscreen && document.body.msRequestFullscreen() }, disableFullScreen: function () { document.exitFullscreen ? document.exitFullscreen() : document.mozCancelFullScreen ? document.mozCancelFullScreen() : document.webkitCancelFullScreen ? document.webkitCancelFullScreen() : document.msExitFullscreen && document.msExitFullscreen() }, buildList: function () { $("#win10-menu .list .sub-item").slideUp(), $("#win10-menu .list .item").each(function () { $(this).next().hasClass("sub-item") && ($(this).addClass("has-sub-down"), $(this).removeClass("has-sub-up")) }) }, openUrl: function (a, b, c) { var d, e, f, g, h, i, j, k, l, m; return Win10._countTask > 12 ? (layer.msg("您打开的太多了，歇会儿吧~"), !1) : (Win10._countTask++, a || (a = "404"), a = a.replace(/(^\s*)|(\s*$)/g, ""), d = /^(https?:\/\/|\.\.?\/|\/\/?)/, d.test(a) || (a = "http://" + a), a ? (b || (b = a), Win10.isSmallScreen() || "max" === c ? (e = ["100%", document.body.clientHeight - 40 + "px"], f = ["0", "0"]) : "object" == typeof c ? (e = c[0], f = c[1], g = parseFloat(e[0]) / 100, h = parseFloat(e[1]) / 100, f && "center" != f || (i = parseInt($(window).height()), i = (i - i * h) / 2 - 41, j = parseInt($(window).width()), j = (j - j * g) / 2 - 120, f = [Math.round(20 * (Win10._countTask % 10) + i) + "px", Math.round(20 * (Win10._countTask % 10) + 100 + j) + "px"])) : (e = ["80%", "80%"], i = parseInt($(window).height()), i = (i - .8 * i) / 2 - 41, j = parseInt($(window).width()), j = (j - .8 * j) / 2 - 120, f = [Math.round(20 * (Win10._countTask % 10) + i) + "px", Math.round(20 * (Win10._countTask % 10) + 100 + j) + "px"]), k = layer.open({ type: 2, shadeClose: !0, shade: !1, maxmin: !0, title: b, content: a, area: e, offset: f, isOutAnim: !1, skin: "win10-open-iframe", cancel: function (a) { $("#win10_" + a).remove(), Win10._checkTop(), Win10._countTask--, Win10._renderBar() }, min: function (a) { return a.hide(), $("#win10_" + k).removeClass("show"), Win10._checkTop(), !1 }, full: function (a) { a.find(".layui-layer-min").css("display", "inline-block") } }), $("#win10_btn_group_middle .btn.active").removeClass("active"), l = $('<div id="win10_' + k + '" index="' + k + '" class="btn show active"><div class="btn_title">' + b + '</div><div class="btn_close fa fa-close"></div></div>'), m = Win10.getLayeroByIndex(k), m.css("z-index", Win10._countTask + 813), Win10._settop(m), m.find(".layui-layer-setwin").prepend('<a class="win10-btn-refresh" index="' + k + '" title="' + Win10.lang("刷新", "Refresh") + '" href="javascript:void(0)"><span class="fa fa-refresh"></span></a>'), m.find(".layui-layer-setwin .layui-layer-max").click(function () { setTimeout(function () { var a = m.css("height"); a = parseInt(a.replace("px", "")), a >= document.body.clientHeight && (m.css("height", a - 40), m.find(".layui-layer-content").css("height", a - 83), m.find(".layui-layer-content iframe").css("height", a - 83)) }, 300) }), $("#win10_btn_group_middle").append(l), Win10._renderBar(), l.click(function () { var a = $(this).attr("index"), b = Win10.getLayeroByIndex(a); $(this).hasClass("show") ? $(this).hasClass("active") ? ($(this).removeClass("active"), $(this).removeClass("show"), Win10._checkTop(), b.hide()) : ($("#win10_btn_group_middle .btn.active").removeClass("active"), $(this).addClass("active"), Win10._settop(b)) : ($(this).addClass("show"), $("#win10_btn_group_middle .btn.active").removeClass("active"), $(this).addClass("active"), Win10._settop(b), b.show()) }), Win10._iframeOnClick.track(m.find("iframe:first")[0], function () { 0 === Object.getOwnPropertyNames(Win10._iframe_click_lock_children).length ? (Win10._settop(m), Win10._checkTop()) : console.log("click locked") }), Win10.menuClose(), Win10.commandCenterClose(), k) : (console.warn("请设置url"), void 0)) }, closeAll: function () { $(".win10-open-iframe").remove(), $("#win10_btn_group_middle").html(""), Win10._countTask = 0, Win10._renderBar() }, setAnimated: function (a, b) { Win10._animated_classes = a, Win10._animated_liveness = b }, exit: function () { }, lang: function (a, b) { return "zh-cn" === Win10._lang || "zh-tw" === Win10._lang ? a : b }, aboutUs: function () { layer.open({ type: 1, closeBtn: 1, anim: 2, skin: "layui-layer-molv", title: "WIN10-UI " + Win10._version, shadeClose: !0, area: ["320px", "200px"], content: '<div style="padding: 10px;font-size: 12px"><p>支持组件:layer、jquery、animated.css、font-awesome</p></div>' }) }, setContextMenu: function (a, b) { "string" == typeof a && (a = $(a)), a.unbind("contextmenu"), a.on("contextmenu", function (a) { b && (Win10._renderContextMenu(a.clientX, a.clientY, b, this), a.cancelable && (a.defaultPrevented || a.preventDefault()), a.stopPropagation()) }) }, hideWins: function () { $("#win10_btn_group_middle>.btn.show").each(function () { var a = $(this).attr("index"), b = Win10.getLayeroByIndex(a); $(this).removeClass("show"), $(this).removeClass("active"), b.hide() }) }, showWins: function () { $("#win10_btn_group_middle>.btn").each(function () { var a = $(this).attr("index"), b = Win10.getLayeroByIndex(a); $(this).addClass("show"), b.show() }), Win10._checkTop() }, getDesktopScene: function () { return $("#win10-desktop-scene") }, onReady: function (a) { Win10._handleReady.push(a) } }; exports(_modName, Win10) });