using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScaler : MonoBehaviour
{
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] float scaleRatio;


    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        ScaleImage();
    }
    private void ScaleImage()
    {
        _rectTransform = GetComponent<RectTransform>();
        float diagonal = Mathf.Sqrt(Mathf.Pow(Screen.width, 2) + Mathf.Pow(Screen.height, 2));
        float scaleRatio = 0.08f;
        _rectTransform.sizeDelta = new Vector2(diagonal * scaleRatio, diagonal * scaleRatio);
    }
}
