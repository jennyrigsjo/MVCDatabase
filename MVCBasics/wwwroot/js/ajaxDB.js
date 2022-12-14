
var buttonClicked = "";


$("#spaForm input[type = 'submit']").click(function() {
    buttonClicked = $(this).attr("id");
});


$("#spaForm").submit(function (event) {

    event.preventDefault(); // stop page reload

    let formEl = document.forms.spaForm;
    let formData = new FormData(formEl);
    let id = formData.get('id');

    if (buttonClicked == "details")
    {
        GetPerson(id);
    }

    if (buttonClicked == "delete")
    {
        DeletePerson(id);
    }

});


function GetPeopleList() {

    let url = "/AjaxDB/PeopleList";

    $.ajax({
        type: 'GET',
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            PrintResult(response);
        },
        error: function (error) {
            // This part will not trigger unless response status code is set to anything other than 2**
        }
    });
}


function GetPerson(id) {

    if (id == "")
    {
        PrintResult("Please provide an ID.");
        return;
    }

    let url = `/AjaxDB/GetPerson/${id}`;

    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            PrintResult(response);
        },
        error: function (error) {
            // This part will not trigger unless response status code is set to anything other than 2**
        }
    });
}


function DeletePerson(id) {

    if (id == "")
    {
        PrintResult("Please provide an ID.");
        return;
    }

    let url = `/AjaxDB/DeletePerson/${id}`;

    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            PrintResult(`Item with id '${id}' has been successfully deleted.`);
        },
        error: function (error) {
            PrintResult(`Item with id '${id}' could not be deleted.`);
        }
    });
}


function PrintResult(result) {
    document.getElementById("spaResult").innerHTML = result;
}


/*** Old code (do not remove, may be useful in the future) ***/

//function GetPeopleList() {
//    let url = "/Ajax/PeopleList";

//    $.get(url, function (response) {
//        PrintResult(response);
//    });
//}


//function DoPostAction(action, id) {
//    let url = `/Ajax/${action}/${id}`;

//    $.post(url, function (response) {
//        document.getElementById("spaResult").innerHTML = response;
//    });
//}


//function DoAJAXPostAction(action, id) {

//    let url = `/Ajax/${action}/${id}`;

//    $.ajax({
//        type: 'POST',
//        url: url,
//        contentType: 'application/json; charset=utf-8',
//        success: function (response) {
//            console.log(response);
//            PrintResult(response.model.message);
//        },
//        error: function (error) {
//            console.log(error);
//            PrintResult(error.responseJSON.model.message);
//        }
//    });
//}