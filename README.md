# Es.Logging

[![Build Status](https://travis-ci.org/EsWork/Es.Logging.svg?branch=master)](https://travis-ci.org/EsWork/Es.Logging)

`Es.Logging`抽象出.Net平台的日志通用接口，自身并没有日志处理实现，默认实现了NLog、Log4net、Microsoft.Extensions.Logging和console standard output支持。

通常日志的实例我们都在构造函数中创建

```cs
public class Foo{
    private readonly ILogger _logger;

    public Foo(){
       _logger = LoggerManager.GetLogger<Foo>();
    }
}
```
但是很多时候我们也许会在静态类使用，也许`Logger`静态实例在没有`LoggerProvider`时候可能会失效，`Es.Logging`现在已经支持。

```cs
public static class Foo{
    private static readonly ILogger _logger = LoggerManager.GetLogger<Foo>();
}
```


Features
---

- 聚合.NET平台常用日志类库
- 已有静态`Logger`实例支持后期追加的`LoggerProvider`
- 支持`Unix`&`Windows`控制台输出
- 支持`NLog`
- 支持`Log4net`
- 支持`Microsoft.Extensions.Logging`



Packages & Status
---

Package  | NuGet         |
-------- | :------------ |
|**Es.Logging**|[![NuGet package](https://buildstats.info/nuget/Es.Logging)](https://www.nuget.org/packages/Es.Logging)
|**Es.Logging.Console**|[![NuGet package](https://buildstats.info/nuget/Es.Logging.Console)](https://www.nuget.org/packages/Es.Logging.Console)
|**Es.Logging.NLog**|[![NuGNuGet packageet](https://buildstats.info/nuget/Es.Logging.NLog)](https://www.nuget.org/packages/Es.Logging.NLog)
|**Es.Logging.Log4**|[![NuGet package](https://buildstats.info/nuget/Es.Logging.Log4)](https://www.nuget.org/packages/Es.Logging.Log4)
|**Es.Microsoft.Logging**|[![NuGet package](https://buildstats.info/nuget/Es.Microsoft.Logging)](https://www.nuget.org/packages/Es.Microsoft.Logging)


Usage
---

 标准控制台输出

```cs
using Es.Logging;

public static class Foo{
    //static Logger instance
    private static readonly ILogger _logger = LoggerManager.GetLogger<Foo>();

     private static void Main(string[] args) {
         //add console output
         LoggerManager.Factory.AddConsole(LogLevel.Trace);
         //logger info
         _logger.Info("Es.Logging");
     }
}
```

 推荐使用`NLog`

```cs
using Es.Logging;

public static class Foo{
    //static Logger instance
    private static readonly ILogger _logger = LoggerManager.GetLogger<Foo>();

     private static void Main(string[] args) {
          //init NLog config
          LoggingConfiguration config = new LoggingConfiguration();
          ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget();
          config.AddTarget("console", consoleTarget);
          LoggingRule rule = new LoggingRule("*", NLog.LogLevel.Trace, consoleTarget);
          config.LoggingRules.Add(rule);

          LogFactory factory = new LogFactory(config);

          //add NLog Provider
          _logFactory.AddNLog(factory);

          //logger info
          _logger.Info("Es.Logging");
     }
}
```


更多请查看[Sample](https://github.com/EsWork/Es.Logging/tree/master/src/Sample)

## License
See [LICENSE](https://github.com/EsWork/Es.Logging/tree/master/LICENSE) for details.
