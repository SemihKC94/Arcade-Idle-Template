/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SKC
{

    /*
     * Global Asset references
     * Edit Asset references in the prefab CodeMonkey/Resources/CodeMonkeyAssets
     * */
    public class SKC_Assets : MonoBehaviour
    {

        // Internal instance reference
        private static SKC_Assets _i;

        // Instance reference
        public static SKC_Assets i
        {
            get
            {
                if (_i == null) _i = Instantiate(Resources.Load<SKC_Assets>("SKCAssets"));
                return _i;
            }
        }


        // All references

        public Sprite s_White;
        public Material m_White;

    }

}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */