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
        //ScaleImage();
        if (isCardShowBackSide)
        {
            _sourceImage.sprite = _backCardSprite;
        }
        else
        {
            _sourceImage.sprite = _cardSprite;

        }
    }
    //move init sprite functionalities
    
    void CreateSpriteFromTextureArray()
    {
        Texture2D texture = new Texture2D(_texture2DArray.width, _texture2DArray.height, TextureFormat.RGBA32, false);
        Color[] pixels = _texture2DArray.GetPixels(textureIndex);
        texture.SetPixels(pixels);
        texture.Apply();


        // Создание спрайта из текстуры
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        // Использование спрайта, например, присвоение его в качестве спрайта для спрайтового рендера или SpriteRenderer
        //_sourceImage.sprite = sprite;
        _cardSprite = sprite;
    }

    private void ScaleImage()
    {
        _rectTransform = GetComponent<RectTransform>();
        float diagonal = Mathf.Sqrt(Mathf.Pow(Screen.width, 2) + Mathf.Pow(Screen.height, 2));
        _rectTransform.sizeDelta = new Vector2(diagonal * scaleRatio, diagonal * scaleRatio);
    }

    //move functionalities
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
    //
}