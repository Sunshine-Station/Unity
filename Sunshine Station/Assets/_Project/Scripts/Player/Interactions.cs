using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace Sunshine
{
    public enum Hand { LEFT, RIGHT };

    public class Interactions : MonoBehaviour
    {
        [SerializeField] private Hand _hand;
        [SerializeField] private XRIDefaultInputActions _inputActions;
        InputAction _interactButton;

        private List<IInteractable> _storedInteractions = new List<IInteractable>();

        private Collider _collider;

        private void Awake()
        {
            _inputActions = new XRIDefaultInputActions();
            _collider = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            // Sets the interact button to the trigger of whichever
            // controller is set in inspector with "_hand".
            // If "_hand" is null (somehow?), it will default to left.
            _interactButton = _hand switch // (this is just an inline switch)
            {
                Hand.LEFT   => _inputActions.XRILeftHandInteraction.Activate,
                Hand.RIGHT  => _inputActions.XRIRightHandInteraction.Activate,
                _           => _inputActions.XRILeftHandInteraction.Activate
            };

            _interactButton.Enable();

            _interactButton.performed += TryInteract;
        }

        private void OnDisable()
        {
            _interactButton.Disable();
        }

        /// <summary>
        /// Tries to call Interact() on the 
        /// most recent stored interaction.
        /// If the stored interaction is null, nothing happens.
        /// </summary>
        private void TryInteract(InputAction.CallbackContext context)
        {
            if (_storedInteractions == null) { Debug.Log("Stored Interactions is Null");return; }
            if (_storedInteractions.Count == 0)
            {
                Debug.Log("Stored Interactions is 0"); return; }

            int lastIndex = _storedInteractions.Count - 1;

            _storedInteractions[lastIndex].Interact(_hand);
        }

        /// <summary>
        /// Quickly turns the collider off and back on.
        /// Useful in certain edge cases, like if this
        /// collider is fully inside a valid trigger, then detects a
        /// second trigger which is subsequently destroyed (i.e. collectable).
        /// In such a case, the stored interaction interface
        /// would remain null after the second collider is destroyed.
        /// This reset ensures a collision with nearby triggers,
        /// calling OnTriggerEnter and storing their interactions again.
        /// </summary>
        private void redetect()
        {
            _collider.enabled = false;
            _collider.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            // GetCompInParent checks the object first, then checks parents in order. This way,
            // the interface doesn't necessarily have to reside on the trigger collider object.
            IInteractable interaction = other.GetComponentInParent<IInteractable>();

            if (interaction == null) { return; }

            // Add this interaction to the list.
            _storedInteractions.Add(interaction);

            // Tell it we're here and what hand we are.
            interaction.ControllerEnter(_hand);
        }

        private void OnTriggerExit(Collider other)
        {
            // GetCompInParent checks the object first, then checks parents in order. This way,
            // the interface doesn't necessarily have to reside on the trigger collider object.
            IInteractable interaction = other.gameObject.GetComponentInParent<IInteractable>();

            // Tell it we're leaving and what hand we are.
            interaction?.ControllerExit(_hand);

            // If it's in the list of stored
            // interactions, remove it.
            if (_storedInteractions.Contains(interaction))
            {
                _storedInteractions.Remove(interaction);
            }

            // If we happen to still be near something, then
            redetect();
        }
    }
}
