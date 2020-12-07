using UnityEngine;

public class ChangeTriggerStateOnCollision : MonoBehaviour
{
    [SerializeField] private Collider otherCollider;
    [SerializeField] private bool isTriggerState;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            otherCollider.isTrigger = isTriggerState;
    }
}
