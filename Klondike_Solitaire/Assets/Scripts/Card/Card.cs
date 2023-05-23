using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _sourceImage;
    [SerializeField] private Sprite _backCardSprite;
    public CardColumn _currentColoumn;
    public CardModel _cardModel;
    public DragHandler _dragHandler;
    public bool _isNeedToGoDafultParent;

    public void Init(CardModel cardModel, CardColumn cardColoumn, bool isFaceUp)
    {
        _cardModel = cardModel;
        _cardModel.isFaceUp = isFaceUp;
        _currentColoumn = cardColoumn;
        _dragHandler = GetComponent<DragHandler>();
        
        if (isFaceUp)
        {
            _sourceImage.sprite = _cardModel.faceImage;

        }
        else
        {
            _sourceImage.sprite = _backCardSprite;

        }
    }
}