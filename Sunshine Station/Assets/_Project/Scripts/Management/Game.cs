using UnityEngine;

namespace Sunshine
{
    public class Game : Singleton<Game>
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Camera playerView;

        public GameObject Player { get { return player; } }
        public Camera PlayerView { get { return playerView; } }

        protected override void Awake()
        {
            base.Awake();

            if (player == null)
            {
                player = GameObject.Find("PLAYER");
            }
        }
    }
}
