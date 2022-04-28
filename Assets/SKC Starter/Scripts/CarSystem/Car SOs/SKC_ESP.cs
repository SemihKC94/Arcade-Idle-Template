/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using UnityEngine;

[CreateAssetMenu(fileName ="New ESP Configuration", menuName ="SKC_Data/Car/ESP Configuration")]
public class SKC_ESP : ScriptableObject
{
    #region Private Vars
    private JointSpring mStrongHandling;
    private JointSpring mMediumHandling;
    private JointSpring mWeakHandling;
    #endregion

    #region Accessable
    public JointSpring StrongHandling => mStrongHandling;
    public JointSpring MediumHandling => mMediumHandling;
    public JointSpring WeakHandling => mWeakHandling;
    public bool IsInit { get; set; } = false;
    #endregion

    private void OnEnable()
    {
        IsInit = false;
    }

    #region Init
    public void InitSettings()
    {
        if (IsInit) return;
        IsInit = true;

        mWeakHandling = new JointSpring
        {
            spring = 20000f,
            damper = 2500f,
            targetPosition = 0.5f
        };

        mMediumHandling = new JointSpring
        {
            spring = 40000f,
            damper = 4000f,
            targetPosition = 0.5f
        };

        mStrongHandling = new JointSpring
        {
            spring = 60000f,
            damper = 6000f,
            targetPosition = 0.5f
        };
    }
    #endregion
}

/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */