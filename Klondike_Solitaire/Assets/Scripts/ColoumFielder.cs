using UnityEngine;

public class ColoumFielder : MonoBehaviour
{
    [SerializeField] Card _cardPrefab;
    [SerializeField] RectTransform _parent;
    [SerializeField] int _spawnValue;
    [SerializeField] float _spawnOffset;
    public Transform _previosSpawmObject;
    
    void Start()
    {
        _parent = GetComponent<RectTransform>();
        for (int i = 0; i < _spawnValue; i++)
        {
            if (i == _spawnValue-1)
            {
                InstantiateCard(false);
            }
            else 
            {
                InstantiateCard(true);
            }
        }
    }

    private void InstantiateCard(bool v)
    {
        var card = Instantiate(_cardPrefab);
        //card.Init(v);
        card.transform.SetParent(_parent);
        if (_previosSpawmObject != null)
        {
            Vector3 newPosition = _previosSpawmObject.transform.localPosition;
            float newY = newPosition.y - _spawnOffset;
            newPosition.y = newY;

            // Применение новой позиции к изображению
            card.transform.localPosition = newPosition;
            _previosSpawmObject = card.transform;
        }
        else
        {
            Vector3 newPosition = card.transform.localPosition;
            float newY = 100*(-1);
            newPosition.y = newY;

            // Применение новой позиции к изображению
            card.transform.localPosition = newPosition;
            _previosSpawmObject = card.transform;
        }
        card.transform.localScale = Vector3.one;
    }
}
