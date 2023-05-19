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
    public int textureIndex;

    private RectTransform _rectTransform;
    private Vector2 _offest;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        Debug.Log(_texture2DArray.depth);
        CreateSpriteFromTextureArray();
    }

    //move init sprite functionalities
    
    void CreateSpriteFromTextureArray()
    {
        // Получение текстуры из Texture2DArray
        Texture2D texture = new Texture2D(_texture2DArray.width, _texture2DArray.height, TextureFormat.RGBA32, false);
        Color[] pixels = _texture2DArray.GetPixels(textureIndex);
        texture.SetPixels(pixels);
        texture.Apply();


        // Создание спрайта из текстуры
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        // Использование спрайта, например, присвоение его в качестве спрайта для спрайтового рендера или SpriteRenderer
        _sourceImage.sprite = sprite;
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