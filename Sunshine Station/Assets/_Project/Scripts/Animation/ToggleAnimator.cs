using UnityEngine;

namespace Sunshine
{
    [RequireComponent(typeof(Animator))]
    public class ToggleAnimator : MonoBehaviour
    {
        [SerializeField] string _onTriggerName;
        [SerializeField] string _offTriggerName;

        private Animator _animator;

        bool _isOn;

        private void Start()
        {
            if (!TryGetComponent(out _animator))
            {
                print ($"No animator found on { name }");
            }
        }

        public void Toggle()
        {
            string toggleMessage = _isOn ? "off" : "on";
            string toggleAction = _isOn ? _offTriggerName : _onTriggerName;

            print ($"{ name } is toggling {toggleMessage}");

            _animator.SetTrigger(toggleAction);
            _isOn = !_isOn;
        }
    }
}
