using UnityEngine;
using static UnityEngine.Random;

namespace NebusokuDev
{
    [CreateAssetMenu]
    public class Kickback : ScriptableObject
    {
        [Header("position"), SerializeField] private Vector3 minMove = new Vector3();
        [SerializeField] private Vector3 maxMove = new Vector3();

        [Header("rotate"), SerializeField] private Vector3 minRotate;
        [SerializeField] private Vector3 maxRotate;


        public (Vector3 position, Vector3 rotate) this[int index]
        {
            get
            {
                var kickBack = new Vector3(Range(minMove.x, maxMove.x), Range(minMove.y, maxMove.y),
                    Range(minMove.z, maxMove.z));
                var rotate = new Vector3(Range(minRotate.x, maxRotate.x), Range(minRotate.y, maxRotate.y),
                    Range(minRotate.y, maxRotate.y));
                return (kickBack, rotate);
            }
        }
    }
}