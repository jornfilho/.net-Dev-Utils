#.NET Dev Utils [![Build status](https://ci.appveyor.com/api/projects/status/ge146r8gotw9r0mb/branch/master)](https://ci.appveyor.com/project/jornfilho/net-dev-utils)#
---

###Nuget package:###

[https://www.nuget.org/packages/DevUtils/](https://www.nuget.org/packages/DevUtils/)

```sh
PM> Install-Package DevUtils
```

---

###Validators###
> **Email**
> 
> - public static bool IsEmailValid(this string email)
>
> **Url**
> 
> - public static bool IsUriValid(this string uri)

---

###Hash###
> **Base64**
> 
> - public static string ToBase64(this string data)
> - public static string FromBase64(this string data)
>
> **Md5**
> 
> - public static string ToMd5(this string data)
>
> **Sha256**
> 
> - public static string ToSha256(this string data)
>
> **GetRandom**
> 
> - public static string CreateRandonHash(int size)

---

###IO###
> **IoDirectoryUtils**
> 
> - public bool IsDirectory(string path)
> - public bool DirectoryExists(string path)
> - public bool CreateDirectory(string path)
> - public int GetCountOfSubdirectories(string path)
> - public bool CopyDirectory(string sourcePath, string targetPath)
> - public bool DeleteDirectoryContents(string path)
> - public bool DeleteDirectory(string path)
> - public IList<FileSystemRights> GetDirectoryPermission(string path)
> - public bool SetDirectoryPermission(string path, FileSystemRights permission)
> - public bool SetDirectoryPermissions(string path, FileSystemRights[] permissions)
> - public DirectoryInfo GetParentDirectory(string path)
>
> **IoFileUtils**
>
> - public bool FileExists(string path)
> - public string ReadFileAsString(string path)
> - public FileStream ReadFileAsStream(string path)
> - public bool CreateFile(string path, string contents)
> - public bool CreateReadOnlyFile(string path, string contents)
> - public TextWriter CreateFileTextWriter(string path)
> - public bool CopyFile(string sourcePath, string targetPath)
> - public int DeleteFiles(string path)
> - public bool DeleteFile(string path)
> - public bool IsFileReadOnly(string path)
> - public bool RemoveReadOnlyAttribute(string path)
> - public int GetCountOfFilesInDirectory(string path)
> - public int GetCountOfFilesInDirectoryAndSubdirectories(string path)

---

###Xml###
>
> **XmlUtils**
> 
> - public bool CreateDocument(string path, string fileName, string xml, string xsd, string ns)
> - public bool ValidateDocument(string xml, string xsd, string ns)
> - public string GetElement(string path, string element, XNamespace ns)
> - public bool UpdateElement(string path, string element, string value, XNamespace ns)
>
> **XmlExtensions**
> 
> - public static string ToXml(this object o)

---

###ProcessUtils###
> 
> - public bool ExecuteProcess(ProcessStartInfo processInfo, out string output, out string errors)

---

###ServiceUtils###
> 
> - public WindowsServiceState GetServiceState(string host, string serviceName)
> - public bool ChangeServiceState(string host,string serviceName,WindowsServiceAction action)

---

###EnumExtensions###
> 
> - public static T ToEnum<T>(this System.Enum enumeration)
> - public static T ToEnum<T>(this int value)
> - public static int FromEnumToInt(this System.Enum enumeration)
> - public static string FromEnumToString(this System.Enum enumeration)

---

###PrimitivesExtensions###
> **IsValid**
>
> - public static bool IsValidBool(this string strValue)
> - public static bool IsValidByte(this string strValue)
> - public static bool IsValidDecimal(this string strValue)
> - public static bool IsValidDouble(this string strValue)
> - public static bool IsValidFloat(this string strValue)
> - public static bool IsValidInt(this string strValue)
> - public static bool IsValidLong(this string strValue)
> - public static bool IsValidShort(this string strValue)
> 
> **StringExtensions**
>
> - public static string ToUnicode(this string text)
> - public static string ToUnicodeWithoutSpace(this string text)
> - public static string Left(this string text, int length)
> - public static string Right(this string text, int length)
>
> **BoolExtensions**
>
>> **From string to bool**
>>
>> - public static bool TryParseBool(this string strValue, bool defaultValue)
>> - public static bool TryParseBool(this string strValue)
>>
>> **From string to bool array**
>>
>> - public static bool[] TryParseBoolArray(this string strValue, bool[] defaultValue, bool allowDefaultConversion)
>> - public static bool[] TryParseBoolArray(this string strValue, bool[] defaultValue)
>> - public static bool[] TryParseBoolArray(this string strValue)
>
> **ByteExtensions**
>
>> **From string to byte**
>>
>> - public static byte TryParseByte(this string strValue, byte defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
>> - public static byte TryParseByte(this string strValue, byte defaultValue, NumberStyles numberStyle, CultureInfo culture)
>> - public static byte TryParseByte(this string strValue, NumberStyles numberStyle, CultureInfo culture)
>> - public static byte TryParseByte(this string strValue, byte defaultValue, bool allowZero)
>> - public static byte TryParseByte(this string strValue, byte defaultValue)
>> - public static byte TryParseByte(this string strValue)
>>
>> **From nullable byte to byte**
>>
>> - public static byte TryParseByte(this byte? byteValue, byte defaultValue)
>> - public static byte TryParseByte(this byte? byteValue)
>>
>> **From short and nullable short to byte**
>>
>> - public static byte TryParseByte(this short shortValue, byte defaultValue)
>> - public static byte TryParseByte(this short shortValue)
>> - public static byte TryParseByte(this short? shortValue, byte defaultValue)
>> - public static byte TryParseByte(this short? shortValue)
>>
>> **From int and nullable int to byte**
>>
>> - public static byte TryParseByte(this int intValue, byte defaultValue)
>> - public static byte TryParseByte(this int intValue)
>> - public static byte TryParseByte(this int? intValue, byte defaultValue)
>> - public static byte TryParseByte(this int? intValue)
>>
>> **From long and nullable long to byte**
>>
>> - public static byte TryParseByte(this long longValue, byte defaultValue)
>> - public static byte TryParseByte(this long longValue)
>> - public static byte TryParseByte(this long? longValue, byte defaultValue)
>> - public static byte TryParseByte(this long? longValue)
>>
>> **From decimal and nullable decimal to byte**
>>
>> - public static byte TryParseByte(this decimal decimalValue, byte defaultValue)
>> - public static byte TryParseByte(this decimal decimalValue)
>> - public static byte TryParseByte(this decimal? decimalValue, byte defaultValue)
>> - public static byte TryParseByte(this decimal? decimalValue)
>>
>> **From double and nullable double to byte**
>>
>> - public static byte TryParseByte(this double doubleValue, byte defaultValue)
>> - public static byte TryParseByte(this double doubleValue)
>> - public static byte TryParseByte(this double? doubleValue, byte defaultValue)
>> - public static byte TryParseByte(this double? doubleValue)
>>
>> **From float and nullable float to byte**
>>
>> - public static byte TryParseByte(this float floatValue, byte defaultValue)
>> - public static byte TryParseByte(this float floatValue)
>> - public static byte TryParseByte(this float? floatValue, byte defaultValue)
>> - public static byte TryParseByte(this float? floatValue)
>>
>> **From string to byte array**
>>
>> - public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
>> - public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
>> - public static byte[] TryParseByteArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
>> - public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, bool allowDefaultConversion)
>> - public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue)
>> - public static byte[] TryParseByteArray(this string strValue)
>>
>
> **DecimalExtensions**<br>
> *Same ByteExtensions methods*
> 
> - From string to decimal
> - From nullable decimal to decimal
> - From byte and nullable byte to decimal
> - From short and nullable short to decimal
> - From int and nullable int to decimal
> - From long and nullable long to decimal
> - From double and nullable double to decimal
> - From float and nullable float to decimal
> - From string to decimal array
>
> **DoubleExtensions**<br>
> *Same ByteExtensions methods*
> 
> - From string to double
> - From nullable double to double
> - From byte and nullable byte to double
> - From short and nullable short to double
> - From int and nullable int to double
> - From long and nullable long to double
> - From decimal and nullable decimal to double
> - From float and nullable float to double
> - From string to double array
>
> **FloatExtensions**<br>
> *Same ByteExtensions methods*
> 
> - From string to float
> - From nullable float to float
> - From byte and nullable byte to float
> - From short and nullable short to float
> - From int and nullable int to float
> - From long and nullable long to float
> - From double and nullable double to float
> - From decimal and nullable decimal to float
> - From string to float array
>
> **IntExtensions**<br>
> *Same ByteExtensions methods*
> 
> - From string to int
> - From nullable int to int
> - From byte and nullable byte to int
> - From short and nullable short to int
> - From decimal and nullable decimal to int
> - From long and nullable long to int
> - From double and nullable double to int
> - From float and nullable float to int
> - From string to int array
>
> **LongExtensions**<br>
> *Same ByteExtensions methods*
> 
> - From string to long
> - From nullable long to long
> - From byte and nullable byte to long
> - From short and nullable short to long
> - From int and nullable int to long
> - From decimal and nullable decimal to long
> - From double and nullable double to long
> - From float and nullable float to long
> - From string to long array
>
> **ShortExtensions**<br>
> *Same ByteExtensions methods*
> 
> - From string to short
> - From nullable short to short
> - From byte and nullable byte to short
> - From decimal and nullable decimal to short
> - From int and nullable int to short
> - From long and nullable long to short
> - From double and nullable double to short
> - From float and nullable float to short
> - From string to short array
>

