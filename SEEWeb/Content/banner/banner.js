/**
* 制作思路把所有图片排成一排，超出窗口隐藏，用控制器控制$('.slides')的margin左右移动。
*/

; $(function ($, window, document, undefined) {
    slide = function (container, options) {
        /*
         options = {
             auto: true,
             time: 3000,
             event: 'hover' | 'click',
             activeControllerCls: 'className',
             exchangeEnd: $.noop
         }
         */
        "use strict";
        if (!container) return;
        var options = options||{},
            isAuto = options.auto,//是否自动
            controller = options.controller,//控制器类名
            event = options.event,//控制器的控制方式
            interval,
            slidesWrapper = container.children().first(),//第一个图片的权重
            length = container.children().length + 1,//图片的个数
            childWidth = container.width(),//图片窗口的宽度
            totalWidth = childWidth * length;//图片的总宽度
        $(".slideBox").css({"width":totalWidth});
        $(controller.children().eq(0)).addClass('active');

        var toNum = true;
        function prev() {//上一页
            if($(".active").index() == 0){
                toNum = length - 1;
            }else{
                toNum = $(".active").index() - 1
            }

            locate(toNum);
        }

        function next() {//下一页
            if($(".active").index() == (length -1)){
                toNum = 0;
            }else{
                toNum = $(".active").index() + 1
            }

            locate(toNum);
        }

        function slideAuto() {//自动播放
            if(isAuto == true){
                interval = setInterval(function () {
                    next();
                }, options.time)
            }
        }

        function locate(num) {//定位
            $(controller.children()).removeClass("active");
            $(controller.children().eq(num)).addClass('active');
            $('.slides').css({"margin-left": "-" + (num * childWidth)+"px"});
        }

        function stop() {//鼠标悬停
            clearInterval(interval);
        }

        slideAuto();

        $(".flexslider").mouseover(function () {
            stop();
        }).mouseout(function () {
            slideAuto();
        });


        if(event == "hover"){//event判断点击或者移至
            $(controller.children()).mouseover(function (){
                locate($(this).index());
            });
        }else if(event == "click"){
            $(controller.children()).click(function (){
                locate($(this).index());
            });
        }


        return {
            prev: function () {
                prev();
            },
            next: function () {
                next();
            }
        }

    };
}(jQuery, window, document));


