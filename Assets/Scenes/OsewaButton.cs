using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsewaButton : MonoBehaviour
{
    // ダイアログを追加する親のCanvas
    [SerializeField] private Canvas parent = default;
    // 表示するダイアログ
    [SerializeField] private OsewaModal modal = default;
    // ボタンタイトル
    [SerializeField] private Text title = default;
    // ボタンメモ
    [SerializeField] private Text memo = default;
    // ボタンの実行回数
    [SerializeField] private Text times = default;
    // ボタンのスパン
    [SerializeField] private Image spanImage = default;
    // ボタンのチェックマーク
    [SerializeField] private Image check = default;
    // ボタンのベースデザイン
    [SerializeField] private Image baseImage = default;

    private OsewaItem osewaItem = default;

    public void Set(OsewaItem osewaItem, Canvas parent)
    {
        // 文字設定
        this.osewaItem = osewaItem;
        this.parent = parent;
        this.title.text = osewaItem.title;
        this.memo.text = osewaItem.memo;
        this.times.text = osewaItem.getDone() + "/" + osewaItem.needTime.ToString();

        if(osewaItem.getDone() >= osewaItem.needTime){
            var sprite = Resources.Load<Sprite>("TaskItems/completed_task");
            baseImage.sprite = sprite;
        }
        check.enabled = osewaItem.getDone() >= osewaItem.needTime;

        var status = osewaItem.getDone() >= osewaItem.needTime ? "working" : "completed";
        switch (osewaItem.span)
            {
                case Span.Day:
                    var spanSpriteDay = Resources.Load<Sprite>("TaskItems/Labels/" + status + "_day_label");
                    spanImage.sprite = spanSpriteDay;
                    break;
                case Span.Week:
                    var spanSpriteWeek = Resources.Load<Sprite>("TaskItems/Labels/" + status + "_week_label");
                    spanImage.sprite = spanSpriteWeek;
                    break;
                case Span.Month:
                    var spanSpriteMonth = Resources.Load<Sprite>("TaskItems/Labels/" + status + "_month_label");
                    spanImage.sprite = spanSpriteMonth;
                    break;
                default:
                    Debug.Log(osewaItem.span);
                    break;
            }
    }

    // ボタンを押した後のアクション
    public void ShowModal()
    {
        // 生成してCanvasの子要素に設定
        var _modal = Instantiate(modal);
        _modal.Set(this.osewaItem);
        _modal.transform.SetParent(parent.transform, false);
    }
}
