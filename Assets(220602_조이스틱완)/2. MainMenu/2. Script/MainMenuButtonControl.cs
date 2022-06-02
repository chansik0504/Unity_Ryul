using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuButtonControl : MonoBehaviour
{
    private static int MainMenuStartButton = 0;
    void Start()
    {
        if (MainMenuStartButton != 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        GameObject.Find("Canvas").transform.Find("DestroyButton").gameObject.SetActive(false);

        GameObject.Find("Canvas").transform.Find("Menu1").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Menu2").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Menu3").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("Menu4").gameObject.SetActive(true);
    }
    public void NewStart()
    {
        MainMenuStartButton++;
        SceneManager.LoadScene("NewStart");
    }

    public void LoadStart()
    {
        MainMenuStartButton++;
        SceneManager.LoadScene("LoadStart");
    }

    public void Setting()
    {
        // 옵션 온오프
    }

    public void Exit()
    {
        // 종료
    }
}
