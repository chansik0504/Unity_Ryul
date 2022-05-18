using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSet : MonoBehaviour
{
    public int size;
    public float scale;
    public RectTransform[] rect;
	// Use this for initialization
	void Start () {

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //
        //

        //      Screen.SetResolution(1280,800,true);

        rect[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width/ scale);
        rect[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / scale);

        rect[1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / scale);
        rect[1].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / scale);

        rect[2].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / scale);
        rect[2].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / scale);

        //    size = Screen.width;
    }
	
	// Update is called once per frame
	void Update () {
        size = Screen.width;
    }
}
