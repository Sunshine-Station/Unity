using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace Sunshine
{
    // COMPLETELY UNFINISHED, AND I'M GIVING UP FOR NOW. I JUST WANT TO CHECK A FUCKIN BUTTON PRESS
    public class InteractableButton : MonoBehaviour
    {
        [SerializeField] private List<InputActionAsset> _inputs;

        private InputActionManager manager;

        private bool _inRange;

        private void Awake()
        {
            manager = new InputActionManager();
            manager.actionAssets = _inputs;
        }

        private void OnEnable()
        {
            manager.EnableInput();
        }

        private void OnDisable()
        {
            manager.DisableInput();
        }
    }
}
