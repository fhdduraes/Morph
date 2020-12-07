using UnityEngine;

namespace InteractionSystem
{
    public enum InteractionState { Initial, Final }

    public abstract class Interaction : MonoBehaviour
    {
        private InteractionState _currentState = InteractionState.Initial;
        public InteractionState CurrentState
        {
            get => _currentState;
            protected set
            {
                _currentState = value;
                StateHasBeenChanged = true;
            }
        }

        public bool StateHasBeenChanged { get; set; } = false;

        public abstract void Trigger();

        protected void InvertCurrentState() => CurrentState = InvertState(CurrentState);

        private InteractionState InvertState(InteractionState state)
        {
            if (state == InteractionState.Initial)
                return InteractionState.Final;

            return InteractionState.Initial;
        }
    }
}