using System.Collections.Generic;
using _ScriptableObjects;
using _Source.Models;
using _Source.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Source.Core
{
    
    public class CardGame : MonoBehaviour
    {
        private static CardGame _instance;

        public int LayoutsCount;

        private Dictionary<CardInstance, CardView> _cardDictionary = new();
        
        public List<CardAsset> initialCards;
        
        public List<GameObject> layouts;
        
        [SerializeField]
        private GameObject _cardViewPrefab;
        
        public static CardGame Instance => _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            for (int i = 0; i < LayoutsCount; i++)
            {
                foreach (var cardAsset in initialCards)
                {
                    CardInstance cardInstance = CreateCard(cardAsset);
                
                    CreateCardView(cardInstance);
                    
                    cardInstance.MoveToLayout(i);
                }
            }
        }

        private CardInstance CreateCard(CardAsset cardAsset)
        {
            return new CardInstance(cardAsset);
        }
        
        private void CreateCardView(CardInstance cardInstance)
        {
            CardView cardViewObject = Instantiate(_cardViewPrefab, transform).GetComponent<CardView>();
            cardViewObject.Init(cardInstance);
            
            _cardDictionary.Add(cardInstance, cardViewObject);
        }
        
        public List<CardView> GetCardInLayout(int layoutId)
        {
            List<CardView> cardViews = new();
            
            foreach (var card in _cardDictionary)
            {
                if (card.Key.GetLayoutId() == layoutId)
                {
                    cardViews.Add(card.Value);
                }
            }

            return cardViews;
        }
    }
}