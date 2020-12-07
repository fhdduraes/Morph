using TMPro;
using UnityEngine;

namespace InteractionSystem
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI interactionText;

        private void Start() => ClearInteractionText();

        public void SetInteractionText(string newText) => interactionText.SetText(newText);

        public void ClearInteractionText() => SetInteractionText(string.Empty);
    }
}