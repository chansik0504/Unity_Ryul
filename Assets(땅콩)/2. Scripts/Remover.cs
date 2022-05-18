using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Remover : MonoBehaviour
{
// 물 풍덩 프리팹 연결 
	public GameObject splash;
	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		// 만약 플레이어가 trigger에 충돌했다면... 
		if(col.gameObject.tag == "Player")
		{
			// .. 카메라가 플레이어를 tracking 하는것을 중지 
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>().enabled = false;
			
			// .. 플레이어를 따라다니는 Health Bar를 비 활성화 
			if(GameObject.FindGameObjectWithTag("Life").activeSelf)
			{
				GameObject.FindGameObjectWithTag("Life").SetActive(false);
			}
			
			// ... 플레이어가 떨어진 지점에 splash를 생성 
			Instantiate(splash, col.transform.position, transform.rotation);
			// ... player를 destroy
			Destroy (col.gameObject);
			// ... 현재 씬을(level)을 reload
			StartCoroutine("ReloadGame");
		}
		else
		{
			// ... 몬스터가 떨어진 지점에 splash를 생성  
			Instantiate(splash, col.transform.position, transform.rotation);
			
			// ... enemy를 destroy
			Destroy (col.gameObject);	
		}
	}
	
	IEnumerator ReloadGame()
	{			
		// ... 잠시 멈췄다가 
		yield return new WaitForSeconds(2);
		// ... 그리고 나서 level(씬)을 reload
		//Application.LoadLevel(Application.loadedLevel);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


	//추가 설명 
	/*
	가장 최근에 로드 된 씬(현재 씬) 의 인덱스를 보기 위해 Application.loadedLevel 을 사용하면 아래의 경고 메시지 처럼
	Application.loadedLevel'은(는) 사용되지 않습니다. '"Use SceneManager to determine what scenes have been loaded"' 라는
    경고 메시지를 띄웁니다.
    이럴 땐 경고 메시지에서 권유하는 것 처럼 SceneManager 를 사용하면 됩니다. 방식은 다음과 같습니다.
    Application.loadedLevel 이거 대신에 -> SceneManager.GetActiveScene().buildIndex
    */
}
