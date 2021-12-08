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
        // 遷移
        SceneManager.LoadScene(MAIN_SCENE);
    }

}
