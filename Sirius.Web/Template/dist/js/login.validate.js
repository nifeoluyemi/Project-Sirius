$().ready(function(){

    $("#login-form").validate({
        rules:{
            username : "required",
            password : "required",
        },

        messages:{
            username : "Please enter username.",
            password : "Please enter password.",
        }
    });
/*
    if (!$("#login-form").valid()) {
        return false;
    };

    return true; */
});