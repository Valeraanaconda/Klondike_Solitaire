using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    [SerializeField] private CardColumn _cardColumn;

    public void Awake()
    {
        _cardColumn = GetComponent<CardColumn>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card _movableCard = eventData.pointerDrag.GetComponent<Card>();
        Card lastCardInDropColoumn = _cardColumn.GetLastCard();

        if (_movableCard._cardModel.isFaceUp && lastCardInDropColoumn._cardModel.isFaceUp) //добавить правила что достоинство должно быть ниже последней карты
        {
            _movableCard._isNeedToGoDafultParent = false;
            _cardColumn.AddNewCard(_movableCard);
            _movableCard._currentColoumn.RevomeCard(_movableCard);
        }
    }
}
