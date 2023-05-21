using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoumnController : MonoBehaviour
{
    [SerializeField] List<CardColumn> _cardColumns;
    [SerializeField] CardCreator _cardCreator;

    public void InitColumns(List<CardModel> cardModels)
    {

        int modeleIndx = 0;
        for (int i = 0; i < _cardColumns.Count; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                Card card = _cardCreator.CreateCard(cardModels[modeleIndx]);
                _cardColumns[i].AddCard(card);

                if (j == i)
                {
                    card.Init(cardModels[modeleIndx], false); // последн€€ карта на столе лежит рубашкой вверх
                }
                else
                {
                    card.Init(cardModels[modeleIndx], true);
                }
                modeleIndx++;
            }
        }
    }
}
