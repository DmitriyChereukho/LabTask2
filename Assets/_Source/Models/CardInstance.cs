using System;
using _ScriptableObjects;

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
            _layoutId = layoutId;
        }
        
        public int GetLayoutId()
        {
            return _layoutId;
        }
    }
}