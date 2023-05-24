using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WasteController : MonoBehaviour
{
    [SerializeField] private List<Card> _wasteCards;
    [SerializeField] private Transform _waste;
    [SerializeField] private TextMeshProUGUI _wasteCount;

    public void Init(List<Card> cards)
    {
        _wasteCards = cards;
        SetWasteCount(_wasteCards.Count);
        SetcardsInWaste();
    }

    private void SetWasteCount(int value)
    {
        _wasteCount.text = value.ToString();
    }

    private void SetcardsInWaste()
    {
        foreach (var card in _wasteCards)
        {
            card.transform.SetParent(_waste);
            card.gameObject.SetActive(false);
        }
    }
}
