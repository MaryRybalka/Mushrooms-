using UnityEngine;

namespace MushroomNocturne.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 8f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.2f;
        [SerializeField] private LayerMask groundLayer;

        private Rigidbody2D _rigidbody;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<PlayerInput>();
        }

        private void FixedUpdate()
        {
            var velocity = _rigidbody.velocity;
            velocity.x = _playerInput.MoveAxis.x * moveSpeed;
            _rigidbody.velocity = velocity;

            if (_playerInput.JumpPressed && IsGrounded())
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            _playerInput.ConsumeJump();
        }

        private bool IsGrounded()
        {
            if (groundCheck == null)
            {
                return false;
            }

            return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
        }

        private void OnDrawGizmosSelected()
        {
            if (groundCheck == null)
            {
                return;
            }

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
