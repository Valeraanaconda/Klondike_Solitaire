using UnityEngine;

public class CardCreator : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;

    public Card CreateCard(CardModel cardModel)
    {
        var card = Instantiate(_cardPrefab);
        return card;    
    }
}
