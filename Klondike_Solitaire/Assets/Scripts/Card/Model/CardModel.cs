using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardModel
{
    public Rank Rank { get; }
    public Suit Suit { get; }
    public bool IsFaceUp { get; set; }

    public CardModel(Rank rank, Suit suit,bool isFaceUp)
    {
        Rank = rank;
        Suit = suit;
        IsFaceUp = isFaceUp;
    }

    public CardModel()
    {
    }
}
