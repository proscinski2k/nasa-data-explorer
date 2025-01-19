# NASA Data Explorer

## About The Project
> NASA Data Explorer enables users to explore NASA's extensive data through their API. The solution consists of a Web API layer and a Windows Forms user interface.

## Authors
> * Adrian Prościński
> * Yevhenii Soliuk

## Getting Started

### Prerequisites
> * Visual Studio 2022 or higher

### Configuration
> 1. Clone the repository
>    ```sh
>    git clone https://github.com/proscinski2k/nasa-data-explorer.git
>    ```
>
> 2. Configure your `appsettings.json`:
>    ```json
>    {
>      "NasaApi": {
>        "Key": "YOUR_API_KEY_HERE"
>      },
>      "ClientToken": "YOUR_CLIENT_TOKEN"
>    }
>    ```
>
> **Note**: Get your NASA API key at [https://api.nasa.gov/](https://api.nasa.gov/)

### API Authorization
> The Web API is secured with a token-based authentication system. To use the Swagger UI:
>
> 1. Navigate to [https://localhost:7015/swagger/index.html](https://localhost:7015/swagger/index.html)
> 2. Click the `Authorize` button in the top-right corner
> 3. Enter your `ClientToken` from `appsettings.json`
> 4. Click `Authorize`
> 5. You can now test the endpoints

## Project Structure
> - `web-api/` - .NET Web API project
> - `win-forms/` - Windows Forms client application

## Security Note
> Never commit your `appsettings.json` or `appsettings.Development.json` files containing sensitive data. These files are included in `.gitignore`.
