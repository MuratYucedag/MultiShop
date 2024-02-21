/**
*  jQuery Stepform, version 1.0
*  (c) 2016 Paresh Masade
*
*  jQuery Stepform is freely distributable under the terms of an MIT-style license.
*  For details, see the web site: https://github.com/masade/stepform
*/

(function( $ ) {

	var	keys = {
			ESC: 27,
			TAB: 9,
			RETURN: 13,
			LEFT: 37,
			UP: 38,
			RIGHT: 39,
			DOWN: 40
		};

	$.fn.stepform = function(options) {
		var noop = $.noop;

		var options = $.extend({
		  margin 		:  	20,
		  classes		: 	"sf",
		  navtext		: 	{
		  	next : "NEXT >",
		  	prev : "<",
		  },
		  validate 		: true,
		}, options);

		return this.each(function() {
			var $this = $(this);

			$this
			.addClass('sf')
			.wrapInner("<div class='sf-container'></div>")
			.append("<div class='sf-navigation'></div>")
			.wrapInner("<div class='sf-wrapper'></div>")

			$this.steps = $this.find('.sf-step');
			$this.container = $this.find('.sf-container');
			$this.nav 	=	$this.find('.sf-navigation');
			var stepsCount = $this.steps.length;
			var stepWidth = $this.width();
			$this.container.width(stepWidth*stepsCount);
			$this.steps.width(stepWidth);

			function buildNavigation(count){
				$this.nav.append("<a class='nav-next' data-nav='1'>"+options.navtext.next+"</a>");
				$this.nav.append("<a class='nav-prev' data-nav='-1'>"+options.navtext.prev+"</a>");
				// $this.nav.append("<input type='submit' value='Submit' class='btn btn-outline btn-danger pull-right nav-submit' />");
				for(let i=1;i<=count;i++){
					$this.nav.append("<span data-navstep='"+i+"'></span>");
				}
			}

			function gotoStep(step){
				var index = step - 1;
				if(index <0 || step > stepsCount)
					return;

				if(!validateStep($this.data('activestep'),step))
				   return;

				$this.data('activestep',step);
				// console.log($this.data('activestep'));

				$this.steps.removeClass('sf-active');
				$this.steps.eq(index).addClass('sf-active');
				$this.nav.find('span').removeClass('sf-nav-active sf-nav-done').eq(index).addClass('sf-nav-active');
				$this.nav.find('span:lt('+index+')').addClass('sf-nav-done');
				$this.nav.find('.nav-prev').toggle(index==0?false:true);
				$this.nav.find('.nav-next').toggle(index==stepsCount-1?false:true);
				// $this.nav.find('.nav-submit').toggle(index==stepsCount-1?true:false);

		        $this.container.stop().animate({
		            marginLeft: '-' + stepWidth*(index) + 'px'
		        },500,function(){
					$this.steps.eq(index).find(':input:first').focus();
				});
			}
			function validateField($elem){
				var valueLength = $.trim($elem.val()).length;
				var validate 	= $elem.data('validate');
				var hasError = false;

				$elem.parent().find('.sf-error-message').remove();
				$elem.parent().removeClass('sf-error');


				let errorMsg = "Please fill this field"
				if(validate == "email"){
					let pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
					if(!pattern.test($elem.val())){
					   hasError = true;
					   errorMsg = "Please enter a valid email address"
					}
				}
				else if(valueLength < validate){
					hasError = true;
					if($elem.data('validate') > 1)
						errorMsg = "Needs to be minimum of " + validate + " characters"
				}

				if(hasError){
					$elem.parent().addClass('sf-error');
					$elem.after('<span class="sf-error-message">'+errorMsg+'</span>');
				}


				return hasError;
			}

			function validateStep(activestep, nextstep){
				var hasError = false;
				if(!options.validate)
					return true;
				// console.log(activestep,nextstep);
				if(nextstep > activestep){
					$this.steps.eq(activestep-1).find(':input[data-validate]').each(function(i){
						let thisError = validateField($(this))
						hasError = hasError? hasError : thisError;
					});
				}
				$this.nav.find('span').eq(activestep-1).toggleClass('sf-nav-error',hasError);
				return hasError?false:true;
			}

			function init(){
				buildNavigation(stepsCount);
				$this.data('activestep',1);
				gotoStep(1);
				$this.sfbind();
			}

			// click nav
		    $this.nav.on('click','a',function(e){
		        e.preventDefault();
		    	gotoStep($this.data('activestep')+$(this).data('nav'))
		    });

		    // key navs
			$this.steps.each(function(){
				// ON LAST ELEMENT tab go to next page
				// on first element  shift+tab go to prev page
				// on enter in any element, behave like tab
				// on submit enter form submit
				var $thisInputs = $(this).find(':input');
				$thisInputs.filter(':first').addClass('sf-step-first');
				$thisInputs.filter(':last').addClass('sf-step-last');

				$thisInputs.filter(":radio.sf-step-first,:radio.sf-step-last").each(function(i){
					let $elem = $thisInputs.filter("input[name='"+$(this).attr('name')+"']");
					if($(this).hasClass("sf-step-first"))
						$elem.addClass("sf-step-first")
					if($(this).hasClass("sf-step-last"))
						$elem.addClass("sf-step-last")
				})

				$thisInputs.keydown(function(e){
					if($(this).data('validate'))
						validateField($(this));

					if ($.inArray(e.which,[keys.RETURN])>=0){
						if(!$(this).is(':submit')){
							e.preventDefault();
							if($(this).is('.sf-step-last'))
								gotoStep($this.data('activestep')+1)
							else
								$thisInputs.eq($thisInputs.index($(this))+1).focus();
						}
					}

					else if($.inArray(e.which,[keys.TAB])>=0){

						if (!e.shiftKey && $(this).is('.sf-step-last')){
							e.preventDefault();
							gotoStep($this.data('activestep')+1)
						}
						else if (e.shiftKey && $(this).is('.sf-step-first')){
							e.preventDefault();
							gotoStep($this.data('activestep')-1)
						}
					}


				});

			});


			init();
		});//this each

  };
})( jQuery );

(function( $ ) {

	$.fn.sfbind = function(options) {

		var options = $.extend({
		}, options);

		return this.each(function() {
			var $this = $(this);

			$this.find('[data-sf-bind]').each(function(){
				let fieldName = $(this).data('sf-bind');
				$this.on('change keyup keydown','[name="'+fieldName+'"]',function(e){
				// $this.find('').keydown(function(e){
					$this.find('[data-sf-bind="'+fieldName+'"]').html($(this).val());
				});
			})

		});//this each
  };
})( jQuery );

$(document).ready(function() {
	$(".stepform").stepform();
});