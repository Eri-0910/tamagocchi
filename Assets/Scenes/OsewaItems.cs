using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

[Serializable]
public class OsewaItems
{
    public List<OsewaItem> eat;
    public List<OsewaItem> bath;
    public List<OsewaItem> clean;
    public List<OsewaItem> wash;
    public List<OsewaItem> exercise;
    public List<OsewaItem> study;
    public List<OsewaItem> play;

    public OsewaItems(List<OsewaItem> eat, List<OsewaItem> bath, List<OsewaItem> clean, List<OsewaItem> wash, List<OsewaItem> exercise, List<OsewaItem> study, List<OsewaItem> play)
    {
        this.eat = eat.ToList();
        this.bath = bath.ToList();
        this.clean = clean.ToList();
        this.wash = wash.ToList();
        this.exercise = exercise.ToList();
        this.study = study.ToList();
        this.play = play.ToList();
    }
}

[Serializable]
public class OsewaItem
{
    public int id;
    public string category;
    public string title;
    public string memo;
    public int needTime;
    public List<string> checkedTimes;
    public Span span;
    public string done;

    public OsewaItem(int id, string category, string title, string memo, int needTime, Span span, List<DateTime> checkedTimes)
    {
        this.id = id;
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
