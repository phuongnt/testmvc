(function ($) {
    // Shell for your plugin code
    $.fn.highlight = function (options) {
        options = $.extend($.fn.highlight.defaults, options);
        return this.each(function () {
            //enter your code here
            $(this).data('original-color', $(this).css('background-color'))
                    .css('background-color', options.color)
                    .one('mouseenter', function () {
                        $(this).animate({
                            'background-color': $(this).data('original-color')
                        }, 'fast');
                    });
        });
    }
    $.fn.highlight.defaults = {
        color: '#fff47f',
        duration: 'fast'
    };
})(jQuery);

(function ($) {
    $.fn.test2 = function () {
        $(this).css({ 'color': 'red' });
    }
})(jQuery);