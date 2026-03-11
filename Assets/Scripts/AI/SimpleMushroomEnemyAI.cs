using UnityEngine;

namespace MushroomNocturne.AI
{
    public class SimpleMushroomEnemyAI : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float detectionRange = 6f;
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float stopDistance = 1.2f;

        private void Update()
        {
            if (player == null) return;

            float distance = Vector2.Distance(transform.position, player.position);
            if (distance > detectionRange || distance < stopDistance) return;

            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }
}
