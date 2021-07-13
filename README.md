# Desafio Toro Investimentos US-003

Tomei a decisão de concluir a US003 devido a minha experiência na área de backend e a parte de integração com conta corrente que vivencio na minha posição profissional atual.

### Serviços do projeto
#### Serviço SPB
Foi desenhado para receber solicitações de movimentações do SPB oriundas da RSFN e integra-las com o serviço de Conta Corrente.
#### Serviço Conta Corrente
O serviço de conta corrente administra todos os recursos disponíveis para movimentar as contas em sí. Para atender o projeto foi inicialmente pensado para receber a integração com o serviço citado acima e abrir novas contas.
Onde um banco de dados em SQL foi montado para persistir estes dados.

### Passo a Passo para movimentar uma conta corrente baseado na US.
1. Abrir uma conta com o seguinte request:
+ Request [Post]

    ```
    https://localhost:16002/contacorrente/abrir?titular={NomeDoTitular}&inscricao={Cpf/Cnpj}&conta={NumeroDaConta}
    ```

+ Response 201 (Application/json)
    
      {
        "id": 1,
        "titular": "Nome do titular",
        "inscricao": "cpf/cnpj",
        "agencia": "0001",
        "conta": "Numero da conta",
        "saldo": 0
      }
2. Enviar seguinte requisição ao serviço do SPB:
+ Request [Post]

    ```
    https://localhost:16004/spb
    ```

+ Response 200 (Application/json)

      {
        "event": "TRANSFER",
        "target": {
          "bank": "352",
          "branch": "0001",
          "account": "Conta"
        },
        "origin": {
          "bank": "033",
          "branch": "03312",
          "cpf": "Cpf/Cnpj"
        },
        "amount": 1000
      }
      
### Para executar a aplicação siga os seguintes passos:
1. Faça um clone do repositório através do comando 
```
git clone https://github.com/Raphael-Afonso/DesafioToroInvestimentos
```
2. Navegue até a pasta "ContaCorrente-Backend" e execute o seguinte comando:
```
dotnet build
```
3. Na pasta "SPB-Backend" execute o mesmo comando:
```
dotnet build
```
4. Retorne a raíz e execute o docker compose para criar a infraestrutura de containers e iniciar os serviços
```
docker-compose up
```

##### Possíveis melhorias futuras:
+ Utilização de mensageria para transitar mensagens entre os serviços e ganhar resiliência;
+ Validar os dados na abertura de contas correntes;
+ Implementar OAuth para trazer mais segurança as APIs;
