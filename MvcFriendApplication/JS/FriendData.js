//$(document).ready(function () {
//    $.ajax({
//        url: "http://localhost:57636/api/FriendApi/",
//        type: "Get",
//        success: function (data) { 
//            for (var i = 0; i < data.length; i++) {
//                $("<tr></tr><td></td>" + data[i].FriendID + "</td><td></td>" + data[i].FriendName + 
//                    "</td><td></td>" + data[i].Place + "</td></tr>").appendTo("#tbFriend");                   
//            }
//        },
//        error: function (msg) { alert(msg); }
//    });
//});



$(document).ready(function () {


    CreateValidation();
    EditValidation();
    $('#friendsDiv').hide();
    $('#editDiv').hide();
    $('#createDiv').hide();
    $("#deleteDiv").hide();

});
function CreateValidation() {
    $("form[name='insertFrdForm']").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            txtnfrdId: "required",
            txtnfrdName: "required",
            txtnfrdPlace: { maxlength: 25 }
        },
        // Specify validation error messages
        messages: {
            txtnfrdId: "Please enter your friend Id",
            txtnfrdName: "Please enter your friend name",
            txtnfrdPlace: "Please enter no more than 25 characters"
        }
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        //submitHandler: function (form) {
        //    form.submit();
        //}
    });
}
function EditValidation() {
    $("form[name='editFrdForm']").validate({
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            FriendID: "required",
            FriendName: "required",
            Place: { maxlength: 25 }
        },
        // Specify validation error messages
        messages: {
            FriendID: "Please enter your friend Id",
            FriendName: "Please enter your friend name",
            Place: "Please enter no more than 25 characters"
        }
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        //submitHandler: function (form) {
        //    form.submit();
        //}
    });
}

function LoadFriends() {
    debugger;
    $.ajax({
        url: "http://localhost:57636/api/FriendApi/",
        type: "Get",
        success: function (data) {
            var trHTML = '';
            $.each(data, function (i, item) {
                trHTML += "<tr><td>" + data[i].FriendID + '</td><td>' + data[i].FriendName + '</td><td>' + data[i].Place +
                    '</td><td>' + "<a href='#' class='btn btn-warning' onclick='EditFriend(" + data[i].FriendID + ")' ><span class='glyphicon glyphicon-edit'></span></a>" +
         "<a href='#' class='btn btn-danger' onclick='DeleteFriend(" + data[i].FriendID + ")'><span class='glyphicon glyphicon-trash'></span></a>" + "</td>" +
                    '</tr>';
            });

            $('#tbfriends').html(trHTML);
            $('#friendsDiv').show();
            $('#createDiv').hide();
            $("#deleteDiv").hide();


        },
        error: function (msg) { alert("in load function"); debugger; alert(msg); }
    });
}
function EditFriend(id) {
    $.ajax({
        url: 'http://localhost:57636/api/FriendApi/' + id,
        type: 'GET',
        dataType: "json",
        success: function (data) {

            var friendId = data.FriendID;
            var name = data.FriendName;
            var place = data.Place;
            $('#txtfrdId').val(friendId);
            $('#txtfrdName').val(name);
            $('#txtfrdPlace').val(place);
            $('#editDiv').show();
            $('#friendsDiv').hide();
            $('#createDiv').hide();
            $("#deleteDiv").hide();
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}
$(document).on("click", "#btnEditFriend", function () {
    debugger;
    if (!$("form[name='editFrdForm']").valid()) { // Not Valid
        return false;
    } else {
        var friend = {
            FriendID: $("#txtfrdId").val(),
            FriendName: $("#txtfrdName").val(),
            Place: $("#txtfrdPlace").val()
        };
        var model = JSON.stringify(friend);
        $.ajax({
            type: 'POST',
            data: model,
            url: 'http://localhost:57636/api/FriendApi',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger;
                alert(data);

                LoadFriends();
                $('#editDiv').hide();
                $('#friendsDiv').show();

            },
            fail: function () {
                alert('failed');

            }

        });

    }

});

function AddNewFriend() {
    $('#friendsDiv').hide();
    $('#editDiv').hide();
    $("#deleteDiv").hide();
    $('#createDiv').show();


};

$(document).on("click", "#btnAddFriend", function () {
    debugger;
    if (!$("form[name='insertFrdForm']").valid()) { // Not Valid
        return false;
    } else {

        debugger;
        var friend = {
            FriendID: $("#txtnfrdId").val(),
            FriendName: $("#txtnfrdName").val(),
            Place: $("#txtnfrdPlace").val()
        };
        var model = JSON.stringify(friend);
        $.ajax({
            type: 'POST',
            data: model,
            url: 'http://localhost:57636/api/FriendApi',
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                alert(data + "Add");
                debugger;
                LoadFriends();
                $('#editDiv').hide();
                $('#createDiv').hide();
                $("#deleteDiv").hide();
                $('#friendsDiv').show();


            },
            fail: function () {
                alert('failed');
            }

        });
    }

});

function DeleteFriend(id) {
    $.ajax({
        url: 'http://localhost:57636/api/FriendApi/' + id,
        type: 'GET',
        success: function (data) {

            var friendId = data.FriendID;
            var name = data.FriendName;
            var place = data.Place;
            $('#txtdfrdId').text(friendId);
            $('#txtdfrdName').text(name);
            $('#txtdfrdPlace').text(place);
            $("#deleteDiv").show();
            $('#editDiv').hide();
            $('#friendsDiv').hide();
            $('#createDiv').hide();

        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

function ConfirmDeleteFriend() {
    debugger;
    var friendId = $("#txtdfrdId").text();

    $.ajax({
        type: 'DELETE',
        data: friendId,
        url: 'http://localhost:57636/api/FriendApi/' + friendId,
        success: function (data) {
            LoadFriends();
            $('#deleteDiv').hide();

        },
        fail: function () {
            alert('failed');

        }

    });

}
