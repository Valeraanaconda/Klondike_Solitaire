using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardColumn : MonoBehaviour
{
    [SerializeField] private List<Card> cards;
    private Transform _previosSpawmObject;
    private int _initOffset = 25;
    private int _newCardOffset = 50;
    private int _defaultY = -100;

    public void InitCard(Card card) // rename
    {
        AddCard(card);
        SetDefaultPosition(card, _initOffset);
    }

    public void AddNewCard(Card card)
    {
        AddCard(card);
        SetDefaultPosition(card, _newCardOffset);
    }

    private void AddCard(Card card)
    {
        cards.Add(card);
    }

    public void RevomeCard(Card card)
    {
        foreach (var obj in cards)
        {
            if (obj == card)
            {
                cards.Remove(obj);
                return;
            }
        }
    }

    public Card GetLastCard()
    {
        return cards.LastOrDefault();
    }

    private void SetDefaultPosition(Card card, int offest)
    {
        card.transform.SetParent(transform);
        Vector3 newPosition = new Vector3();
        if (_previosSpawmObject != null)
        {
            newPosition = _previosSpawmObject.transform.localPosition;
            float newY = newPosition.y - offest;
            newPosition.y = newY;

            card.transform.localPosition = newPosition;
            _previosSpawmObject = card.transform;
        }
        else
        {

            newPosition = card.transform.localPosition;
            newPosition.y = _defaultY;

            card.transform.localPosition = newPosition;
            _previosSpawmObject = card.transform;
        }
        card.transform.localScale = Vector3.one;
    }
}
