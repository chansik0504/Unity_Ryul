using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Move : MonoBehaviour
{
    private int Count = 0;
    public float moveSpeed = 2.0f;
    void FixedUpdate()
    {
        if (Count >= 1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void CounDown()
    {
        Count++;
    }

}
