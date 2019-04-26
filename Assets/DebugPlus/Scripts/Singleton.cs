using UnityEngine;

namespace DebugPlusNS {
    public class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour {
        private static object o = new object();

        private static T i;
        public static T I {
            get {
                if (applicationIsQuitting) {
                    Debug.LogWarning("Single instance of "+ typeof(T) + " already destroyed on application quit. Won't create again - returning null.");
                    return null;
                }

                lock (o) {
                    if (i == null) {
                        i = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1) {
                            Debug.LogError("There are many instances of the singleton behavior " + typeof(T) + " in the scene, which is illegal.");
                            return i;
                        }

                        if (i == null) {
                            GameObject singleton = new GameObject();
                            i = singleton.AddComponent<T>();
                            singleton.name = typeof(T) + " singleton";

                            DontDestroyOnLoad(singleton);
                        }
                    }
                    return i;
                }
            }
        }

        private static bool applicationIsQuitting = false;
        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        ///   it will create a buggy ghost object that will stay on the Editor scene
        ///   even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        private void OnDestroy() {
            applicationIsQuitting = true;
        }
    }
}