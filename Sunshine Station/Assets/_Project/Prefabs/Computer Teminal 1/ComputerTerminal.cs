// layla
using UnityEngine;
using UnityEngine.Events;

namespace Sunshine
{
    public class ComputerTerminal : MonoBehaviour
    {

        [Header("Interaction Events")]
        [SerializeField] private UnityEvent OnWakeUp;
        [SerializeField] private UnityEvent OnGoToSleep;
        [SerializeField] private UnityEvent OnInteract;

        private Canvas _screenCanvas;

        private void Awake()
        {
            _screenCanvas = GetComponentInChildren<Canvas>();
        }

        private void Start()
        {
            _screenCanvas.worldCamera = Camera.main;
        }

        public void WakeUp()
        {
            OnWakeUp?.Invoke();
        }

        public void GoToSleep()
        {
            OnGoToSleep?.Invoke();
        }

        public void Interact()
        {
            OnInteract?.Invoke();
        }
    }
}
