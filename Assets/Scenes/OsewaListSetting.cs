using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OsewaListSetting : MonoBehaviour
{
    // 表示するカテゴリーリスト
    [SerializeField] private CategoryList categoryList = default;
    // 表示するボタン
    [SerializeField] private OsewaButton osewaButton = default;
    // モーダルセットする場所
    [SerializeField] private Canvas modalparent = default;
    // リストをセットする場所
    [SerializeField] private GameObject listparent = default;

    // [SerializeField] OsewaItems osewaItemsBase = new OsewaItems(
    //     new OsewaItem[] {
    //         new OsewaItem("eat", "朝ごはんを食べる", "", 1, Span.Day, new List<DateTime>()  {
    //             new DateTime(2021, 7, 21, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)}),
    //         new OsewaItem("eat", "昼ごはんを食べる", "大学の食堂で食べる", 1, Span.Day,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 24, 12, 47, 0),
    //             new DateTime(2021, 7, 25, 12, 47, 0)}),
    //         new OsewaItem("eat", "夜ごはんを食べる", "なるべく自炊！", 1, Span.Day,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 24, 17, 47, 0)}),
    //         new OsewaItem("eat", "おやつを食べる", "週に２回まで。", 2, Span.Week,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)})},
    //     new OsewaItem[] {
    //         new OsewaItem("bath", "お風呂に入る", "", 1, Span.Day,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)})},
    //     new OsewaItem[] {
    //         new OsewaItem("clean", "部屋を片付ける", "a", 3, Span.Week,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)}),
    //         new OsewaItem("clean", "キッチンを片付ける", "a", 1, Span.Week, new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)}),
    //         new OsewaItem("clean", "お風呂場を片付ける", "a", 1, Span.Week,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)})},
    //     new OsewaItem[] {
    //         new OsewaItem("wash", "洗濯する", "a", 1, Span.Day,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)}),
    //         new OsewaItem("wash",  "服を畳む", "a", 1, Span.Day,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)})},
    //     new OsewaItem[] {
    //         new OsewaItem("exercise", "筋トレ", "a", 4, Span.Week,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)}),
    //         new OsewaItem("exercise", "ランニング", "a", 2, Span.Week,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 25, 7, 47, 0),
    //             new DateTime(2021, 7, 25, 7, 47, 0)})},
    //     new OsewaItem[] {
    //         new OsewaItem("study", "TOEIC対策", "a", 5, Span.Month,  new List<DateTime>()  {
    //             new DateTime(2021, 7, 16, 7, 47, 0)})},
    //     new OsewaItem[] {
    //         new OsewaItem("play", "アニメをみる", "a", 3, Span.Month,  new List<DateTime>()  {
    //             new DateTime(2021, 6, 28, 7, 47, 0),
    //             new DateTime(2021, 7, 10, 7, 47, 0)})}
    // );

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetString("Osewa", JsonUtility.ToJson(osewaItemsBase));
        // Debug.Log(JsonUtility.ToJson(osewaItemsBase));
        //JsonUtilityを使ってJSONからOsewaItems作成
        var json = PlayerPrefs.GetString("Osewa");
        OsewaItems osewaItems = JsonUtility.FromJson<OsewaItems>(json);

        SetTodoButton("eat", osewaItems.eat);
        SetTodoButton("bath", osewaItems.bath);
        SetTodoButton("clean", osewaItems.clean);
        SetTodoButton("wash", osewaItems.wash);
        SetTodoButton("exercise", osewaItems.exercise);
        SetTodoButton("study", osewaItems.study);
        SetTodoButton("play", osewaItems.play);
    }

    void SetTodoButton(string category, OsewaItem[] catOsewaItems)
    {
        var sprite = Resources.Load<Sprite>("CategoryIcons/" + category);
        var _categoryList = Instantiate(categoryList);
        _categoryList.transform.SetParent(listparent.transform, false);
        _categoryList.Icon.sprite = sprite;

        var notFinished = false;

        foreach (var osewaItem in catOsewaItems)
        {
            // 生成してCanvasの子要素に設定
            var _osewaButton = Instantiate(osewaButton);
            _osewaButton.Set(osewaItem, modalparent);
            _osewaButton.transform.SetParent(_categoryList.buttonArea.transform, false);
            if(osewaItem.getDone() < osewaItem.needTime){
                notFinished = true;
            }
        }

        _categoryList.warning.enabled = notFinished;
    }
}
