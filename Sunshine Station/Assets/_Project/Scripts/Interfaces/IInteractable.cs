using UnityEngine;

namespace Sunshine
{
    // THIS MIGHT BE TOTALLY OBSOLETE
    // The way this XR Interaction system works, it might be all built in.
    public interface IInteractable
    {
        /// <summary>
        /// To be called when the player is in range of the interaction and presses the interact key.
        /// </summary>
        void Interact();

        /// <summary>
        /// To be called as soon as the player detects an IInteractable from its interaction-checking function or component.
        /// </summary>
        void OnPlayerEnterRange();

        /// <summary>
        /// To be called when the player leaves interaction range of the _storedInteraction object. Use of this function would require the Player to store the _storedInteraction Object when it's first detected, so it can still be accessed after leaving the trigger collider
        /// </summary>
        void OnPlayerExitRange();
    }
}
