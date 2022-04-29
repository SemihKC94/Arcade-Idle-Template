/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIController : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Joystick joyStick = null;

    [SerializeField] private bool ShowUIElements;
    [SerializeField] private bool ShowPrefabs;
    [SKC_ConditionalHide("ShowUIElements",true)] [SerializeField] private bool ShowTexts;
    [SKC_ConditionalHide("ShowTexts",true)] [SerializeField] private TextMeshProUGUI _moneyText = null;
    [SKC_ConditionalHide("ShowUIElements",true)] [SerializeField] private bool ShowCG;
    [SKC_ConditionalHide("ShowCG",true)] [SerializeField] private CanvasGroup _splashScreen = null;
    [SKC_ConditionalHide("ShowPrefabs",true)] [SerializeField] private bool ShowEffectPrefab;
    [SKC_ConditionalHide("ShowEffectPrefab",true)] [SerializeField] private GameObject moneyPopUp = null;

    // Privates 
#region Privates 
    private int moneyHolder;

#endregion        

    #region Fake Singleton Pattern
    public static GUIController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        // Events
        EventBroker.OnPlay += Event_OnPlay;
        EventBroker.OnSave += Event_OnSave;
        EventBroker.UpdateMoneyUI += Event_MoneyUpdate;
    }
    #endregion

#region Unity Methods
    private void Start()
    {
        StartCoroutine(SplashScreen());
    }


#endregion

#region Event's Methods
    private void Event_OnPlay()
    {
        // Do Something
    }

    private void Event_OnSave()
    {
        // Do Something
    }

    private void Event_MoneyUpdate()
    {
        moneyHolder = CharacterManager.Instance.MoneyAmount(); // Get Money amount
        
        _moneyText.SetText(moneyHolder.ToString());
    }

#endregion

#region Private Methods
    private IEnumerator SplashScreen()
    {
        LeanTween.alphaCanvas(_splashScreen,1f,1f);
        _splashScreen.interactable = true;
        _splashScreen.blocksRaycasts = true;

        yield return new WaitForSeconds(1f);

        LeanTween.alphaCanvas(_splashScreen,0f,1f);
        _splashScreen.interactable = false;
        _splashScreen.blocksRaycasts = false;

        EventBroker.UpdateMoney();
    }


#endregion

#region Public Methods
    public void MoneyPopUp(int temp)
    {
        GameObject moneyPopUpFromPool = (GameObject)SKC_PoolSystem.Instance.SpawnFromPool("MoneyPopUp",Vector3.zero,Quaternion.identity);
        bool plus = false;
        string moneyInt = temp.ToString();
        if(temp > 0) 
        {
            plus = true;
            moneyInt ="+"+ temp.ToString();
        }
        moneyPopUpFromPool.GetComponent<MoneyPopUp>().SetConfig(moneyInt,plus,_moneyText.GetComponent<RectTransform>());
    }
#endregion

#region Transmitter     
    public Vector2 InputDirection()
    {
        return joyStick.Direction;
    }

    public bool OnPointerDown()
    {
        return joyStick.onFingerDown;
    }

#endregion    
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */