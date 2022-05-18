using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float dirX = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        Vector3 moveDir = new Vector3(dirX, 0, 0);
        transform.Translate(moveDir * Time.deltaTime);
    }
}
