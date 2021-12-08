using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static SceneNames;
using static Utils;

public class OsewaModal : MonoBehaviour
{
    // ボタンタイトル
    [SerializeField] private Text title = default;
    // ボタンメモ
    [SerializeField] private Text memo = default;
    // ボタンの実行回数
    [SerializeField] private Text times = default;
    // ボタンのスパン
    [SerializeField] private Text span = default;
    // カテゴリイメージ
    [SerializeField] private Image category = default;
    // バックグラウンドイメージ
    [SerializeField] private Image BG = default;

    private string categoryStr = default;
    private int id = default;

    public void Set(OsewaItem osewaItem)
    {
        this.id = osewaItem.id;
        this.categoryStr = osewaItem.category;

        this.title.text = osewaItem.title;
        this.memo.text = osewaItem.memo;
        this.times.text = osewaItem.getDone() + "/" + osewaItem.needTime.ToString();

        switch (osewaItem.span)
            {
                case Span.Day:
                    this.span.text = "1日" + osewaItem.needTime + "回";
                    break;
                case Span.Week:
                    this.span.text = "1週" + osewaItem.needTime + "回";
                    break;
                case Span.Month:
                    this.span.text = "1月" + osewaItem.needTime + "回";
                    break;
                default:
                    Debug.Log(osewaItem.span);
                    break;
            }

        var sprite = Resources.Load<Sprite>("CategoryIcons/" + osewaItem.category);
        var modalSprite = Resources.Load<Sprite>("TaskItems/Modal/modal_" + osewaItem.category);
        category.sprite = sprite;
        BG.sprite = modalSprite;
    }

    public void OnClickBack()
    {
        Destroy(this.gameObject);
    }

    public void OnClickAction()
    {
        var json = PlayerPrefs.GetString("Osewa");
        OsewaItems osewaItems = JsonUtility.FromJson<OsewaItems>(json);

        //  やった記録
        //  Jsonの形式要修正
        switch (this.categoryStr)
            {
                case "eat":
                    var eatIndex = osewaItems.eat.FindIndex(checkSame);
                    osewaItems.eat[eatIndex].checkedTimes.Add(DateTimeToString(DateTime.Now));
                    PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItems));
                    break;
                case "bath":
                    var bathIndex = osewaItems.bath.FindIndex(checkSame);
                    osewaItems.bath[bathIndex].checkedTimes.Add(DateTimeToString(DateTime.Now));
                    PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItems));
                    break;
                case "clean":
                    var cleanIndex = osewaItems.clean.FindIndex(checkSame);
                    osewaItems.clean[cleanIndex].checkedTimes.Add(DateTimeToString(DateTime.Now));
                    PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItems));
                    break;
                case "wash":
                    var washIndex = osewaItems.wash.FindIndex(checkSame);
                    osewaItems.wash[washIndex].checkedTimes.Add(DateTimeToString(DateTime.Now));
                    PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItems));
                    break;
                case "exercise":
                    var exerciseIndex = osewaItems.exercise.FindIndex(checkSame);
                    osewaItems.exercise[exerciseIndex].checkedTimes.Add(DateTimeToString(DateTime.Now));
                    PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItems));
                    break;
                case "study":
                    var studyIndex = osewaItems.study.FindIndex(checkSame);
                    osewaItems.study[studyIndex].checkedTimes.Add(DateTimeToString(DateTime.Now));
                    PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItems));
                    break;
                case "play":
                    var playindex = osewaItems.play.FindIndex(checkSame);
                    osewaItems.play[playindex].checkedTimes.Add(DateTimeToString(DateTime.Now));
                    PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItems));
                    break;
                default:
                    Debug.Log(this.categoryStr);
                    break;
            }

        MainSetting.nextAction = this.categoryStr;
        SceneManager.LoadScene(MAIN_SCENE);
        Destroy(this.gameObject);
    }

    private bool checkSame(OsewaItem target){
        return target.id == this.id;
    }

    public void OnClickSetting()
    {
        
    }
}
