using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using static Utils;

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
        this.checkedTimes = checkedTimes.Select<DateTime,string>((DateTime checkedTime) => Utils.DateTimeToString(checkedTime)).ToList();
        this.span = span;
    }

    /// <summary>
    /// 期間内にお世話を行った回数をチェックする
    /// </summary>
    /// <returns>回数</returns>
    public int getDoneTimes()
    {
        // これ以上不要なデータを消しておく
        this.checkedTimes.RemoveAll(IsNeedless);
        // 期間内に何回行ったかをチェック
        int times = this.checkedTimes.FindAll(IsThisTimeDone).Count;
        // 返す
        return times;
    }

    /// <summary>
    /// 前の期間内にお世話を行った回数をチェックする
    /// </summary>
    /// <returns>回数</returns>
    public int getDoneBeforeTimes()
    {
        // これ以上不要なデータを消しておく
        this.checkedTimes.RemoveAll(IsNeedless);
        // 前の期間内に何回行ったかをチェック
        int times = this.checkedTimes.FindAll(IsBeforeimeDone).Count;
        // 返す
        return times;
    }

    /// <summary>
    /// 不要な完了データかどうかをチェックする
    /// </summary>
    /// <returns>不要である</returns>
    private bool IsNeedless(string d)
    {
        switch(this.span)
        {
            case Span.Day:
                return Utils.StringToDateTime(d) < DateTime.Today.AddDays(-2).Date;
            case Span.Week:
                return Utils.StringToDateTime(d) < DateTime.Today.AddDays(-14).Date;
            case Span.Month:
                return Utils.StringToDateTime(d) < DateTime.Today.AddMonths(-2).Date;
            default:
                return false;
        }
    }

    /// <summary>
    /// この期間内での完了かどうか
    /// </summary>
    /// <returns>この期間での完了である</returns>
    private bool IsThisTimeDone(string d)
    {
        switch(this.span)
        {
            case Span.Day:
                // 完了日が今日
                return  DateTime.Today.Date == Utils.StringToDateTime(d).Date;
            case Span.Week:
                // 完了日が7日前より最近
                return  DateTime.Today.AddDays(-7).Date <= Utils.StringToDateTime(d).Date;
            case Span.Month:
                // 完了日が 1月前より最近
                return DateTime.Today.AddMonths(-1).Date <= Utils.StringToDateTime(d).Date;
            default:
                return false;
        }
    }

    /// <summary>
    /// 前の期間内での完了かどうか
    /// </summary>
    /// <returns>前の期間での完了である</returns>
    private bool IsBeforeimeDone(string d)
    {
        switch(this.span)
        {
            case Span.Day:
                // 完了日が昨日
                return  DateTime.Today.AddDays(-1).Date == Utils.StringToDateTime(d).Date;
            case Span.Week:
                // 完了日が7日前から14日前
                return  DateTime.Today.AddDays(-14).Date <= Utils.StringToDateTime(d).Date && Utils.StringToDateTime(d).Date < DateTime.Today.AddDays(-7).Date;
            case Span.Month:
                // 完了日が 1月前から2ヶ月前
                return DateTime.Today.AddMonths(-2).Date <= Utils.StringToDateTime(d).Date && Utils.StringToDateTime(d).Date < DateTime.Today.AddMonths(-1).Date;
            default:
                return false;
        }
    }
}

public enum Span : ushort
{
    Day = 0,
    Week = 1,
    Month = 2
}
