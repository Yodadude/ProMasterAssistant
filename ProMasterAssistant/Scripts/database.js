
//if (!window.JSON) {
//	window.JSON = {
//		parse: function (sJson) { return eval("(" + sJson + ")"); },
//		stringify: function (vContent) {
//			if (vContent instanceof Object) {
//				var sOutput = "";
//				if (vContent.constructor === Array) {
//					for (var nId = 0; nId < vContent.length; sOutput += this.stringify(vContent[nId]) + ",", nId++);
//					return "[" + sOutput.substr(0, sOutput.length - 1) + "]";
//				}
//				if (vContent.toString !== Object.prototype.toString) { return "\"" + vContent.toString().replace(/"/g, "\\$&") + "\""; }
//				for (var sProp in vContent) { sOutput += "\"" + sProp.replace(/"/g, "\\$&") + "\":" + this.stringify(vContent[sProp]) + ","; }
//				return "{" + sOutput.substr(0, sOutput.length - 1) + "}";
//			}
//			return typeof vContent === "string" ? "\"" + vContent.replace(/"/g, "\\$&") + "\"" : String(vContent);
//		}
//	};
//}

$(function () {
	$("#savebtn").click(saveConnection);
	$("#delbtn").click(deleteConnection);
	$("#list tr").hover(
		function () {
			$(this).addClass("highlight");
		},
		function () {
			$(this).removeClass("highlight");
		}
	);

	$("#list tr").live("click", handleSelect);

	displayConnections();
	
});


function displayConnections() {

	var connections = localStorage.getItem("connections");
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


function saveConnection() {

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

	var connections = JSON.parse(localStorage.getItem("connections"));

	connections.push({ connectionName: connName.val(), serverName: serverName.val(), databaseName: databaseName.val(), userId: userId.val(), password: password.val() });

	localStorage.setItem("connections", JSON.stringify(connections));

	$("#connection_name").val("");
	$("#connection_string").val("");
	$('#add-dialog').modal('hide');

	displayConnections();
}


function deleteConnection() {
	
}