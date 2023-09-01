
$(".validate-login").click(function () {
    var LoginData = getlogin();
    if (LoginData.Username === "") {
        Swal.fire(
            'UserName!',
            'Please Enter UserName!',
            'warning'
        )
        return false;
    }


    if (LoginData.Password === "") {
        Swal.fire(
            'Password!',
            'Please Enter Password!',
            'warning'
        )

        return false;
    }
}

/*
    $.ajax({
    type: "Post",
    url: 'Login',
    data: { Username: $("#Username").val(), Password: $("#Password").val() }, 
    dataType: "json",
  
        });

    });
        */)

    function getlogin() {
        return {

        Username: $("#Username").val(),
        Password: $("#Password").val(),
        }
        
    }
