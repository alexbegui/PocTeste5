# Proposta de Reestruturação Arquitetural

## Análise da Estrutura Atual

Atualmente, o projeto apresenta algumas inconsistências arquiteturais que podem dificultar a manutenção e escalabilidade do código:

1. **Duplicação de Responsabilidades**: Existem interfaces de repositório no projeto `Gestao.Domain` e implementações concretas no projeto `Inventory.DataBase`, mas com nomenclaturas inconsistentes.

2. **Nomenclatura Inconsistente**: Alguns projetos usam o prefixo "Gestao" enquanto outros usam "Inventory" ou "CensusFieldSurvey".

3. **Ausência de Camada de Aplicação**: Não existe uma camada clara que separe a lógica de negócio da infraestrutura.

4. **Acoplamento entre Camadas**: O projeto cliente (`Gestao.Client`) referencia diretamente tanto o domínio quanto a implementação de banco de dados.

## Proposta de Nova Estrutura

Seguindo os princípios da Clean Architecture e mantendo a separação de responsabilidades, proponho a seguinte estrutura:

### 1. Gestao.Domain

Manter este projeto como o núcleo da aplicação, contendo:
- Entidades de domínio (Account, Category, Document, etc.)
- Interfaces de repositório (IRepository<T>, IAccountRepository, etc.)
- Interfaces de serviço de domínio
- Enums e constantes de domínio

**Mudanças**:
- Remover qualquer dependência de infraestrutura
- Manter apenas interfaces e modelos

### 2. Gestao.Application

Criar este novo projeto para conter:
- Serviços de aplicação que implementam a lógica de negócio
- DTOs (Data Transfer Objects) para comunicação entre camadas
- Mapeamentos entre entidades e DTOs
- Validações de regras de negócio

### 3. Gestao.Infrastructure

Renomear o projeto `Inventory.DataBase` para `Gestao.Gestao.Infraestrutura` e organizar:
- Implementações concretas de repositórios
- Configuração do contexto de banco de dados
- Migrações
- Interceptores e configurações de EF Core

### 4. Gestao.Infrastructure.Migration

Renomear `Inventory.DataBase.Migration` para `Gestao.Infrastructure.Migration`.

### 5. Gestao.API

Criar este projeto para:
- Endpoints da API
- Configuração de autenticação e autorização
- Injeção de dependências

### 6. Gestao.Client

Manter este projeto, mas:
- Remover referências diretas à infraestrutura
- Comunicar apenas com a API
- Implementar serviços de cliente que consomem a API

## Implementação de Padrões

### Padrão Repository

1. **Interface Genérica no Domínio**:
```csharp
public interface IRepository<T> where T : class
{
    Task<T?> GetById(int id);
    Task<List<T>> GetAll();
    Task Add(T obj);
    Task Update(T obj);
    Task Remove(int id);
    Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression);
}
```

2. **Interfaces Específicas no Domínio**:
```csharp
public interface ICategoryRepository : IRepository<Category>
{
    Task<List<Category>> GetByCompany(int companyId);
    Task<PaginatedList<Category>> GetPaginated(int companyId, int pageIndex, int pageSize);
}
```

3. **Implementação na Infraestrutura**:
```csharp
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    // Implementação específica
}
```

### Padrão Unit of Work

Implementar o padrão Unit of Work para gerenciar transações:

```csharp
public interface IUnitOfWork
{
    IAccountRepository Accounts { get; }
    ICategoryRepository Categories { get; }
    ICompanyRepository Companies { get; }
    IDocumentRepository Documents { get; }
    IFinancialTransactionRepository FinancialTransactions { get; }
    
    Task<int> SaveChangesAsync();
}
```

### Padrão Service

Criar serviços na camada de aplicação:

```csharp
public interface ICategoryService
{
    Task<CategoryDto> GetById(int id);
    Task<List<CategoryDto>> GetByCompany(int companyId);
    Task<PaginatedList<CategoryDto>> GetPaginated(int companyId, int pageIndex, int pageSize);
    Task Create(CategoryDto category);
    Task Update(CategoryDto category);
    Task Delete(int id);
}

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    // Implementação
}
```

## Benefícios da Nova Estrutura

1. **Separação Clara de Responsabilidades**: Cada camada tem um propósito bem definido.
2. **Testabilidade**: Interfaces bem definidas facilitam a criação de testes unitários.
3. **Manutenibilidade**: Código mais organizado e previsível.
4. **Escalabilidade**: Facilita a adição de novos recursos.
5. **Consistência**: Nomenclatura padronizada em todo o projeto.

## Passos para Implementação

1. Criar os novos projetos (Gestao.Application, Gestao.API)
2. Renomear projetos existentes para manter consistência
3. Reorganizar código entre as camadas
4. Atualizar referências entre projetos
5. Implementar padrões adicionais (Unit of Work, Services)
6. Atualizar a injeção de dependências

Esta proposta visa simplificar a estrutura do projeto, tornando-a mais intuitiva e alinhada com as melhores práticas de desenvolvimento de software moderno.