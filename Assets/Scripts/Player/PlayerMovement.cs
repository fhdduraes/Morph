using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool PlayerIsGrounded { get; private set; } = false;

        [SerializeField] private PlayerController controller;

        [Header("Configuration")]
        [SerializeField] private float speed = 4.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private Vector3 groundOffset;
        [SerializeField] private float groundDistance;

        private readonly float gravity = Physics.gravity.y;
        private Vector3 verticalMovement = Vector3.zero;

        private void FixedUpdate()
        {
            PlayerIsGrounded = Physics.Raycast(transform.position + groundOffset, -transform.up, groundDistance);

            if (PlayerIsGrounded && controller.PlayerInput.JumpButtonDown)
                verticalMovement.y = Mathf.Sqrt(-jumpHeight * gravity);

            Vector3 horizontalMovement = transform.right * controller.PlayerInput.Axis.horizontal;
            horizontalMovement += transform.forward * controller.PlayerInput.Axis.vertical;
            verticalMovement.y += gravity * Time.deltaTime;

            controller.CharacterController.Move((horizontalMovement * speed + verticalMovement) * Time.deltaTime);
        }

        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 groundOrigin = transform.position + groundOffset;
            Gizmos.DrawLine(groundOrigin, groundOrigin + -transform.up * groundDistance);
        }
        #endif
    }
}