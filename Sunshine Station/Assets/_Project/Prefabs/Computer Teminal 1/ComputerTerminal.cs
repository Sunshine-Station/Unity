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

        public void WakeUp()
        {
            OnWakeUp.Invoke();
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
