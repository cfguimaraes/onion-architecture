# onion-architecture
Esse projeto é um modelo arquitetural com o propósito de servir de template inicialização de projetos
bem como guia para maturidade de projetos desacoplados, 
com maior manutenibilidade e testável.

## Modelo

A proposta é um modelo em camadas, onde cada camada interna é responsável pelos níveis mais baixos da implementação, 
idealmente as camadas externas não devem ser acessíveis as camadas internas.

Existem muitos projetos que não consideram acesso a dados como parte integrante do modelo, 
esse modelo pode ser utilizado sem acesso a dados simplesmente removendo a camada responsável pelo acesso,
o que é válido para inclusão e alteração de outras camadas conforme necessidade.

![Onion modelo conceitual](/Onion-Architecture.png)
