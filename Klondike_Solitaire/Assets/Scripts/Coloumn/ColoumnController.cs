using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoumnController : MonoBehaviour
{
    [SerializeField] private List<CardColumn> _cardColumns;
    [SerializeField] private CardCreator _cardCreator;
    [SerializeField] private CardMoverController cardMover;

    public void InitColumns(List<CardModel> cardModels)
    {
        int modelIndex = 0;
        for (int i = 0; i < _cardColumns.Count; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Card card = _cardCreator.CreateCard(cardModels[modelIndex]);
                _cardColumns[i].InitCard(card);

                if (j == i)
                {
                    card.Init(cardModels[modelIndex], _cardColumns[i], true); // последн€€ карта на столе лежит рубашкой вверх
                }
                else
                {
                    card.Init(cardModels[modelIndex], _cardColumns[i], false);
                }
                card._dragHandler._OnBeginDrag += cardMover.ReparentCardToTopUI;
                modelIndex++;
            }
        }
    }
}
