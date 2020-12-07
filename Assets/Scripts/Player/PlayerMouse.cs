using UnityEngine;

namespace Player
{
    public class PlayerMouse : MonoBehaviour
    {
        [SerializeField] private PlayerController controller;
        [SerializeField] private float mouseSensitivity = 150.0f;
        private float xRotation = 0.0f;

        void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float mouseX = controller.PlayerInput.Mouse.x * mouseSensitivity * Time.deltaTime;
            float mouseY = controller.PlayerInput.Mouse.y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            controller.PlayerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            controller.PlayerBody.Rotate(Vector3.up, mouseX);
        }
    }
}