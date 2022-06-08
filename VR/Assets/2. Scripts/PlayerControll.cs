using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public GameObject CAM;
    public GameObject CAMTong;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        CAMTong.GetComponent<Transform>().position = this.transform.position;

        if (CAM.GetComponent<Transform>().rotation.eulerAngles.x >=273.0f &&
            CAM.GetComponent<Transform>().rotation.eulerAngles.x <= 350.0f)
        {
            this.transform.Translate(new Vector3(0, 0, 0.1f));
        }
        //this.transform.rotation = new Quaternion(0,GameObject.Find("MainCamera").GetComponent<Transform>().rotation.y,0, GameObject.Find("MainCamera").GetComponent<Transform>().rotation.w);
        this.transform.rotation = Quaternion.Euler(0, CAM.GetComponent<Transform>().rotation.eulerAngles.y, 0);



    }
}
