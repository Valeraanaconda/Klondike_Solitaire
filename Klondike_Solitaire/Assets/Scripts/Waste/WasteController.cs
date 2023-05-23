using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WasteController : MonoBehaviour
{
    [SerializeField] private List<Card> _wasteCards;
    [SerializeField] private TextMeshProUGUI _wasteCount;

    public void Init(List<Card> cards)
    {
        _wasteCards = cards;
        SetWasteCount(_wasteCards.Count);
    }

    private void SetWasteCount(int value)
    {
        _wasteCount.text = value.ToString();
    }
}
