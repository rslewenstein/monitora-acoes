# Monitora Ações

### PT-BR

(em desenvolvimento)
Bot para monitorar os preços das ações da bolsa brasileira. O intuito dessa aplicação é automatizar a minha busca pelo menor preço das ações(compra) e maior preço(venda), sendo assim, não preciso ficar todos os dias pesquisando pelos preços.
A aplicação funciona da seguinte maneira:

- É realizado um cadastro das ações que queremos monitorar o preço:
  (sigla (Ex: petr3), nome da empresa, preço atual, preço mínimo, preço máximo).
- O bot será executado de 2 a 3 vezes por dia. Caso alguma ação monitorada atinja o preço mínimo ou máximo, será disparado uma mensagem para o Telegram.

#### Tecnologias utilizadas:

.NetCore 5, MongoDB, TDD, xUnit, Integração com o Telegram, Crawler (para pegar os dados na web).

### EN-US

(developing)
Bot to monitor the prices of stocks on the Brazilian stock exchange. The purpose of this application is to automate my search for the lowest stock price (buy) and the highest price (sell), so I don't need to be every day searching for prices.
The application works as follows:

- A register of the stocks we want to monitor the price is made:
  (acronym (Ex: petr3), company name, current price, minimum price, maximum price).
- The bot will run 2 to 3 times a day. If any monitored stock reaches the minimum or maximum price, a message will be triggered to Telegram.

#### Technologies Used:

.NetCore 5, MongoDB, TDD, xUnit, Telegram Integration, Crawler (to get data from the web).
