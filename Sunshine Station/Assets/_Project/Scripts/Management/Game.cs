using System.Collections.Generic;
using UnityEngine;

namespace Sunshine
{
    public class Game : Singleton<Game>
    {
        private List<Singleton<MonoBehaviour>> _managers = new List<Singleton<MonoBehaviour>>();

        private void GetManagers()
        {
            _managers.Clear();

            Singleton<MonoBehaviour>[] mgrsInScene = FindObjectsOfType<Singleton<MonoBehaviour>>();

            foreach (Singleton<MonoBehaviour> mgr in mgrsInScene)
            {
                _managers.Add(mgr);
            }
        }
    }
}
