using UnityEngine;

namespace Sunshine
{
    [RequireComponent(typeof(Animator))]
    public class AnimTrigger : MonoBehaviour
    {
        [SerializeField] private Animator _targetAnimator;

        private void Start()
        {
            if (_targetAnimator == null)
                { print($"No trigger assigned to {name}'s ToggleAnimator"); }
        }

        public void Trigger(string nameOfTrigger)
        {
            print ($"Setting trigger on { name }");
            _targetAnimator.SetTrigger(nameOfTrigger);
        }
    }
}
