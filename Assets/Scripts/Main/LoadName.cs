using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static SceneNames;

public class LoadName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 名前の取得
        string name = PlayerPrefs.GetString("Name");

        // キャラクターが存在するかどうか(=初回起動かどうか)で、どう遷移するか変える
        if (name == null)
        {
            // 遷移
            SceneManager.LoadScene(NAME_SCENE);
        } else
        {
            // 設定
            GetComponent<Text>().text = name;
        }
    }

}
