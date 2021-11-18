using System.Linq;
using NebusokuDev.ShooterWeaponSystem.Core.Attribute;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Collision.ObjectMaterial
{
    public class TerrainObjectMaterial : MonoBehaviour,IObjectMaterial
    {
        [SerializeField, TagField] private string[] materials;
        private TerrainData _terrainData;

        private void Awake() =>_terrainData = GetComponent<Terrain>().terrainData;

        public string GetMaterial(Vector3 position)
        {
            var offsetX = (int) (_terrainData.alphamapWidth * position.x / _terrainData.size.x);
            var offsetZ = (int) (_terrainData.alphamapHeight * position.z / _terrainData.size.z);
            var alphamaps = _terrainData.GetAlphamaps(offsetX, offsetZ, 1, 1);

            var weights = alphamaps.Cast<float>().ToArray();
            if (weights.Length < 1) return "";
            var terrainLayer = System.Array.IndexOf(weights, weights.Max());
            if (materials.Length < terrainLayer || materials.Length < 1) return "";
            return materials[terrainLayer];
        }
    }
}