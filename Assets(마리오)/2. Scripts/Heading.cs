using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heading : MonoBehaviour
{
    public float Delay;
    private Animator anim;
    public Sprite Empty;

    public GameObject MushRoom;

    void OnTriggerEnter2D(Collider2D Object) 
    {
        if (Object.tag == "Brick")
        {
            Destroy(Object.gameObject, Delay);
        }

        else if (Object.tag == "Question")
        {
            if(Object.GetComponent<SpriteRenderer>().sprite != Empty)
            {
                GameObject MushRoomInstance = Instantiate(MushRoom, Object.transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
                MushRoomInstance.transform.position = new Vector2(Object.transform.position.x, Object.transform.position.y + 0.16f);
            }

            //Destroy(Object);

            Object.GetComponent<SpriteRenderer>().sprite = Empty;
        }
    }
}
