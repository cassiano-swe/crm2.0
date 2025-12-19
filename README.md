# PomIO CRM

PomIO CRM is a lightweight CRM built on ASP.NET Core minimal APIs to centralize contact and organization data.

## Stack
- .NET 9 with minimal APIs
- Entity Framework Core using an in-memory database (for development)
- FluentValidation (CPF, CNPJ, email)
- Swagger/OpenAPI for exploring the routes
- Prettier + C# plugin (optional) for formatting

## How to run
1. Prerequisite: .NET 9 SDK installed (Node + npm optional if you want to run Prettier).
2. Restore dependencies: `dotnet restore src/Crm.Api/src.csproj`
3. Start the API: `dotnet run --project src/Crm.Api/src.csproj`
4. Swagger is available at `/swagger` and health check at `/health`. The in-memory database resets on every run.

## Key routes
- Contacts: `POST /api/contacts`, `GET /api/contacts/{id}`, `PUT /api/contacts`, `DELETE /api/contacts?id={id}`
- Organizations: `POST /api/organizations`, `GET /api/organizations/{id}`, `PUT /api/organizations`, `DELETE /api/organizations?id={id}`

## Domain (draft)
- Contact: person with identification (CPF), contact details, and optional lead origin/category.
- Organization: company with identification (CNPJ/legal name), contacts, website, and address.
- Category, LeadOrigin, Sector: simple reference tables used by contacts/organizations.

## Suggested next steps
- Move to a relational database (e.g., SQL Server or PostgreSQL) with EF Core migrations.
- Seed data for reference tables.
- Basic authentication/authorization to protect routes.
- Integration tests covering routes and validations.
