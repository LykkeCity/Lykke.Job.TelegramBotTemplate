# Lykke.Job.TelegramBotTemplate

## How install and use template?

Clone repo to some directory

Install template:
```sh
$ dotnet new --install ${path}
```
where `${path}` is the **full** path to the clonned directory (where folder .template.config placed) **without trailing slash**

Now new template can be used in dotnet cli:

```sh
dotnet new lketgbot -n ${BotName} -o Lykke.Job.${BotName} 
```
This will create a solution in the current folder, where `${JobName}` is the job name without Lykke.Job. prefix. 
Switches:
* **-n|--name**: BotName
* **-o|--output**: Output directory name

When temlate has changed, to update installed template run again command:

```sh
$ dotnet new --install ${path}
```

To remove all installed custom temlates run command:

```sh
$ dotnet new --debug:reinit ++
```

## Developing notes

### Environment variables

To define your own environment variables, see [Working with multiple environments](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments)

* *ASPNETCORE_ENVIRONMENT* - defines environment name, the value can be: Development, Staging, Production.
* *SettingsUrl* - defines URL of remote settings or path for local settings.

Reflect your settings structure in appsettings.json - leave all of field blank, or just show value's format. Fill appsettings.XXX.json with real settings data. Ensure that appsettings.XXX.json is ignored in git.

Default launchSettings.json is:

```json
{
  "profiles": {
    "LykkeJob local dev settings": {
      "commandName": "Project",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "SettingsUrl": "appsettings.Development.json"
      }
    },
    "LykkeJob local test settings": {
      "commandName": "Project",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Staging",
        "SettingsUrl": "appsettings.Testing.json"
      }
    },
    "LykkeJob remote settings": {
      "commandName": "Project",
      "environmentVariables": {
        "SettingsUrl": "http://settings.lykke-settings.svc.cluster.local/your_token_LykkeJobJob"
      }
    }
  }
}
```

### Telegram bot 

1) First, talk to [BotFather](https://t.me/botfather) on Telegram to get an API token.
2) Then, place your token in settings.json in project folder under field "BotToken".

Default settings.json is:
```json
{
  //"SecTokenPassword": "TestPwd",
  //"Db": "DbConnStr",
  "Telegram": {
    "Db": {
      "LogsConnString": "UseDevelopmentStorage=true"
    },

	  "BotToken": "",
  },  
   
  "SlackNotifications": {
    "AzureQueue": {
      "ConnectionString": "UseDevelopmentStorage=true",
      "QueueName": "slack-notifications"
    },
    "ThrottlingLimitSeconds": 60
  }
}
```

In settings.json you can add your own variables as well.

In TelegramBot/TelegramBotService.cs file located basic examples of handling commands, loading files, getting user data and custom inline and regular keyboards.


