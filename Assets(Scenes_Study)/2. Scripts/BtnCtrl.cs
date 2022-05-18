using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl : MonoBehaviour
{
    public GameObject spObj;
    public Text tx;
    private bool isPlay;
    public Sprite[] spImgs;
    public Image spAnim;
    int spImgCount;
    float animTime;
    // Start is called before the first frame update
    void Start()
    {
        // spImgs = new Sprite[5];
        spAnim.sprite = spImgs[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        {
            if (Time.time > animTime)
            {
                spImgCount += 1;
                if (spImgCount > 4)
                {
                    spImgCount = 0;
                }
            }
            spAnim.sprite = spImgs[spImgCount];
            animTime = Time.time;
        }
    }

    public void Play()
    {
        // Destroy(gameObject);
        if (!isPlay)
        {
            isPlay = true;
            spObj.SetActive(true);
            tx.text = "STOP";
        }
        else
        {
            isPlay = false;
            spObj.SetActive(false);
            tx.text = "PLAY";
        }
    }
}
