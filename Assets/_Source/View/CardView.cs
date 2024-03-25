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
            
            gameObject.name = cardInstance.Asset.cardName;
            
            _cardImage.sprite = cardInstance.Asset.cardImage;
            
            _cardBack.sprite = cardInstance.Asset.cardBack;
        }
        
        public void Rotate(bool isViewed)
        {
            _cardImage.gameObject.SetActive(isViewed);
        }

       public void PlayCard()
        {
            //throw new System.NotImplementedException();
            _cardInstance.MoveToLayout(2);
        }
    }
}