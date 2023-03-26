function hl(el, type) {
    var name = jQuery(el).attr("name");

    if (type == "in")
        jQuery(".g_highlight[name='" + name + "']").addClass("g_highlight_over").removeClass("g_highlight");
    else
        jQuery(".g_highlight_over[name='" + name + "']").removeClass("g_highlight_over").addClass("g_highlight");
}

function prepareImage()
{
	var img = jQuery("img.dragger");
	
	var width = img.width();
	var height = img.height();

	img.attr("owidth", width);
	img.attr("oheight", height);

	jQuery("div.dragger").each(function(idx){
		var el = jQuery(this);
		el.attr("owidth", parseInt(el.css("width")));
		el.attr("oheight", parseInt(el.css("height")));
		el.attr("oleft", parseInt(el.css("margin-left")));
		el.attr("otop", parseInt(el.css("margin-top")));
	});
}

var startRescaled = false;
function rescaleImage(delta) {
	var img = jQuery("img.dragger");
		
	var originalWidth = img.attr("owidth");
	var originalHeight = img.attr("oheight");

	if (!originalWidth || originalWidth == 0)
	{
		prepareImage();

		originalWidth = img.attr("owidth");
		originalHeight = img.attr("oheight");
	}

	var currentWidth = img.width();
	var currentHeight = img.height();

	var scale = currentWidth / originalWidth;

	var cont = jQuery("#viewport");
		
	var viewWidth = parseInt(cont.css("width"));
	var viewHeight = parseInt(cont.css("height"));
		
	var minScale = Math.min(viewWidth / originalWidth, viewHeight / originalHeight);

	var newscale = scale + (delta / 10);
	if (newscale < minScale)
		newscale = minScale;

	if (newscale > 1)
		newscale = 1;

	var correctX = Math.max(0, (viewWidth - originalWidth*newscale) / 2);
	var correctY = Math.max(0, (viewHeight - originalHeight*newscale) / 2);

	img.attr("width", originalWidth*newscale);
	img.attr("height", originalHeight*newscale);
	img.css("margin-left", correctX + "px");
	img.css("margin-top", correctY + "px");

	jQuery("div.dragger").each(function(idx){
		var el = jQuery(this);
		el.css("margin-left", (el.attr("oleft")*newscale + correctX) + "px");
		el.css("margin-top", (el.attr("otop")*newscale + correctY) + "px");
		el.css("width", el.attr("owidth")*newscale + "px");
		el.css("height", el.attr("oheight")*newscale + "px");
	});
}

function g_getHint(el) {
    var str = "<table border=0>";
    var items = $(el.closest("tr")).find("td.hd");

    for (var i = 0; i < items.length; i++) {
        var txt = jQuery(items[i]).text();
        if (txt.length <= 0)
            continue;

        str = str + "<tr><th align=right style=\"white-space: nowrap\">" + jQuery("#" + jQuery(items[i]).attr("name")).text() + ": </th><td >" + txt + "</td></tr>";
    }

    str = str + "</table>";

    return str;
}


function LxmCatalogSelected(obj) {
    updateLaximoWizard(document.getElementById("LxmCatalog").value);
}

function tippyInitVehicles() {
    tippy('.auto-tippy',
        {
            allowHTML: true,
            content: 'Loading...',
            onCreate(instance) {
                // Setup our own custom state properties
                instance._isFetching = false;
                instance._src = null;
                instance._error = null;
            },
            onShow(instance) {
                if (instance._isFetching || instance._src || instance._error) {
                    return;
                }
                instance._isFetching = true;
                instance.setContent(g_getHint(instance.reference));
                instance._isFetching = false;
            },
            onHidden(instance) {
                instance.setContent('Loading...');
                // Unset these properties so new network requests can be initiated
                instance._src = null;
                instance._error = null;
            }
        });
}

function tippyInitUnitDetail() {
    tippy('.unit-tippy',
        {
            allowHTML: true,
            content: 'Loading...',
            onCreate(instance) {
                // Setup our own custom state properties
                instance._isFetching = false;
                instance._src = null;
                instance._error = null;
            },
            onShow(instance) {
                if (instance._isFetching || instance._src || instance._error) {
                    return;
                }
                instance._isFetching = true;
                instance.setContent(g_getHint(instance.reference));
                instance._isFetching = false;
            },
            onHidden(instance) {
                instance.setContent('Loading...');
                // Unset these properties so new network requests can be initiated
                instance._src = null;
                instance._error = null;
            }
        });
    tippy('.unit-tippy-mobile',
        {
            allowHTML: true,
            content: 'Loading...',
            onCreate(instance) {
                // Setup our own custom state properties
                instance._isFetching = false;
                instance._src = null;
                instance._error = null;
            },
            onShow(instance) {
                if (instance._isFetching || instance._src || instance._error) {
                    return;
                }
                instance._isFetching = true;
                instance.setContent(g_getHint(document.getElementById(instance.reference.dataset.id)));
                instance._isFetching = false;
            },
            onHidden(instance) {
                instance.setContent('Loading...');
                // Unset these properties so new network requests can be initiated
                instance._src = null;
                instance._error = null;
            }
        });
}


