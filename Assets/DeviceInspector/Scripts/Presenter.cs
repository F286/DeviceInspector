using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DeviceInspector
{
    public class Presenter : MonoBehaviour, IPresenter {

        IView _view = null;
        public IView view {
            get {
                if (_view == null) {
                    _view = Core.FindOfType<IView>();
                }
                return _view;
            }
        }

        protected void Awake() {
            view.presenter = this;
        }

        GameObject _prevSelected;

        public void Update() {
            if( _prevSelected != Selection.activeGameObject) {
                _prevSelected = Selection.activeGameObject;
                view.SetSelection(Selection.activeGameObject);
            }
        }
        
    }
}