jQuery(document).ready(function($){
	$('.xemthem').click(function(e){		
		$(this).parent().parent().find('.fix-show').addClass('show');
		$(this).hide();
		$('.thugon').show();
	})
	$('.thugon').click(function(e){		
		$(this).parent().parent().find('.fix-show').removeClass('show');
		$(this).hide();
		$('.xemthem').show();
	})
	
	$('.open-close').on('click', function(e){
		e.preventDefault();
		var $this = $(this);
		$this.parents('.level0').find('.submenu-mb').stop().slideToggle();
		$(this).toggleClass('active')
		return false;
	});
	$("#owl-demo").owlCarousel({
		navigation : true, // Show next and prev buttons
		slideSpeed : 300,
		paginationSpeed : 400,
		singleItem:true,
		navigation : false,
		autoPlay: true
	});
	$('#best-seller').owlCarousel({
		navigation:true,
		navigationText:["<i class='fa fa-angle-double-left'></i>","<i class='fa fa-angle-double-right'></i>"],
		pagination:false,
		slideSpeed : 300,
		loop:true,
		nav: true,
		dots: false,
		autoplayHoverPause: true,
		paginationSpeed : 400,
		items : 6, //10 items above 1000px browser width
		itemsDesktop : [1000,5], //5 items between 1000px and 901px
		itemsDesktopSmall : [900,3], // betweem 900px and 601px
		itemsTablet: [768,2], //2 items between 600 and 0
		itemsMobile : [540,1] // itemsMobile disabled - inherit from itemsTablet option
	});
	$('#related').owlCarousel({
		navigation:true,
		navigationText:["<i class='fa fa-angle-double-left'></i>","<i class='fa fa-angle-double-right'></i>"],
		pagination:false,
		slideSpeed : 300,
		paginationSpeed : 400,
		items : 4, //10 items above 1000px browser width
		itemsDesktop : [1000,3], //5 items between 1000px and 901px
		itemsDesktopSmall : [900,3], // betweem 900px and 601px
		itemsTablet: [768,2], //2 items between 600 and 0
		itemsMobile : [540,1] // itemsMobile disabled - inherit from itemsTablet option
	});
	$('#product-related').owlCarousel({
		navigation:true,
		navigationText:["<i class='fa fa-angle-double-left'></i>","<i class='fa fa-angle-double-right'></i>"],
		pagination:false,
		slideSpeed : 300,
		paginationSpeed : 400,
		items : 5, //10 items above 1000px browser width
		itemsDesktop : [1000,3], //5 items between 1000px and 901px
		itemsDesktopSmall : [900,3], // betweem 900px and 601px
		itemsTablet: [768,2], //2 items between 600 and 0
		itemsMobile : [540,1] // itemsMobile disabled - inherit from itemsTablet option
	});
	$('.title_block').on('click', function(e){
		e.preventDefault();
		var $this = $(this);
		$this.parents('#category-mobile').find('.verticalcontent').stop().slideToggle();
		return false;
	}); 
	$(".header-menu-btn span").on("click",function(){
		$(".header-nav-mobile").css("left","0px");
	});
	$(".header-menu-btn-hidden").on("click", function(){
		$(".header-nav-mobile").css("left","-300px");
	});
	$(window).scroll(function () {
		if ($(window).scrollTop() != 0) {
			$('#back-top').fadeIn();

		} else {

			$('#back-top').fadeOut();

		}

	});

	$('#back-top').click(function () {
		$('html, body').animate({ scrollTop: 0 }, 500);

	});
});