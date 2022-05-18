using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Turn : MonoBehaviour
{
    public Mushroom_Move M_M;
    void OnTriggerEnter2D(Collider2D Who)
    {
        if(Who.tag == "Ground")
        {
            // Vector3 Temp = transform.root.localScale;
            // Temp.x *= -1;
            // transform.root.localScale = Temp;

            M_M.moveSpeed *= -1;
        }
    }
}
