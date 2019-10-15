var signaturePad;

var createCarousel = function() {

	$("#carousel").owlCarousel({
		navigation: true, // Show next and prev buttons

		slideSpeed: 300,
		paginationSpeed: 400,
		navigationText: ["previous","next"],
		mouseDrag: false,
		touchDrag: false,
		rewindNav: false,
		items: 1,
		itemsDesktop: false,
		itemsDesktopSmall: false,
		itemsTablet: true,
		itemsMobile : false

	});
};

var doGoToErrorTab = function(){
	
	var wtab = $("#waiverform .error").first().parents(".wtab");
	if(wtab.hasClass("tab1")){
	  $("#carousel").trigger('owl.goTo', [0,0]);
	}else if (wtab.hasClass("tab2")){
	  $("#carousel").trigger('owl.goTo', [1,0]);
	}else if (wtab.hasClass("tab3")){
	  $("#carousel").trigger('owl.goTo', [2,0]);
	}else if (wtab.hasClass("tab4")){
	  $("#carousel").trigger('owl.goTo', [3,0]);  
	}else if (wtab.hasClass("tab5")){
	  $("#carousel").trigger('owl.goTo', [4,0]);  
	}else if (wtab.hasClass("tab6")){
	  $("#carousel").trigger('owl.goTo', [5,0]);	  
	}
	
};

var createSignatureWidget = function() {

	var wrapper = document.getElementById("signature-pad"),
		clearButton = wrapper.querySelector("[data-action=clear]"),
		saveButton = wrapper.querySelector("[data-action=save]"),
		canvas = wrapper.querySelector("canvas");

	// Adjust canvas coordinate space taking into account pixel ratio,
	// to make it look crisp on mobile devices.
	// This also causes canvas to be cleared.
	function resizeCanvas() {
		var ratio =  window.devicePixelRatio || 1;
		canvas.width = canvas.offsetWidth * ratio;
		canvas.height = canvas.offsetHeight * ratio;
		canvas.getContext("2d").scale(ratio, ratio);
	}

	window.onresize = resizeCanvas;
	resizeCanvas();

	signaturePad = new SignaturePad(canvas);

	clearButton.addEventListener("click", function (event) {
		signaturePad.clear();
	});
	
	saveButton.addEventListener("click", function (event) {	
		$("#waiverform").submit();		
	});

};


var initToastr = function(){
	toastr.options = {
	  "closeButton": false,
	  "debug": false,
	  "newestOnTop": false,
	  "progressBar": false,
	  "positionClass": "toast-top-center",
	  "preventDuplicates": false,
	  "onclick": null,
	  "showDuration": "300",
	  "hideDuration": "1000",
	  "timeOut": "5000",
	  "extendedTimeOut": "1000",
	  "showEasing": "swing",
	  "hideEasing": "linear",
	  "showMethod": "fadeIn",
	  "hideMethod": "fadeOut"
	}
	
};

var playSuccess = function(){
   var audio = document.getElementById("audioSuccess");
   audio.play();
};

var populateWaiverCustomerName = function(){
	var strName = "&nbsp;"+$("#first-name").val() + "&nbsp;" + $("#last-name").val()+"&nbsp;";
	$("#divParName").html(strName);
}

$(function() {
	initToastr();
	createCarousel();
	createSignatureWidget();
	
	$("#first-name").change(function(){
		populateWaiverCustomerName();		
	});
	$("#last-name").change(function(){
		populateWaiverCustomerName();		
	});
	
});