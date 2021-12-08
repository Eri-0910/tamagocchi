using System;
using System.Globalization;

public class Utils
{
    private static readonly string dateFormat = "M/d/yyyy h:m:s tt";

    /// <summary>
    /// 文字列をDateTimeに変換
    /// </summary>
    public static DateTime StringToDateTime(string dateString)
    {
        return DateTime.ParseExact(dateString, dateFormat, new CultureInfo("en-US")).Date;
    }

    /// <summary>
    /// DateTimeを文字列に変換
    /// </summary>
    public static string DateTimeToString(DateTime date)
    {
        return date.ToString(dateFormat);
    }
}
