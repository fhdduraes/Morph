using System;
using UnityEngine;

namespace InteractionSystem
{
    public class LerpRotation : Interaction
    {
        [SerializeField] private Transform objectToRotate;
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private float moveDurationInSeconds = 1f;

        private Quaternion startPosition;
        private Quaternion convertedEndPosition;

        private float lerpTimer = 0f;
        private bool startMovementTrigger = false;

        private void Awake()
        {
            startPosition = objectToRotate.localRotation;
            convertedEndPosition = Quaternion.Euler(endPosition);
        }

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

        private void LerpToFinal() => LerpBetweenRotations(startPosition, convertedEndPosition);
        private void LerpToInitial() => LerpBetweenRotations(convertedEndPosition, startPosition);

        private void LerpBetweenRotations(Quaternion start, Quaternion end)
        {
            lerpTimer += Time.deltaTime;
            float percentage = lerpTimer / moveDurationInSeconds;

            objectToRotate.localRotation = Quaternion.Lerp(start, end, percentage);

            if (lerpTimer >= moveDurationInSeconds)
            {
                InvertCurrentState();
                lerpTimer = 0f;
                startMovementTrigger = false;
            }
        }
    }
}