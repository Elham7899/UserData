var searchkey = "1";
var index = 0;
var childindex = 0;
var paginationcount = 0;
var childpaginationcount = 0;
var count = 4;
var childcount = 4;
var userId = -1;
var childId = -2;
var userIdF = 0;
var tableRowId = 0;
var childtableRowId = 0;

$(document).ready(function getAll() {
    $("#child_table").hide();
    $("#btnShowChild").hide();
    $("#btnAddChild").hide();
    getAllUser();
    setPaginationForPage();
});

function getAllUser() {
    $.ajax({
        type: "GET",
        url: "users/Get?name=" + searchkey + "&index=" + index + "&count=" + count,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(index);
            setData(data);
            removeClick();
            edit();
        },
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function getAllChild() {
    $.ajax({
        type: "Get",
        url: "users/children/Get?userId=" + userIdF + "&index=" + childindex + " &count=" + childcount,
        contectType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            setChildData(data);
            childRemoveClick();
            editChild();
            $("#child_table").show();
        },
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
        }
    })
}

function setData(data) {
    $("#tbody").empty();
    tableRowId = index * count;
    data.forEach(function (data) {
        debugger;
        tableRowId += 1;
        var row = '<tr id="row_' + data.id + '" class="firstname-row"><td class="selected">' + tableRowId + '</td><td id="firstName_' + data.id + '" >' + data.firstName + "</td>" +
            "<td id='lastName_" + data.id + "'>" + data.lastName + "</td>" +
            '<td class="text-center" ><button class="btn btn-primary remove"  id="firstName_' + data.id + '" type="button" >Remove</button>' +
            ' <button class="btn btn-primary edit" type = "button" id="edit_' + data.id + '" data-toggle="modal" data-target="#">Edit</button ></td></tr>";';

        $('#Table').append(row);
    });
    selectedrowclick();
}

function setChildData(data) {
    $("#child_tbody").empty();
    childtableRowId = childindex * childcount;
    data.forEach(function (data) {
        childtableRowId += 1;
        var row = '<tr id="childrow_' + data.id + '" class="firstname-row"><td>' + childtableRowId + '</td><td id="childfirstName_' + data.id + '" >' + data.firstName + "</td>" +
            "<td id='childlastName_" + data.id + "'>" + data.lastName + "</td>" +
            '<td class="text-center" ><button class="btn btn-primary removechild"  id="btnremovechild_' + data.id + '" type="button" >Remove</button>' +
            ' <button class="btn btn-primary editchild" type = "button" id="btneditchild_' + data.id + '" data-toggle="modal" data-target="#">Edit</button ></td></tr>";';

        $('#child_table').append(row);
    });
}

function setPaginationForPage() {

    $.ajax({
        type: "GET",
        url: "users/GetCount",
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            $("#pagination_contianer").empty();

            paginationcount = Math.ceil(data / 4);
            var previous = '<li class="page-item disabled"><p id="previous">Previous</p></li >';
            $("#pagination_contianer").append(previous);
            for (var i = 1; i < paginationcount; i++) {
                var body = '<li class="page-item"><p class="page-index" id="pindex_' + i + '">' + i + '</p></li>';
                $("#pagination_contianer").append(body);
            }
            var next = '<li class="page-item"><p id="next">Next</p></li>';
            $("#pagination_contianer").append(next);

            getAllUser();
            nextandpreclick();
        }
    });
}

function setChildPaginationForPage() {
    $.ajax({
        type: "GET",
        url: "users/children/GetChildCount?userId=" + userIdF,
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            $("#childpagination_contianer").empty();
            console.log(data);
            childpaginationcount = Math.ceil(data / 4);
            console.log(childpaginationcount);

            var previous = '<li class="page-item disabled"><p id="childprevious">Previous</p></li >';
            $("#childpagination_contianer").append(previous);
            for (var i = 1; i < childpaginationcount; i++) {
                var body = '<li class="page-item"><p class="page-index" id="pindex_' + i + '">' + i + '</p></li>';
                $("#childpagination_contianer").append(body);
            }
            var next = '<li class="page-item"><p id="childnext">Next</p></li>';
            $("#childpagination_contianer").append(next);

            getAllChild();
            childnextandpreclick();
        }
    });
}

