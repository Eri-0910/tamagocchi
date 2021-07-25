using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void Set(OsewaItem osewaItem)
    {
        this.title.text = osewaItem.title;
        this.memo.text = osewaItem.memo;
        this.times.text = osewaItem.getDone() + "/" + osewaItem.needTime.ToString();
        this.span.text = "1日" + osewaItem.needTime + "回";

        var sprite = Resources.Load<Sprite>("CategoryIcons/" + osewaItem.category);
        category.sprite = sprite;
    }

    public void OnClickBack()
    {
        Destroy(this.gameObject);
    }

    public void OnClickAction()
    {
        SceneManager.LoadScene("SampleScene");
        Destroy(this.gameObject);
    }

    public void OnClickSetting()
    {
        
    }
}
