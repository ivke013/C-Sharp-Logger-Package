# C# Logger Library for .NET | File and Database Logging Made Easy

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## Overview

The **C# Logger Library** is a highly customizable and extensible logging framework for .NET applications. It provides robust solutions for logging to **files**, **SQL Server**, **MySQL**, and more. This library is ideal for developers seeking a reliable logging solution in desktop or web applications.

---

## Features

- 🔥 **File Logging**: Easily log messages to files with detailed formatting.
- 🛠️ **Database Logging**: Log messages to SQL Server or MySQL databases.
- 🎯 **Customizable Levels**: Supports `Debug`, `Info`, `Warn`, `Error`, and `Fatal` levels.
- ⚙️ **Extensibility**: Implement custom log providers for additional storage solutions.
- 🌐 **Multi-Platform**: Compatible with .NET 6+, .NET Core 3.1, and .NET Framework 4.8+.
- 📈 **Performance**: Lightweight and optimized for high-performance applications.

---

## Table of Contents

1. [Installation](#installation)
2. [Usage](#usage)
3. [Logging Levels](#logging-levels)
4. [Configuration Examples](#configuration-examples)
    - File Logger
    - SQL Server Logger
    - MySQL Logger
5. [Extending the Logger](#extending-the-logger)
6. [License](#license)

---

## Installation

To include this library in your project, follow these steps:

1. Clone or download this repository:
   ```bash
   git clone https://github.com/ivke013/C-Sharp-Logger-Package.git
   ```

2. Add the **Logger** project to your solution:
   - Open your `.sln` file in Visual Studio.
   - Right-click on the solution and select **Add > Existing Project**.
   - Navigate to the `Logger` folder and select `Logger.csproj`.

3. Add a reference to the `Logger` project in your main application.

---

## Usage

### File Logger Example

To use the `FileLogger` in your application:

1. Register the `FileLogger` using Dependency Injection (DI):
   ```csharp
   services.AddSingleton<ILogger, FileLogger>(provider =>
   {
       string logPath = "C:\\Logs\\application.log";
       return new FileLogger(logPath);
   });
   ```

2. Inject the `ILogger` into your class:
   ```csharp
   public class MyApp
   {
       private readonly ILogger _logger;

       public MyApp(ILogger logger)
       {
           _logger = logger;
       }

       public void Run()
       {
           _logger.Info("Application started successfully.");
           _logger.Warn("This is a warning message.");
           _logger.Error("An error occurred.");
       }
   }
   ```

---

## Logging Levels

| **Level**   | **Description**                                   |
|-------------|---------------------------------------------------|
| `Debug`     | Detailed information for troubleshooting.         |
| `Info`      | General application events or information.        |
| `Warn`      | Non-critical issues or potential problems.        |
| `Error`     | Recoverable application errors.                   |
| `Fatal`     | Critical errors requiring immediate attention.    |

---

## Configuration Examples

### File Logger

```csharp
ILogger logger = new FileLogger("C:\\Logs\\app.log");
logger.Info("This is a file log message.");
```

### SQL Server Logger

```csharp
IDatabaseLogProvider sqlLogProvider = new SqlServerLogProvider("your-sql-connection-string");
sqlLogProvider.InsertLog(DateTime.Now, "Info", "This is a log message", null);
```

### MySQL Logger

```csharp
IDatabaseLogProvider mySqlLogProvider = new MySqlLogProvider("your-mysql-connection-string");
mySqlLogProvider.InsertLog(DateTime.Now, "Error", "An error occurred", "Exception details here");
```

---

## Extending the Logger

You can add custom log providers by implementing the `IDatabaseLogProvider` interface:

```csharp
public class CustomLogProvider : IDatabaseLogProvider
{
    public void InsertLog(DateTime timestamp, string level, string message, string exception)
    {
        // Implement custom logic here
    }
}
```

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contributing

We welcome contributions! Please submit pull requests or issues to improve the library.

---

## Author

**Ivan Stojmenovic**  
📧 [office.stojmenovic@gmail.com](mailto:office.stojmenovic@gmail.com)  
🌍 [GitHub Profile](https://github.com/ivke013)

