
## Technologies

- **ASP.NET Core**: Web framework for building APIs.
- **Entity Framework Core**: ORM for database access.
- **JWT**: JSON Web Tokens for authentication.

## Installation

1. **Clone the repository**

    ```bash
    git clone https://github.com/havranekj/VSATicket.git
    cd VSATicket
    ```

2. **Configure the database**

    Update `appsettings.json` with your database connection settings.

3. **Apply migrations**

    ```bash
    dotnet ef database update
    ```

4. **Run the application**

    ```bash
    dotnet run
    ```

## Endpoints

### Authentication

- **POST /api/auth/register**: Register a new user.
- **POST /api/auth/login**: Log in a user and get a JWT token.

### Tickets

- **GET /api/tickets/{id}**: Get a ticket by ID (for `user` and `admin` roles).
- **POST /api/tickets**: Create a new ticket (for `user` role only).
- **PATCH /api/tickets/{id}/status**: Change the status of a ticket (for `admin` role only).
- **PATCH /api/tickets/{id}/resolve**: Resolve a ticket (for `admin` role only).
- **DELETE /api/tickets/{id}**: Delete a ticket (for `user` role only).

### Ticket Search

- **GET /api/tickets/status/{status}**: Search tickets by status (for `admin` roles).
- **GET /api/tickets/creator/{createdBy}**: Search tickets by creator (for `user` roles).




