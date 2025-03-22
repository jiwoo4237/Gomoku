using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class CardPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action OnEnter;  // CardsController에서 처리할 이벤트
    public Action OnExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnter?.Invoke();  // CardsController로 이벤트 전달
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExit?.Invoke();   // CardsController로 이벤트 전달
    }
}
