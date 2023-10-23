<h1 align="center">🌍 Sistema de Gerenciamento de Dados do IBGE 🌍</h1>

## Tópicos

1. <a href="#agradecimentos">Agradecimentos</a><br>
2. <a href="#projeto">Projeto</a><br>
3. <a href="#recursos">Principais Recursos</a><br>
4. <a href="#tecnologias">Tecnologias</a><br>
5. <a href="#estrutura">Apresentação Gráfica da Estrutura do Projeto</a><br>
6. <a href="#endpoints">Endpoints</a><br>
7. <a href="#userEndpoint">Endpoints de Usuário</a><br>
8. <a href="#addressEndpoint">Endpoints de Endereços</a><br>
9. <a href="#contribuidores">Contribuidores</a><br>


<section id="agradecimentos"></section>

<div align="center" margin="100px">
	<h2>Agradecimentos</h2> 
	<br>
	<a href="https://balta.io/">
		<img src="https://baltaio.blob.core.windows.net/static/images/dark/balta-logo.svg" style="width: 250px;"></img>
	</a>
</div>
<br>

- Gostaríamos de agradecer ao André Baltieri, que, por meio de sua plataforma, está promovendo o conhecimento por meio deste desafio. 
Foi possível colocar em prática vários dos cursos que realizamos até o momento. Além disso, ele incentivou o networking entre os alunos 
ao formar grupos para o desenvolvimento do projeto, bem como na sua comunidade no Discord, onde pudemos tirar dúvidas.
<br>

<section id="projeto"> </section>

## 📋 Projeto
- O Sistema de Gerenciamento de Dados do IBGE é uma API construída para facilitar a consulta, atualização, exclusão e criação de registros em uma base de dados simulada do Instituto Brasileiro de Geografia e Estatísticas (IBGE).

Link: https://challengeibge.azurewebsites.net/swagger/index.html

<br>
<section id="recursos"></section>

## 📃Principais Recursos</h2>
1. Consulta de Dados: Os usuários podem realizar consultas na base de dados simulada do IBGE para obter informações como:
	- Pesquisar por um Estado e suas cidades
	- Pesquisar por cidades com determinado nome
2. Gerenciamento de Usuários: O projeto oferece um sistema de cadastro de usuários com autenticação por email e senha, garantindo que apenas pessoas autorizadas tenham acesso à determinadas funcionalidades.
3. Segurança de Senhas: Por questão de segurança, todas as senhas são armazenadas de forma criptografada, garantindo que ninguém, nem mesmo os administradores do sistema, tenham acesso direto às senhas dos usuários.
4. Autorização e Controle de Acesso: Algumas partes da API exigem níveis de permissão específicos, com cargos e privilégios associados

<br>
<section id="tecnologias"></section>

## 💻 Tecnologias
- .NET
- Dapper
- Entity Framework
- SqlServer
- MediatR
- Flunt
- Swagger

<br>
<section id="estrutura"></section>

## 🔎 Apresentação Gráfica da Estrutura do Projeto
<div align="center">
	<img src="./ChallengeIBGE.Api/img/api-endpoints.png" style="width: 300px;border: 1px solid;"></img><br>
	<img src="./ChallengeIBGE.Api/img/requirements-structure.png" style="width: 900px;border: 1px solid;"></img><br>
	<img src="./ChallengeIBGE.Api/img/folder-structure.png" style="width: 900px;border: 1px solid;"></img<br>
	<img src="./ChallengeIBGE.Api/img/use-cases.png" style="width: 900px;border: 1px solid;"></img><br>
</div>

<br>
<section id="endpoints"></section>

## 📌 Endpoints
- Aqui estão todos os endpoints da API. Sempre que um novo usuário é cadastrado, ele é atribuído ao cargo 
de "User" por padrão. Isso permite que ele adicione outros cargos disponíveis no banco de dados. 
Para obter autorização para utilizar alguns recursos relacionados a usuários, é necessário ter o cargo de "Admin". 
Lembre-se de que, sempre que um novo cargo for adicionado, será necessário fazer uma nova autenticação para 
evitar erros de Bad Request.
- É importante lembrar que, caso o projeto seja colocado em produção, será necessário revogar a permissão dos usuários de 
adicionar novos cargos.
<section id="userEndpoint"></section>

### Endpoints de Usuário
- Autenticação
```
• URL: 
	https://localhost:7111/api/v1/user/authenticate

• Json de Inserção:
{
	"email": "teste@teste.com",
	"password": "ABC123abc123"
}

• Json de Retorno:
{
	"data": {
		"id": "15d848b7-a088-4c2c-a38d-92fbea6c765b",
		"email": "teste@teste.com",
		"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjE1ZDg0OGI3LWEwODgtNGMyYy1hMzhkLTkyZmJlYTZjNzY1YiIsInVuaXF1ZV9uYW1lIjoidGVzdGVAdGVzdGUuY29tIiwicm9sZSI6IlVzZXIiLCJuYmYiOjE2OTc3MzU4NDUsImV4cCI6MTY5Nzc3OTA0NSwiaWF0IjoxNjk3NzM1ODQ1fQ.28v32dXByv_u0ppSCIrRn1beIxrDVyB3STsjGE2VvS4",
		"roles": [
			"User"
		]
	},
	"message": "",
	"status": 200,
	"isSuccess": true,
	"notifications": null
}
```
- Criar usuário
```
• URL: 
	https://localhost:7111/api/v1/user/create

• Json de Inserção:
{
	"firstName": "NomeUsuario",
	"lastName": "SobrenomeUsuario",
	"email": "emailusuario@email.com",
	"password": "ABC123abc123"
}

• Json de Retorno:
{
	"data": {
		"id": "ea8ba056-6b9e-4730-bea2-9943ea8fbbc9",
		"name": "NomeUsuario",
		"email": "emailusuario@email.com"
	},
	"message": "User created successfully.",
	"status": 201,
	"isSuccess": true,
	"notifications": null
}
```

