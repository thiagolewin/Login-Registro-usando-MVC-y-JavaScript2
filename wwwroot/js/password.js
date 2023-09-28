const form = document.querySelector("form")
form.addEventListener("submit",(e)=> {
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
        console.log("MalContraseña");
        return false;
    } else {
        if(e.target[1].value != e.target[2].value) {
            console.log("Contraseñas distintas");
            return false;
        } else {
            console.log("ok");
            form.submit();
        }
    }
})