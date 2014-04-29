#.NET Dev Utils [![Build status](https://ci.appveyor.com/api/projects/status/ge146r8gotw9r0mb)](https://ci.appveyor.com/project/jornfilho/net-dev-utils)#
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

##And much more...##

<!--http://dillinger.io/-->