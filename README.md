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
>> public static bool IsEmailValid(this string email)
>
> **Url**
>> public static bool IsUriValid(this string uri)

---

###Hash###
> **Base64**
>> public static string ToBase64(this string data)
>
>> public static string FromBase64(this string data)
>
> **Md5**
>> public static string ToMd5(this string data)
>
> **Sha256**
>> public static string ToSha256(this string data)
>
> **GetRandom**
>> public static string CreateRandonHash(int size)

---

###PrimitivesExtensions###
> **BoolExtensions**
>
>> **From string to bool**
>>
>>> public static bool TryParseBool(this string strValue, bool defaultValue)
>>
>>> public static bool TryParseBool(this string strValue)
>>
>> **From string to bool array**
>>
>>> public static bool[] TryParseBoolArray(this string strValue, bool[] defaultValue, bool allowDefaultConversion)
>>
>>> public static bool[] TryParseBoolArray(this string strValue, bool[] defaultValue)
>>
>>> public static bool[] TryParseBoolArray(this string strValue)
>
> **ByteExtensions**
>
>> **From string to byte**
>>
>>> public static byte TryParseByte(this string strValue, byte defaultValue, bool allowZero, NumberStyles numberStyle, CultureInfo culture)
>>
>>> public static byte TryParseByte(this string strValue, byte defaultValue, NumberStyles numberStyle, CultureInfo culture)
>>
>>> public static byte TryParseByte(this string strValue, NumberStyles numberStyle, CultureInfo culture)
>>
>>> public static byte TryParseByte(this string strValue, byte defaultValue, bool allowZero)
>>
>>> public static byte TryParseByte(this string strValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this string strValue)
>>
>> **From nullable byte to byte**
>>
>>> public static byte TryParseByte(this byte? byteValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this byte? byteValue)
>>
>> **From short to byte**
>>
>>> public static byte TryParseByte(this short shortValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this short shortValue)
>>
>> **From nullable short to byte**
>>
>>> public static byte TryParseByte(this short? shortValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this short? shortValue)
>>
>> **From int to byte**
>>
>>> public static byte TryParseByte(this int intValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this int intValue)
>>
>> **From nullable int to byte**
>>
>>> public static byte TryParseByte(this int? intValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this int? intValue)
>>
>> **From long to byte**
>>
>>> public static byte TryParseByte(this long longValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this long longValue)
>>
>> **From nullable long to byte**
>>
>>> public static byte TryParseByte(this long? longValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this long? longValue)
>>
>> **From decimal to byte**
>>
>>> public static byte TryParseByte(this decimal decimalValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this decimal decimalValue)
>>
>> **From nullable decimal to byte**
>>
>>> public static byte TryParseByte(this decimal? decimalValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this decimal? decimalValue)
>>
>> **From double to byte**
>>
>>> public static byte TryParseByte(this double doubleValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this double doubleValue)
>>
>> **From nullable double to byte**
>>
>>> public static byte TryParseByte(this double? doubleValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this double? doubleValue)
>>
>> **From float to byte**
>>
>>> public static byte TryParseByte(this float floatValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this float floatValue)
>>
>> **From nullable float to byte**
>>
>>> public static byte TryParseByte(this float? floatValue, byte defaultValue)
>>
>>> public static byte TryParseByte(this float? floatValue)
>>
>> **From string to byte array**
>>
>>> public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, bool allowDefaultConversion, NumberStyles numberStyle, CultureInfo culture)
>>
>>> public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, NumberStyles numberStyle, CultureInfo culture)
>>
>>> public static byte[] TryParseByteArray(this string strValue, NumberStyles numberStyle, CultureInfo culture)
>>
>>> public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue, bool allowDefaultConversion)
>>
>>> public static byte[] TryParseByteArray(this string strValue, byte[] defaultValue)
>>
>>> public static byte[] TryParseByteArray(this string strValue)
>>
>
> **DecimalExtensions**
>
>> Same method like ByteExtensions
>
> **DoubleExtensions**
>
>> Same method like ByteExtensions
>
> **FloatExtensions**
>
>> Same method like ByteExtensions
>
> **IntExtensions**
>
>> Same method like ByteExtensions
>
> **LongExtensions**
>
>> Same method like ByteExtensions
>
> **ShortExtensions**
>
>> Same method like ByteExtensions
>
> **StringExtensions**
>
>> public static string ToUnicode(this string text)
>>
>> public static string ToUnicodeWithoutSpace(this string text)
>>
>> public static string Left(this string text, int length)
>>
>> public static string Right(this string text, int length)
>
> **IsValid**
>
>> public static bool IsValidBool(this string strValue)
>>
>> public static bool IsValidByte(this string strValue)
>>
>> public static bool IsValidDecimal(this string strValue)
>>
>> public static bool IsValidDouble(this string strValue)
>>
>> public static bool IsValidFloat(this string strValue)
>>
>> public static bool IsValidInt(this string strValue)
>>
>> public static bool IsValidLong(this string strValue)
>>
>> public static bool IsValidShort(this string strValue)

---

