using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Image _sourceImage;
    [SerializeField] private Sprite _backCardSprite;

    [SerializeField] CardModel _cardModel;
    private RectTransform _rectTransform;
    private Vector2 _offest;
    private Sprite _cardSprite;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Init(CardModel cardModel,bool isCardShowBackSide)
    {
        _cardModel = cardModel;
        if (isCardShowBackSide)
        {
            _sourceImage.sprite = _backCardSprite;
        }
        else
        {
            _sourceImage.sprite = _cardModel.faceImage;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPos = eventData.position + _offest;
        _rectTransform.position = newPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 vec = new Vector2(_rectTransform.position.x, _rectTransform.position.y);
        _offest = vec - eventData.position;
    }
}