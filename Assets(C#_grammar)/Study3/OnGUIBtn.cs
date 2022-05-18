using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUIBtn : MonoBehaviour
{
    void OnGUI()
    {
        if(GUILayout.Button("My button"))
        {
            Debug.Log("Push");
        }
        if (Event.current.type == EventType.Repaint && GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
            GUILayout.Label("Mouse over!");
        else
            GUILayout.Label("Mouse somewhere else");
    }
}