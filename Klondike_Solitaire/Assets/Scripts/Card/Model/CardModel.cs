using UnityEngine;

public class CardModel
{
    [SerializeField] private Rank rank;
    [SerializeField] private Suit suit;
    [SerializeField] public Sprite faceImage;
    [SerializeField] public bool isFaceUp;


    public CardModel(Rank rank, Suit suit, bool isFaceUp, Sprite faceImage)
    {
        this.rank = rank;
        this.suit = suit;
        this.faceImage = faceImage;
        this.isFaceUp = isFaceUp;
    }

    public CardModel()
    {
    }
}
