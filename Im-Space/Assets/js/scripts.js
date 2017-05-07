/*********************** navigation ***********************/
$(function () {
    'use strict';
    $('#nav li:has(ul)').doubleTapToGo();
});


$(document).ready(function () {
    'use strict';
    /****************** homepage slider ******************/
    //initialize swiper when document ready  
    var mySwiper = new Swiper('.hero-slider', {
        speed: 1000,
        autoplay: 5000,
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev'
            //        effect: 'fade',
    });
    
//    var mySwiper2 = new Swiper('.faq-slider', {
//		pagination: '.swiper-pagination',
//        speed: 1000,
//        autoplay: 5000,
//        slidesPerView: 5,
//        nextButton: '.swiper-button-next',
//        prevButton: '.swiper-button-prev'
//    });

    /**************** home offers slider *****************/
    //initialize swiper when document ready  
    var homeOffersSwiper = new Swiper('.home-offers-slider', {
        speed: 1000,
        autoplay: 5000,
        nextButton: '.swiper-button-next',
        prevButton: '.swiper-button-prev',
        pagination: '.swiper-pagination',
        paginationClickable: true,
        spaceBetween: 30
            //        effect: 'fade',
    });

    /*************** Equal Height Columns ***************/
    if ($(window).width() >= 768) {
        var heightOne = 0;
        $('.equalHeight').each(function () {
            var height = $(this).outerHeight();
            if (height > heightOne) {
                heightOne = height;
            }
        });
        $(".equalHeight").outerHeight(heightOne);
    }

    /*************** File Upload button ***************/
    $('.btn-fileupload').change(function () {
        var filename = $(this).val();
        var lastIndex = filename.lastIndexOf("\\");
        if (lastIndex >= 0) {
            filename = filename.substring(lastIndex + 1);
        }
        $('.fileupload-cont .txtbox').val(filename);
    });

});

/*************** home new products PAGING ***************/

$(function () {
    'use strict';
    $("div.newpro-holder1").jPages({
        containerID: "newpro-tab1",
        perPage: 6,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next",
        previous: "span.prev",
        midRange: 15,
        links: "blank"
    });
});

$(function () {
    'use strict';
    $("div.newpro-holder2").jPages({
        containerID: "newpro-tab2",
        perPage: 6,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next2",
        previous: "span.prev2",
        midRange: 15,
        links: "blank"
    });
});

$(function () {
    'use strict';
    $("div.newpro-holder3").jPages({
        containerID: "newpro-tab3",
        perPage: 6,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next3",
        previous: "span.prev3",
        midRange: 15,
        links: "blank"
    });
});

$(function () {
    'use strict';
    $("div.newpro-holder4").jPages({
        containerID: "newpro-tab4",
        perPage: 6,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next4",
        previous: "span.prev4",
        midRange: 15,
        links: "blank"
    });
});


$(function () {
    'use strict';
    $("div.mostview-holder").jPages({
        containerID: "home-mostviewed",
        perPage: 8,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next5",
        previous: "span.prev5",
        midRange: 15,
        links: "blank"
    });
});

/********************* Product page ***********************/
$(function () {
    'use strict';
    $("div.pro-holder1").jPages({
        containerID: "pro-tab1",
        perPage: 16,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next",
        previous: "span.prev",
        midRange: 15,
        links: "blank"
    });
});

$(function () {
    'use strict';
    $("div.pro-holder2").jPages({
        containerID: "pro-tab2",
        perPage: 16,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next2",
        previous: "span.prev2",
        midRange: 15,
        links: "blank"
    });
});

$(function () {
    'use strict';
    $("div.pro-holder3").jPages({
        containerID: "pro-tab3",
        perPage: 16,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next3",
        previous: "span.prev3",
        midRange: 15,
        links: "blank"
    });
});

$(function () {
    'use strict';
    $("div.pro-holder4").jPages({
        containerID: "pro-tab4",
        perPage: 16,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next4",
        previous: "span.prev4",
        midRange: 15,
        links: "blank"
    });
});

$(function () {
    'use strict';
    $("div.pro-dtls-holder").jPages({
        containerID: "pro-dtls-slider",
        perPage: 6,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next",
        previous: "span.prev",
        midRange: 15,
        links: "blank"
    });
});

/***************** home new products TABS *****************/
$(function () {
    'use strict';
    $("#new-products-tabs").tabs();
});

$(function () {
    'use strict';
    $("#products-tabs").tabs();
});

/***************** Media pages *******************/
/*** News ***/
$(function () {
    'use strict';
    $("div.news-holder").jPages({
        containerID: "media-news-slider",
        perPage: 6,
        animation: "fadeInLeft",
        delay: 0,
        next: "span.next",
        previous: "span.prev",
        midRange: 15,
        links: "blank"
    });
});

/*** Photos ***/
var galleryTop = new Swiper('.gallery-top', {
	nextButton: '.swiper-button-next',
    prevButton: '.swiper-button-prev',
	centeredSlides: true,
	loop: true,
	effect: "coverflow",
	coverflow: {
		rotate: 0,
		stretch: 500,
		depth: 200,
		modifier: 1,
		slideShadows : false
	}
});
var galleryThumbs = new Swiper('.gallery-thumbs', {
	nextButton: '.next',
	prevButton: '.prev',
	pagination: '.swiper-pagination',
	paginationClickable: true,
	spaceBetween: 10,
	centeredSlides: true,
	slidesPerView: 'auto',
	touchRatio: 0.2,
	slideToClickedSlide: true
});
galleryTop.params.control = galleryThumbs;
galleryThumbs.params.control = galleryTop;


/***************** Branches Accordion ******************/
$(function () {
	'use strict';
	$("#branches-accordion").accordion({
		collapsible: true,
		heightStyle: "content"
    });
});