function childnextandpreclick() {
    $("#childprevious").click(function () {
        if (childindex > 0) {
            childindex--;
            console.log(childindex);
            getAllChild();
        }
    })

    $("#childnext").click(function () {
        if (childpaginationcount -1 > childindex) {
            childindex++;
            getAllChild();
        }
    })

    $(".page-index").click(function () {
        childindex = this.id.split("_")[1];
        getAllChild();
    })
}

function setPaginationForSearch() {
    var name = $("#FirstName").val();
    $.ajax({
        type: "GET",
        url: "users/GetSearchCount?name=" + name,
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            $("#pagination_contianer").empty();

            paginationcount = Math.ceil(data / 4);
            var previous = '<li class="page-item disabled"><p id="previous">Previous</p></li >';
            $("#pagination_contianer").append(previous);
            for (var i = 1; i < paginationcount; i++) {
                var body = '<li class="page-item"><p>' + i + '</p></li>';
                $("#pagination_contianer").append(body);
            }
            var next = '<li class="page-item"><p id="next">Next</p></li>';
            $("#pagination_contianer").append(next);

            nextandpreclick();
        }
    });
}

function nextandpreclick() {
    debugger;
    $("#previous").click(function () {
        if (index > 0) {
            index--;
            console.log(index);
            getAllUser();
        }
    })

    $("#next").click(function () {
        if (paginationcount -1 > index) {
            index++;
            console.log(index);
            getAllUser();
        }
    })

    $(".page-index").click(function () {
        index = this.id.split("_")[1];
        console.log(index);
        getAllUser();
    })
}

function selectedrowclick() {
    $(".selected").click(function () {
        $("#btnShowChild").show();
        $("#btnAddChild").show();
        setClick();
    })
}

$("#btnShowChild").click(function () {
    getAllChild();
    setChildPaginationForPage();
})

$("#btnAddChild").click(function () {
    $("#myModal").modal("show");
})

function setClick() {
    $(".firstname-row").click(function () {
        let id = this.id;
        userIdF = id.split("_")[1];
    });
}

$("#btn_refresh").click(function () {
    searchkey = "1";
    $("#child_table").hide();
    $("#btnShowChild").hide();
    $("#btnAddChild").hide();
    $("#childpagination_contianer").hide();
    setPaginationForPage();
    getAllUser();
});

function removeClick() {
    $(".remove").click(function () {
        let id = this.id;
        var rowid = Number(id.split("_")[1]);
        $.ajax({
            headers: {
                'Accept': 'application/json',
                contentType: "application/json; charset=utf-8"
            },
            url: "users/delete?id=" + rowid,
            type: "delete",
            success: function () {
                var tr = $("#row_" + rowid).remove();
            },

            failure: function (data) {
                alert("failure");
            },

            error: function (data) {
                alert(data.responseText);
                console.log(data);
            }
        });
    });
}

function childRemoveClick() {
    $(".removechild").click(function () {
        let id = this.id;
        var rowid = Number(id.split("_")[1]);
        $.ajax({
            headers: {
                'Accept': 'application/json',
                contentType: "application/json; charset=utf-8"
            },
            url: "users/children/delete?id=" + rowid,
            type: "delete",
            success: function () {
                $("#childrow_" + rowid).remove();
            },

            failure: function (data) {
                alert("failure");
            },

            error: function (data) {
                alert(data.responseText);
                console.log(data);
            }
        });
    });
}

$("#btn_Add").click(function () {
    $("#myModal").modal("show");
});

$("#btn_Search").click(function () {
    index = 0;
    searchkey = $("#FirstName").val();

    setPaginationForSearch();

    getAllUser();
})

function edit() {
    $(".edit").click(function () {
        let id = this.id;
        var rowid = id.split("_")[1];
        userId = rowid;
        let user = {
            firstName: $("#firstName_" + rowid).text(),
            lastName: $("#lastName_" + rowid).text()
        };

        var idrow = rowid;

        var fname = $(this).parents("tr").find("td:eq(1)").html();
        var lname = $(this).parents("tr").find("td:eq(2)").html();
        var rowNumber = $(this).parents("tr").index();
        $("#edit-fname").val(fname);
        $("#edit-lname").val(lname);
        $(".save").attr("for", rowNumber);
        $("#myModal").modal("show");
    })
}

