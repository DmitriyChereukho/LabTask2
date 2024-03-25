using System;
using System.Collections.Generic;
using _Source.Core;
using UnityEngine;

namespace _Source.View
{
    public class CardLayout : MonoBehaviour
    {
        public int LayoutId;
        
        public Vector2 Offset;

        public void Update()
        {
            foreach (var cardView in CardGame.Instance.GetCardInLayout(LayoutId))
            {
                cardView.transform.SetParent(transform);
            }
        }
    }
}