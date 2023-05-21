using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private DeckManager _deckManager;

    private void Start()
    {
        Init();
    }
    
    private void Init()
    {
        _deckManager.Init();
    }
}
