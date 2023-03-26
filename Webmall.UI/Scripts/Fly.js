// // Compare Image flying effect
//$(document).on('click', '.js-add-compare-product', fly);

function fly(imgToDrag, top, left) {
    //e.preventDefault();
    //var $this = $(e.currentTarget);
    var compareIcon = $('.logged-in__basket');

    //var imgToDrag = ($this.data('main') == 'yes') ? $(document).find(".js-product-slider .slick-current img").eq(0)
    //    : $this.closest('.js-content').find("img").eq(0)
    if (imgToDrag.length) {
        var imgClone = imgToDrag.clone()
            .offset({
                top: top ? top : imgToDrag.offset().top,
                left: left ? left : imgToDrag.offset().left
            })
            .css({
                'opacity': '0.7',
                'position': 'absolute',
                'height': '100px',
                'max-width': '100px',
                'z-index': '1000'
            })
            .appendTo($('body'))
            .animate({
                'top': compareIcon.offset().top + 10,
                'left': compareIcon.offset().left + 10,
                'max-width': 50,
                'height': 50
            }, 1000, 'easeInOutExpo');
        imgClone.animate({
            'width': 0,
            'height': 0
        });

        setTimeout(function () {
            compareIcon.addClass('pulse');
        }, 1500);
        setTimeout(function () {
            compareIcon.removeClass('pulse');
        }, 2000);
    }
}
// Image flying effect