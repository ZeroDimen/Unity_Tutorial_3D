using UnityEngine;
using UnityEngine.EventSystems;

// UI의 상단 바를 상호작용을 구현하기 위한 스크립트
public class UI_Handler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    // 모든 오브젝트는 Transform을  가지고있음
    // 모든 UI 오브젝트는 RectTransform을 가지고있음
    
    private RectTransform parentRect;
    private Vector2 basePos;
    private Vector2 startPos;
    private Vector2 moveOffset;

    private void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();
        
        // parentRect.SetAsFirstSibling(); // 아래 그려지도록 설정
        // parentRect.SetAsLastSibling(); // 위에 그려지도록 설정
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling(); // 위에 그려지도록 설정
        basePos = parentRect.anchoredPosition; // 기존 UI의 위치
        startPos= eventData.position; // 시작점
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos; // 드래그한 상태의 Dir
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}
