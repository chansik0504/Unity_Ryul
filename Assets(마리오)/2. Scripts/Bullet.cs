using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(transform.root.gameObject, 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Monster")
        {
            Debug.Log("Hi");
            Destroy(transform.root.gameObject);
            Destroy(col.transform.root.gameObject);
        }
    }
}
