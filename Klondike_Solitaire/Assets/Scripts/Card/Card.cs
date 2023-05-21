using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{ 
    //TODO extract view
    [SerializeField] private Image _sourceImage;
    [SerializeField] private Sprite _backCardSprite;

    [SerializeField] CardModel _cardModel;


    public void Init(CardModel cardModel, bool isFaceUp)
    {
        _cardModel = cardModel;
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