
$(function () {
	$("#list tr").live("click", handleSelect);
	$("#savebtn").click(validateConnection);
	$("#delbtn").click(deleteConnection);
	$("#setbtn").click(setActiveConnection);
	$("#list tr").hover(
		function () {
			$(this).addClass("highlight");
		},
		function () {
			$(this).removeClass("highlight");
		}
	);
	displayConnections();	
});


function displayConnections() {

	var connections = localStorage.getItem("connections");

	if (connections === undefined)
		return;

	var conns = JSON.parse(connections);

	if (conns.length) {
		$("#list").empty();
		for (var i = 0; i < conns.length; i++) {
			$("#list").append("<tr><td>" + conns[i].connectionName + "</td><td>" + conns[i].serverName + "</td><td>" + conns[i].databaseName + "</td><td>" + conns[i].userId + "</td><td>" + conns[i].password + "</td></tr>");
		}
	}
}

function handleSelect() {
	$("#list tr").removeClass("select");
	$(this).addClass("select");
}


function validateConnection() {

	var connName = $("#connection_name");
	var serverName = $("#server_name");
	var databaseName = $("#database_name");
	var userId = $("#user_id");
	var password = $("#password");
	var errors = false;

	$("#add-dialog div.error").removeClass("error");

	if (jQuery.trim(connName.val()).length == 0) {
		connName.parent().addClass("error");
		errors = true;
	}
	
	if (jQuery.trim(serverName.val()).length == 0) {
		serverName.parent().addClass("error");
		errors = true;
	}

	if (jQuery.trim(databaseName.val()).length == 0) {
		databaseName.parent().addClass("error");
		errors = true;
	}

	if (jQuery.trim(userId.val()).length == 0) {
		userId.parent().addClass("error");
		errors = true;
	}

	if (jQuery.trim(password.val()).length == 0) {
		password.parent().addClass("error");
		errors = true;
	}

	if (errors) {
		connName.focus();
		return;
	}

	$('#add-dialog').modal('hide');

	saveConnections({
		connectionName: connName.val(),
		server: server.val(),
		databaseName: database.val(),
		userId: userId.val(),
		password: password.val()
	});

	$("#connection_name, #server_name, #database_name, #user_id, #password").val("");
	
	displayConnections();
}

function saveConnections(connInfo) {

	//	$.post('Home/Add', {
//		connName: connName.val(),
//		connString: connString.val()
//	}, 
//	function (data) {
//		if (data.status == "error") {
//			alert(data.message);
//			return;
//		}
//		$("table#list").append("<tr><td>" + connName.val() + "</td><td>" + connString.val() + "</td></tr>");
//		$("#connection_name").val("");
//		$("#connection_string").val("");
//		$('#add-dialog').modal('hide');
	//	});

	$("#list").append("<tr><td>" + connInfo.connectionName + "</td><td>" + connInfo.server + "</td><td>" + connInfo.database + "</td><td>" + connInfo.userId + "</td><td>" + connInfo.password + "</td></tr>");

	var connections = JSON.parse(localStorage.getItem("connections"));

	connections.push({ connectionName: connInfo.connName, server: connInfo.server, database: connInfo.database, userId: connInfo.userId, password: connInfo.password });

	localStorage.setItem("connections", JSON.stringify(connections));

}

function deleteConnection() {

	var connections = [];
	var row = $("#list tr.select");

	if (row.length > 0) {
		if (!confirm("Are you sure?"))
			return;
		$(row).remove();
		$("#list tr").each(function () {
			connections.push({ connectionName: $(":nth-child(1)", this).text(), server: $(":nth-child(2)", this).text(), database: $(":nth-child(3)", this).text(), userId: $(":nth-child(4)", this).text(), password: $(":nth-child(5)", this).text() });
		});
		localStorage.setItem("connections", JSON.stringify(connections));
	}
}

function setActiveConnection() {
	
	var row = $("#list tr.select");

	if (row.length == 0)
		return;

	$.post('Home/SetConnection', {
			connectionName: $(":nth-child(1)", row).val(),
			server: $(":nth-child(2)", row).val(),
			database: $(":nth-child(3)", row).val(),
			userId: $(":nth-child(4)", row).val(),
			password: $(":nth-child(5)", row).val()
		},
		function(data) {
			if (data.status == "error") {
				alert(data.message);
				return;
			}
			$(row).css("background-color","pink");
		});
}