using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //UI 클릭시 터치 이벤트 발생 방지.

/*
 * 유니티의 모든 이벤트를 후킹하는 예제이다. 참고로 주석이 없어도 이벤트 함수의 이름으로 역할을 알 수 있다.(개발시 참고)
 */

public class csEventHookingAll :
    MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerUpHandler,
    IPointerDownHandler,
    IBeginDragHandler,
    IEndDragHandler,
    IDragHandler,
    IDropHandler,
        ISelectHandler,
        IDeselectHandler,
        IScrollHandler,
        IMoveHandler,
        ISubmitHandler,
        ICancelHandler,
        IUpdateSelectedHandler
    {

    // 터치 확인 변수
    Touch tempTouchs;
    Vector3 touchedPos;
    public bool touchOn;

    public void OnBeginDrag(PointerEventData eventData)
        {
            //throw new NotImplementedException();
            Debug.Log( "OnBeginDrag : " + eventData );
        }

        public void OnCancel(BaseEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnCancel : " + eventData );
        }

        public void OnDeselect(BaseEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnDeselect : " + eventData );
        }

        public void OnDrag(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnDrag : " + eventData );
        }

        public void OnDrop(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnDrop : " + eventData );
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnEndDrag : " + eventData );
        }

        public void OnMove(AxisEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnMove : " + eventData );
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnPointerClick : " + eventData );
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnPointerDown : " + eventData );
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnPointerEnter : " + eventData );
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //throw new NotImplementedException
             Debug.Log( "OnPointerExit : " + eventData );
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnPointerUp : " + eventData );
        }

        public void OnScroll(PointerEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnScroll : " + eventData );
        }

        public void OnSelect(BaseEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnSelect : " + eventData );
        }

        public void OnSubmit(BaseEventData eventData)
        {
            //throw new NotImplementedException
             Debug.Log( "OnSubmit : " + eventData );
        }

        public void OnUpdateSelected(BaseEventData eventData)
        {
            //throw new NotImplementedException();
             Debug.Log( "OnUpdateSelected : " + eventData );
        }

    // 인스펙터에서 컴포넌트 활성/비활성 치리시 필요
    // Use this for initialization
    void Start () {
		
	}

    /*
     * 참고) 만약 켄버스에 이미지만 있다면 이벤트 후킹이 가능하지만 거기다 
     * 버튼을 달면 후킹이 어려움이 있다. 이럴때 다음을 참고하자
     * 
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Debug.Log("Event System1");
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            Debug.Log("Event System2");
            return;
        }
     *       
     */

    void Update()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    Debug.Log("Event System1");
        //    return;
        //}

        //if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        //{
        //    Debug.Log("Event System2");
        //    return;
        //}


        // 컴퓨터
        if ((Input.GetMouseButtonDown(0)))  //버튼을 누름.
        {
            //UI 중 어떤 것이라도(텍스트라도) Raycast Target이 켜져있다면 
            //게임 클릭에서 제외하여 UI만의 세계가 되는 것)
            //이벤트(Click On 등)와도 관계 없고, Raycast Target와 관계가 있음.

            ////UI이 위가 아니면.
            //if (EventSystem.current.IsPointerOverGameObject() == false)
            //{  
            //    //StartCoroutine("코루틴");
            //}

            // 확인 로직
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.LogWarning("Event System1");
                return;
            }
        }

        // 모바일
        //터치가 1개 이상이면.
        //이렇게 처리해주고 실행하면 UI와 게임 내 터치가 구분되어짐.
        if (Input.touchCount > 0)
        {    
            for (int i = 0; i < Input.touchCount; i++)
            {
                //이렇게 다른 부분이라고는 터치 번호가 들어가는 i뿐.
                // 현재 터치되고 있는 번호에 맞게 검사.
                if (EventSystem.current.IsPointerOverGameObject(i) == false)
                {
                    tempTouchs = Input.GetTouch(i);
                    //해당 터치가 시작됐다면.
                    if (tempTouchs.phase == TouchPhase.Began)
                    {    
                        touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position);//월드 좌표 가져오기.

                        touchOn = true;

                        break;   //한 프레임(update)에는 하나만.
                    }
                }
            }
        }

    }
	
}