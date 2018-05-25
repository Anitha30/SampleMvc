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
    $('#friendsDiv').hide();
    $('#editDiv').hide();
    $('#createDiv').hide();
    $("#deleteDiv").hide();


});
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
        error: function (msg) { alert(msg); }
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

            //var trHTML = '';

            //trHTML += '<tr><td>' + friendId + '</td><td>' + name +
            //'</td><td>' + place + '</td>' + '</td></tr>';
            ////$('#editfr').append(trHTML);
            //$('#container').html(trHTML)
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

$("#btnEditFriend").click(function () {

    var friend = {
        FriendID: $("#txtfrdId").val(),
        FriendName: $("#txtfrdName").val(),
        Place: $("#txtfrdPlace").val()
    };
    var model = JSON.stringify(friend);
    //if (CheckRequiredFields()) {

    //    $('#dvLoader').show();
    $.ajax({
        type: 'POST',
        data: model,
        url: 'http://localhost:57636/api/FriendApi',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            LoadFriends();
            $('#editDiv').hide();

        },
        fail: function () {
            alert('failed');

        }

    });

    //}

});

function AddNewFriend() {
    $('#friendsDiv').hide();
    $('#editDiv').hide();
    $("#deleteDiv").hide();
    $("#createDiv").load('/Friend/Create');
    $('#createDiv').show();


};

$("#btnAddFriend").click(function () {
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
            LoadFriends();
            $('#editDiv').hide();
            $('#createDiv').hide();
            $("#deleteDiv").hide();

        },
        fail: function () {
            alert('failed');
        }

    });
});


function SaveNewFriend() {
    debugger;
   // var $form = $("#myform");
   // $form.action = "/Area/MyController/" + action;

    //$.validator.unobtrusive.parse($form);
    //$form.validate();

    //if ($form.valid()) {
    //    //    $form.submit();
        //}
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
                LoadFriends();
                $('#editDiv').hide();
                $('#createDiv').hide();
                $("#deleteDiv").hide();

            },
            fail: function () {
                alert('failed');
            }

        });
    }
//}

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

            //var trHTML = '';

            //trHTML += '<tr><td>' + friendId + '</td><td>' + name +
            //'</td><td>' + place + '</td>' + '</td></tr>';
            ////$('#editfr').append(trHTML);
            //$('#container').html(trHTML)
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}

//$("#btnDeleteFriend").click(function () {
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

//});
