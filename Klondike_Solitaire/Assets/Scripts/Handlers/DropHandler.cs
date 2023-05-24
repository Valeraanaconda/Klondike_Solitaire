using System.Collections.Generic;
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

        if (_movableCard._currentColoumn == _cardColumn)
        {
            return;
        }


        if (_movableCard.transform.childCount > 0)
        {
            List<Card> childCards = new List<Card>
            {
                _movableCard
            };
            GetcChildList(_movableCard, childCards);
            foreach (Card card in childCards)
            {
                AddCard(card, lastCardInDropColoumn);
            }
        }
        else
        {
            AddCard(_movableCard, lastCardInDropColoumn);
        }
    }

    private static void GetcChildList(Card _movableCard, List<Card> childCards)
    {
        for (int i = 0; i < _movableCard.transform.childCount; i++)
        {
            Card childCard = _movableCard.transform.GetChild(i).GetComponent<Card>();

            if (childCard != null)
            {
                childCards.Add(childCard);
            }
        }
    }

    private void AddCard(Card _movableCard, Card lastCardInDropColoumn)
    {
        if (_movableCard._cardModel.isFaceUp && lastCardInDropColoumn._cardModel.isFaceUp)
        {
            _movableCard._isNeedToGoDafultParent = false;
            _cardColumn.AddNewCard(_movableCard);
            _movableCard._currentColoumn.RevomeCard(_movableCard);
            _movableCard._currentColoumn = _cardColumn;
        }
    }
}
