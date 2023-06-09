using System.Collections.Generic;
using UnityEngine;

public class CardCache : MonoBehaviour
{
    [SerializeField] private Transform _buffertraqnsform;

    public void ReparentCardToTopUI(Card card)
    {
        var movableCard = card._currentColoumn;
        List<Card> cards = movableCard.GetCardsAfter(card);
        if (cards != null)
        {
            foreach (var obj in cards)
            {
                obj.transform.SetParent(card.transform);
            }
        }

        card.transform.SetParent(_buffertraqnsform);
    }
}
