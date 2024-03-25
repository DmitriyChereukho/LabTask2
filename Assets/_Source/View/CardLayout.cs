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
        
        public bool FaceUp;

        public void Update()
        {
            foreach (var cardInstance in CardGame.Instance.GetCardInLayout(LayoutId))
            {
                CardView cardView = CardGame.Instance.GetCardView(cardInstance);
                
                Flip(cardView);
                
                RectTransform viewTransform;
                (viewTransform = cardView.transform as RectTransform)!.SetParent(transform, false);
                viewTransform!.anchoredPosition = new Vector3(Offset.x * cardInstance.CardPosition, 0, 0);
                viewTransform.SetSiblingIndex(cardInstance.CardPosition);
            }
        }

        private void Flip(CardView cardView)
        {
            cardView.Rotate(FaceUp);
        }
    }
}