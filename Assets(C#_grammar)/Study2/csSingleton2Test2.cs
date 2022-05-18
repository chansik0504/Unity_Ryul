using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSingleton2Test2 : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        csSingleton2.Instance.num += 1;
        Debug.Log(csSingleton2.Instance.num);
    }

    // Update is called once per frame
    void Update()
    {

    }
}