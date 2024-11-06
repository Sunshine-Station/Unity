// layla
using System.Collections.Generic;
using UnityEngine;

namespace Sunshine
{
    // I think this is useless and there's an easier way to do this

    [CreateAssetMenu(fileName = "New Material List", menuName = "Material List")]
    public class MaterialList : ScriptableObject
    {
        [SerializeField] private NamedMat[] _materials;

        public Dictionary<string, Material> Materials = new Dictionary<string, Material>();

        private void OnEnable()
        {
            foreach (NamedMat mat in _materials)
            {
                Materials.Add(mat.name, mat.mat);
            }
        }
    }

    [System.Serializable]
    public struct NamedMat
    {
        public string name;
        public Material mat;
    }
}