---

###DateTimeExtensions###
>
> **Offset**
>
> - public static int GetDateTimeOffsetMinutes(this DateTime date, TimeZoneInfo timezoneInfo)
> - public static int GetDateTimeOffsetMinutes(this DateTime date, string timezoneName)
> - public static int GetDateTimeOffsetMinutes(this DateTime date)
>
> **Utils**
>
>> **Business days**
>>
>> - public static DateTime AddBusinessDays(this DateTime date, int days, DayOfWeek[] businessDays)
>> - public static DateTime AddBusinessDays(this DateTime date, int days)
>> - public static DateTime RemoveBusinessDays(this DateTime date, int days, DayOfWeek[] businessDays)
>> - public static DateTime RemoveBusinessDays(this DateTime date, int days)
>>
>> **Set date**
>>
>> - public static DateTime SetDate(this DateTime date, int year, int month, int day)
>> - public static DateTime SetYear(this DateTime date, int year)
>> - public static DateTime SetMonth(this DateTime date, int month)
>> - public static DateTime SetDay(this DateTime date, int day)
>>
>> **Set time**
>>
>> - public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
>> - public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
>> - public static DateTime SetTime(this DateTime date, int hour, int minute)
>> - public static DateTime SetHour(this DateTime date, int hour)
>> - public static DateTime SetMinute(this DateTime date, int minute)
>> - public static DateTime SetSecond(this DateTime date, int second)
>> - public static DateTime SetMillisecond(this DateTime date, int millisecond)
>>
>> **Start of year**
>>
>> - public static DateTime StartOfYear(this DateTime date)
>> - public static DateTime StartOfYear(int year)
>> - public static DateTime StartOfBusinessYear(this DateTime date, DayOfWeek[] businessDays)
>> - public static DateTime StartOfBusinessYear(this DateTime date)
>> - public static DateTime StartOfBusinessYear(int year, DayOfWeek[] businessDays)
>> - public static DateTime StartOfBusinessYear(int year)
>>
>> **End of year**
>>
>> - public static DateTime EndOfYear(this DateTime date)
>> - public static DateTime EndOfYear(int year)
>> - public static DateTime EndOfBusinessYear(this DateTime date, DayOfWeek[] businessDays)
>> - public static DateTime EndOfBusinessYear(this DateTime date)
>> - public static DateTime EndOfBusinessYear(int year, DayOfWeek[] businessDays)
>> - public static DateTime EndOfBusinessYear(int year)
>>
>> **Start of month**
>>
>> - public static DateTime StartOfMonth(this DateTime date)
>> - public static DateTime StartOfMonth(Month month, int year)
>> - public static DateTime StartOfBusinessMonth(this DateTime date, DayOfWeek[] businessDays)
>> - public static DateTime StartOfBusinessMonth(this DateTime date)
>> - public static DateTime StartOfBusinessMonth(Month month, int year, DayOfWeek[] businessDays)
>> - public static DateTime StartOfBusinessMonth(Month month, int year)
>>
>> **End of month**
>>
>> - public static DateTime EndOfMonth(this DateTime date)
>> - public static DateTime EndOfMonth(Month month, int year)
>> - public static DateTime EndOfBusinessMonth(this DateTime date, DayOfWeek[] businessDays)
>> - public static DateTime EndOfBusinessMonth(this DateTime date)
>> - public static DateTime EndOfBusinessMonth(Month month, int year, DayOfWeek[] businessDays)
>> - public static DateTime EndOfBusinessMonth(Month month, int year)
>>
>> **Start of week**
>>
>> - public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDay)
>> - public static DateTime StartOfWeek(this DateTime date)
>> - public static DateTime StartOfBusinessWeek(this DateTime date, DayOfWeek firstBusinessDay)
>> - public static DateTime StartOfBusinessWeek(this DateTime date)
>>
>> **End of week**
>>
>> - public static DateTime EndOfWeek(this DateTime date, DayOfWeek lastDay)
>> - public static DateTime EndOfWeek(this DateTime date)
>> - public static DateTime EndOfBusinessWeek(this DateTime date, DayOfWeek lastBusinessDay)
>> - public static DateTime EndOfBusinessWeek(this DateTime date)
>>
>> **Start of day**
>>
>> - public static DateTime StartOfDay(this DateTime date)
>>
>> **End of day**
>>
>> - public static DateTime EndOfDay(this DateTime date)
>>
>
> **DateExtensions**
> 
>> **ToUtc**
>> 
>> - public static DateTime ToUtc(this DateTime date, TimeZoneInfo timezoneInfo)
>> - public static DateTime ToUtc(this DateTime date, string timezoneName)
>> - public static DateTime ToUtc(this DateTime date)
>>
>> **ToTimezoneDate**
>> 
>> - public static DateTime ToTimezoneDate(this DateTime date, TimeZoneInfo currentTimeZoneInfo, TimeZoneInfo destinationTimeZoneInfo)
>> - public static DateTime ToTimezoneDate(this DateTime date, string currentTimeZoneName, TimeZoneInfo destinationTimeZoneInfo)
>> - public static DateTime ToTimezoneDate(this DateTime date, TimeZoneInfo currentTimezoneInfo, string destinationTimeZoneName)
>> - public static DateTime ToTimezoneDate(this DateTime date, string currentTimeZoneName, string destinationTimeZoneName)
>> - public static DateTime ToTimezoneDate(this DateTime date, TimeZoneInfo destinationTimeZoneInfo)
>> - public static DateTime ToTimezoneDate(this DateTime date, string destinationTimeZoneName)
>>
>> **TryParseDate**
>>
>> - public static DateTime TryParseDate(this string strValue, DateTime defaultValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
>> - public static DateTime TryParseDate(this string strValue, CultureInfo culture, DateTimeStyles dateTimeStyle)
>> - public static DateTime TryParseDate(this string strValue, DateTime defaultValue)
>> - public static DateTime TryParseDate(this string strValue)
>> - public static DateTime TryParseDate(this DateTime? nullableDate, DateTime defaultValue)
>> - public static DateTime TryParseDate(this DateTime? nullableDate)
>>
>> **ToUnixTimestamp**
>>
>> - public static long ToUnixTimestamp(this DateTime date, TimeZoneInfo timezoneInfo)
>> - public static long ToUnixTimestamp(this DateTime date, string timezoneName)
>> - public static long ToUnixTimestamp(this DateTime date)
>>
>> **FromUnixTimestamp**
>>
>> - public static DateTime FromUnixTimestamp(this long unixTimestap, TimeZoneInfo timezoneInfo)
>> - public static DateTime FromUnixTimestamp(this long unixTimestap, string timezoneName)
>> - public static DateTime FromUnixTimestamp(this long unixTimestap)
>>


---

###And much more...###


<!-- http://dillinger.io/ -->