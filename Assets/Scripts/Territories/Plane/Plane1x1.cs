using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class Plane1x1 : MonoBehaviour
{
    [SerializeField] private bool ShowNeighbours = false;
    [SKC_ConditionalHide("ShowNeighbours",true)] [SerializeField] private Plane1x1 topNeighbour = null;
    [SKC_ConditionalHide("ShowNeighbours",true)] [SerializeField] private Plane1x1 leftNeighbour = null;
    [SKC_ConditionalHide("ShowNeighbours",true)] [SerializeField] private Plane1x1 rightNeighbour = null;
    [SerializeField] private bool ShowTopElements = false;
    [SKC_ConditionalHide("ShowTopElements",true)] [SerializeField] private bool ShowTopCanvasGroup = false;
    [SKC_ConditionalHide("ShowTopCanvasGroup",true)] [SerializeField] private CanvasGroup topCanvas = null;
    [SKC_ConditionalHide("ShowTopElements",true)] [SerializeField] private bool ShowTopImages = false;
    [SKC_ConditionalHide("ShowTopImages",true)] [SerializeField] private Image topCounterBar = null;
    [SKC_ConditionalHide("ShowTopElements",true)] [SerializeField] private bool ShowTopTMPUGUI = false;
    [SKC_ConditionalHide("ShowTopTMPUGUI",true)] [SerializeField] private TextMeshProUGUI topCollectPercent = null;
    [SKC_ConditionalHide("ShowTopElements",true)] [SerializeField] private bool ShowTopColliders = false;
    [SKC_ConditionalHide("ShowTopColliders",true)] [SerializeField] private Collider topTrigger = null;
    [SKC_ConditionalHide("ShowTopColliders",true)] [SerializeField] private Transform topGoldTarget = null;
    [Space(10)]
    [SerializeField] private bool ShowLeftElements = false;
    [SKC_ConditionalHide("ShowLeftElements",true)] [SerializeField] private bool ShowLeftCanvasGroup = false;
    [SKC_ConditionalHide("ShowLeftCanvasGroup",true)] [SerializeField] private CanvasGroup leftCanvas = null;
    [SKC_ConditionalHide("ShowLeftElements",true)] [SerializeField] private bool ShowLeftImages = false;
    [SKC_ConditionalHide("ShowLeftImages",true)] [SerializeField] private Image leftCounterBar = null;
    [SKC_ConditionalHide("ShowLeftElements",true)] [SerializeField] private bool ShowLeftTMPUGUI = false;
    [SKC_ConditionalHide("ShowLeftTMPUGUI",true)] [SerializeField] private TextMeshProUGUI leftCollectPercent = null;
    [SKC_ConditionalHide("ShowLeftElements",true)] [SerializeField] private bool ShowLeftColliders = false;
    [SKC_ConditionalHide("ShowLeftColliders",true)] [SerializeField] private Collider leftTrigger = null;
    [SKC_ConditionalHide("ShowLeftColliders",true)] [SerializeField] private Transform leftGoldTarget = null;
    [Space(10)]
    [SerializeField] private bool ShowRightElements = false;
    [SKC_ConditionalHide("ShowRightElements",true)] [SerializeField] private bool ShowRightCanvasGroup = false;
    [SKC_ConditionalHide("ShowRightCanvasGroup",true)] [SerializeField] private CanvasGroup rightCanvas = null;
    [SKC_ConditionalHide("ShowRightElements",true)] [SerializeField] private bool ShowRightImages = false;
    [SKC_ConditionalHide("ShowRightImages",true)] [SerializeField] private Image rightCounterBar = null;
    [SKC_ConditionalHide("ShowRightElements",true)] [SerializeField] private bool ShowRightTMPUGUI = false;
    [SKC_ConditionalHide("ShowRightTMPUGUI",true)] [SerializeField] private TextMeshProUGUI rightCollectPercent = null;
    [SKC_ConditionalHide("ShowRightElements",true)] [SerializeField] private bool ShowRightColliders = false;
    [SKC_ConditionalHide("ShowRightColliders",true)] [SerializeField] private Collider rightTrigger = null;
    [SKC_ConditionalHide("ShowRightColliders",true)] [SerializeField] private Transform rightGoldTarget = null;
    [Space(10)]
    [SerializeField] private bool ShowSavedElements = false;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private int territoryID = 0;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private int ownStatus = 0;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private int zoneNumber = 0;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private int barMaxAmount = 20;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private float callItemDelay = 0;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private int topBarCollect = 0;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private int leftBarCollect = 0;
    [SKC_ConditionalHide("ShowSavedElements",true)] [SerializeField] private int rightBarCollect = 0;

    [SerializeField] private bool TopNavMeshObs = false;
    [SKC_ConditionalHide("TopNavMeshObs", true)] [SerializeField] private GameObject topNavMeshObs = null;
    [SerializeField] private bool LeftNavMeshObs = false;
    [SKC_ConditionalHide("LeftNavMeshObs", true)] [SerializeField] private GameObject leftNavMeshObs = null;
    [SerializeField] private bool RightNavMeshObs = false;
    [SKC_ConditionalHide("RightNavMeshObs", true)] [SerializeField] private GameObject rightNavMeshObs = null;

    // Privates
    // Components
    private NavMeshSurface thisNavMeshSurface;
    private UniqueTerritory uniqueTerritory;

    // Trigger Config
    private bool protectOneTrigger = false;
    private float inTriggerTime = 0f;
    private float triggerCountTimer = 2f;
    private float callItemCD = 0f;

#region  Unity Methods

    private void Awake()
    {
        if (TopNavMeshObs) topNavMeshObs.gameObject.SetActive(true);
        else topNavMeshObs.gameObject.SetActive(false);

        if (RightNavMeshObs) rightNavMeshObs.gameObject.SetActive(true);
        else rightNavMeshObs.gameObject.SetActive(false);

        if (LeftNavMeshObs) leftNavMeshObs.gameObject.SetActive(true);
        else leftNavMeshObs.gameObject.SetActive(false);
    }
    private void Start()
    {
        thisNavMeshSurface = GetComponent<NavMeshSurface>();
        uniqueTerritory = transform.parent.parent.GetComponent<UniqueTerritory>();
    }
#endregion

#region Custom Private Methods
    // private void CallItemToPlayer(Transform target,PickupType itemType)                                      // Use Later
    // {
    //     if(CharacterManager.Instance.MoneyAmount() > 5)
    //     {
    //         bool tierIIRate = Random.Range(1,101) > 60;
    //         if(tierIIRate)
    //         {
    //             bool tierIIIRate = Random.Range(1,101) > 50;
    //             if(tierIIIRate) dropFromPlayer.GetItemToTarget(target,itemType,PickupTier.TierIII);
    //             else dropFromPlayer.GetItemToTarget(target,itemType,PickupTier.TierII);
    //         }
    //         else
    //         {
    //             dropFromPlayer.GetItemToTarget(target,itemType,PickupTier.TierI);
    //         }
    //         CharacterManager.Instance.GetMoney(-5,true);
    //     }
    // }

    private void CallGoldToPlayer(Transform target)
    {
        if(CharacterManager.Instance.MoneyAmount() > 0)
        {
            CharacterManager.Instance.GetGoldFromChar(target);
            CharacterManager.Instance.GetMoney(-1,true);
            SoundFXManager.Instance.PlaySound(SoundFXManager.Instance.pickDown,true);
        }
    }

    private void UpdateUI()
    {
        if(topBarCollect <= barMaxAmount) topCounterBar.fillAmount = (float)((float)topBarCollect / (float)barMaxAmount);
        if(leftBarCollect <= barMaxAmount) leftCounterBar.fillAmount = (float)((float)leftBarCollect / (float)barMaxAmount);
        if(rightBarCollect <= barMaxAmount) rightCounterBar.fillAmount = (float)((float)rightBarCollect / (float)barMaxAmount);

        topCollectPercent.SetText(topBarCollect.ToString());
        leftCollectPercent.SetText(leftBarCollect.ToString());
        rightCollectPercent.SetText(rightBarCollect.ToString());

        CheckNeighbour();        

        TerritoryManager.Instance.CheckOurZone();
    }

    private void SaveThis()
    {
        GameManager.SaveData.TerritoriesOwnStatus.Zone[zoneNumber].PlaneInfoInc[territoryID].leftBarCollect = leftBarCollect;
        GameManager.SaveData.TerritoriesOwnStatus.Zone[zoneNumber].PlaneInfoInc[territoryID].rightBarCollect = rightBarCollect;
        GameManager.SaveData.TerritoriesOwnStatus.Zone[zoneNumber].PlaneInfoInc[territoryID].topBarCollect = topBarCollect;
        GameManager.SaveData.TerritoriesOwnStatus.Zone[zoneNumber].Plane[territoryID] = ownStatus;
        EventBroker.InvokeSave();
    }

    

    private void CheckNeighbour()
    {
        if(topBarCollect >= barMaxAmount)
            if(topNeighbour.ownStatus == 0) UnlockNeighbour("Top");
        if(leftBarCollect >= barMaxAmount)
            if(leftNeighbour.ownStatus == 0) UnlockNeighbour("Left");
        if(rightBarCollect >= barMaxAmount)
            if(rightNeighbour.ownStatus == 0) UnlockNeighbour("Right");

        if(topNeighbour != null)
        {
            if(topNeighbour.ownStatus == 0)
            {
                if(ShowTopElements)
                {
                    topCanvas.gameObject.SetActive(true);
                    topTrigger.gameObject.SetActive(true);
                }
            }
            else
            {
                if(ShowTopElements)
                {
                    topCanvas.gameObject.SetActive(false);
                    topTrigger.gameObject.SetActive(false);
                }
            }
        }
        if(leftNeighbour != null)
        {
            if(leftNeighbour.ownStatus == 0)
            {
                if(ShowLeftElements)
                {
                    leftCanvas.gameObject.SetActive(true);
                    leftTrigger.gameObject.SetActive(true);
                }
            }
            else
            {
                if(ShowLeftElements)
                {
                    leftCanvas.gameObject.SetActive(false);
                    leftTrigger.gameObject.SetActive(false);
                }
            }
        }
        if(rightNeighbour != null)
        {
            if(rightNeighbour.ownStatus == 0)
            {
                if(ShowRightElements)
                {
                    rightCanvas.gameObject.SetActive(true);
                    rightTrigger.gameObject.SetActive(true);
                }
            }
            else
            {
                if(ShowRightElements)
                {
                    rightCanvas.gameObject.SetActive(false);
                    rightTrigger.gameObject.SetActive(false);
                }
            }
        }
            BuildNavMeshes();

    }
#endregion

#region Custom Accesable Methods

    public void Init(int id,int hasOwn,PlaneInfo savedPlaneConfig)
    {
        territoryID = id;
        ownStatus = hasOwn;
        topBarCollect = savedPlaneConfig.topBarCollect;
        leftBarCollect = savedPlaneConfig.leftBarCollect;
        rightBarCollect = savedPlaneConfig.rightBarCollect;
        if(ownStatus == 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            UpdateUI();
            SaveThis();
        }
    }

    public void BuildNavMeshes()
    {
        thisNavMeshSurface.BuildNavMesh();
    }
    public void InGameInit()
    {
        UpdateUI();
        SaveThis();
    }

    private void UnlockNeighbour(string which)
    {
        switch(which)
        {
            case "Top":
                topNeighbour.gameObject.SetActive(true);
                topNeighbour.ownStatus = 1;
                topNeighbour.InGameInit();
                UpdateUI();
                SaveThis();

                break;
            case "Left":
                leftNeighbour.gameObject.SetActive(true);
                leftNeighbour.ownStatus = 1;
                leftNeighbour.InGameInit();
                UpdateUI();
                SaveThis();

                break;
            case "Right":
                rightNeighbour.gameObject.SetActive(true);
                rightNeighbour.ownStatus = 1;
                rightNeighbour.InGameInit();
                UpdateUI();
                SaveThis();

                break;
        }
    }
    
    public void CanvasAlphaZero(string temp)
    {
        switch(temp)
        {
            case "Top":
                if(ShowTopElements) LeanTween.alphaCanvas(topCanvas,0f,.2f);

                break;

            case "Left":
                if(ShowLeftElements) LeanTween.alphaCanvas(leftCanvas,0f,.2f);

                break;

            case "Right":
                if(ShowRightElements) LeanTween.alphaCanvas(rightCanvas,0f,.2f);

                break;
        }
    }

    public void CanvasAlphaOne(string temp)
    {
        switch(temp)
        {
            case "Top":
                if(ShowTopElements) LeanTween.alphaCanvas(topCanvas,1f,.2f);

                break;

            case "Left":
                if(ShowLeftElements) LeanTween.alphaCanvas(leftCanvas,1f,.2f);

                break;

            case "Right":
                if(ShowRightElements) LeanTween.alphaCanvas(rightCanvas,1f,.2f);

                break;
        }
    }

    public void TriggerExitAction()
    {
        triggerCountTimer = 0;
        callItemCD = 0;
    }

    // Trigger Receiver Func
    public void TriggerEnterAction(string whichTrigger)
    {
        switch(whichTrigger)
        {
            case "Top":
                triggerCountTimer += Time.deltaTime;

                if(triggerCountTimer > inTriggerTime)
                {
                    callItemCD += Time.deltaTime;

                    if(callItemCD > callItemDelay)
                    {
                        callItemCD = 0;
                        if(topBarCollect < barMaxAmount) 
                        {
                            topBarCollect++;
                            CallGoldToPlayer(topGoldTarget);
                            UpdateUI();
                            SaveThis();
                        }
                    }
                }
                break;

            case "Left":
                triggerCountTimer += Time.deltaTime;

                if(triggerCountTimer > inTriggerTime)
                {
                    callItemCD += Time.deltaTime;

                    if(callItemCD > callItemDelay)
                    {
                        callItemCD = 0;
                        if(leftBarCollect < barMaxAmount) 
                        {
                            leftBarCollect++;
                            CallGoldToPlayer(leftGoldTarget);
                            UpdateUI();
                            SaveThis();
                        }
                    }
                }

                break;

            case "Right":
                triggerCountTimer += Time.deltaTime;

                if(triggerCountTimer > inTriggerTime)
                {
                    callItemCD += Time.deltaTime;

                    if(callItemCD > callItemDelay)
                    {
                        callItemCD = 0;
                        if(rightBarCollect < barMaxAmount) 
                        {
                            rightBarCollect++;
                            CallGoldToPlayer(rightGoldTarget);
                            UpdateUI();
                            SaveThis();
                        }
                    }
                }

                break;
        }
    }
    
#endregion
}

        // switch(whichTrigger)
        // {
        //     case "Top":
                
        //         break;

        //     case "Left":

        //         break;

        //     case "Right":

        //         break;
        // }