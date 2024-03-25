using _Source.Core;
using _Source.Models;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.View
{
    public class CardView : MonoBehaviour
    {
        private CardInstance _cardInstance;
        
        [SerializeField]
        private Image _cardImage;
        
        [SerializeField]
        private Image _cardBack;

        public void Init(CardInstance cardInstance)
        {
            _cardInstance = cardInstance;
            
            _cardImage.sprite = cardInstance.Asset.cardImage;
            //_cardImage.color = cardInstance.Asset.cardColor;
            
            _cardBack.sprite = cardInstance.Asset.cardBack;
            //_cardBack.color = cardInstance.Asset.cardColor;
        }
        
    }
}