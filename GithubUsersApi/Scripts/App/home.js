$(function () {

    // click event to invoke contoller method via ajax call
    $("#btnSearch").click(function () {
        if (validate()) {
            var btn = $(this);
            $(btn).text("Fetching data...");
            try {
                var userName = $("#txtUserName").val().trim();
                fetchGitHubUserRepo($(btn), userName);
            }
            catch (exception) {
                console.log(exception.responseText);
            }
        }
    });
    //ajax call to controller method
    var fetchGitHubUserRepo = function ($btn, userName) {
        //ajax call to webAPI  
        $.ajax({
            type: "POST",
            data: {
                "userName": userName
            },
            dataType: 'html',
            url: "../Home/GetUserDetails",
            success: function (result) {
                if (result != "") {
                    $("#content").empty();
                    $("#content").append(result);
                }
                else {
                    $("#validator").removeClass("hide");
                }
                $btn.text("Search");
                $("#txtUserName").attr("readonly", true);
            },
            error: function (err) {
                $btn.text("Search");
                console.log(err.responseText);
            }
        });
    }
    //validate method
    var validate = function () {
        $("#validator").addClass("hide");
        $("#content").html("");
        if ($('#txtUserName').val().trim() == "") {
            $("#validator").removeClass("hide");
            return false;
        }
        return true;
    }

    //click event for refreshing data
    $("#btnRefresh").click(function () {
        $('#txtUserName').val("");
        $("#content").html("");
        $("#txtUserName").attr("readonly", false);
        $("#txtUserName").focus();
    });

});