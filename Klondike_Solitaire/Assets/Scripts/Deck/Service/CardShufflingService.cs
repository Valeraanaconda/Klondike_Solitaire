using System.Collections.Generic;
using System;

public class CardShufflingService
{
    public CardShufflingService() { }

    public void ShuffleDeck(List<CardModel> unShuffledDeck)
    {
        Random random = new Random();
        int n = unShuffledDeck.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            CardModel card = unShuffledDeck[k];
            unShuffledDeck[k] = unShuffledDeck[n];
            unShuffledDeck[n] = card;
        }
    }
}
