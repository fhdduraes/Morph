using UnityEngine;

namespace InteractionSystem
{
    public class ToggleLight : Interaction
    {
        [Header("Components")]
        [SerializeField] private MeshRenderer lampMeshRenderer;
        [SerializeField] private Material lampOffMaterial;
        [SerializeField] private Material lampOnMaterial;
        [SerializeField] private Light lampLight;

        [Header("Configuration")]
        [SerializeField] private bool lampIsOn = false;

        private void Awake() 
        {
            CurrentState = lampIsOn ? InteractionState.Initial : InteractionState.Final;
            lampMeshRenderer.material = lampIsOn ? lampOnMaterial : lampOffMaterial;
            lampLight.enabled = lampIsOn;
        }

        public override void Trigger()
        {
            InvertCurrentState();
            lampMeshRenderer.material = lampIsOn ? lampOffMaterial : lampOnMaterial;
            lampLight.enabled = !lampIsOn;
            lampIsOn = !lampIsOn;
        }
    }
}