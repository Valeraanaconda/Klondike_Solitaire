using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [HideInInspector] private List<CardModel> _deck;
    [SerializeField] private List<CardModel> _playDeck;
    [SerializeField] private ColumnController _coloumnController;
    [SerializeField] private WasteController _wasteController;

    private CardShufflingService _cardShufflingService;
    private CardModelCreationService _cardCreationService;
    private SpriteConverter _spriteConverter;

    public void Init()
    {
        List<Card> waste = new List<Card>();
        InitServices();
        Sprite[,] cardSprites = _spriteConverter.ConvertToSprites();

        _deck = _cardCreationService.CreateCards(cardSprites);
        _playDeck = CloneList(_deck);
        _cardShufflingService.ShuffleDeck(_playDeck);
        _coloumnController.InitColumns(_playDeck, waste);
        _wasteController.Init(waste);
    }

    private void InitServices()
    {
        _cardShufflingService = new CardShufflingService();
        _cardCreationService = new CardModelCreationService();
        _spriteConverter = new SpriteConverter();
    }

    public static List<T> CloneList<T>(List<T> originalList)
    {
        List<T> clonedList = new List<T>(originalList);
        return clonedList;
    }
}
