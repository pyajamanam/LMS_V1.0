/// <reference path="../scripts/jquery-1.8.3.min.js" />
/// <reference path="../scripts/jquery.validate.min.js" />


$(document).ready(function () {
    // loadData();
});


$('[data-toggle="tabajax"]').click(function (e) {
    debugger;
    var $this = $(this),
        loadurl = $this.attr('href'),
        targ = $this.attr('data-target');

    $.get(loadurl, function (data) {
        $(targ).html(data);
    });

    $this.tab('show');
    return false;
});
//Load Data function
function loadData() {
    $('#norecords').html('');
    $('.tbody').html('');
    $.ajax({
        url: "/Manage/GetUserGoals",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            if (!$.isArray(result.usergoals.Qualificationslist) || !result.usergoals.Qualificationslist.length) {
                //handler either not an array or empty array
                $('.tbody').html(html);
                $('#norecords').html('<h4 style="text-align:center;font-weight:300">No Records found</h4>');
            }
            else {
                $.each(result.usergoals.Qualificationslist, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.Id + '</td>';
                    html += '<td>' + item.QualificationName + '</td>';
                    html += '<td>' + item.Remarks + '</td>';
                    html += '<td><a href="#" onclick="Delele(' + item.Id + ')"><i class="fas fa-minus"></i></a></td>';
                    html += '</tr>';
                });
                $('.modal-backdrop').remove();
                $('.tbody').html(html);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function loadInactiveUsers() {
    $('#norecords').html('');
    $('.tbody').html('');
    $.ajax({
        url: "/Manage/InactiveUserList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            if (!$.isArray(result.UserModel) || !result.UserModel.length) {
                //handler either not an array or empty array
                $('.tbody').html(html);
                $('#norecords').html('<h4 style="text-align:center;font-weight:300">No Records found</h4>');
            }
            else {
                $.each(result.UserModel, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.UserId + '</td>';
                    html += '<td>' + item.UserName + '</td>';
                    html += '<td>' + item.FullName + '</td>';
                    html += '<td>' + item.EmailAddress + '</td>';
                    html += '<td>' + item.Role + '</td>';
                    html += '<td>' + item.Inactive + '</td>';
                    html += '<td><a href="#" onclick="return getbyID(' + item.UserId + ')">Edit</a> | <a href="#" onclick="Delele(' + item.UserId + ')">Delete</a></td>';
                    html += '</tr>';
                });
                $('.modal-backdrop').remove();
                $('.tbody').html(html);
            }

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $('.tbody').html('<h4>this is inactive users</h4>');
}
//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        UserId: $('#UserId').val(),
        UserName: $('#Name').val(),
        FullName: $('#FullName').val(),
        EmailAddress: $('#Email').val(),
        Password: $('#Password').val(),
        Role: $("#ddlRoles option:selected").val(),
        InActive: $('#InActive').is(":checked")
    };
    $.ajax({
        url: "/Manage/AddUser",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Function for getting the Data Based upon Employee ID
function getbyID(EmpID) {
    $('#ddlRoles').empty();
    $('#Name').css('border-color', 'lightgrey');
    //$('#Age').css('border-color', 'lightgrey');
    //$('#State').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Manage/getbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            debugger;
            console.log(result.usermodel.UserId);
            $('#UserId').val(result.usermodel.UserId);
            $('#Name').val(result.usermodel.UserName);
            $('#FullName').val(result.usermodel.FullName);
            $('#Email').val(result.usermodel.EmailAddress);
            $('#InActive').val(result.usermodel.InActive);
            $('#norecords').html('');
            $.each(result.usermodel.Rolelist, function (data, roleitem) {
                if (roleitem.Selected) {
                    $("#ddlRoles").append($("<option selected='true'></option>").val(roleitem.Value).html(roleitem.Text));
                }
                else {
                    $("#ddlRoles").append($("<option></option>").val(roleitem.Value).html(roleitem.Text));

                }
            })
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//function for updating employee's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        UserId: $('#UserId').val(),
        UserName: $('#Name').val(),
        FullName: $('#FullName').val(),
        Password: $('#Password').val(),
        //Age: $('#Age').val(),
        //State: $('#State').val(),
        EmailAddress: $('#Email').val(),
        InActive: $('#InActive').is(":checked"),
        Role: $("#ddlRoles option:selected").val()

    };
    $.ajax({
        url: "/Manage/UpdateUser",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#EmployeeID').val("");
            $('#Name').val("");
            // $('#Age').val("");
            //// $('#State').val("");
            // $('#Country').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting employee's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
//Function for clearing the textboxes
function clearTextBox() {
    $('#UserId').val("");
    $('#Name').val("");
    $('#Email').val("");
    $('#ddlRoles').val(0);
    $('#Password').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#State').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    //if ($('#Age').val().trim() == "") {
    //    $('#Age').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#Age').css('border-color', 'lightgrey');
    //}
    //if ($('#State').val().trim() == "") {
    //    $('#State').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#State').css('border-color', 'lightgrey');
    //}
    //if ($('#Country').val().trim() == "") {
    //    $('#Country').css('border-color', 'Red');
    //    isValid = false;
    //}
    //else {
    //    $('#Country').css('border-color', 'lightgrey');
    //}
    return isValid;
}
