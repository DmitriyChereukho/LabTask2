using System;
using _ScriptableObjects;
using _Source.Core;

namespace _Source.Models
{
    public class CardInstance
    {
        public CardAsset Asset { get; }
        private int _layoutId;
        public int CardPosition;

        public CardInstance(CardAsset cardAsset)
        {
            Asset = cardAsset;
        }

        public void MoveToLayout(int layoutId)
        {
            int previousLayoutId = _layoutId;
            _layoutId = layoutId;
            CardGame.Instance.RecalculateLayout(_layoutId);
            CardGame.Instance.RecalculateLayout(previousLayoutId);
        }
        
        public int GetLayoutId()
        {
            return _layoutId;
        }
    }
}