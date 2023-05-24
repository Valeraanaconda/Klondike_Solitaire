using System;
using System.Collections.Generic;
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
            if (transform.childCount > 0)
            {
                List<Card> childCards = new List<Card>();
                ReturnParent(card);

                GetChildList(childCards);

                foreach (Card card in childCards)
                {
                    card.transform.SetParent(_originalParent);
                }
            }
            else
            {
                ReturnParent(card);
            }
        }
    }

    private void GetChildList(List<Card> childCards)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Card childCard = transform.GetChild(i).GetComponent<Card>();
            if (childCard != null)
            {
                childCards.Add(childCard);
            }
        }
    }

    private void ReturnParent(Card card)
    {
        card.transform.SetParent(_originalParent);
        card.transform.localPosition = new Vector3(_startPosition.x, _startPosition.y);
    }
}