function editChild() {
    $(".editchild").click(function () {
        let id = this.id;
        var rowid = id.split("_")[1];
        childId = rowid;
        let child = {
            firstName: $("#childfirstName_" + rowid).text(),
            lastName: $("#childlastName_" + rowid).text()
        };

        var fname = $(this).parents("tr").find("td:eq(1)").html();
        var lname = $(this).parents("tr").find("td:eq(2)").html();
        var rowNumber = $(this).parents("tr").index();
        $("#edit-fname").val(fname);
        $("#edit-lname").val(lname);
        $(".save").attr("for", rowNumber);
        $("#myModal").modal("show");
    })
}

$(".save").click(function (e) {
    var user = {};
    user.firstName = $("#edit-fname").val();
    user.lastName = $("#edit-lname").val();
    if (userId != -1) {
        debugger;
        $.ajax({
            type: "PUT",
            url: "users/update?id=" + userId,
            data: JSON.stringify(user),
            contentType: "application/json; charset=utf-8",

            success: function () {
                userId = -1;
                getAllUser();
                $("#myModal").modal("toggle");
            },
            failure: function (data) {
                console.log(data);
                alert("failure");
            },
            error: function (data) {
                alert(data.responseText);
                console.log(data);
            }
        });
        var rowNumber = parseInt($(this).attr("for"));
        $('td:eq(0)', 'tr:eq(' + (rowNumber + 1) + ')').html($("#edit-fname").val());
        $('td:eq(1)', 'tr:eq(' + (rowNumber + 1) + ')').html($("#edit-lname").val());
    }
    else if (userId == -1) {
        debugger;
        let user = {
            lastName: $("#edit-lname").val(),
            firstName: $("#edit-fname").val()
        };
        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json charset=utf-8',
            },
            url: "users/create",
            type: "Post",
            data: JSON.stringify(user),

            success: function () {
                $("#myModal").modal();
                getAllUser();
                setNotification();
                $("#myModal").modal("toggle");
                $("#edit-fname").val("");
                $("#edit-lname").val("");
            },

            failure: function (data) {
                alert("failure");
            },

            error: function (data) {
                alert(data.responseText);
            }
        });
    }
    if (childId != -2) {
        debugger;
        let child = {
            lastName: $("#edit-lname").val(),
            firstName: $("#edit-fname").val()
        };
        $.ajax({
            type: "PUT",
            url: "users/children/update?id=" + childId,
            data: JSON.stringify(child),
            contentType: "application/json; charset=utf-8",

            success: function () {
                childId = -1;
                getAllChild();
                $("#myModal").modal("toggle");
            },
            failure: function (data) {
                alert("failure");
            },

            error: function (data) {
                alert(data.responseText);
            }
        });
        var rowNumber = parseInt($(this).attr("for"));
        $('td:eq(0)', 'tr:eq(' + (rowNumber + 1) + ')').html($("#edit-fname").val());
        $('td:eq(1)', 'tr:eq(' + (rowNumber + 1) + ')').html($("#edit-lname").val());
    }
    if (childId == -2) {
        debugger;
        let child = {
            lastName: $("#edit-lname").val(),
            firstName: $("#edit-fname").val()
        };
        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json charset=utf-8',
            },
            url: "users/children/post?id=" + userIdF,
            type: "Post",
            data: JSON.stringify(child),

            success: function () {
                $("#myModal").modal();
                getAllChild();
                $("#myModal").modal("toggle");
                $("#edit-fname").val("");
                $("#edit-lname").val("");
            },

            failure: function (data) {
                alert("failure");
            },

            error: function (data) {
                alert(data.responseText);
            }
        });
    }
});

$(".close").click(function () {
    $("#edit-fname").val("");
    $("#edit-lname").val("");
    $(".saveEdits").attr("for", "0");
    $("#myModal").fadeOut(300);
    $("#myModal").modal("toggle");
});

function setNotification() {
    $("#message").fadeIn("slow");
    $("#message a.close-notify").click(function () {
        $("#message").fadeOut("slow");
        return false;
    });
}