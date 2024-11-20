using System.Collections.Generic;
using UnityEngine;

namespace Sunshine
{
    // Completely unfinished
    // --layla
    public class InfoScreen : MonoBehaviour
    {
        // Components
        [SerializeField] private Canvas canvas;

        // Sun Data
        [SerializeField] private SunData defaultDisplay;

        [SerializeField] private SunData currentDisplay;

        [SerializeField] private List<SunData> sunDatas;
        [SerializeField] private int indexToDisplay = 0;

        // Positioning Info
        [SerializeField] private Transform canvasSpawnPoint;
        [SerializeField] private Transform usbSlotStart;
        [SerializeField] private Transform usbSlotEnd;

        private void Update()
        {
            if (currentDisplay != sunDatas[indexToDisplay])
            {
                currentDisplay = sunDatas[indexToDisplay];
                canvas = Instantiate(currentDisplay.WorldSpaceCanvas, canvasSpawnPoint.position, Quaternion.identity, transform);
            }
        }
    }
}
