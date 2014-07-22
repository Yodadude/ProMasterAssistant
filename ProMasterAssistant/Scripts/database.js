
$(function () {
	$("#list tr").live("click", handleSelect);
	//$("#savebtn").click(validateConnection);
	//$("#delbtn").click(deleteConnection);
	$("#setbtn").click(setActiveConnection);
	$("#list tr").hover(
		function () {
			$(this).addClass("highlight");
		},
		function () {
			$(this).removeClass("highlight");
		}
	);
	//displayConnections();	
});


function displayConnections() {

	var connections = localStorage.getItem("connections") || [];

	if (connections === undefined)
		return;

	var conns = JSON.parse(connections);

	if (conns && conns.length) {
		$("#list").empty();
		for (var i = 0; i < conns.length; i++) {
			$("#list").append("<tr><td>" + conns[i].connid + "</td><td>" + conns[i].server + "</td><td>" + conns[i].database + "</td><td>" + conns[i].userid + "</td><td>" + conns[i].password + "</td></tr>");
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
		connid: connName.val(),
		server: serverName.val(),
		database: databaseName.val(),
		userid: userId.val(),
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

    $("#list").append("<tr><td>" + connInfo.connid + "</td><td>" + connInfo.server + "</td><td>" + connInfo.database + "</td><td>" + connInfo.userid + "</td><td>" + connInfo.password + "</td></tr>");

	var connections = JSON.parse(localStorage.getItem("connections")) || [];

	connections.push({ connid: connInfo.connid, server: connInfo.server, database: connInfo.database, userid: connInfo.userid, password: connInfo.password });

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
		    connections.push({ connid: $(":nth-child(1)", this).text(), server: $(":nth-child(2)", this).text(), database: $(":nth-child(3)", this).text(), userid: $(":nth-child(4)", this).text(), password: $(":nth-child(5)", this).text() });
		});
		localStorage.setItem("connections", JSON.stringify(connections));
	}
}

function setActiveConnection() {
	
	var row = $("#list tr.select");

	if (row.length == 0)
	    return;

	var connectionName = $(":nth-child(1)", row).text();

	$("#connectionStringName").val(connectionName);
	$("#form1")[0].submit();

    //window.open("/Home/SetConnection?ConnectionStringName=" + encodeURIComponent(connectionName));



	//$.post('Home/SetConnection', { ConnectionStringName: connectionName	},
	//	function(data) {
	//		if (data.status == "error") {
	//			alert(data.message);
	//			return;
	//		}
	//		$("#list tr.current").removeClass("current");
	//		$(row).addClass("current");
	//		$("#current-connection").text(connectionName);
	//	});
}