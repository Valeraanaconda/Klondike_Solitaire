using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardColumn : MonoBehaviour
{
    [SerializeField] private List<Card> cards;
    [SerializeField] private int _coloumnIndex;
    private Transform _previosSpawmObject;

    public void SetColoumnNumber(int index)
    {
        _coloumnIndex = index;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
        SetDefaultPosition(card);
    }

    private void SetDefaultPosition(Card card)
    {
        card.transform.SetParent(transform);
        //TODO Refactor
        if (_previosSpawmObject != null)
        {
            Vector3 newPosition = _previosSpawmObject.transform.localPosition;
            float newY = newPosition.y - 25f;
            newPosition.y = newY;

            // Применение новой позиции к изображению
            card.transform.localPosition = newPosition;
            _previosSpawmObject = card.transform;
        }
        else
        {
            Vector3 newPosition = card.transform.localPosition;
            float newY = 100 * (-1);
            newPosition.y = newY;

            // Применение новой позиции к изображению
            card.transform.localPosition = newPosition;
            _previosSpawmObject = card.transform;
        }
        card.transform.localScale = Vector3.one;
    }
}
