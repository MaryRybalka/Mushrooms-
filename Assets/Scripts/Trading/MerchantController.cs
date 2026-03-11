using System.Collections.Generic;
using UnityEngine;
using MushroomNocturne.Achievements;

namespace MushroomNocturne.Trading
{
    public class MerchantController : MonoBehaviour
    {
        [SerializeField] private List<TradeItem> stock = new();

        public bool TryBuy(TradeItem item, PlayerWallet wallet)
        {
            if (item == null || wallet == null) return false;
            if (!stock.Contains(item)) return false;
            if (!wallet.Spend(item.price)) return false;

            AchievementService.Instance?.IncrementCounter("items_bought", 1);
            Debug.Log($"Purchased: {item.displayName}");
            return true;
        }
    }
}
