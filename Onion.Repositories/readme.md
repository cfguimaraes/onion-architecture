# Repositories
## Proposito da camada
Definir um contrato fortemente tipado para acesso a recursos externos

Vários projetos existentes consideram o acesso a dados como uma operação de alto nível, não existindo nos níveis mais baixo, contudo é acessível e incentivada através de IoC.
Em minha visão o acesso a dados é uma operação comum desde o início da era computacional, cálculos sem informações não tem valor, são apenas dados.
Essa arquitetura define como camada mais baixa o acesso a dados, e levando em consideração as várias camadas de abstração, só poderia ser considerada tão baixo nível quanto desserialização e operações de *reflection*, como ambas as operações podem ser vistas do ângulo de acesso a dados é ideal que estejam centralizadas em uma camada de *Repositories* que permita acesso programático aos recursos usufruindo de toda a sorte de recursos de otimização disponibilizados pelo .net
> Se não houver necessidade de acesso a dados em seu sistema a camada pode simplesmente ser ignorada, sem prejuízos as camadas superiores.

### Faça
1. Centralize seus repositorios baseado em similaridade das operações
    - Utilizando uma base SQL você provavelmente terá que lidar com tabelas que se cruzarão em vários repositorios, **Pessoas** são um exemplo claro disso.
    - Se a operação que estiver invocando for para gestão de pessoas centralize alí todas as operações refentes as pessoas, nas vendas a pessoas é apenas um incremento a informação, ainda que seja a parte crucial dessa, a pessoa continua a existir se a venda deixar de existir, portanto esse repositorio lida com vendas e não com pessoas.
2. Não reutilize objetos de outras camadas, você gerará alto acoplamento entre seu domínio e sua persistência, o que quase sempre é algo indesejado e completamente desencorajado no modelo Onion.
	- Defina tipos independentes das entidades do seu sistema, persistência não corresponde ao seu domínio, se você precisar alterar todo o modelo de persistência é um caso claro de mau gerenciamento de escopo.
	- Com um contrato definido de persistência você pode alterar o mecanismo de persistência como desejar, sem impactar nas camadas superiores, pode alterar o seu SGBD desde que o contrato seja preservado e não gerará refação.
3. Com um contrato para acesso a dados fica muito mais fácil gerar *stubs* para testas funcionalidades expostas pelo sistema
4. Repositórios consumir repositórios
	- Caso seu repositório precise acessar um recurso que já esteja pronto mas que pertença a um domínio distinto reutilize esse recurso, será muito mais proveitoso o compilador te alertar que algo foi alterado e você refatorar tudo que descobrir em tempo de execução que uma mudança no repositório deixou um código depreciado em produção por estar duplicado.

### Evite
1. Utilizar repositórios para acessar recursos que não são gerenciadas pelo seu sistema
	- Utilize a camada **Services** para acessar recursos não gerenciáveis, se um recurso é gerenciado externamente e você precisar consumi-lo idealmente deverá encapsular essa informação, contudo isso é algo completamente particular ao serviço em questão, e exceto em integrações você não terá muitas chamadas para o mesmo serviço, torna ideal então a gerencia desse recurso como um serviço, afinal é isso que ele é, um componente externo, não gerenciável que provê algum recurso para sua aplicação
	- Outra característica que torna útil a gestão de componentes externos como serviços é o versionamento, você pode escalar muito mais facilmente consumindo recursos externos através de serviços, que poderão ter recursos exclusivos e sob demanda.
2. Fazer muitas chamadas para montar objetos completos
	- Obter pessoas através de uma repositório; em seguida obter os telefones e endereços através de outro repositório (algumas vezes 1 a 1) e por final obter os faturamentos por outro repositório
	- Caso se encontre no cenário acima defina que é o responsável pela informação de maior valor, o que compõe essa informação e o que agrega. No caso acima telefones e endereços sempre serão agregadores, mas a informação importante pode ser vista tanto do viés de faturamento quanto da pessoa em sí.
3. Fazer com que um recurso seja obtido de várias formas distintas com pouca alteração no processo de obtenção de dados
	- Um exemplo disso é a obtenção de um recurso por `Id`, `Identificador secundário` e transformação de nome (`like` e até `full text search`), tente de alguma forma centralizar sua informação em um único método senão terá para cada forma de obtenção um bloco de código para manutenção.
	- .Net proporciona a interface IQueryable que pode ser uma ótima fonte para abstração de dados e consumo de recursos, seja utilizando `Entity Framework`, criando o seu `provider` ou até mesmo criando uma query baseado em um contrato, como o `Dapper.SqlBuilder` que te permitirá construir queries dinâmicas com segurança.