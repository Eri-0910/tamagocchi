using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

[Serializable]
public class OsewaItems
{
    public OsewaItem[] eat;
    public OsewaItem[] bath;
    public OsewaItem[] clean;
    public OsewaItem[] wash;
    public OsewaItem[] exercise;
    public OsewaItem[] study;
    public OsewaItem[] play;

    public OsewaItems(OsewaItem[] eat, OsewaItem[] bath, OsewaItem[] clean, OsewaItem[] wash,OsewaItem[] exercise, OsewaItem[] study, OsewaItem[] play)
    {
        this.eat = eat;
        this.bath = bath;
        this.clean = clean;
        this.wash = wash;
        this.exercise = exercise;
        this.study = study;
        this.play = play;
    }
}

[Serializable]
public class OsewaItem
{
    public string category;
    public string title;
    public string memo;
    public int needTime;
    public List<string> checkedTimes;
    public Span span;
    public string done;

    public OsewaItem(string category, string title, string memo, int needTime, Span span, List<DateTime> checkedTimes)
    {
        this.category = category;
        this.title = title;
        this.memo = memo;
        this.needTime = needTime;
        this.checkedTimes = checkedTimes.Select<DateTime,string>((DateTime checkedTime) => checkedTime.ToString("M/d/yyyy h:m:s tt")).ToList();
        this.span = span;
    }

    public int getDone()
    {
        var times = 5;
        this.checkedTimes.RemoveAll(IsNeedless);
        times = this.checkedTimes.FindAll(IsThisTimeDone).Count;
        return times;
    }

    private static bool IsNeedless(string d)
    {
        return DateTime.ParseExact(d, "M/d/yyyy h:m:s tt", new CultureInfo("en-US")).Date < DateTime.Today.AddDays(-2).Date;
    }

    private static bool IsThisTimeDone(string d)
    {
        return  DateTime.Today.Date == DateTime.ParseExact(d, "M/d/yyyy h:m:s tt", new CultureInfo("en-US")).Date;
    }
}

public enum Span : ushort
{
    Day = 0,
    Week = 1,
    Month = 2
}
