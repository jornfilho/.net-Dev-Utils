# Release notes #
---

## Version 1.0.3 ##

#### Enum extensions ####
- Convert Enum to ```IList<T>``` with static method ```.FromEnum()```

----------

#### Web.config / App.config extensions ####
Static method to manipulate some sections from app.config or web.config file

######```<appSettings>```######

- Get item value using method ```string GetFromAppSettings(string paramName)```
- Modify item value using method ```bool SetToAppSettings(string paramName, string paramValue)```
- Create item using method ```bool SetToAppSettings(string paramName, string paramValue)```
- Delete item using method ```bool DeleteFromAppSettings(string paramName)```

######```<connectionStrings>```######

- Get item value using method ```string GetFromConnectionString(string paramName, ConnectionStringInformationType informationType)```
- Modify item value using method ```bool SetToConnectionString(string paramName, ConnectionStringInformationType informationType, string paramValue)```
 

######```<system.web>```######

Get sections using method ```T GetFromSystemWeb<T>(SystemWebSections section) where T : class```

- Get section ```AuthenticationSection```
- Get section ```CompilationSection```
- Get section ```CustomErrorsSection```
- Get section ```GlobalizationSection```
- Get section ```HttpRuntimeSection```
- Get section ```IdentitySection```
- Get section ```TraceSection```

----------

<!-- 
Keywords:
c# .net asp.net utils converter parse 
hash validate 
date datetime unix offset timezone timezoneinfo timezonename 
long int float double string short byte 
sha256 base64 md5 
email random url uri unicode 
IO directory file 
xml 
proccess 
service services 
enum
webconfig web.config appconfig app.config
-->