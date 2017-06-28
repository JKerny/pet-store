$(document).ready(function () {
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

    
});
//function OnDeleteClick(e) {
//    var flag = confirm("Are you sure you want to delete this pet?")
//    if (flag) {
//        return true;
//    }
//    else {
//        return false;
//    }

//}

