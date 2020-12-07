using UnityEngine;

namespace InteractionSystem
{
    public class InteractionText : MonoBehaviour
    {
        public InteractionState BaseInteractionState => baseInteraction.CurrentState;

        [SerializeField] private Interaction baseInteraction;
        [SerializeField] private string initialText = "Open";
        [SerializeField] private string finalText = "Close";

        public void SetUIBasedOnState(InteractionUI ui)
        {
            ui.SetInteractionText(GetCurrentText());
        }

        public void VerifyForStateChanging(InteractionUI ui)
        {
            if (!baseInteraction.StateHasBeenChanged)
                return;

            SetUIBasedOnState(ui);
            baseInteraction.StateHasBeenChanged = false;
        }

        private string GetCurrentText()
        {
            if (BaseInteractionState == InteractionState.Initial)
                return initialText;

            return finalText;
        }
    }
}