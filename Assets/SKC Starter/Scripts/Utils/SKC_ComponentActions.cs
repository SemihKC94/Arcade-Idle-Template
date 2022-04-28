/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System;
using UnityEngine;

namespace SKC.MonoBehaviours
{

    /*
     * Trigger Actions on MonoBehaviour Component events
     * */
    public class SKC_ComponentActions : MonoBehaviour
    {

        public Action OnDestroyFunc;
        public Action OnEnableFunc;
        public Action OnDisableFunc;
        public Action OnUpdate;

        void OnDestroy()
        {
            if (OnDestroyFunc != null) OnDestroyFunc();
        }
        void OnEnable()
        {
            if (OnEnableFunc != null) OnEnableFunc();
        }
        void OnDisable()
        {
            if (OnDisableFunc != null) OnDisableFunc();
        }
        void Update()
        {
            if (OnUpdate != null) OnUpdate();
        }


        public static void CreateComponent(Action OnDestroyFunc = null, Action OnEnableFunc = null, Action OnDisableFunc = null, Action OnUpdate = null)
        {
            GameObject gameObject = new GameObject("ComponentActions");
            AddComponent(gameObject, OnDestroyFunc, OnEnableFunc, OnDisableFunc, OnUpdate);
        }
        public static void AddComponent(GameObject gameObject, Action OnDestroyFunc = null, Action OnEnableFunc = null, Action OnDisableFunc = null, Action OnUpdate = null)
        {
            SKC_ComponentActions componentFuncs = gameObject.AddComponent<SKC_ComponentActions>();
            componentFuncs.OnDestroyFunc = OnDestroyFunc;
            componentFuncs.OnEnableFunc = OnEnableFunc;
            componentFuncs.OnDisableFunc = OnDisableFunc;
            componentFuncs.OnUpdate = OnUpdate;
        }
    }

}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */