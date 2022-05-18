using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TYPE_DIR
{
    DIR_FRONT = 0,
    DIR_BACK,
    DIR_LEFT,
    DIR_RIGHT,
    DIR_TOP,
    DIR_BOTTOM
}

public class AutoMove : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public int testNum;

    //프로퍼티 선언 
    public float instance 
    {
        get { return moveSpeed = 3.0f; }
    }

    public TYPE_DIR direction = TYPE_DIR.DIR_TOP;

    // Update is called once per frame
    void Update()
    {
        Vector3 v = this.transform.position;
        switch (this.direction)
        {
            case TYPE_DIR.DIR_FRONT:
                v.z += this.moveSpeed * Time.deltaTime;
                break;

            case TYPE_DIR.DIR_BACK:
                v.z -= this.moveSpeed * Time.deltaTime;
                break;

            case TYPE_DIR.DIR_LEFT:
                v.x -= this.moveSpeed * Time.deltaTime;
                break;

            case TYPE_DIR.DIR_RIGHT:
                v.x += this.moveSpeed * Time.deltaTime;
                break;

            case TYPE_DIR.DIR_TOP:
                v.y += this.moveSpeed * Time.deltaTime;
                break;

            case TYPE_DIR.DIR_BOTTOM:
                v.y -= this.moveSpeed * Time.deltaTime;
                break;
        }
        this.transform.position = v;
    }

    public void OriginSet()
    {
        this.transform.position = Vector3.zero;
    }
}