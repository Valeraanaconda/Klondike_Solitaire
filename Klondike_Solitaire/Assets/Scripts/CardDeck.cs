using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private List<Card> _cards;

    [SerializeField] private Texture2DArray _texture2DArray;

    [SerializeField] TextMeshProUGUI _cardCount;

    private void Awake()
    {
        _cardCount.text = _texture2DArray.depth.ToString();
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        
    }
}
