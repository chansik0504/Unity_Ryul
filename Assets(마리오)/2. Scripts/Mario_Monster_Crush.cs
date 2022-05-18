using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_Monster_Crush : MonoBehaviour
{
    public Animator anim;
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.tag == "Mario")
        {
            col.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            anim.SetTrigger("Crush");

            transform.root.GetComponent<Animator>().enabled = false;

            transform.root.GetComponent<Monster_Die>().moveSpeed = 0;
        }
    }
}
