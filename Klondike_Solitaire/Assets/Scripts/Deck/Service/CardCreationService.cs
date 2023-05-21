using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardCreationService
{
    public CardCreationService() { }

    public List<CardModel> CreateCards(Sprite[,] inputSprites)
    {

        List<CardModel> outputList = new List<CardModel>();

        int rows = inputSprites.GetLength(0);
        int columns = inputSprites.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Rank rank = (Rank)col;
                CardModel card = new CardModel();

                switch (row)
                {
                    case 0:
                        card = new(rank, Suit.Hearts, false);
                        outputList.Add(card);
                        break;
                    case 1:
                        card = new(rank, Suit.Diamonds, false);
                        outputList.Add(card);
                        break;
                    case 2:
                        card = new(rank, Suit.Clubs, false);
                        outputList.Add(card);
                        break;
                    case 3:
                        card = new(rank, Suit.Spades, false);
                        outputList.Add(card);
                        break;
                }
            }
        }

        return outputList;
    }
}
