# Use Cases

## Proposito da camada
Essa camada atua como um *façade*, sua função é expor as funcionalidades para os clientes da aplicação através de uma interface clara, isso é conseguido com base nos contratos da camada de `DTOs`.

### Faça
1. Exponha algum recurso que permite aos clientes saberem claramente as funcionalidades que o seu sistema disponibiliza
2. Seja uma Classe, interface, *IoC* ou qualquer recurso, seja consiso, isso vai facilitar a compreensão dos clientes e reduzir manutenções
3. Exponha seus casos de uso com os conceitos SOLID em mente, isso facilitará a escalabilidade e reduzirá refatorações, reduzindo potencialmente a refatoração de clientes e proporcionará alta produtividade
    - S (Single Responsibility): Faça com que cada API (Apllication Interface) seja responsável exclusivamente por um única funcionalidade
    - O (Open/Close): Seu código deve ser projetado de forma que:
        - Defina uma interface de extensibilidade, como uma própria `interface` ou uma `abstract class`, esse recurso é bem mais elegante, pois concilia-se com o princípio anterior
        - Permita ao cliente o encapsulamento das funcionalidades pelos clientes, isso pode ser maximizado com um bom contrato de `DTOs`, aproveite essa camada e faça sobrecarga de métodos quando desejar alterar um fluxo ou comportamento
    - L (Liskov substitution principle): Determina que instâncias de classes filhas podem substituir as classes pais SEM alterar o fluxo correto do programa. 
        - Esse princípio é relativamente simples de ser atingido se estivermos seguindo bem os passos anteriores, então considere isso uma métrica
        - Podemos exemplificar isso com as classes `Animal`, `Cachorro` e `Gato`, se considerarmos que o nosso objeto `Animal` tem nome, logo `Cachorro` e `Gato` terão, contudo, se `Animal` implementa um método `Grunhir` nenhuma das classes filhas poderia substituir o `Animal` no código, pois a implementação de `Gato` poderia ser miar e `Cachorro` latir, dessa forma eles podem substituir programáticamente um Animal no código, mas não de forma funcional pois ALTERAREMOS o fluxo desejado do código pois afinal qual é a implementação que animal tem para `Grunhir`. 
            - Seria mais correto que a classe `Animal` fosse abstrata e também `Grunhir`, pois dessa forma caberia as implementações definir o comportamento correto do sistema, e pelo principio de substituição nosso método seria baseado em parâmetros do tipo `Animal` pois dessa forma tanto `Cachorro` quando `Gatos` são animais que respeitam o contrato.
    - I (Interface Segregation): Clientes não devem ter que implementar métodos que eles não necessitam
        - Um caso claro disso é o processo de logistica envolvida em uma venda. Quando alguém compra algo o estoque deve ser movimentado, contudo, quem gerencia estoque é diferente de quem gerencia itens de pedido então não faz sentido que o mesmo processo de venda obrigue os clientes a gerenciar tanto o processo financeiro da venda quanto o de logística da venda
            - A solução para esse cenário é dividir (segregar) os contratos das interfaces em várias responsabilidades, financeiro, logística, cobrança e fiscal. Quando um determinado cliente não tiver a funcionalidade financeira o caso de uso correspondente saberá lidar com tal situação e ele não deverá implementar uma funcionalidade que nunca usará.
    - D (Dependency Inversion): Entidades devem depender de abstrações e módulos de alto nível não devem depender de baixos níveis, ou seja, abstração é a chave.
        - Esse é um excelente princípio, permite um código muito escalável, tomando como exemplo o código anterior o módulo responsável pelo fiscal deve depender da abstração criada para definir o contrato da operação.
        - A principal vantagem da aplicação desse princípio é a testabilidade dos componentes separados do seu código. Todos os framework bem sucedidos já fazem isso a anos, além disso permite Injeção de Dependencia que traz ainda mais desacoplamento e redução de manutenção.
        - Obviamente seu código é completamente escalável, pois com base no princípio Open/Closed seu código será extensível, mas corremos sérios riscos de esbarrar no princípio de Liskov, com o caso clássico do retangulo que não é quadrado
### Evite
1. Expor vários métodos com uma assinatura parecida, ou que tenham propósitos parecidos de existência
    - Isso demonstra pouco entendimento do domínio do sistema, ou seja, aquilo que ele é proposto a fazer
    - Essa é uma camada de casos de usos, ou seja, são as funcionalidades que serão expostas para interação com algum ator, se há vários métodos comuns com responsabilidades parecidas será necessário manutenção
    > Atores são qualquer entidade que se comunica com o sistema, seja esse uma pessoa ou outro sistema

2. Expor camadas internas do sistema, como a `Entities`, abrace a OOP (Object Oriented Programming) e tenha amor pelas boas práticas de programação, então KISS (Keep It Simple Stupid) & DRY (Dont Repeat Yourself), facilmente um caso de uso atravessa fronteiras de um entidade e pode consumir várias, sendo esse o caso mais comum em OOP

3. Expor muitos métodos, gestão centralizada tende a ser melhor que segmentação dos casos de usos.

4. Criar `Interfaces` que vão ter uma única implementação
    - Seu código vai ter todos os recursos abstraídos abaixo dessa camada nesse modelo arquitetural, não tem motivo para criar uma abstração aqui que vai ter sempre uma única implementação, sempre que for necessário alterar o comportamento não é o caso de uso que deve mudar, mas sim sua implementação na(s) camada(s) respectivas, isso fará a mágica acontecer com o correto gerenciamento de dependências e TDD de alto nível.
    - Se seu caso de uso teve que mudar é porquê o negócio mudou, isso **poderá** acarretar refatoração nos outros componentes, mas não é regra
    > Um componente só deve ter um motivo para mudar.
5. Alinhar seu código com um framework ou tecnologia
    - Seu código deve depender de abstrações, as instancias devem ser recebidas como parâmetro isso permite que o cliente especifique como vai lidar com as dependências, seja manualmente ou utilizando um *framework* de DI