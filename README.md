# 🎵 Songs API

Songs API é uma aplicação simples desenvolvida em **.NET Core** que permite gerenciar músicas. Com funcionalidades de **CRUD** (Create, Read, Update, Delete), a API possibilita o cadastro, visualização, edição e exclusão de músicas de forma eficiente.

---

## 🚀 Funcionalidades

- **Criar músicas**: Adicione novas músicas ao banco de dados.
- **Listar músicas**: Obtenha uma lista completa de músicas cadastradas.
- **Atualizar músicas**: Edite informações de uma música existente.
- **Deletar músicas**: Remova músicas do banco de dados com base no ID ou artista.

---

## 🛠️ Tecnologias Utilizadas

- **C#**: Linguagem principal utilizada no desenvolvimento.
- **.NET Core 6**: Framework utilizado para construir a API.
- **Entity Framework Core**: Para acesso e manipulação do banco de dados.
- **SQL Server**: Banco de dados utilizado.
- **Swagger**: Para documentação e teste das rotas da API.
- **LINQ**: Consultas dinâmicas para manipular dados.


---

## 📂 Estrutura do Projeto

```plaintext
songs-api/
├── Controllers/
│   └── SongsController.cs    # Gerencia as rotas e requisições da API
├── Models/
│   └── Song.cs               # Modelo de dados da música
├── Services/
│   └── SongService.cs        # Lógica de negócio da aplicação
├── Program.cs                # Configuração principal do projeto
├── appsettings.json          # Configurações de ambiente e banco de dados
├── SongsApi.sln              # Arquivo de solução do projeto

```

---

### 📖 Rotas Disponíveis

#### **GET**
- **`/buscar-todas-as-musicas`**  
  Retorna a lista de todas as músicas cadastradas.

- **`/buscar-musica-por-id?id={id}`**  
  Busca uma música específica pelo ID.

- **`/busca-musicas-album?album={album}`**  
  Busca músicas de um álbum específico.

- **`/busca-musicas-artista?artista={artista}`**  
  Retorna músicas de um artista específico.

- **`/busca-musicas-ano?ano={ano}`**  
  Busca músicas lançadas em um ano específico.

- **`/busca-musicas-genero?genero={genero}`**  
  Retorna músicas de um gênero específico.

#### **POST**
- **`/cadastrar-musica`**  
  Cadastra uma nova música.  

  **Exemplo de Body:**
  ```json
  {
    "id": 0,
    "nome": "Bohemian Rhapsody",
    "album": "A Night at the Opera",
    "artista": "Queen",
    "anoLancamento": "1975",
    "genero": "Rock"
  }

  

--- 



### 🌟 Destaques do Projeto
- Validações de Dados: Garante que as músicas cadastradas possuam informações completas e consistentes. 
- CRUD Completo: Funcionalidades robustas para manipular os dados de músicas.
- Rotas Granulares: Permite atualizações específicas (ex.: apenas o nome ou o artista). 
- Eficiência: Utilização do Entity Framework Core para operações otimizadas no banco  de dados.
- Integração com Swagger: Documentação interativa para facilitar o uso da API. 

---

## 👨‍💻 Autor  
### **André Azevedo**  

💼 [LinkedIn](https://www.linkedin.com/in/andre-victor-azevedo/)  
🛠️ [GitHub](https://github.com/andreeviictor1/)  

Dúvidas ou sugestões?  
Sinta-se à vontade para abrir uma issue ou entrar em contato comigo! 🚀  
