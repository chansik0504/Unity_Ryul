using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCas : MonoBehaviour
{
    RaycastHit hitInfo;

    [SerializeField]
    private float Dt;
    // Start is called before the first frame update
    void Start()
    {
        Dt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 100))
        {
            Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);

            if (hitInfo.collider.tag == "Item")
            {
                Debug.Log("안드가냐");
                Debug.Log(Dt);
                Dt += Time.deltaTime;
                if (Dt >= 2.0f)
                {
                    Destroy(hitInfo.transform.gameObject);
                    Dt = 0.0f;
                }

                return;
            }
        }
        Dt = 0.0f;
    }
}
