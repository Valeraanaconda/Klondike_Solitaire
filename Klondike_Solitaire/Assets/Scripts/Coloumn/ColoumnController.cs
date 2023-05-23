using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoumnController : MonoBehaviour
{
    [SerializeField] private List<CardColumn> _cardColumns;
    [SerializeField] private CardCreator _cardCreator;
    [SerializeField] private CardMoverController cardMover;

    public void InitColumns(List<CardModel> cardModels,List<Card> waste)
    {
        int modelIndex = 0;
        for (int i = 0; i < _cardColumns.Count; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Card card = _cardCreator.CreateCard(cardModels[modelIndex]);
                _cardColumns[i].DefaultCard(card);

                if (j == i)
                {
                    card.Init(cardModels[modelIndex], _cardColumns[i], true);
                }
                else
                {
                    card.Init(cardModels[modelIndex], _cardColumns[i], false);
                }
                card._dragHandler._OnBeginDrag += cardMover.ReparentCardToTopUI;
                modelIndex++;
            }
        }

        for (int i = modelIndex; i < cardModels.Count; i++)
        {
            Card card = _cardCreator.CreateCard(cardModels[modelIndex]);
            waste.Add(card);
        }
    }
}
