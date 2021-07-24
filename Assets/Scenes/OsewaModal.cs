using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OsewaModal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
