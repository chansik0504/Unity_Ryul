using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowAlpha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Image = GameObject.Find("Canvas/Image2");
        Color color = Image.GetComponent<Image>().color;
        color.a = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Image = GameObject.Find("Canvas/Image2");
        Color color = Image.GetComponent<Image>().color;
        color.a -= 0.005f;

        this.GetComponent<Image>().color = color;
    }
}