###DateTimeExtensions###
>
> **Offset**
>
>> public static int GetDateTimeOffsetMinutes(this DateTime date, TimeZoneInfo timezoneInfo)
>>
>> public static int GetDateTimeOffsetMinutes(this DateTime date, string timezoneName)
>>
>> public static int GetDateTimeOffsetMinutes(this DateTime date)
>
> **Utils**
>
>> **Business days**
>>
>>> public static DateTime AddBusinessDays(this DateTime date, int days, DayOfWeek[] businessDays)
>>
>>> public static DateTime AddBusinessDays(this DateTime date, int days)
>>
>>> public static DateTime RemoveBusinessDays(this DateTime date, int days, DayOfWeek[] businessDays)
>>
>>> public static DateTime RemoveBusinessDays(this DateTime date, int days)
>>
>> **Set date**
>>
>>> public static DateTime SetDate(this DateTime date, int year, int month, int day)
>>
>>> public static DateTime SetYear(this DateTime date, int year)
>>
>>> public static DateTime SetMonth(this DateTime date, int month)
>>
>>> public static DateTime SetDay(this DateTime date, int day)
>>
>> **Set time**
>>
>>> public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
>>
>>> public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
>>
>>> public static DateTime SetTime(this DateTime date, int hour, int minute)
>>
>>> public static DateTime SetHour(this DateTime date, int hour)
>>
>>> public static DateTime SetMinute(this DateTime date, int minute)
>>
>>> public static DateTime SetSecond(this DateTime date, int second)
>>
>>> public static DateTime SetMillisecond(this DateTime date, int millisecond)
>>
>> **Start of year**
>>
>>> public static DateTime StartOfYear(this DateTime date)
>>
>>> public static DateTime StartOfYear(int year)
>>
>>> public static DateTime StartOfBusinessYear(this DateTime date, DayOfWeek[] businessDays)
>>
>>> public static DateTime StartOfBusinessYear(this DateTime date)
>>
>>> public static DateTime StartOfBusinessYear(int year, DayOfWeek[] businessDays)
>>
>>> public static DateTime StartOfBusinessYear(int year)
>>
>> **End of year**
>>
>>> public static DateTime EndOfYear(this DateTime date)
>>
>>> public static DateTime EndOfYear(int year)
>>
>>> public static DateTime EndOfBusinessYear(this DateTime date, DayOfWeek[] businessDays)
>>
>>> public static DateTime EndOfBusinessYear(this DateTime date)
>>
>>> public static DateTime EndOfBusinessYear(int year, DayOfWeek[] businessDays)
>>
>>> public static DateTime EndOfBusinessYear(int year)
>>
>> **Start of month**
>>
>>> public static DateTime StartOfMonth(this DateTime date)
>>
>>> public static DateTime StartOfMonth(Month month, int year)
>>
>>> public static DateTime StartOfBusinessMonth(this DateTime date, DayOfWeek[] businessDays)
>>
>>> public static DateTime StartOfBusinessMonth(this DateTime date)
>>
>>> public static DateTime StartOfBusinessMonth(Month month, int year, DayOfWeek[] businessDays)
>>
>>> public static DateTime StartOfBusinessMonth(Month month, int year)
>>
>> **End of month**
>>
>>> public static DateTime EndOfMonth(this DateTime date)
>>
>>> public static DateTime EndOfMonth(Month month, int year)
>>
>>> public static DateTime EndOfBusinessMonth(this DateTime date, DayOfWeek[] businessDays)
>>
>>> public static DateTime EndOfBusinessMonth(this DateTime date)
>>
>>> public static DateTime EndOfBusinessMonth(Month month, int year, DayOfWeek[] businessDays)
>>
>>> public static DateTime EndOfBusinessMonth(Month month, int year)
>>
>> **Start of week**
>>
>>> public static DateTime StartOfWeek(this DateTime date, DayOfWeek firstDay)
>>
>>> public static DateTime StartOfWeek(this DateTime date)
>>
>>> public static DateTime StartOfBusinessWeek(this DateTime date, DayOfWeek firstBusinessDay)
>>
>>> public static DateTime StartOfBusinessWeek(this DateTime date)
>>
>> **End of week**
>>
>>> public static DateTime EndOfWeek(this DateTime date, DayOfWeek lastDay)
>>
>>> public static DateTime EndOfWeek(this DateTime date)
>>
>>> public static DateTime EndOfBusinessWeek(this DateTime date, DayOfWeek lastBusinessDay)
>>
>>> public static DateTime EndOfBusinessWeek(this DateTime date)
>>
>> **Start of day**
>>
>>> public static DateTime StartOfDay(this DateTime date)
>>
>> **End of day**
>>
>>> public static DateTime EndOfDay(this DateTime date)
>>
>
> **DateExtensions**
> 
>> **ToUtc**
>> 
>>> public static DateTime ToUtc(this DateTime date, TimeZoneInfo timezoneInfo)
>>> 
>>> public static DateTime ToUtc(this DateTime date, string timezoneName)
>>> 
>>> public static DateTime ToUtc(this DateTime date)

---

###And much more...###


<!-- http://dillinger.io/ -->