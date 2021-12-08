using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SceneNames;

public class MoveMain : MonoBehaviour
{
    public InputField inputField;

    public void OnClickSubmitButton()
    {
        // 入力がないのにボタンを押された時
        if(inputField.text == null || inputField.text == ""){
            Debug.Log("Name Null");
            return;
        }
        Debug.Log (inputField.text);
        // 入力の保存
        PlayerPrefs.SetString("Name", inputField.text);
        // 年齢の追加
        PlayerPrefs.SetString("BirthDay", DateTime.Today.Date.ToString());
        // 世代の設定
        int generation = PlayerPrefs.GetInt("Generation", 0);
        PlayerPrefs.SetInt("Generation", generation+1);
        // 遷移
        SceneManager.LoadScene(MAIN_SCENE);
    }

}
