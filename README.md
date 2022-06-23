# Calculadora de retorno CDB
## [B]³ | Atos 

Siga as instruções abaixo para compilar e executar o projeto


### Pré-requisitos
[Dotnet CLI v6.0.301](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

[Node v16.15.1](https://nodejs.org/pt-br/download/)

[Angular CLI v14.0.2](https://www.npmjs.com/package/@angular/cli)

[Visual Studio Code](https://code.visualstudio.com/download)



### Clonar repositório

Abra o terminal de comando, e selecione uma pasta para clonar o repositório como seguinte comando:
```
git clone https://github.com/marcellomso/CDBCalc.git
```


### Compilação
Ainda no terminal, acesse a pasta raiz do projeto e execute o build da aplicação com os seguintes comandos:
```
cd ./CDBCalculator
dotnet build
```

Aguarde enquanto são baixadas as dependências do projeto de back e font


### Executar a aplicação
Após baixar e instalar todas as dependências já é possível executar o projeto. Acesse a pasta do projeto CDBCalc e esecute o comando Run do CLI do DotNet

```
cd ./cdbcalc
dotnet run
```

Esse comando vai iniciar a API que estára respondendo no endereço https://localhost:7141/. Se o browser não for carregado automaticamento copie o endereço e cole em uma nova aba do navegador.

Essa etapa vai startar a aplicação Web. Aguarde até que o carregamento seja concluído e ao final do processo você será redirecionado automaticamente para a página inicial do projeto no endereço:
https://localhost:44446/


### Testes Unitário
Para executar os testes basta digitar o comando dotnet test dentro da pasta do projeto.

```
cd ./cdbcalc.tests
dotnet test
```

### Abrir o projeto
Para abrir o projeto, navegue para a pasta raziz do projeto, digitando o seguinte comando no terminal para iniciar o Visual Studio Code:
```
cd ..
code .
```