- Buscar usuário
```
• URL: 
	https://localhost:7111/api/v1/user/search/{id} 

• URL de Busca:
	https://localhost:7111/api/v1/user/search/ea8ba056-6b9e-4730-bea2-9943ea8fbbc9

• Json de Retorno:
{
	"data": {
		"id": "ea8ba056-6b9e-4730-bea2-9943ea8fbbc9",
		"firstName": "NomeUsuario",
		"lastName": "SobrenomeUsuario",
		"email": "emailusuario@email.com",
		"roles": []
	},
	"message": "",
	"status": 200,
	"isSuccess": true,
	"notifications": null
}
```
- Atualizar usuário
```
• URL: 
	https://localhost:7111/api/v1/user/update

• Json de Inserção:
{
	"id": "ea8ba056-6b9e-4730-bea2-9943ea8fbbc9",
	"updatedFirstName": "NovoNomeUsuario",
	"updatedLastName": "NovoSobrenomeUsuario",
	"updatedEmail": "novoemailusuario@email.com"
}

• Json de Retorno:
{
	"data": {
		"id": "ea8ba056-6b9e-4730-bea2-9943ea8fbbc9",
		"firstName": "NovoNomeUsuario",
		"email": "novoemailusuario@email.com"
	},
	"message": "User updated successfully",
	"status": 200,
	"isSuccess": true,
	"notifications": null
}
```
- Deletar usuário
```
• URL: 
	https://localhost:7111/api/v1/user/delete

• Json de Inserção:
{
	"id": "ea8ba056-6b9e-4730-bea2-9943ea8fbbc9"
}

• Json de Retorno:
{
	"User deleted successfully."
}
```

<section id="addressEndpoint"></section>

### Endpoints de Endereços
- Criar endereço
```
• URL: 
	https://localhost:7111/api/v1/address/create

• Json de Inserção:
{
    "id": 1010101,
    "city": "Balta City",
    "state": "SP"
}

• Json de Retorno:
{
    "data": {
        "city": "Balta City",
        "state": "SP",
        "id": 1010101
    },
    "message": "Address created successfully.",
    "status": 201,
    "isSuccess": true,
    "notifications": null
}
```
- Atualizar endereço
```
• URL: 
	https://localhost:7111/api/v1/address/update

• Json de Inserção:
{
    "id": 1010101,
    "city": "Balta",
    "state": "SP"
}

• Json de Retorno:
{
    "data": {
        "id": 1010101,
        "city": "Balta",
        "state": "SP"
    },
    "message": "Address updated successfully.",
    "status": 200,
    "isSuccess": true,
    "notifications": null
}
```
- Deletar endereço
```
• URL: 
	https://localhost:7111/api/v1/address/delete

• Json de Inserção:
{
    "id": 1010101
}

• Json de Retorno:
{
	"Address deleted successfully."
}
```
- Buscar endereço por ID
```
• URL: 
	https://localhost:7111/api/v1/address/search?id={id}

• URL de Busca:
	https://localhost:7111/api/v1/address/search?id=4106902

• Json de Retorno:
{
    "data": {
        "addresses": [
            {
                "id": 4106902,
                "city": "Curitiba",
                "state": "PR"
            }
        ]
    },
    "message": "",
    "status": 200,
    "isSuccess": true,
    "notifications": null
}
```
- Buscar endereço por Cidade
```
• URL: 
	https://localhost:7111/api/v1/address/search?city={city}

• URL de Busca:
	https://localhost:7111/api/v1/address/search?city=Curitiba

• Json de Retorno:
{
	"data": {
		"addresses": [
			{
				"id": 4106902,
				"city": "Curitiba",
				"state": "PR"
			},
			{
				"id": 4204806,
				"city": "Curitibanos",
				"state": "SC"
			}
		]
	},
	"message": "",
	"status": 200,
	"isSuccess": true,
	"notifications": null
}
```
- Buscar endereço por Estado
```
• URL: 
	https://localhost:7111/api/v1/address/search?state={state}

• URL de Busca:
	https://localhost:7111/api/v1/address/search?state=SC

• Json de Retorno:
{
	"data": {
		"addresses": [
			{
				"id": 4200051,
				"city": "Abdon Batista",
				"state": "SC"
			},
			{
				"id": 4200101,
				"city": "Abelardo Luz",
				"state": "SC"
			},
			{
				"id": 4200200,
				"city": "Agrolândia",
				"state": "SC"
			},
			{
				"id": 4200309,
				"city": "Agronômica",
				"state": "SC"
			},
			{
				"id": 4200408,
				"city": "Água Doce",
				"state": "SC"
			},
			{
				"id": 4200507,
				"city": "Águas de Chapecó",
				"state": "SC"
			}
			...
		]
	},
	"message": "",
	"status": 200,
	"isSuccess": true,
	"notifications": null
}
```

<br>
<section id="contribuidores"></section>

## ©️ Contribuidores

- Erik Coelho
	- [GitHub](https://github.com/ErikCoelho)
	- [Linkedin](https://www.linkedin.com/in/erik-coelho-56121318b/)
- Igor Santiago
	- [GitHub](https://github.com/igorsantiiago)
	- [Linkedin](https://www.linkedin.com/in/igorsantiago/)
