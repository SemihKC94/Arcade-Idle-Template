/*//////////////////////////////////////////////////////////////////////////////////////////
//      █─▄▄▄▄█▄─█─▄█─▄▄▄─█                                                               //
//      █▄▄▄▄─██─▄▀██─███▀█             Scripts created by Semih Kubilay Çetin            //
//      ▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀                                                               //
//////////////////////////////////////////////////////////////////////////////////////////*/

[System.Serializable]
public class SaveData
{
    public int Level { get; set; }
    public int CharacterLevel { get; set; }
    public float CharacterExp { get; set; }
    public int PlaneCount { get; set; }
    public string GamePlayVersion { get; set; }
    public double SoftCurrency { get; set; }
    public double HardCurrency { get; set; }
    public Territory TerritoriesOwnStatus { get; set; }
}
/* Tip    #if UNITY_EDITOR
          Debug.Log("Unity Editor");
          #endif                          Tip End */