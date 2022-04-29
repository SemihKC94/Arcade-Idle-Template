/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static SaveData SaveData;
    public static GameState GameState = GameState.Wait;

    #region Project Setup
    void Awake()
    {
        Application.targetFrameRate = 60;

        EventBroker.OnPlay += EventBroker_OnPlay;
        EventBroker.OnSave += EventBroker_OnSave;

        StartCoroutine(Initialize());
    }

    #endregion

    #region EventHandlers
    private void EventBroker_OnPlay()
    {
        GameState = GameState.Play;
    }

    private void EventBroker_OnSave()
    {
        DataManager.SaveData(StringConstants.SaveData, SaveData);
    }

    #endregion EventHandlers

    private IEnumerator Initialize()
    {
        GameState = GameState.Init;

        yield return new WaitForSeconds(0.05f);

        LoadSaveData();

        yield return new WaitForSeconds(0.05f);

        GameState = GameState.Wait;
    }


    private void LoadSaveData()
    {
        var savedData = DataManager.LoadData<SaveData>(StringConstants.SaveData);

        if (savedData == null)
        {
            //new User
            SaveData = new SaveData()
            {
                Level = 1,
                CharacterLevel = 1,
                CharacterExp = 0.0f,
                PlaneCount = 9,
                HardCurrency = 0,
                SoftCurrency = 1000,
                GamePlayVersion = Application.version,
                TerritoriesOwnStatus =new Territory()
            };
            DataManager.SaveData(StringConstants.SaveData, SaveData);
        }
        else
        {
            SaveData = savedData;
        }
    }

}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */