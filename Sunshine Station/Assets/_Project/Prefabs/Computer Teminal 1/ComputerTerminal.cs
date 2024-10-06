// layla
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Sunshine
{
    public class ComputerTerminal : MonoBehaviour
    {
        [Header("Trigger")]
        [SerializeField] private InteractionTrigger _interactionTrigger;

        [Header("Interaction Events")]
        [SerializeField] private UnityEvent WakeUp;
        [SerializeField] private UnityEvent GoToSleep;
        [SerializeField] private UnityEvent OpenDoors;


        private void Awake()
        {
        }

        private void OnEnable()
        {
            _interactionTrigger.onPlayerEnter += onWakeUp;
            _interactionTrigger.onPlayerExit += onGoToSleep;
            _interactionTrigger.onInteract += onOpenDoors;
        }

        private void OnDisable()
        {
            _interactionTrigger.onPlayerEnter -= onWakeUp;
            _interactionTrigger.onPlayerExit -= onGoToSleep;
            _interactionTrigger.onInteract -= onOpenDoors;
        }

        private void onWakeUp()
        {
            WakeUp?.Invoke();
        }

        private void onGoToSleep()
        {
            GoToSleep?.Invoke();
        }

        private void onOpenDoors()
        {
            OpenDoors?.Invoke();
        }
    }
}
