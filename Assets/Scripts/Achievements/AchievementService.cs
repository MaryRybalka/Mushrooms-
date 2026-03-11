using System.Collections.Generic;
using UnityEngine;

namespace MushroomNocturne.Achievements
{
    public class AchievementService : MonoBehaviour
    {
        public static AchievementService Instance { get; private set; }

        private readonly HashSet<string> _unlocked = new();
        private readonly Dictionary<string, int> _counters = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void Unlock(string id)
        {
            if (_unlocked.Add(id))
            {
                Debug.Log($"Achievement unlocked: {id}");
            }
        }

        public void IncrementCounter(string id, int amount)
        {
            _counters.TryGetValue(id, out int value);
            value += amount;
            _counters[id] = value;

            if (id == "items_bought" && value >= 10)
            {
                Unlock("merchant_of_the_day");
            }
        }

        public bool IsUnlocked(string id) => _unlocked.Contains(id);
    }
}
