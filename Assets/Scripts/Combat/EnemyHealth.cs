using UnityEngine;

namespace MushroomNocturne.Combat
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 30;
        [SerializeField] private int contactDamage = 10;

        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - amount);
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerCombatController>();
            if (player != null)
            {
                player.TakeDamage(contactDamage);
            }
        }
    }
}
