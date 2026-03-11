using UnityEngine;

namespace MushroomNocturne.Trading
{
    [CreateAssetMenu(menuName = "MushroomNocturne/Trade Item")]
    public class TradeItem : ScriptableObject
    {
        public string itemId;
        public string displayName;
        public int price;
    }
}
