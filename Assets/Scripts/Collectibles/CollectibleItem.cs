using UnityEngine;

namespace MushroomNocturne.Collectibles
{
    public class CollectibleItem : MonoBehaviour
    {
        [SerializeField] private string collectibleId;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (CollectibleRegistry.Instance == null) return;

            if (CollectibleRegistry.Instance.Register(collectibleId))
            {
                Destroy(gameObject);
            }
        }
    }
}
