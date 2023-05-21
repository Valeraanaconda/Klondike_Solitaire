using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<CardModel> _deck;
    [SerializeField] private List<CardModel> _playDeck;
    [SerializeField] private Texture2DArray _texture2DArray;
    [SerializeField] private ColoumnController _coloumnController;

    private CardShufflingService _cardShufflingService;
    private CardModelCreationService _cardCreationService;
    private SpriteConverter _spriteConverter;

    public void Init()
    {
        InitServices();
        _deck = _cardCreationService.CreateCards(_spriteConverter.ConvertToSprites(_texture2DArray));
        //get play deck
        _playDeck = CloneList(_deck);
        _coloumnController.InitColumns(_playDeck);
    }

    private void InitServices()
    {
        _cardShufflingService = new CardShufflingService();
        _cardCreationService = new CardModelCreationService();
        _spriteConverter = new SpriteConverter();
    }

    //TODO Refactor
    static List<T> CloneList<T>(List<T> originalList)
    {
        List<T> clonedList = new List<T>(originalList);
        return clonedList;
    }
}
