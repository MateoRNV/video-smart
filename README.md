# Video Smart API

Pequena API em .NET 8

## Requisitos
- SQLite ou DB Browser for SQLite (opcional para visualizar a base de dados)

## Como executar o projeto
1. **Clonar o repositório e preparar pacots do nuget**  
   ```sh
   git clone https://github.com/MateoRNV/video-smart.git
   cd video-smart
   dotnet restore
   ```
3. **Aplicar as migrações e criar a base de dados**  
   ```sh
   dotnet ef database update
   ```

4. **Executar a API e testar no swagger**  
   ```sh
   dotnet run
   http://localhost:5000/swagger
   ```

## Endpoints do desafio
- **Principais do desafio**
  - `GET /api/players/{id}` → Obter um platyer pelo ID  
  - `POST /api/events` → Criar um evento  

  **Extras para testes**
  - `POST /api/players` → Criar uma nova metrica  
  - `POST /api/sessions` → Criar uma sessão (necessária para os eventos)
  - `GET /api/players` → Obter todos os players  
  - `PUT /api/players/{id}` → Atualizar um player  
  - `DELETE /api/players/{id}` → Remover um player  
  - `GET /api/events/{id}` → Obter um evento pelo ID  
  - `GET /api/events` → Obter todos os eventos  
  - `PUT /api/events/{id}` → Atualizar um evento  
  - `DELETE /api/events/{id}` → Remover um evento  
  - `GET /api/sessions/{id}` → Obter uma sessão pelo ID  
  - `GET /api/sessions` → Obter todas as sessões  
  - `DELETE /api/sessions/{id}` → Remover uma sessão  

- **Events**


## Base de dados
- Gerada automaticamente em `videoSmart.db`
