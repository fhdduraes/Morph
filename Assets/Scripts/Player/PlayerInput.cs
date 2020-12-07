using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public (float horizontal, float vertical) Axis => axis;
        public (float x, float y) Mouse => mouse;
        public bool JumpButtonDown { get; private set; }
        public bool IsUsingInput { get; private set; }

        private const string HORIZONTAL_INPUT = "Horizontal";
        private const string VERTICAL_INPUT = "Vertical";
        private const string MOUSEX_INPUT = "Mouse X";
        private const string MOUSEY_INPUT = "Mouse Y";
        private const string JUMP_INPUT = "Jump";

        private (float horizontal, float vertical) axis = (0f, 0f);
        private (float x, float y) mouse = (0f, 0f);

        private void Update()
        {
            axis.horizontal = Input.GetAxis(HORIZONTAL_INPUT);
            axis.vertical = Input.GetAxis(VERTICAL_INPUT);

            mouse.x = Input.GetAxis(MOUSEX_INPUT);
            mouse.y = Input.GetAxis(MOUSEY_INPUT);

            JumpButtonDown = Input.GetButtonDown(JUMP_INPUT);
            IsUsingInput = Input.GetButton(HORIZONTAL_INPUT) || Input.GetButton(VERTICAL_INPUT);
        }

    }
}