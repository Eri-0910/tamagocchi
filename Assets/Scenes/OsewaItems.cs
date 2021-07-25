using System;
using System.Collections;
using System.Collections.Generic;
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

public class OsewaItem
{
    public string category;
    public string title;
    public string memo;
    public int needTime;
    public List<DateTime> checkedTimes;
    public Span span;
    public string done;

    public OsewaItem(string category, string title, string memo, int needTime, Span span, List<DateTime> checkedTimes)
    {
        this.category = category;
        this.title = title;
        this.memo = memo;
        this.needTime = needTime;
        this.checkedTimes = checkedTimes;
    }

    public int getDone()
    {
        var times = 5;
        this.checkedTimes.RemoveAll(IsNeedless);
        times = this.checkedTimes.FindAll(IsThisTimeDone).Count;
        return times;
    }

    private static bool IsNeedless(DateTime d)
    {
        return d.Date < DateTime.Today.AddDays(-2).Date;
    }

    private static bool IsThisTimeDone(DateTime d)
    {
        return  DateTime.Today.Date == d.Date;
    }
}

public enum Span : ushort
{
    Day = 0,
    Week = 1,
    Month = 2
}
