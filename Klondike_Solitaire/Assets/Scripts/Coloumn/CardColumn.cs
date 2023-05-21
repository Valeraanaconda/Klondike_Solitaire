using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardColumn : MonoBehaviour
{
    [SerializeField] private List<Card> cards;
    public Transform _previosSpawmObject;

    public void AddCard(Card card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);
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
        //разместить по правилам
    }
}
