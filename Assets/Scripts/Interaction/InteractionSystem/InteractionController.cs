using UnityEngine;

namespace InteractionSystem
{
    public class InteractionController : MonoBehaviour
    {
        private InteractionText interactionText;
        private Interaction[] interactions;

        private void Awake()
        {
            interactions = GetComponents<Interaction>();
            interactionText = GetComponent<InteractionText>();
        }

        public void RaycastEnter(InteractionUI interactionUI)
        {
            interactionText.SetUIBasedOnState(interactionUI);
        }

        public void RaycastStay(InteractionUI interactionUI)
        {
            interactionText.VerifyForStateChanging(interactionUI);
        }

        public void RaycastTrigger()
        {
            foreach (Interaction interaction in interactions)
                interaction.Trigger();
        }
    }
}