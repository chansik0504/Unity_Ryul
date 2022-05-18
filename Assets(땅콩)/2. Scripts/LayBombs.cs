using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayBombs : MonoBehaviour
{
	[HideInInspector]
	public bool bombLaid = false;		// 폭탄을 현재 던졌는지 아닌지 알기 위한 변수 
	public int bombCount = 0;			// 얼마나 많은 폭탄을 플레이어가 가졌는지 알기 위한 변수 
	public AudioClip bombsAway;			// 플레이어가 폭탄을 던질때를  위한 사운드 
	public GameObject bomb;             // 폭탄 프리팹


	//private GUITexture bombHUD;			// 플레이어가 폭탄을 가졌는지 아닌지의 경고 화면을 위한 레퍼런스
	private Image bombHUD;
	
	
	void Awake ()
	{
		// 레퍼런스(참조)들을 셋팅.
		//bombHUD = GameObject.Find("ui_bombHUD").GetComponent<GUITexture>();
		bombHUD = GameObject.Find("ui_bombHUD").GetComponent<Image>();
	}
	
	
	void Update ()
	{
		// 만약 폭탄 던지는 버튼을 눌렀을때 조건에 따라서 폭탄이 던져지지 않거나 폭탄이 던져진다
		if(Input.GetButtonDown("Fire2") && !bombLaid && bombCount > 0)
		{
			// 소유한 폭탄의 수 감소 
			bombCount--;
			
			// bombLaid를 true로 셋팅(폭탄을 던졌으니)
			bombLaid = true;
			
			// 폭탄 던지는 사운드 플레이 
			AudioSource.PlayClipAtPoint(bombsAway,transform.position);
			
			// bomb prefab 생성 
			Instantiate(bomb, transform.position, transform.rotation);
		}
		
		// 폭탄 경고 화면은 만약 플레이어가 폭탄을 소유하면 활성화 되어야만 한다  그 밖에는 비활성화 되야함  
		bombHUD.enabled = bombCount > 0;
	}
}
