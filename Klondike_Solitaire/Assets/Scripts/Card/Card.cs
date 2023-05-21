using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Texture2DArray _texture2DArray;
    [SerializeField] private Image _sourceImage;
    [SerializeField] private Sprite _backCardSprite;
    [SerializeField] float scaleRatio;

    [SerializeField] private int textureIndex;

    private RectTransform _rectTransform;
    private Vector2 _offest;
    private Sprite _cardSprite;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void Init(bool isCardShowBackSide)
    {
        CreateSpriteFromTextureArray();
        if (isCardShowBackSide)
        {
            _sourceImage.sprite = _backCardSprite;
        }
        else
        {
            _sourceImage.sprite = _cardSprite;

        }
    }
    
    void CreateSpriteFromTextureArray()
    {
        Texture2D texture = new Texture2D(_texture2DArray.width, _texture2DArray.height, TextureFormat.RGBA32, false);
        Color[] pixels = _texture2DArray.GetPixels(textureIndex);
        texture.SetPixels(pixels);
        texture.Apply();

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        _cardSprite = sprite;
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