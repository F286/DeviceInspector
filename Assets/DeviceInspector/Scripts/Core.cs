using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeviceInspector {
    public static class Core {
        
        public static T FindOfType<T>() where T : class {
            foreach(var monoBehaviour in GameObject.FindObjectsOfType<MonoBehaviour>()) {
                if (monoBehaviour is T) {
                    return monoBehaviour as T;
                }
            }
            return default(T);
        }
    }
}