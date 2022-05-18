using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine;

public class OpenManager : MonoBehaviour
{
    public VideoPlayer video;

	// Use this for initialization
	void Start () {
        //영상 재생
        video.Play();
    }
	
	// Update is called once per frame
	void Update () {
		//영상 멈추고 게임스테이지 
        if(!video.isPlaying)
        {
            SceneManager.LoadScene("scCh2");
            Debug.Log(123);
        }
	}
}