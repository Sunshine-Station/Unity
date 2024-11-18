using UnityEngine;

namespace Sunshine
{
    public class FacePlayer : MonoBehaviour
    {
        [SerializeField] private bool _invert;

        private void Update()
        {
            transform.LookAt(Game.MGR.PlayerView.transform.position);

            if (_invert)
            {
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
