using System.Collections.Generic;
using UnityEngine;
using MushroomNocturne.Achievements;

namespace MushroomNocturne.Collectibles
{
    public class CollectibleRegistry : MonoBehaviour
    {
        public static CollectibleRegistry Instance { get; private set; }

        private readonly HashSet<string> _collected = new();
        public int CollectedCount => _collected.Count;

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

        public bool Register(string id)
        {
            bool added = _collected.Add(id);
            if (added && _collected.Count >= 12)
            {
                AchievementService.Instance?.Unlock("archivist");
            }

            return added;
        }
    }
}
