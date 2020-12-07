using UnityEngine;

namespace InteractionSystem
{
    public class InteractionBrowser : MonoBehaviour
    {
        [SerializeField] private InteractionUI interactionUI;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private float raycastDistance;

        private InteractionController currentController;
        private Transform cameraTransform;
        private bool canInteract = false;

        private void Awake() => cameraTransform = mainCamera.transform;

        private void FixedUpdate() => CheckRaycast();

        private void Update()
        {
            if (canInteract && Input.GetButtonDown("Fire1"))
                currentController.RaycastTrigger();
        }

        private void CheckRaycast()
        {
            bool raycastResult = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, raycastDistance);
            GameObject foundGameObject = raycastResult ? hit.collider.gameObject : null;

            if (raycastResult && ((1 << foundGameObject.layer) & interactableLayer) != 0)
            {
                if (currentController == null || foundGameObject != currentController.gameObject)
                {
                    currentController = foundGameObject.GetComponent<InteractionController>();
                    currentController.RaycastEnter(interactionUI);
                }
                else
                {
                    currentController.RaycastStay(interactionUI);
                }

                canInteract = true;
            }
            else if (currentController != null)
            {
                interactionUI.ClearInteractionText();
                currentController = null;
                canInteract = false;
            }
        }
    }
}