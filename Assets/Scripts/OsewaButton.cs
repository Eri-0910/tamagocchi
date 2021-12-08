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

        // やった回数が必要回数以上なら、背景を完了用に変える
        if(osewaItem.getDone() >= osewaItem.needTime){
            var sprite = Resources.Load<Sprite>("TaskItems/completed_task");
            baseImage.sprite = sprite;
        }
        // やった回数が必要回数以上なら、チェックマークをつける
        check.enabled = osewaItem.getDone() >= osewaItem.needTime;

        var status = osewaItem.getDone() >= osewaItem.needTime ? "working" : "completed";
        var spanSprite = Resources.Load<Sprite>(getSpanImagePath(status, osewaItem.span));
        spanImage.sprite = spanSprite;
    }

    /// <summary>
    /// 期間の画像パスを取得
    /// </summary>
    string getSpanImagePath(string status, Span span){
        switch (span)
        {
            case Span.Day:
                return "TaskItems/Labels/" + status + "_day_label";
            case Span.Week:
                return "TaskItems/Labels/" + status + "_week_label";
            case Span.Month:
                return "TaskItems/Labels/" + status + "_month_label";
            default:
                Debug.Log("span " + osewaItem.span + " is illegal.");
                return "TaskItems/Labels/" + status + "_day_label";
        }
    }

    /// <summary>
    /// 各アイテムのモーダルを表示
    /// </summary>
    public void ShowModal()
    {
        // 生成してCanvasの子要素に設定
        var _modal = Instantiate(modal);
        _modal.Set(this.osewaItem);
        _modal.transform.SetParent(parent.transform, false);
    }
}
