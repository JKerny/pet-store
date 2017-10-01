$(document).ready(function () 
    {

    $('.logOff').click(function () {
        $("#logoutForm").submit();
    }
    )

    $('.delete-pet').click(function () {
        var flag = confirm("Are you sure you want to delete this pet?")
        if (flag) {
            return true;
        }
        else {
            return false;
        }

    });

    $('.delete-animal').click(function () {
        var flag = confirm("Deleting this animal type will delete all " + $(this).data("petcount") + " associated pets do you want to continue?");
        if (flag) {
            return true;
        }
        else {
            return false;
        }

    });

    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            GetPetData();
        }
    });
    var pageSize = 10;
    var pageIndex = 1;
    function GetPetData() {
        $.ajax(
            {
                type: 'GET',
                url: '/home/GetPaginatedPetData',
                data: { "pageindex": pageIndex, "pagesize": pageSize },
                dataType: 'json',
                success: function (data) {
                    if (data != null) {
                        for (var i = 0; i < data.length; i++) {
                            $("table")
                                .append(
                                "<tr>" +
                                "<td>" + data[i].AnimalType + "</td>" +
                                "<td>" + data[i].Name + "</td>" +
                                "<td>" + data[i].DateOfBirth + "</td>" +
                                "<td>" + data[i].Weight + "</td>" +
                                "</tr>"
                                );
                        }
                        pageIndex++;
                    }
                },
                beforeSend: function () {
                    $("#progress").show();
                },
                complete: function () {
                    $("#progress").hide();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                }
            })
    }
});


