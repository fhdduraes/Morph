using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Scripts")]
        public PlayerInput PlayerInput;
        public PlayerMovement PlayerMovement;
        public PlayerSound PlayerSound;
        public PlayerMouse PlayerMouse;

        [Header("Player Components")]
        public CharacterController CharacterController;
        public Transform PlayerBody;
        public Camera PlayerCamera;
        public AudioSource WalkingAudioSource;

        private void Awake() => PlayerBody = transform;
    }
}