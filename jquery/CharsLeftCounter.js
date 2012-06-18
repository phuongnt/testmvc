
// Version 0.1.0.0

//    Copyright (c) 2011 Jovica Milenovic

//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:

//    The above copyright notice and this permission notice shall be included in
//    all copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//    THE SOFTWARE.


(function ($) {
    $.fn.CharsLeftCounter = function (outputId, max) {
        var o = $('#' + outputId);
        var maxchar = max;
        var me = $(this);
        var backspace = 8;
        var del = 46;

        o.text(maxchar);

        this.bind('keydown', function (e) {
            var key = e.which;
            if ((key > 36 && key < 41) || key == backspace || key == del)  // ignore navigation arrows and backspace
                return true;
            if ($(this).val().length == maxchar) {
                o.text(0);
                return false;
            }
        });

        this.bind('keyup', function (e) {
            var key = e.which;
            if ((key > 36 && key < 41)) { // ignore navigation arrows
                return $(this);
            }
            //            $('#key').text(key); Print out key
            if ($(this).val().length > (maxchar) && key != 8) {
                $(this).val($(this).val().substring(0, maxchar));
                o.text(0);
                return false;
            }
            o.text(maxchar - $(this).val().length);
            return $(this);
        });

        var removeCharsAboveMax = function () { // resolve paste issue
            if (me.val().length > (maxchar)) {
                me.val(me.val().substring(0, maxchar));
            }
        };

        var timer = null;

        this.bind('focusin', function (e) {
            timer = window.setInterval(removeCharsAboveMax, 1000);
        });

        this.bind('focusout', function (e) {
            window.clearInterval(timer);
        });

    };
})(jQuery);
 
