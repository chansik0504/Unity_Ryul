using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
	public AudioClip pickupClip;		// 폭탄 상자가 픽업됬을때를 위한 사운드 
	
	
	private Animator anim;				// animator component를 위한 레퍼런스 
	private bool landed = false;		// 상자가 아직 착륙 전인지 아닌지를 위한 변수 
	
	
	void Awake()
	{
		// 레퍼런스(참조)들을 셋팅.
		anim = transform.root.GetComponent<Animator>();
	}
	
	
	void OnTriggerEnter2D (Collider2D other)
	{
		// 만약 플레이어가 trigger zone에 들어왔을경우...
		if(other.tag == "Player")
		{
			// 픽업 사운드 이팩트를 플레이 
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);
			
			// 플레이어가 가진 폭탄의 수를 증가 
			other.GetComponent<LayBombs>().bombCount++;
			
			// 폭탄 상자를 파괴 
			Destroy(transform.root.gameObject);
		}
		// 그렇지 않고 만약 상자가 땅위에 착륙했을때...
		else if(other.tag == "ground" && !landed)
		{
			// animator의 trigger parameter를 Land로 셋팅 
			anim.SetTrigger("Land");
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;		
		}
	}
}
