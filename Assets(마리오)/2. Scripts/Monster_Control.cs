using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Control : MonoBehaviour
{
    public Monster_Die M_D;
    void OnTriggerEnter2D(Collider2D Who)
    {
        if(Who.tag == "Ground")
        {
            // Vector3 Temp = transform.root.localScale;
            // Temp.x *= -1;
            // transform.root.localScale = Temp;

            M_D.moveSpeed *= -1;
        }
    }
}
