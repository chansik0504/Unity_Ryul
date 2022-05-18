using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heading_Brick : MonoBehaviour
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
    public float Delay;
    private Animator anim;
    private Vector3 Destination_One;
    private Vector3 Destination_Two;


    void OnTriggerEnter2D(Collider2D Marios_Head)
    {
        if (GameObject.Find("Mario") && Marios_Head.tag == "Head") // 작은마리오 + 머리
        {
            CurveSwitch++;
            Destination_One = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.05f, transform.localPosition.z);
            Destination_Two = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        
        else if (Marios_Head.tag == "Head" && !GameObject.Find("Mario")) // 작은마리오X + 머리
        {
            Destroy(this.gameObject, Delay);
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
