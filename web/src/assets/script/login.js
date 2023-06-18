function validarLogin() {
    return new Promise((resolve, reject) => {
        // Obtenha os valores dos campos de entrada
        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;

        // Crie o objeto de dados para enviar na requisição
        const data = {
            entidade: {
                email: email,
                senha: password
            },
            operacao: "CONSULTAR"
        };

        // Realize a requisição AJAX para fazer o login
        fetch('https://localhost:7210/Candidato/consultarCandidato', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
            .then(response => response.json())
            .then(data => {
                // Processar a resposta do servidor
                if (Object.keys(data.data.entidades).length > 0) {
                    // Login bem-sucedido
                    resolve(true);
                    // Redirecionar para outra página, fazer outras ações, etc.
                } else {
                    // Login inválido
                    // Limpar os campos de entrada, se necessário
                    document.getElementById('email').value = '';
                    document.getElementById('password').value = '';
                    resolve(false);
                }
            })
            .catch(error => {
                // Lidar com erros na requisição
                console.error('Erro na requisição:', error);
                resolve(false);
            });
    });
}

function validarCadastro() {
    return new Promise((resolve, reject) => {
        // Obtenha os valores dos campos de entrada
        const email = document.getElementById('email').value;
        const password = document.getElementById('password').value;

        const nome = document.getElementById('name').value;
        const nomeMae = document.getElementById('motherName').value;
        const nomePai = document.getElementById('fatherName').value;

        const telefone1 = document.getElementById('phone1').value;
        const telefone2 = document.getElementById('phone2').value;
        const telefone3 = document.getElementById('phone3').value;

        const estado = document.getElementById('state').value;
        const cidade = document.getElementById('city').value;
        const cep = document.getElementById('CEP').value;
        const numero = document.getElementById('number').value;
        const rua = document.getElementById('street').value;

        const cursoSelecionado1 = document.getElementById('curso1');
        const cursoSelecionado2 = document.getElementById('curso2');
        const cursoSelecionado3 = document.getElementById('curso3');

        const cursoInteresseSelecionado1 = document.getElementById('cursoInteresse1');
        const cursoInteresseSelecionado2 = document.getElementById('cursoInteresse2');
        const cursoInteresseSelecionado3 = document.getElementById('cursoInteresse3');


        let selectedOption = cursoSelecionado1.options[cursoSelecionado1.selectedIndex];
        const curso1 = selectedOption.value;

        selectedOption = cursoSelecionado2.options[cursoSelecionado2.selectedIndex];
        const curso2 = selectedOption.value;

        selectedOption = cursoSelecionado3.options[cursoSelecionado3.selectedIndex];
        const curso3 = selectedOption.value;

        selectedOption = cursoInteresseSelecionado1.options[cursoInteresseSelecionado1.selectedIndex];
        const cursoInteresse1 = selectedOption.value;

        selectedOption = cursoInteresseSelecionado2.options[cursoInteresseSelecionado2.selectedIndex];
        const cursoInteresse2 = selectedOption.value;

        selectedOption = cursoInteresseSelecionado3.options[cursoInteresseSelecionado3.selectedIndex];
        const cursoInteresse3 = selectedOption.value;

        let tel = {
            telefones: [],
        };

        if (telefone1 !== "" && telefone1 !== undefined && telefone1 !== null) {
            tel.telefones.push({
                numero: telefone1,
                tipo: 1 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        if (telefone2 !== "" && telefone2 !== undefined && telefone2 !== null) {
            tel.telefones.push({
                numero: telefone2,
                tipo: 2 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        if (telefone3 !== "" && telefone3 !== undefined && telefone3 !== null) {
            tel.telefones.push({
                numero: telefone3,
                tipo: 3 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        let cursos = {
            cursos: [],
            cursosInteresse: []
        }

        if (curso1 != "" && curso1 !== undefined && curso1 !== null) {
            cursos.cursos.push({
                Nome: curso1,
                Descricao: "",
                Prioridade: 1 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        if (curso2 != "" && curso2 !== undefined && curso2 !== null) {
            cursos.cursos.push({
                Nome: curso2,
                Descricao: "",
                Prioridade: 1 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        if (curso3 != "" && curso3 !== undefined && curso3 !== null) {
            cursos.cursos.push({
                Nome: curso3,
                Descricao: "",
                Prioridade: 1 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        if (cursoInteresse1 != "" && cursoInteresse1 !== undefined && cursoInteresse1 !== null) {
            cursos.cursosInteresse.push({
                Nome: cursoInteresse1,
                Descricao: "",
                Prioridade: 1 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        if (cursoInteresse2 != "" && cursoInteresse2 !== undefined && cursoInteresse2 !== null) {
            cursos.cursosInteresse.push({
                Nome: cursoInteresse2,
                Descricao: "",
                Prioridade: 2 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        if (cursoInteresse3 != "" && cursoInteresse3 !== undefined && cursoInteresse3 !== null) {
            cursos.cursosInteresse.push({
                Nome: cursoInteresse3,
                Descricao: "",
                Prioridade: 3 // ou substitua 1 pelo valor do tipo de telefone desejado
            });
        }

        // Crie o objeto de dados para enviar na requisição
        const data = {
            entidade: {
                nome: nome,
                nomePai: nomePai,
                NomeMae: nomeMae,
                email: email,
                senha: password,
                telefones: tel.telefones,
                endereco: {
                    logradouro: rua,
                    CEP: cep,
                    numero: numero,
                    cidade: {
                        nome: cidade,
                        estado: {
                            nome: estado
                        }
                    }
                },
                cursosMatriculados: cursos.cursos,
                CursosInteresses: cursos.cursosInteresse,
            },
            operacao: "SALVAR"
        };

        // Realize a requisição AJAX para fazer o login
        fetch('https://localhost:7210/Candidato/salvarCandidato', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
            .then(response => response.json())
            .then(data => {
                // Processar a resposta do servidor
                if (Object.keys(data.data.entidades).length > 0) {
                    // Login bem-sucedido
                    resolve(true);
                    // Redirecionar para outra página, fazer outras ações, etc.
                } else {
                    console.log(data)
                    // Login inválido
                    // Limpar os campos de entrada, se necessário

                    document.getElementById('email').value = '';
                    document.getElementById('password').value = '';
                    resolve(false);
                }
            })
            .catch(error => {
                resolve(false);
                // Lidar com erros na requisição
                console.error('Erro na requisição:', error);
            });


    });
}

function popularSelectCursos() {
    const cursos = [{
            id: 0,
            nome: ''
        },
        {
            id: 1,
            nome: 'Engenharia de Software'
        },
        {
            id: 2,
            nome: 'Medicina'
        },
        {
            id: 3,
            nome: 'Direito'
        }
    ];



    const selectElement1 = document.getElementById('curso1');
    const selectElement2 = document.getElementById('curso2');
    const selectElement3 = document.getElementById('curso3');

    const selectInteresse1 = document.getElementById('cursoInteresse1');
    const selectInteresse2 = document.getElementById('cursoInteresse2');
    const selectInteresse3 = document.getElementById('cursoInteresse3');

    let options = cursos.map(curso => `<option value=${curso.nome}>${curso.nome}</option>`).join('\n');

    selectElement1.innerHTML = options;
    selectElement2.innerHTML = options;
    selectElement3.innerHTML = options;

    selectInteresse1.innerHTML = options;
    selectInteresse2.innerHTML = options;
    selectInteresse3.innerHTML = options;

}


function login() {
    const form = document.getElementById('loginForm');
    console.log("oi")

    validarLogin().then(result => {
        console.log(result);
        if (result) {
            form.submit();
            window.location.href = './homepage.html';
        }
    });

}

function cadastrarCandidato() {
    const form = document.getElementById('cadastroForm');
    validarCadastro().then(result => {
        console.log(result);
        if (result) {
            form.submit();
            window.location.href = './login.html';
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    popularSelectCursos();
});