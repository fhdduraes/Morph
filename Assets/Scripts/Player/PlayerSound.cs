using UnityEngine;

namespace Player
{
    public class PlayerSound : MonoBehaviour
    {
        [SerializeField] private PlayerController controller;

        private void Update()
        {
            bool isPaused = !controller.WalkingAudioSource.isPlaying;
            bool isGrounded = controller.PlayerMovement.PlayerIsGrounded;
            bool isUsingInput = controller.PlayerInput.IsUsingInput;

            if (isPaused)
            {
                if (isUsingInput && isGrounded)
                    controller.WalkingAudioSource.UnPause();
            }

            else if (!isUsingInput || !isGrounded)
                controller.WalkingAudioSource.Pause();

            if (isGrounded && controller.PlayerInput.JumpButtonDown)
                controller.WalkingAudioSource.Pause();
        }
    }
}