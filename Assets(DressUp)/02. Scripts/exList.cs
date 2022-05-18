using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exList : MonoBehaviour
{
    public GameObject[] enemies;
    List<GameObject> newList = new List<GameObject>();

    void Start()
    {
        foreach (GameObject e in enemies)
        {
            if (e.tag == "Enemy")
            {
                newList.Add(e);
            }
        }
    }

    void OnMouseDown()
    {
        for (int i = 0 ; i < newList.Count; i++)
        {
            newList[i].GetComponent<Renderer>().material.color = Color.red;
            Debug.Log(newList[i].name);
        }
    }
}
