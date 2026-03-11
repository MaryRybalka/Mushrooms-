using UnityEngine;

namespace MushroomNocturne.Combat
{
    public class PlayerCombatController : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int currentHealth = 100;
        [SerializeField] private int lightAttackDamage = 20;
        [SerializeField] private float attackRadius = 1.1f;
        [SerializeField] private LayerMask enemyLayer;

        [Header("Timing")]
        [SerializeField] private float attackCooldown = 0.35f;
        [SerializeField] private float dodgeInvulnerabilityTime = 0.25f;

        private float _nextAttackTime;
        private bool _isInvulnerable;

        public int CurrentHealth => currentHealth;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                TryLightAttack();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(PerformDodge());
            }
        }

        public void TakeDamage(int amount)
        {
            if (_isInvulnerable) return;

            currentHealth = Mathf.Max(0, currentHealth - amount);
            if (currentHealth <= 0)
            {
                Debug.Log("Player defeated.");
            }
        }

        public void RestoreFullHealth()
        {
            currentHealth = maxHealth;
        }

        private void TryLightAttack()
        {
            if (Time.time < _nextAttackTime) return;

            _nextAttackTime = Time.time + attackCooldown;
            var hits = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);

            foreach (var hit in hits)
            {
                var health = hit.GetComponent<EnemyHealth>();
                if (health != null)
                {
                    health.TakeDamage(lightAttackDamage);
                }
            }
        }

        private System.Collections.IEnumerator PerformDodge()
        {
            _isInvulnerable = true;
            yield return new WaitForSeconds(dodgeInvulnerabilityTime);
            _isInvulnerable = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
    }
}
