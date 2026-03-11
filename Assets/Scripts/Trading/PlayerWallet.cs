using UnityEngine;

namespace MushroomNocturne.Trading
{
    public class PlayerWallet : MonoBehaviour
    {
        [SerializeField] private int sporeDust = 100;

        public int Balance => sporeDust;

        public bool Spend(int amount)
        {
            if (sporeDust < amount) return false;
            sporeDust -= amount;
            return true;
        }

        public void Add(int amount)
        {
            sporeDust += amount;
        }
    }
}
