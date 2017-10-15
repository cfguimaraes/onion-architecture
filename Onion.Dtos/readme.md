# DTOs

## Propósito da camada
Definir uma interface acessível externamente com objetos fortemente tipados, o objetivo central dessa camada e encapsular e centralizar os *requests* e *reponses* disponibilizando uma forma consistente de comunição com os clientes (aplicações) sem alterar o funcionamento do sistema.

### Faça
1. Seja consistente em seus DTOs, isso será de acordo com o domínio do sistema que estiver utilizando.
2. Mantenha DTOs simples, um DTO (Data Transfer Object) só tem como objetivo organizar e trafegar informações para passagem como parâmetro (input ou output)
3. Use DTOs para encapsular muitos objetos de domínio
	- Dado um pedido de venda, esse pode ser descrito como a data da operação, os itens da operações e seus respectivos valores e quantidades e também o cliente e operador, idealmente teríamos entidades para lidar com todos as particularidades desses objetos, afinal itens de pedido tem comportamento diferente de cliente portanto devem ter abstrações distintas, assim um DTO pode ser utilizado para encapsular a complexidade de obter a informações de muitas fontes e até aumentar a performance pois atuará como uma agregador

### Evite
1. Criar mais que um DTO em pastas distintas com o mesmo proposito
2. Fazer validações nessa camada, centralize em uma camada abaixo dessa, se necessário crie uma camada para validações ou centralize-as nos casos de usos
3. Expor recursos de camadas inferiores, essa camada deve ser utilizada apenas como contrato da informação disponibilizada e requerida pelo caso de uso específico
4. Expor propriedades das suas entidades, quanto menos a audiência souber de seu domínio, melhor