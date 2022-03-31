using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Extension
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                }

                if (_instance == null)
                {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }


                return _instance;
            }
        }

        private static T _instance;


#if UNITY_EDITOR

        // editor only 
        protected virtual void OnValidate()
        {
        }
#endif

        // unity update life cycles
        protected virtual void OnDestroy()
        {
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {
        }

        protected virtual void FixedUpdate()
        {
        }

        protected virtual void Update()
        {
        }

        protected virtual void LateUpdate()
        {
        }


        // sealed
        private void OnGUI()
        {
        }
    }
}