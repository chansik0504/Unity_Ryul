using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBtn : MonoBehaviour
{
    public UnityEngine.UI.Scrollbar obj_scrollbar_;

    public void OnPointEnter()
    {
        StartCoroutine(TimeToAction());
    }

    public void OnPointExit()
    {
        obj_scrollbar_.size = 0;
        StopAllCoroutines();
    }
    
    IEnumerator TimeToAction()
    {
        for(float value = 0.0f; value < 1.0f; value += 0.01f)
        {
            obj_scrollbar_.size = value;
            yield return new WaitForEndOfFrame();
        }

        obj_scrollbar_.size = 1.0f;
        Debug.Log("버튼 동작 처리");
    }
}
