# Entities

## Propósito da camada
Implementação das regras de negócio do sistema ao nível mais baixo, componente individual abstraído e delimitado quanto às propriedades, comportamentos e eventos.

### Faça
1. Crie objetos imutáveis
    - Imutabilidade é uma boa forma de manipulação de informação, resolve muitos problemas com alteração indesejada de estado e deixa muito claro os fluxos de alteração e controle que estão sendo efetuados no objeto.
2. Defina contratos para propriedades que precisam acessar algum recurso externo
    - Isso permite que uma implementação *fake* simule o comportamente desejado auxiliando em testes de unidade e minimizando os bugs
    - Pode ser alterado livremente a implementação e injetada dinamicamente, tornando seu código mais escalável
3. O domínio de um sistema é particular a esse sistema, você tem total liberdade (e dever) de gerenciar bem o seu domínio, customize-o ao gosto, para atender as necessidades do SEU PROJETO.
4. Preze pela qualidade arquitetural, é a melhor forma de garantir produtividade elevada ao longo do tempo sem a dor de cabeça de refatoração
5. SOLID é amigo, e anda de mãos dadas com a OOP, não seja um careta
6. Testes de unidades, no mínimo e principalmente para os componentes críticos

### Evite
1. Manter vários objetos para gerenciar os mesmos comportamentos, ou comportamentos que possam ser unificados
2. Poluir sua entidade com propriedades de outras, as famosas classes invejosas
3. [Entidades anêmicas](https://www.martinfowler.com/bliki/AnemicDomainModel.html) 
4. Testes de unidade que não agregam valor, cobertura 100% é diferente de código 100% coberto