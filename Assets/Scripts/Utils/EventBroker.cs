using System;

public class EventBroker
{
    public static event Action OnPlay;
    public static void InvokePlay()
    {
        OnPlay?.Invoke();
    }

    public static event Action<string> OnMechanicActivated;
    public static void InvokeMechanicActivated(string description)
    {
        OnMechanicActivated?.Invoke(description);
    }

    public static event Action OnSave;
    public static void InvokeSave()
    {
        OnSave?.Invoke();
    }

    public static event Action UpdateMoneyUI;
    public static void UpdateMoney()
    {
        UpdateMoneyUI?.Invoke();
    }
}
