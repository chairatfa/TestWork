
$(document).on("click", "#btnInsertSave", function() {

    alert("OK");
    // $('#myModal').modal('hide');
    // var formData = new FormData($('#product_view_insert')[0]);
    var inemail=document.getElementById("Email");
    ValidateEmail(inemail)

});

function ValidateEmail(inemail)
{
        var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if(inemail.value.match(mailformat))
        {
        alert("Valid email address!");
        // document.form1.text1.focus();
        return true;
        }
        else
        {
        alert("You have entered an invalid email address!");
        // document.form1.text1.focus();
        return false;
        }
}