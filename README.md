# 5by5-Biltiful
Desenvolver uma aplicação que irá compartilhar diversas informações entre os “Módulos” que 
cada integrante da equipe será responsável.

<br>

[biltiful.pdf](https://github.com/CauaDeSa/5by5-Biltiful/files/15270553/biltiful.pdf)

<br>

# Especificações

Apresentar informações sobre um projeto que controlará as compras e vendas de produtos de uma 
empresa que fabrica cosméticos denominada BILTIFUL. Os módulos são referentes aos controles 
de:
<br><br>
* Cadastros Básicos de todas as Informações (Cliente, Fornecedor, Matéria-Prima, 
Produto produzido pela empresa e, controle de Clientes Inadimplentes e Fornecedores 
bloqueados);
* Venda dos Produtos;
* Compra de Matéria-prima;
* Produção dos Cosméticos
  
<br>

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/8cde7ae7-6c09-40e4-9514-0a383e5d10a6" width="520px">

<br><br>

# Cadastros Básicos

Esse módulo deverá ser responsável pelos cadastros básicos que serão utilizados pelos outros 
módulos.
As operações básicas para um cadastro serão:
• Cadastrar (Verificar se todas as informações estão dentro das políticas da empresa);
• Localizar (Um registro (Cliente/Produto/Matéria-prima/Inadimplente/Fornecedor 
Bloqueado) específico);
• Editar (Alterar os dados de um cliente, desde que esse dado não seja uma informação 
chave, a qual identifica unicamente um registro desse cadastro).
• Impressão por Registro (Onde o usuário poderá “navegar” pelos registros cadastrados, 
podendo ir para o próximo ou anterior e, também podendo ir para as extremidades (início 
e final da listagem).
• Não poderão ser cadastrados dois registros com o mesmo “atributo” chave.
• Os cadastros de Cliente/Produto/Matéria-prima não poderão ser excluídos, e sim, ter sua 
situação alterada de “Ativa” para “Inativa”, dessa forma, não aparecerão nas impressões 
dos cadastros.

<br>

### Cadastro de clientes

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/b3444f78-8fe7-43a2-94fa-ef0abd492fcc" width="520px">

<br><br>

### Cadastro de fornecedores

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/25e773cb-50da-44ad-af20-3166a635676c" width="520px">

<br><br>

### Cadastro de Matéria-prima

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/c469364a-205b-433c-9d64-81921effc3b0" width="520px">

<br><br>

### Cadastro de Produtos (cosméticos)

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/df81df54-74af-4f4d-8085-f6f2fdb73a49" width="520px">

<br><br>

### Cadastro de Inadimplentes

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/0ecb1d16-0b40-4d9f-a488-c929943cbbf6" width="520px">

<br><br>

Esse cadastro deverá ser responsável pelo controle de pessoas físicas que tiveram algum problema 
financeiro com a empresa e/ou tiveram alguma avaliação negativa pelo departamento financeiro 
da empresa.
As operações básicas para uma pessoa física de risco serão:
• Cadastrar (Inserir o CPF de uma pessoa física relação);
• Localizar (Um CPF específico);
• Retirar o CPF dessa listagem (após uma nova análise, o departamento financeiro pode 
retirar o CPF dessa relação, liberando assim, que ele consiga realizar qualquer operação 
com a empresa);
• Não poderão ser cadastrados dois registros com o mesmo “atributo” chave
<br><br>
### Cadastro de Bloqueados

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/5a85404e-2144-4329-85b3-ad4087f68b47" width="520px">

<br><br>

Esse cadastro deverá ser responsável pelo controle de pessoas jurídicas que tiveram algum 
problema financeiro/jurídico com a empresa e/ou tiveram alguma avaliação negativa pelo 
departamento de produção (controle de qualidade das matérias-primas) da empresa.
As operações básicas para um CNPJ de risco serão:
• Cadastrar (Inserir o CNPJ de uma pessoa jurídica nesta relação);
• Localizar (Um CNPJ específico);
• Retirar o CNPJ dessa listagem (após uma nova análise, o departamento de produção ou o 
financeiro pode retirar o CNPJ dessa relação, liberando assim, que ele consiga realizar 
qualquer operação com a empresa);
• Não poderão ser cadastrados dois registros com o mesmo “atributo” chave.

<br>

# Vendas de Produtos
Esse módulo deverá ser responsável pelos registros das vendas dos produtos (cosméticos) 
produzidos pela empresa, para os clientes que já possuem um cadastro na empresa.
As operações básicas para uma venda serão:
• Cadastrar;
• Localizar (Uma venda específica, como todos os seus dados e seus itens);
• Excluir (Apagar as vendas e todos os seus respectivos itens)
• Impressão por Registro (Onde o usuário poderá “navegar” pelos registros cadastrados, 
podendo ir para o próximo ou anterior e, também podendo ir para as extremidades (início 
e final da listagem).
• Não poderão ser cadastrados dois registros com o mesmo “atributo” chave.

<br>

### Cadastro de vendas

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/219b185d-d596-4313-b982-388cd06e9032" width="520px">

<br><br>

Após a identificação básica da venda, poderemos escolher/relacionar os produtos com a venda:

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/d248daf7-64ad-40b1-a629-a64b7d90088a" width="520px">

<br><br>

# Compra de Matéria Prima
Esse módulo deverá ser responsável pelos registros das compras das matérias-primas para a 
produção dos produtos (cosméticos) produzidos pela empresa, pelosfornecedores que já possuem 
um cadastro na empresa.
As operações básicas para uma venda serão:
• Cadastrar;
• Localizar (Uma compra específica, como todos os seus dados e seus itens);
• Excluir (Excluir uma compra e todos os seus respectivos itens);
• Impressão por Registro (Onde o usuário poderá “navegar” pelos registros cadastrados, 
podendo ir para o próximo ou anterior e, também podendo ir para as extremidades (início 
e final da listagem).
• Não poderão ser cadastrados dois registros com o mesmo “atributo” chave.

<br>

### Cadastro de Compra de Matéria-prima

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/5b3fbbe0-9786-45d5-a2d6-896435feb798" width="520px">

<br><br>

Após a identificação básica da compra, poderemos escolher/relacionar as matérias-primas com a 
compra:

<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/5380d47a-4b1f-488b-8eea-e8ba5f91e68d" width="520px">

<br><br>

# Produção de Cosméticos
Esse módulo deverá ser responsável pelos registros das produções de cosméticos (Produtos) 
realizadas pela empresa.
As operações básicas para uma produção serão:
• Cadastrar;
• Localizar (Uma produção específica, como todos os seus dados e seus itens (matériasprimas utilizadas e produto gerado));
• Excluir (Excluir uma produção e todas as quantidades de seus respectivos cosméticos 
gerados e matérias-primas utilizadas);
• Impressão por Registro (Onde o usuário poderá “navegar” pelos registros cadastrados, 
podendo ir para o próximo ou anterior e, também podendo ir para as extremidades (início 
e final da listagem).
• Não poderão ser cadastrados dois registros com o mesmo “atributo” chave.

<br>

### Cadastro de Produção de Cosméticos
<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/514ab1ff-efa8-45b5-a248-3ed5d63439a4" width="520px">

<br><br>

### Cadastro de Itens de Produção de Cosméticos
<img src="https://github.com/CauaDeSa/5by5-Biltiful/assets/127906505/06c9582f-cbb1-41ed-ab6d-6a1cb3d249a6" width="520px">
