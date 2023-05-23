using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardColumn : MonoBehaviour
{
    [SerializeField] private List<Card> cards;
    private Transform _previosSpawnObject;
    private int _initOffset = 25;
    private int _newCardOffset = 50;
    private int _defaultY = -100;

    public void DefaultCard(Card card)
    {
        AddCard(card);
        SetCardPosition(card, _initOffset);
    }

    public void AddNewCard(Card card) //REFACTORING!!!
    {
        AddCard(card);
        SetCardPosition(card, _newCardOffset);
        SetCardPosition(card);
    }

    private void AddCard(Card card)
    {
        cards.Add(card);
    }

    public void RevomeCard(Card card)
    {
        cards.RemoveAll(obj => obj == card);
    }

    public List<Card> GetCardsAfter(Card card)
    {
        int index = cards.IndexOf(card);

        if (index != cards.Count - 1)
        {
            List<Card> list = new List<Card>();
            for (int i = index; i < cards.Count; i++)
            {
                list.Add(cards[i]);
            }
            return list;
        }
        else
        {
            return new List<Card>();
        }
    }

    public Card GetLastCard()
    {
        return cards.LastOrDefault();
    }

    private void SetCardPosition(Card card, int offest)
    {
        card.transform.SetParent(transform);
        Vector3 newPosition = new Vector3();
        if (_previosSpawnObject != null)
        {
            newPosition = _previosSpawnObject.transform.localPosition;
            float newY = newPosition.y - offest;
            newPosition.y = newY;

            card.transform.localPosition = newPosition;
            _previosSpawnObject = card.transform;
        }
        else
        {
            newPosition = card.transform.localPosition;
            newPosition.y = _defaultY;

            card.transform.localPosition = newPosition;
            _previosSpawnObject = card.transform;
        }
        card.transform.localScale = Vector3.one;
    }

    private void SetCardPosition(Card card)
    {
        Vector3 newPosition = new Vector3();

        newPosition = GetLastCard().transform.localPosition;
        

        card.transform.localPosition = newPosition;
        _previosSpawnObject = card.transform;

        card.transform.localScale = Vector3.one;
    }
}
