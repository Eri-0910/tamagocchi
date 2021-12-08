using System;
using System.Globalization;

public class Utils
{
    public static DateTime StringToDateTime(string dateString)
    {
        return DateTime.ParseExact(dateString, "M/d/yyyy h:m:s tt", new CultureInfo("en-US")).Date;
    }
}
