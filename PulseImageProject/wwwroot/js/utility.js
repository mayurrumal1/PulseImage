function notify(status = null, errorMsg = null) {
    let errorClass;
    switch (status) {
        case "success":
            errorClass = "alert-success";
            break;

        case "error":
            errorClass = "alert-danger";
            break;

        default:
            errorClass = "alert-danger";
            errorMsg = "Something went wrong!";
            break;
    }
    $('.alert-msg').html(errorMsg);
    $('.alert').removeClass("alert-success alert-danger").addClass(errorClass).removeAttr("hidden").show();
};