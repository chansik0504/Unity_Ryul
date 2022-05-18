using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemControl : MonoBehaviour
{
    public GameObject Item_text;
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "player")
        {
            Item_text.GetComponent<Text>().text = "아이템을 주우려면 [Z]키를 눌러주세요";

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Item_text.GetComponent<Text>().text = "";
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "player")
        {
            Item_text.GetComponent<Text>().text = "";
        }
    }
}
