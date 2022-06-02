using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LogoManager : MonoBehaviour
{
    public VideoPlayer video;
    public VideoPlayer videoBG;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelayTime", 3.0f);
    }

    IEnumerator DelayTime(float a)
    {
        yield return new WaitForSeconds(a);

        DontDestroyOnLoad(videoBG);
        SceneManager.LoadScene("MainMenu");
    }
}
