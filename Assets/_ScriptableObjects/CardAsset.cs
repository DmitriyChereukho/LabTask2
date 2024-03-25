using UnityEngine;

namespace _ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Card", menuName = "CardGame/CardAsset")]
    public class CardAsset : ScriptableObject
    {
        public string cardName;
        public Color cardColor;
        public Sprite cardImage;
        public Sprite cardBack;
    }
}