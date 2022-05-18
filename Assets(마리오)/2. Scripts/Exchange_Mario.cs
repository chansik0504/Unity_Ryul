using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange_Mario : MonoBehaviour
{
    public Animator anim;
    public GameObject Mario1;
    public GameObject Mario2;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D Mush) 
    {
        if(this.tag == "Mario" && Mush.tag == "Mushroom")
        {
            Destroy(Mush.transform.root.gameObject);

            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

            anim.SetTrigger("Eat");

            // object.Destroy(GetComponent<Rigidbody2D>());

            
            // gameObject.SetActive(false);
            // Mario1.SetActive(true);
        }

        else if (this.tag == "Mario" && Mush.tag == "Flower" && GameObject.Find("Mario1"))
        {
            Destroy(Mush.transform.root.gameObject);

            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

            anim.SetTrigger("Eat");
        }
    }

    void Mario_Off()
    {
        Mario1.transform.position = transform.position;
        gameObject.SetActive(false);
    }

    void Mario1_On()
    {   this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Mario1.SetActive(true);
    }

    void Mario1_Off()
    {
        Mario2.transform.position = transform.position;
        gameObject.SetActive(false);
    }

    void Mario2_On()
    {   this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        Mario2.SetActive(true);
    }
}
