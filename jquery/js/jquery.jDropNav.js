(function($) {
    
    $.fn.jDropNav = function(options) {
        
        // default values go here, and can be replaced by the options //
        var defaults = {
            shspeed: 500,
            loadspeed: 200,
            margin: '-40px',
        };
        
        // checks if options are entered //
        if(options) {
            options = $.extend({}, defaults, options);
        }
        
        // main function code is here //
        var obj = this;
        var jdrop = $('#jDropNav');
        
        jdrop.animate({
            marginTop: options.margin
        }, options.loadspeed);
        obj.toggle(function() {
            jdrop.animate({
                marginTop: '0'
            }, options.shspeed);
        },
        function() {
            jdrop.animate({
                marginTop: options.margin
            }, options.shspeed);
        }
        );
        
    };
    
})(jQuery);