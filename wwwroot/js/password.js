const form = document.querySelector("form")
const input = document.querySelector("#contraseña")
const mensaje = document.querySelector(".mensaje")
const password = document.querySelector(".mensajepassword")
const passwordRepetida = document.querySelector(".mensajepasswordrepetida")
console.log(input)
input.addEventListener("input",(e)=> {
    passwordRepetida.textContent = ""
    password.textContent = ""
    let caracteresEspeciales = ['!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'];
    let abecedarioMayuscula = [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    ];
    
    let contieneCaracter = false
    let contieneMayuscula = false
    caracteresEspeciales.forEach(element => {
        if(e.target.value.includes(element)) {
            contieneCaracter = true
        }
    });
    abecedarioMayuscula.forEach(element => {
        if(e.target.value.includes(element)) {
            contieneMayuscula = true
        }
    });
    if(e.target.value.length < 8 || !contieneCaracter || !contieneMayuscula) {
        password.textContent = "La contraseña debe tener 8 caracteres, un carácter especial y una mayúscula!"
        return false;
    } else {
        if(e.target.value != form.children[6].value) {
            passwordRepetida.textContent = "Contraseñas distintas!"
            return false;
        } else {
            console.log("ok");
        }
    }
})
form.addEventListener("submit",(e)=> {
    console.log("Hola")
    e.preventDefault()
    let caracteresEspeciales = ['!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'];
    let abecedarioMayuscula = [
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    ];
    
    let contieneCaracter = false
    let contieneMayuscula = false
    caracteresEspeciales.forEach(element => {
        if(e.target[1].value.includes(element)) {
            contieneCaracter = true
        }
    });
    abecedarioMayuscula.forEach(element => {
        if(e.target[1].value.includes(element)) {
            contieneMayuscula = true
        }
    });
    if(e.target[1].value.length < 8 || !contieneCaracter || !contieneMayuscula) {
        mensaje.textContent = "La contraseña debe tener 8 caracteres, un carácter especial y una mayúscula!"
        return false;
    } else {
        if(e.target[1].value != e.target[2].value) {
            mensaje.textContent = "Contraseñas distintas!"
            return false;
        } else {
            console.log("ok");
            form.submit();
        }
    }
})