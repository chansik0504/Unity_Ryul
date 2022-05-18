using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int score = 0;			// 플레이어 점수 
	
	
	private PlayerCtrl playerCtrl;	// PlayerCtrl 스크립트를 위한 레퍼런스   
	private int previousScore = 0;  // 이전 프레임에 점수 

	public Text[] spScore;

	void Awake ()
	{
		// 레퍼런스의 셋팅 
		playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();
	}
	
	
	void Update ()
	{
		// 다음과 같이 GUIText 컴포넌트 text 요소에 점수를 셋팅
		//GetComponent<GUIText>().text = "Score: " + score;
		spScore[0].text = "Score: " + score;
		spScore[1].text = "Score: " + score;

		// 만약 점수가 바뀌었다면 
		if (previousScore != score)
			// 조롱 사운드를 플레이하자.   
			playerCtrl.StartCoroutine(playerCtrl.Taunt());
		
		// 이번 플레임에 점수로 previousScore에 설정하자.
		previousScore = score;
	}
	
}
