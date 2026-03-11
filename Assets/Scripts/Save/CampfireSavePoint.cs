using UnityEngine;
using MushroomNocturne.Combat;
using MushroomNocturne.Collectibles;
using MushroomNocturne.Achievements;

namespace MushroomNocturne.Save
{
    public class CampfireSavePoint : MonoBehaviour
    {
        [SerializeField] private string campfireId;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            var player = other.GetComponent<PlayerCombatController>();
            if (player == null) return;

            player.RestoreFullHealth();

            SaveSystem.Save(new SaveData
            {
                lastCampfireId = campfireId,
                playerHealth = player.CurrentHealth,
                collectedChronicles = CollectibleRegistry.Instance?.CollectedCount ?? 0
            });

            AchievementService.Instance?.Unlock("first_campfire");
            Debug.Log($"Saved at campfire: {campfireId}");
        }
    }
}
