// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//function SaveStudent() {
//    //get all selected radio button. In our case we gave same name to radio button
//    //so only one radio button will be selected either Male or Female
//    let formData = {
//        FullName: $("#FullName").val(),
//        Email: $("#Email").val(),
//        Pass: $("#Pass").val(),
//        ConfirmPassword: $("#ConfirmPassword").val(),

//    }
//    console.log(formData)
//    $.ajax({
//        url: "/Users/Create",
//        type: "POST",
//        data: formData,
//        success: function(response) {
//            alert(response);
//        },
//        error: function(request, status, error) {
//            alert(request.responseText);
//        }
//    });
//}




// with validation 

function RegisterUser() {
    debugger;
    let formData = {
        FullName: $("#FullName").val(),
        Email: $("#Email").val(),
        Pass: $("#Pass").val(),
        ConfirmPassword: $("#ConfirmPassword").val(),

    }
    if (formData.FullName != "" && formData.Email != "" && formData.Pass != "" && formData.ConfirmPassword != "") {
        if (formData.Pass == formData.ConfirmPassword) {
            console.log(formData)
            $.ajax({
                url: "Create",
                type: "POST",
                data: formData,
                success: function (response) {

                    // swal("Good job!", "You are Registerd now!", "success");

                    swal({
                        title: "Good job!",
                        text: "You are Registerd now!!",
                        type: "success",
                    }).then(okay => {
                        debugger;
                        if (okay) {
                            window.location = "/SignIn";
                        }
                    });
                },
                error: function (request, status, error) {

                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'should you Enter your information!',
                        footer: '<a href="">Why do I have this issue?</a>'


                    });
                }
            });
        }
        else {
            /*alert("the form can not be empty .");*/
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'should you Enter your information!',
                footer: '<a href="">Why do I have this issue?</a>'
            });

        }


    }
}
 

