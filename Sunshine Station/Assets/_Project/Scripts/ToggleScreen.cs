using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
//all of this is temporary i am very tired
namespace Sunshine
{
    [RequireComponent(typeof(Animator))]
    public class ToggleScreen : MonoBehaviour
    {
        [SerializeField]GameObject screen;

        [SerializeField] Camera screenCamera;

        bool _isOn;

        private void Start()
        {

           
           
            if (!TryGetComponent(out screen))
            {
                print($"No Image found on {name}");
            }
        }

        public void Toggle()
        {
            if (!TryGetComponent(out screen) && !_isOn)
            {
                Instantiate(screen);

            }
            else if (TryGetComponent(out screen) && _isOn)
            {
                Destroy(screen);
            }
        }
    }
}