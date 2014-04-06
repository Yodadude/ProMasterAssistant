
$(function () {
	$("#ref-container").load("Reference", setup);
});

function setup() {
	
	$(function () {
		$('#glruleref a:first').tab('show');
	});

	$("#glruleref a").click(function (e) {
		e.preventDefault();
		$(this).tab("show");
	});

}
