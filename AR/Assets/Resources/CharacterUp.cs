using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUp : MonoBehaviour
{
    public Transform Character;
    public GameObject Pocari;

    private int Left_Shake;
    private int Right_Shake;
    private int Count;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Pocari.transform.position.x < -10)
        {
            Left_Shake = 1;
        }

        else if (Pocari.transform.position.x > 10)
        {
            Right_Shake = 1;
        }

        if (Left_Shake == 1 && Right_Shake == 1)
        {
            Count++;
            Left_Shake = 0;
            Right_Shake = 0;
        }

        if (Count >= 10)
        {
            Character.Translate(new Vector3(0, 1f, 0));
        }
    }
}
