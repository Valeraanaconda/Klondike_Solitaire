using UnityEngine;

public class SetSafetyZone : MonoBehaviour
{
    private RectTransform _uiElement;

    private void Start()
    {
        _uiElement = GetComponent<RectTransform>();
        ApplySafeZoneSize();
    }

    private void ApplySafeZoneSize()
    {
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _uiElement.anchorMin = anchorMin;
        _uiElement.anchorMax = anchorMax;
    }
}