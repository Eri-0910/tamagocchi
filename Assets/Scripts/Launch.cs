using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickStartButton(){
        // 名前の取得
        string Name = PlayerPrefs.GetString("Name");

        if (Name == null)
        {
            // 遷移
            SceneManager.LoadScene("TitleScene");
        } else
        {
            // 遷移
            SceneManager.LoadScene("SampleScene");
        }
    }
}
