using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<CardModel> _deck;
    [SerializeField] private Texture2DArray _texture2DArray;

    private CardShufflingService _cardShufflingService;
    private CardCreationService _cardCreationService;
    private SpriteConverter _spriteConverter;

    public void Init()
    {
        InitServices();
        _deck = _cardCreationService.CreateCards(_spriteConverter.ConvertToSprites(_texture2DArray));
    }

    private void InitServices()
    {
        _cardShufflingService = new CardShufflingService();
        _cardCreationService = new CardCreationService();
        _spriteConverter = new SpriteConverter();
    }
}
