using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLaser : MonoBehaviour
{
    /////////////// 수정 //////////////////
    public static csLaser instance;
    void Awake()
    {
        if(csLaser.instance == null)
        {
            csLaser.instance = this;
        }
    }
    //////////////////////////////////////////
    public float moveSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float moveY = moveSpeed * Time.deltaTime;
        // transform.Translate(0, moveY, 0);

        if(Input.GetKey(KeyCode.Space))
        {
            moveSpeed = 0.2f;
            float moveY = moveSpeed * Time.deltaTime;
            transform.Translate(0, moveY, 0);
        }
        else
        {
            moveSpeed = 0.5f;
            float moveY = moveSpeed * Time.deltaTime;
            transform.Translate(0, moveY, 0);
        }
    }

    void OnBecameInvisible()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
