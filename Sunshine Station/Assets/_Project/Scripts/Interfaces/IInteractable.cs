using UnityEngine;

namespace Sunshine
{
    public interface IInteractable
    {
        /// <summary>
        /// To be called when the player presses the interact key.
        /// </summary>
        void Interact(Hand hand);

        /// <summary>
        /// To be called as soon as the player detects an IProximityTrigger from its interaction-checking function or component.
        /// </summary>
        void ControllerEnter(Hand hand);

        /// <summary>
        /// To be called when the player leaves a collider
        /// </summary>
        void ControllerExit(Hand hand);
    }
}
