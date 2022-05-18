using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heading_Question : MonoBehaviour
{

    public int CurveSwitch = 0;

    public AnimationCurve curve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
	// 시작 딜레이

	public float UpTime = 0.5f;	
	// private float delayTimer = 0.02f;
	private float UpTimer = 0.0f;

    public float DownTime = 0.5f;	
	// private float delayTimer = 0.02f;
	private float DownTimer = 0.0f;

    public Sprite Empty;

    private Vector3 Destination_One;
    private Vector3 Destination_Two;

    public GameObject CoinContainer;
    public GameObject MushroomContainer;
    public GameObject FlowerContainer;

    void OnTriggerEnter2D(Collider2D Marios_Head)
    {
        if (Marios_Head.tag == "Head")
        {
            if(transform.GetComponent<SpriteRenderer>().sprite != Empty)
            {
                if (GameObject.Find("Mario") && transform.tag != "Coin")
                {
                    Vector3 Temp = transform.position;
                    Temp.y += 0.16f;
                    GameObject MushroomInstance = Instantiate(MushroomContainer, Temp, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
                    //MushroomContainer.transform.position = new Vector2(transform.position.x, transform.position.y + 0.16f);
                }

                else if (((GameObject.Find("Mario1") || GameObject.Find("Mario2")) && transform.tag != "Coin"))
                {
                    Vector3 Temp = transform.position;
                    Temp.y += 0.16f;
                    GameObject FlowerInstance = Instantiate(FlowerContainer, Temp, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
                    //FlowerContainer.transform.position = new Vector2(transform.position.x, transform.position.y + 0.16f);
                }
    
                else if (transform.tag == "Coin")
                {
                    GameObject CoinInstance = Instantiate(CoinContainer, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
                    CoinContainer.transform.position = new Vector2(transform.position.x, transform.position.y + 0.16f);

                }

                transform.GetComponent<Animator>().enabled = false;
                transform.GetComponent<SpriteRenderer>().sprite = Empty;

                CurveSwitch++;
                Destination_One = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.05f, transform.localPosition.z);
                Destination_Two = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }

    void Update()
    {
        if (CurveSwitch == 1)
        {
            if (UpTimer <= UpTime)
            {
                // 그래프로 속도 조절하자.
                transform.localPosition = Vector3.Lerp(transform.localPosition, Destination_One , curve.Evaluate(UpTimer / UpTime));
                UpTimer += Time.deltaTime;
                if(transform.localPosition == Destination_One)
                {
                    CurveSwitch++;
                }
            }
        }

        if (CurveSwitch == 2)
        {
            if (DownTimer <= DownTime)
            {
                // 그래프로 속도 조절하자.
                transform.localPosition = Vector3.Lerp(transform.localPosition, Destination_Two, curve.Evaluate(DownTimer / DownTime));
                DownTimer += Time.deltaTime;
                if(transform.localPosition == Destination_Two)
                {
                    CurveSwitch++;
                }
            }
        }
    }
}
