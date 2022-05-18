using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 이벤트 후킹을 위한 네임스페이스
using UnityEngine.EventSystems;

// 마우스 버튼 클릭 이벤트에 대한 후킹시 필요한...즉 후킹할 이벤트에 맞는 인터페이스를 상속받아야 함.
// 만약 가로챌 이벤트가 UI 항목 위로 마우스 커서가 올라간 경우를 체크... 즉 후킹한다면
// IPointerEnterHandler, IPointerExitHandler 이 인터페이스를 상속 및 메소드들을 "구현" 하자
// 이 Interface들은 마우스 커서가 UI 항목위로 Hover 인지 아닌지 여부에 따라서 호출되는 이벤트를 선언하고 있다.
// 반드시 구현한 스크립트는 Canvas에 추가하자

public class csMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //현재 컴포넌트를 가리킬 인스턴스
    public static csMouseHover instance = null;

    //마우스 커서의 UI 항목에 대한 Hover 여부 
    public bool isUIHover = false;

	// Use this for initialization
	void Awake () {

        instance = this;

	}
	

    //마우스 커서가 UI 항목에 위치 할때(Hover 됨) 호출 됨
    public void OnPointerEnter( PointerEventData eventData )
    {
        isUIHover = true;
        Debug.Log(isUIHover);
    }

    //마우스 커서가 UI 항목에서 나갈때....호출 됨
    public void OnPointerExit(PointerEventData eventData)
    {
      //  throw new NotImplementedException();
      isUIHover = false;
      Debug.Log(isUIHover);
    }

    // Use this for initialization
    void Start () {
		
	}
}

/*
 * Hover 여부를 isUIHover 변수에 저장하고 발사 스크립트에서 참조하여 총탄 발사 여부를 처리하면 됨
 * 
 * == 함수 몸체==
 * if(csMouseHover.instance.isUIHover) return;
 * 총알 발사 로직
 */

/*
 * 만약 화면 마우스 클릭이나 탭으로 총을 발사하는 게임일 경우....
 * UI로 게임 나가기 버튼을 눌렀을경우 총도 같이 발사가 된다..(Ex : GetMouseButtonDown 사용시 모든 scene에 UI 항목을 클릭시 총탄이 발사됨)
 * 이것을 막기 위하여 우린 Event Hook이란 것을 이용하여 시스템에서 호출해주는 이벤트를 중간에 가로챌수 있다.
 * Hooking 한 Event에서 우린 적절한 로직으로 처리 해 주면됨
 * 
 * 
 */