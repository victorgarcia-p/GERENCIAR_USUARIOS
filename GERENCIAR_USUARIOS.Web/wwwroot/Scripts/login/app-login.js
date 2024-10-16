document.addEventListener("DOMContentLoaded", function () {
    const loginButton = document.querySelector("button[type='button']");

    loginButton.addEventListener("click", async function () {
        const login = {
            "Usuario": document.getElementById("usuario").value,
            "Senha": document.getElementById("senha").value
        };

        console.log(login);

        const response = await fetch('/Login/RealizarLogin', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: login
        });

        const result = await response.json();
        if (result.message === "Ok") {
            window.location.href = '/Home';
        } else {
            alert(result.message);
        }
    });
});