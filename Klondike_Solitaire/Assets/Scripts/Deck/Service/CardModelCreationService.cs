using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModelCreationService
{
    public CardModelCreationService() { }

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
                Suit cardSuit = Suit.None;
                CardModel card = new CardModel();

                switch (row)
                {
                    case 0:
                        cardSuit = Suit.Hearts;
                        break;
                    case 1:
                        cardSuit = Suit.Diamonds;
                        break;
                    case 2:
                        cardSuit = Suit.Clubs;
                        break;
                    case 3:
                        cardSuit = Suit.Spades;
                        break;
                }

                if (inputSprites[row, col] != null)
                {
                    card = new CardModel(rank, cardSuit, false, inputSprites[row, col]);
                    outputList.Add(card);
                }
            }
        }

        return outputList;
    }
}
