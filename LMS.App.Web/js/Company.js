/// <reference path="../scripts/jquery-1.8.3.min.js" />
/// <reference path="../scripts/jquery.validate.min.js" />

$(document).ready(function () {
    loadData();

});
//Load Data function
function loadData() {
    $('#norecords').html('');
    $.ajax({
        url: "/Company/GetCompanies",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            if (!$.isArray(result.companiesList) || !result.companiesList.length) {
                //handler either not an array or empty array
                $('.tbody').html('');
                $('#norecords').html('<h4 style="text-align:center;font-weight:300">No Records found</h4>');
            }
            else {
                $.each(result.companiesList, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.CompanyId + '</td>';
                    html += '<td>' + item.CompanyName + '</td>';
                    html += '<td>' + item.Address + '</td>';
                    html += '<td>' + item.Remark + '</td>';
                    html += '<td><a href="#" onclick="return getbyID(' + item.CompanyId + ')"><i class="fas fa-plus"></i></a> | <a href="#" onclick="Delele(' + item.CompanyId + ')"><i class="fas fa-minus"></i></a></td>';
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
//Add Data Function
function Add() {
    var res = validate();
    if (res == false) { 
        return false;
    }
    var comObj = {
        //EmployeeID: $('#CompanyId').val(),
        CompanyName: $('#CompanyName').val(),
        Address: $('#Address').val(),
        Remark: $('#Remark').val()
    };
    $.ajax({
        url: "/Company/CompanyAdd",
        data: JSON.stringify(comObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#myModal').modal('hide');
            loadData();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//Function for getting the Data Based upon Employee ID
function getbyID(CompID) {
    debugger;
   // $('#ddlRoles').empty();

    $('#CompanyName').val();
    $('#Address').val();
    $('#Remark').val();
    $('#CompanyName').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Company/getbyID",
        type: "GET",
        data: { CompID: CompID },
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CompanyName').val(result.companymodel.CompanyName);
            $('#Address').val(result.companymodel.Address);
            $('#Remark').val(result.companymodel.Remark);
            $('#CompanyId').val(result.companymodel.CompanyId);
            $('#norecords').html('');
            //$.each(result.usermodel.Rolelist, function (data, roleitem) {
            //    if (roleitem.Selected) {
            //        $("#ddlRoles").append($("<option selected='true'></option>").val(roleitem.Value).html(roleitem.Text));
            //    }
            //    else {
            //        $("#ddlRoles").append($("<option></option>").val(roleitem.Value).html(roleitem.Text));

            //    }
            //}) 
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
        CompanyId: $('#CompanyId').val(),
        CompanyName: $('#CompanyName').val(),
        Remark: $('#Remark').val(),
        Address: $('#Address').val(),

    };
    $.ajax({
        url: "/Company/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#CompanyName').val("");
            $('#Address').val("");
            $('#Remark').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
////function for deleting employee's record
function Delele(ID) {
    debugger;
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Company/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $('#norecords').html('');
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
    $('#CompanyId').val("");
    $('#CompanyName').val("");
    $('#Address').val("");
    $('#Remark').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#CompanyId').css('border-color', 'lightgrey');
    $('#CompanyName').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#CompanyName').val().trim() == "") {
        $('#CompanyName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CompanyName').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
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

