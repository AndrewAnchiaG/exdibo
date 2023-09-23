

/***
 * Check Minimun Requiremen
 * 
 * */
function CheckMinimumRequirement() {

    var strpassword = document.getElementById("Password").value.trim();
    var strConfirmar = document.getElementById("confirmar").value.trim();

    var divmsgerror = document.getElementById("msgcc");
    var diverror = document.getElementById("msgerror");
    var msgerror = "";
    var noValido = / /;

    // Revisar el contenido de 8 caracteres - check the length of 8 characters
    if (strpassword.length <= 7) {
        msgerror = "La contraseña deben contener un mínimo de 8 caracteres <br/>";
    }
    //validar letra minúscula - Check for LowerCase
    if (!strpassword.match(/[a-z]/)) {
        msgerror = msgerror + "La contraseña deben contener al menos una letra minúscula<br/>";
    }
    //validar letra mayúscula - Check for UppeCase
    if (!strpassword.match(/[A-Z]/)) {
        msgerror = msgerror + "La contraseña deben contener al menos una letra mayúscula<br/>";
    }
    //validar numero - Check for Number
    if (!strpassword.match(/\d/)) {
        msgerror = msgerror + "La contraseña deben contener al menos un número <br/>";
    }
    // Revisar la existencia de espacios - check out the space blanck
    if (noValido.test(strpassword)) { 
        msgerror = msgerror + "La contraseña no deben contener espacios en blanco<br/>";
    }
    // Validar que sean igual - Validate equals password   
    if (strConfirmar != strpassword) {
        msgerror = msgerror + "Las contraseñas no coinciden <br/>";
    }
    // Show messages that the password has the security minimum
    if (msgerror.length <= 1) {
        msgerror = "La contraseña cumple con los requerimientos mínimos";
    }
    diverror.innerHTML = msgerror;
    divmsgerror.innerHTML = msgerror;
}


function EqualsConfirm() {
    var iptConfirmar = document.getElementById("confirmar").value.trim();
    var divmsgerror = document.getElementById("msgcc");
    if (iptConfirmar.length >= 1)
    {
        var msgerror = "";
        var iptPassword = document.getElementById("Password").value.trim();
        if (iptPassword === iptConfirmar) {
            msgerror = "Las contraseñas coinciden correctamentamente";
        } else {
            msgerror = "Las contraseñas no coinciden";
        }
        divmsgerror.innerHTML = msgerror;
    } else {
        divmsgerror.innerText = "";
    }
}



function ShowOrHide_Password() {
    var checkbox = document.getElementById("mostrarcontrasena");
    var password1 = document.getElementById("Password");
    var password2 = document.getElementById("confirmar");
    if (checkbox.checked == true) {
        password1.setAttribute('type', 'text');
        password2.setAttribute('type', 'text');
    } else {
        password1.setAttribute('type', 'password');
        password2.setAttribute('type', 'password');
    }
}


function alertSaveChanges() {
    alert("Guardar Cambios");
}




//$(document.registration).ready(function () {

//    $('input').keyup(function () {
//        // set password variable
//        var password = $(this).val();
//        var p1 = document.getElementById("password1").value;
//        var p2 = document.getElementById("password2").value;
       

//        //validar longitud contraseña
//        if (password.length < 8) {
//            $('#length').removeClass('valid').addClass('invalid');
//        } else {
//            $('#length').removeClass('invalid').addClass('valid');
//        }
//        //validar letra
//        if (password.match(/[A-z]/)) {
//            $('#letter').removeClass('invalid').addClass('valid');
//        } else {
//            $('#letter').removeClass('valid').addClass('invalid');
//        }

//        //validar letra mayúscula
//        if (password.match(/[A-Z]/)) {
//            $('#capital').removeClass('invalid').addClass('valid');
//        } else {
//            $('#capital').removeClass('valid').addClass('invalid');
//        }

//        //validar numero
//        if (password.match(/\d/)) {
//            $('#number').removeClass('invalid').addClass('valid');
//        } else {
//            $('#number').removeClass('valid').addClass('invalid');
//        }

//        //validar confirmación contraseña
//        if (p1.length == 0 || p2.length == 0) {
//            $('#null').removeClass('valid').addClass('invalid');
//        } else {
//            $('#null').removeClass('invalid').addClass('valid');
//        }

//        //validar contraseñas cohincidan
//        if (p1 != p2) {
//            $('#match').removeClass('valid').addClass('invalid');
//        } else {
//            $('#match').removeClass('invalid').addClass('valid');
//        }

//        if (noValido.test(p1 || p2)) { // se chequea el regex de que el string no tenga espacio
//            $('#blank').removeClass('valid').addClass('invalid');
//        } else {
//            $('#blank').removeClass('invalid').addClass('valid');
//        }

//    }).focus(function () {
//        $('#pswd_info').show();
//    }).blur(function () {
//        $('#pswd_info').hide();
//    });

//});
