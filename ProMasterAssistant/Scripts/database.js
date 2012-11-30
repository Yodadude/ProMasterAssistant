
$(function () {
	$("#savebtn").click(saveConnection);
	$("#list tr").hover(
		function () {
			$(this).addClass("highlight");
		},
		function () {
			$(this).removeClass("highlight");
		}
	);
	$("#list tr").live("click", handleSelect);
});


function handleSelect() {
	$("#list tr").removeClass("select");
	$(this).addClass("select");
}


function saveConnection() {

	var connName = $("#connection_name");
	var connString = $("#connection_string");
	var errors = false;

	if (jQuery.trim(connName.val()).length == 0) {
		connName.parent().addClass("error");
		errors = true;
	}

	if (jQuery.trim(connString.val()).length == 0) {
		connString.parent().addClass("error");
		errors = true;
	}

	if (errors) {
		connName.focus();
		return;
	}

	$("#add-dialog div.error").removeClass("error");

	$.post('Home/Add', {
		connName: connName.val(),
		connString: connString.val()
	}, 
	function (data) {
		if (data.status == "error") {
			alert(data.message);
			return;
		}
		$("table#list").append("<tr><td>" + connName.val() + "</td><td>" + connString.val() + "</td></tr>");
		$("#connection_name").val("");
		$("#connection_string").val("");
		$('#add-dialog').modal('hide');
	});
	
}
