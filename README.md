# C# Logger Library for .NET | File and Database Logging Made Easy

![C# Logger Library](https://github.com/ivke013/C-Sharp-Logger-Package/raw/main/logo.png)

A lightweight and extensible C# Logger Library designed for .NET applications. This library supports file and database logging for SQL Server and MySQL out of the box and can be easily extended to support other database systems. Perfect for developers who need a flexible, reliable, and scalable logging solution.

## Features

- **File Logging**: Log messages to text files for easy debugging.
- **Database Logging**: Store logs in SQL Server and MySQL databases.
- **Extensibility**: Add custom log providers to support other storage mechanisms.
- **Multiple Log Levels**: Debug, Info, Warn, Error, Fatal.
- **Dependency Injection (DI) Ready**: Integrates seamlessly with DI containers in .NET applications.

## Installation

To use this library in your .NET project, you can clone the repository or add the source files directly to your project. 

```bash
# Clone the repository
git clone https://github.com/ivke013/C-Sharp-Logger-Package.git
```

## Usage

### Basic Usage Without Dependency Injection

1. Add the library source code to your project.
2. Initialize the `FileLogger` class:

```csharp
using VFM.Core.Logger;

class Program
{
    static void Main()
    {
        ILogger logger = new FileLogger("logs/app.log");

        logger.Debug("Debug message");
        logger.Info("Info message");
        logger.Warn("Warning message");
        logger.Error("Error message");
        logger.Fatal("Fatal message");
    }
}
```

### Advanced Usage With Dependency Injection (DI)

1. Register the logger in your DI container:

```csharp
using Microsoft.Extensions.DependencyInjection;
using VFM.Core.Logger;

var services = new ServiceCollection();
services.AddSingleton<ILogger, FileLogger>(provider => new FileLogger("logs/app.log"));

var serviceProvider = services.BuildServiceProvider();

// Resolve the logger
var logger = serviceProvider.GetRequiredService<ILogger>();
logger.Info("Logger initialized with DI");
```

2. Use the logger in your application:

```csharp
public class MyService
{
    private readonly ILogger _logger;

    public MyService(ILogger logger)
    {
        _logger = logger;
    }

    public void DoWork()
    {
        _logger.Info("Work started.");
        // Your logic here
        _logger.Info("Work completed.");
    }
}
```

### Configuring Database Logging

1. Add the desired database provider (`SqlServerLogProvider` or `MySqlLogProvider`):

```csharp
using VFM.Core.Logger;

class Program
{
    static void Main()
    {
        var sqlLogger = new SqlServerLogProvider("Server=myServer;Database=myDB;User Id=myUser;Password=myPassword;");
        sqlLogger.InsertLog(DateTime.UtcNow, "Info", "This is a test log", null);

        var mySqlLogger = new MySqlLogProvider("Server=myServer;Database=myDB;User=myUser;Password=myPassword;");
        mySqlLogger.InsertLog(DateTime.UtcNow, "Error", "This is another test log", "Test exception");
    }
}
```

2. Integrate with the main `ILogger` implementation:

Extend `FileLogger` or create a new logger that combines file and database logging.

### Adding a Custom Log Provider

1. Create a new class that implements `IDatabaseLogProvider`:

```csharp
public class CustomLogProvider : IDatabaseLogProvider
{
    public void InsertLog(DateTime timestamp, string level, string message, string exception)
    {
        // Custom logic here
    }
}
```

2. Register it in your DI container:

```csharp
services.AddSingleton<IDatabaseLogProvider, CustomLogProvider>();
```

3. Use it in your logger:

```csharp
public class CompositeLogger : ILogger
{
    private readonly ILogger _fileLogger;
    private readonly IDatabaseLogProvider _dbLogger;

    public CompositeLogger(ILogger fileLogger, IDatabaseLogProvider dbLogger)
    {
        _fileLogger = fileLogger;
        _dbLogger = dbLogger;
    }

    public void Log(LogLevel level, string message)
    {
        _fileLogger.Log(level, message);
        _dbLogger.InsertLog(DateTime.UtcNow, level.ToString(), message, null);
    }

    // Implement other ILogger methods similarly
}
```

## Extensibility

- Add new database providers by implementing the `IDatabaseLogProvider` interface.
- Create a composite logger to log to multiple destinations simultaneously.
- Customize log formats by modifying the `WriteToFile` method in `FileLogger`.

## Contributing

We welcome contributions! Feel free to fork the repository and submit pull requests with improvements or new features.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## About the Author

- **Author**: Ivan Stojmenovic
- **Email**: [office.stojmenovic@gmail.com](mailto:office.stojmenovic@gmail.com)

---

With this library, logging in .NET applications has never been easier. Start integrating reliable and flexible logging into your projects today!
