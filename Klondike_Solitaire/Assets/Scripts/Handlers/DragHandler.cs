using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action<Card> _OnBeginDrag;
    private CanvasGroup _canvasGroup;
    private Transform _originalParent;
    private Vector3 _startPosition;
    private Card card;

    public void Awake()
    {
        card = GetComponent<Card>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (card._cardModel.isFaceUp)
        {
            _originalParent = transform.parent;
            _startPosition = transform.localPosition;
            _canvasGroup.blocksRaycasts = false;
            card._isNeedToGoDafultParent = true;
            _OnBeginDrag?.Invoke(card);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (card._cardModel.isFaceUp)
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;

        if (card._cardModel.isFaceUp && card._isNeedToGoDafultParent)
        {
            transform.SetParent(_originalParent);
            transform.localPosition = new Vector3(_startPosition.x, _startPosition.y);
        }
    }
}
