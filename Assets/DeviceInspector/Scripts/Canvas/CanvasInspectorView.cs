using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace DeviceInspector {

    public class CanvasInspectorView : MonoBehaviour, IView {

        IPresenter _presenter;
        public IPresenter presenter {
            private get {
               return _presenter;
            }
            set {
                _presenter = value;
            }
        }

        public Transform content;

        public void SetSelection(GameObject selected) {
            
            // Destroy all children in content
            foreach (Transform child in content) {
                GameObject.Destroy(child.gameObject);
            }
            
            // Create inspector heading
            GameObject.Instantiate(Resources.Load<GameObject>("Inspector"), content);

            // Components
            foreach (Component component in selected.GetComponents<Component>()) {
                {
                    var heading = GameObject.Instantiate(Resources.Load<GameObject>("Component"), content);
                    var text = heading.GetComponentsInChildren<Text>();
                    text[0].text = component.GetType().Name;
                }
                // print(component);

                // Fields
                var obj = component;
                const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;///*BindingFlags.NonPublic | */BindingFlags.Public | 
            //  BindingFlags.Instance | BindingFlags.Static;
                FieldInfo[] fields = obj.GetType().GetFields(flags);
                foreach (FieldInfo fieldInfo in fields)
                {
                    Debug.Log("Obj: " + obj.name + ", Field: " + fieldInfo.Name);
                    var heading = GameObject.Instantiate(Resources.Load<GameObject>("TextField"), content);
                    var text = heading.GetComponentsInChildren<Text>();
                    text[0].text = fieldInfo.Name;
                    text[1].text = fieldInfo.GetValue(obj).ToString();
                }
                // PropertyInfo[] properties = obj.GetType().GetProperties(flags);
                // foreach (PropertyInfo propertyInfo in properties)
                // {
                //     Debug.Log("Obj: " + obj.name + ", Property: " + propertyInfo.Name);
                // }
            }
        }

    }
}