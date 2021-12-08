using System;
using System.Globalization;

public class Utils
{
    private static readonly string dateFormat = "M/d/yyyy h:m:s tt";
    public static DateTime StringToDateTime(string dateString)
    {
        return DateTime.ParseExact(dateString, dateFormat, new CultureInfo("en-US")).Date;
    }

    public static string DateTimeToString(DateTime date)
    {
        return date.ToString(dateFormat);
    }
}
