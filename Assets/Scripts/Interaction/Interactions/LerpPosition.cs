using UnityEngine;

namespace InteractionSystem
{
    public class LerpPosition : Interaction
    {
        [SerializeField] private Transform objectToMove;
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private float moveDurationInSeconds = 1f;

        private Vector3 startPosition;
        private float lerpTimer = 0f;
        private bool startMovementTrigger = false;

        private void Awake() => startPosition = objectToMove.localPosition;

        private void Update() => CheckForTrigger();

        public override void Trigger() => startMovementTrigger = true;

        private void CheckForTrigger()
        {
            if (!startMovementTrigger)
                return;

            if (CurrentState == InteractionState.Initial)
            {
                LerpToFinal();
                return;
            }

            LerpToInitial();
        }

        private void LerpToFinal() => LerpBetweenPositions(startPosition, endPosition);
        private void LerpToInitial() => LerpBetweenPositions(endPosition, startPosition);

        private void LerpBetweenPositions(Vector3 start, Vector3 end)
        {
            lerpTimer += Time.deltaTime;
            float percentage = lerpTimer / moveDurationInSeconds;

            objectToMove.localPosition = Vector3.Lerp(start, end, percentage);

            if (lerpTimer >= moveDurationInSeconds)
            {
                InvertCurrentState();
                lerpTimer = 0f;
                startMovementTrigger = false;
            }
        }
    }
}