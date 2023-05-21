using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    private CardColumn _cardColumn;

    private void Awake()
    {
        _cardColumn = GetComponent<CardColumn>();
    }

    public void OnDrop(PointerEventData eventData)
    {

        Card _movableCard = eventData.pointerDrag.GetComponent<Card>();
        _cardColumn.AddCard(_movableCard);
    }

}
