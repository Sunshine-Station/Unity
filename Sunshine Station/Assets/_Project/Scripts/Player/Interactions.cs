using UnityEngine;
using UnityEngine.InputSystem;

namespace Sunshine
{
    public class Interactions : MonoBehaviour
    {
        private enum Hand { LEFT, RIGHT };

        [SerializeField] private Hand _hand;
        [SerializeField] private XRIDefaultInputActions _inputActions;
        InputAction _interactButton;

        private IInteractable _storedInteraction;

        private Collider _collider;

        private void Awake()
        {
            _inputActions = new XRIDefaultInputActions();
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
        /// Tries to call Interact() on the stored interaction.
        /// If the stored interaction is null, nothing happens.
        /// </summary>
        private void TryInteract(InputAction.CallbackContext context)
        {
            _storedInteraction?.Interact();
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
            IInteractable interaction = other.GetComponent<IInteractable>();

            if (interaction == null) { return; }

            // If an interaction is already stored, we boot it. 
            if (_storedInteraction != null)
            {
                _storedInteraction.OnPlayerExitRange();
                _storedInteraction = null;
            }

            _storedInteraction = interaction;
            _storedInteraction.OnPlayerEnterRange();
        }

        private void OnTriggerExit(Collider other)
        {
            IInteractable interaction = other.gameObject.GetComponent<IInteractable>();

            // No matter what, if we're leaving this collider,
            // we want to call this on it.
            interaction?.OnPlayerExitRange();

            // If we happen to still be near something, then
            redetect();
        }
    }
}