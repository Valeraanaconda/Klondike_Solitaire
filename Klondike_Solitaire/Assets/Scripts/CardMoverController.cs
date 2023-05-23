using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardMoverController : MonoBehaviour
{
    [SerializeField] private Transform _buffertraqnsform;

    public void ReparentCardToTopUI(Card card)
    {
        card.transform.SetParent(_buffertraqnsform);
    }
}