$(function () {

    $(".dragger, #viewport").bind("mousewheel", function (event, delta) {
        rescaleImage(delta);
        return false;
    });

    $("#viewport").dragscrollable({ dragSelector: ".dragger, #viewport", acceptPropagatedEvent: false });

    tippyInitUnitDetail();
    //$("#viewport div").tooltip({
    //    track: true,
    //    delay: 0,
    //    showURL: false,
    //    fade: 250,
    //    bodyHandler: function () {
    //        var name = jQuery(this).attr("name");

    //        var items = jQuery("tr[name=" + name + "] td[name=c_name]");

    //        if (items.length == 0)
    //            return false;

    //        return jQuery(items[0]).text();
    //    }
    //});

    $("tr.g_highlight").click(function () {
        var name = jQuery(this).attr("name");
        jQuery(".g_highlight[name=" + name + "]").toggleClass("g_highlight_lock");
        jQuery(".g_highlight_over[name=" + name + "]").toggleClass("g_highlight_lock");
    });

    $("#viewport div").click(function () {
        var name = jQuery(this).attr("name");
        jQuery(".g_highlight[name=" + name + "]").toggleClass("g_highlight_lock");
        jQuery(".g_highlight_over[name=" + name + "]").toggleClass("g_highlight_lock");

        var tr = jQuery("tr.g_highlight_lock[name=" + name + "]");
        if (tr.length == 0)
            return;

        /*var scrolled = false;
        tr.each(function(){
        if (!scrolled)
        jQuery.scrollTo(this);
        //new Fx.Scroll(jQuery('#viewtable')).toElement(this);
        scrolled = true;
        });*/
    });

    $("#viewport div").hover(
		function () {
		    hl(this, "in");
		},
		function () {
		    hl(this, "out");
		}
	);

    //$("td.info").tooltip({ content: "xxxx" });

    //$("td.info").tooltip({ content: g_getHint, track: true, show: { effect: "fade", duration: 250 } });

    rescaleImage(-100);

    $(function () {
        var vinValidationRules = {
            rules: {
                vin: {
                    required: '#frame:blank',
                    minlength: 17,
                    maxlength: 17
                },
                frame: {
                    required: '#vin:blank',
                    minlength: 6,
                    maxlength: 14
                }
            }
        };

        $("#vinForm").validate(vinValidationRules);
    });

//    jQuery(window).bind("resize", function () {
//        fitToWindow();
//    });

//   fitToWindow();

    //if ((document.all) ? false : true)
    //    jQuery('#g_container div table').attr('width', '100%');

    //jQuery('.guayaquil_zoom').colorbox({
    //    'href': function () {
    //        var url = jQuery(this).attr('full');
    //        return url;
    //    },
    //    'photo': true,
    //    'opacity': 0.3,
    //    'title': function () {
    //        var title = jQuery(this).attr('title');
    //        return title;
    //    },
    //    'maxWidth': '98%',
    //    'maxHeight': '98%',
    //    'onComplete': function () {
    //        var img1 = jQuery('#viewport img.dragger');
    //        var img2 = jQuery('#cboxLoadedContent img.cboxPhoto');
    //        var k = img2.attr('width') / img1.attr('owidth');

    //        jQuery('#viewport div.dragger').each(function () {
    //            var el = jQuery(this);
    //            var blank = jQuery('#viewport div.g_highlight img').attr('src');
    //            var hl = el.hasClass('g_highlight_lock');
    //            var nel = '<div class="g_highlight' + (hl ? ' g_highlight_lock' : '') + '" name="' + el.attr('name') + '" style="position: absolute; width: ' + (el.attr('owidth') * k) + 'px; height: ' + (el.attr('oheight') * k) + 'px; margin-top: ' + (el.attr('otop') * k) + 'px; margin-left: ' + (el.attr('oleft') * k) + 'px; overflow: hidden;"><img width="200" height="200" src="' + blank + '"></div>';

    //            img2.before(nel);
    //        });

    //        jQuery('#cboxLoadedContent div').click(function () {
    //            var el = jQuery(this);
    //            var name = el.attr('name');
    //            jQuery('.g_highlight[name=' + name + ']').toggleClass('g_highlight_lock');
    //            jQuery('.g_highlight_over[name=' + name + ']').toggleClass('g_highlight_lock');
    //        });

    //        SubscribeDblClick('#cboxLoadedContent div');

    //        jQuery('#cboxLoadedContent div').tooltip({
    //            track: true,
    //            delay: 0,
    //            showURL: false,
    //            fade: 250,
    //            bodyHandler: function () {
    //                var name = jQuery(this).attr('name');

    //                var items = jQuery('tr[name=' + name + '] td[name=c_name]');

    //                if (items.length == 0)
    //                    return false;

    //                return jQuery(items[0]).text();
    //            }
    //        });
    //    }
    //});

    // SubscribeDblClick('#viewport div');
});
