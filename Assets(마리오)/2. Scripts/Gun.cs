using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Mario_Control mario_control;

    public float Bullet_Speed = 2f;
    public bool Shootting;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(mario_control.dirRight)
            {
                GameObject bulletInstance = Instantiate(Bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
                bulletInstance.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(Bullet_Speed, 0);
            }
            else
            {
                GameObject bulletInstance = Instantiate(Bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
                bulletInstance.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(-Bullet_Speed, 0);
            }
        }
    }
}
