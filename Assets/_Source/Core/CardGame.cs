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

        private Dictionary<CardInstance, CardView> _cardDictionary = new();
        
        public int PlayerCount;

        public int HandCapacity;
        
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
            
            StartTurn();
        }

        private void StartGame()
        {
            for (int i = 0; i < PlayerCount; i++)
            {
                for (int j = 0; j < initialCards.Count; j++)
                {
                    CardInstance cardInstance = CreateCard(initialCards[j]);
                
                    CreateCardView(cardInstance);
                    
                }
            }
        }
        
        private void StartTurn()
        {
            int i = 0;
            foreach (var cardInstance in _cardDictionary.Keys)
            {
                cardInstance.MoveToLayout(i / HandCapacity);
                cardInstance.CardPosition = i++ % HandCapacity;
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
        
        public List<CardInstance> GetCardInLayout(int layoutId)
        {
            List<CardInstance> cardInstances = new();
            
            foreach (var cardInstance in _cardDictionary.Keys)
            {
                if (cardInstance.GetLayoutId() == layoutId)
                {
                    cardInstances.Add(cardInstance);
                }
            }

            return cardInstances;
        }

        public CardView GetCardView(CardInstance cardInstance)
        {
            return _cardDictionary[cardInstance];
        }
        
        public void RecalculateLayout(int layoutId)
        {
            int i = 0;
            foreach (var cardInstance in GetCardInLayout(layoutId))
            {
                cardInstance.CardPosition = i++;
            }
        }
        
        public void ShuffleLayout(int layoutId)
        {
            List<CardInstance> cardInstances = GetCardInLayout(layoutId);
            
            for (int i = 0; i < cardInstances.Count - 1; i++)
            {
                int randomIndex = Random.Range(i + 1, cardInstances.Count);
                
                (cardInstances[i].CardPosition, cardInstances[randomIndex].CardPosition) = (cardInstances[randomIndex].CardPosition, cardInstances[i].CardPosition);
            }
        }
    }
}