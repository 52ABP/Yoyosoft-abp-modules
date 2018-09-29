# 使用方法

### 安装
**Package Manager**
```
Install-Package YoYo.Castle.Log4Net -Version 3.7.2
```
**.NET CLI**
```
dotnet add package YoYo.Castle.Log4Net --version 3.7.2
```
**Paket CLI**
```
paket add YoYo.Castle.Log4Net --version 3.7.2
```

### 代码配置
将 ABP 项目中的 
* 在 StartUp 引用命名空间 **using YoYo.Castle.Logging.Log4Net;**
* 将 StartUp 中 **ConfigureServices** 方法中的 **UseAbpLog4Net** 替换为 **UseYoYoLog4Net**


### log4net.config 基本配置

*更多配置请查看log4net官网: [log4net官方网站](http://logging.apache.org/log4net/release/manual/configuration.html)*

*除写入数据与官方有略有差异,其余都与官方相同*

```xml

<?xml version="1.0" encoding="utf-8" ?>
<log4net>

  <!-- 文件 log4net.Appender.RollingFileAppender -->
  <appender name="L_RollingFileAppender" type="log4net.Appender.RollingFileAppender" >
    <file value="App_Data/Logs/Logs.txt" />
    <appendToFile value="true" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="10" />
    <maximumFileSize value="10000KB" />
    <staticLogFileName value="true" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%-5level %date [%-5.5thread] %-40.40logger - %message%newline" />
    </layout>
    <!--过滤等级-->
    <filter type="log4net.Filter.LevelRangeFilter">
      <levelMin value="DEBUG" />
      <levelMax value="FATAL" />
    </filter>
  </appender>

  <!-- 
	数据库脚本,必须先创建这个表：
      SqlServer Script
  
      CREATE TABLE [dbo].[Logs] (
         [Id] [int] IDENTITY (1, 1) NOT NULL,
         [Date] [datetime] NOT NULL,
         [Thread] [varchar] (255) NOT NULL,
         [Level] [varchar] (50) NOT NULL,
         [Logger] [varchar] (255) NOT NULL,
         [Message] [varchar] (4000) NOT NULL,
         [Exception] [varchar] (2000) NULL
       )
  
  -->

  <!-- 数据库 log4net.Appender.AdoNetAppender -->
  <appender name="L_AdoNetAppender" type="log4net.Appender.AdoNetAppender">
    <!--  -->
    <bufferSize value="0" />
    <!-- 连接类型：
		sqlserver,
		pgsql,
		sqlite,
		mysql 
	-->
    <connectionType value="sqlserver" />
    <!-- 连接字符串 -->
    <connectionString value="这里是你的数据库连接字符串" />
    <!-- 插入命令 -->
    <commandText value="INSERT INTO Logs ([Date],[Thread],[Level],[Logger],[Message],[Exception]) VALUES (@log_date, @thread, @log_level, @logger, @message, @exception)" />
    <!-- 过滤等级 -->
    <filter type="log4net.Filter.LevelRangeFilter">
      <levelMin value="ERROR" />
      <levelMax value="FATAL" />
    </filter>

    <parameter>
      <parameterName value="@log_date" />
      <dbType value="DateTime" />
      <layout type="log4net.Layout.RawTimeStampLayout" />
    </parameter>
    <parameter>
      <parameterName value="@thread" />
      <dbType value="String" />
      <size value="255" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%thread" />
      </layout>
    </parameter>
    <parameter>
      <parameterName value="@log_level" />
      <dbType value="String" />
      <size value="50" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%level" />
      </layout>
    </parameter>
    <parameter>
      <parameterName value="@logger" />
      <dbType value="String" />
      <size value="255" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%logger" />
      </layout>
    </parameter>
    <parameter>
      <parameterName value="@message" />
      <dbType value="String" />
      <size value="4000" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%message" />
      </layout>
    </parameter>
    <parameter>
      <parameterName value="@exception" />
      <dbType value="String" />
      <size value="2000" />
      <layout type="log4net.Layout.ExceptionLayout" />
    </parameter>
  </appender>


  <root>
    <level value="ALL"/>
    <!--
    <level value="DEBUG"/>
    <level value="INFO"/>
    <level value="WARN"/>
    <level value="ERROR"/>
    <level value="FINE"/>
   -->
    <appender-ref ref="L_RollingFileAppender" />
    <!--<appender-ref ref="L_AdoNetAppender" />-->
  </root>

</log4net>



```