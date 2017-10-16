# Services
## Propósito da camada
Encapsular e definir uma implementação padrão para recursos externos não gerenciáveis

- Podemos citar como exemplo as plataformas *Twilio* e *Sendgrid*, provem serviços para disparar mensagens, mas nenhum destes recursos é gerenciado, como a camada é  *cross cutting* e geralmente podemos querer enviar uma resposta *short circuit* torna ideial que seja gerenciado como um serviço disponível as várias camadas da aplicação.
- O ideal é que também sejam encapsulados todos os recursos não gerenciáveis ou que atravesse camadas para centralização a fácil acesso, como **Autenticação**
- Não gostaríamos de gerenciar um padrão como o *composite* como serviço, obviamente essa camada poderá facilitar muito esse tipo de aplicação, mas o ideal é que não se polua essa camada com algo tão arquitetural, que obviamente não é um serviço, mas sim um estilo.
- Essa camada assim como a camada *Entities* é completamente particular aos componentes da sua aplicação, fica portanto esses tópicos como sugestão de aplicação, usufrua destes recursos de forma que BENEFICIEM A SUA APLICAÇÃO e todas as SUAS PARTICULARIDADES.