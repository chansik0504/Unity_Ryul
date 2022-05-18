using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Wall : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D Obj) 
    {
        if(Obj.tag == "Mario")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void OnTriggerExit2D(Collider2D Obj) 
    {
        if(Obj.tag == "Mario")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
