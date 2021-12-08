using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneNames;

public class MoveList : MonoBehaviour
{
    public void OnClickOsewaButton()
    {
        SceneManager.LoadScene(OSEWA_SCENE);
    }
}
