using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneNames;

public class BackMain : MonoBehaviour
{
    public void OnClickBackButton()
    {
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
