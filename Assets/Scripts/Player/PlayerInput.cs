using UnityEngine;

namespace MushroomNocturne.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 MoveAxis { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool AttackPressed { get; private set; }

        private void Update()
        {
            MoveAxis = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical"));
            JumpPressed = UnityEngine.Input.GetButtonDown("Jump");
            AttackPressed = UnityEngine.Input.GetButtonDown("Fire1");
        }

        public void ConsumeJump()
        {
            JumpPressed = false;
        }

        public void ConsumeAttack()
        {
            AttackPressed = false;
        }
    }
}
