using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardModel
{
    [SerializeField] private Rank rank;
    [SerializeField] private Suit suit;
    [SerializeField] public Sprite faceImage; //TODO Refactor create property

    public bool IsFaceUp { get; set; }

    public CardModel(Rank rank, Suit suit, bool isFaceUp, Sprite faceImage)
    {
        this.rank = rank;
        this.suit = suit;
        this.faceImage = faceImage;
        IsFaceUp = isFaceUp;
    }

    public CardModel()
    {
    }
}
