using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeviceInspector {
    public interface IView {
        IPresenter presenter { set; }
        void SetSelection(GameObject selected);
    }
}