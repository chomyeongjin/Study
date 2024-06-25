using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingControl : MonoBehaviour
{
    public GameObject settingView;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRestartBtn() {
        SceneManager.LoadScene("PlayScene");
        settingView.SetActive(false);
    }

    public void OnClickHomeBtn() {
        SceneManager.LoadScene("StartScene");
        settingView.SetActive(false);
    }

    public void OnClickSetting() {
        Time.timeScale = 0;
        settingView.SetActive(true);
    }

    
}
