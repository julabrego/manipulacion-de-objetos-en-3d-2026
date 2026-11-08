using System;

public static class GameEvents
{
    public static event Action OnRestart;
    public static event Action OnStartCharging;
    public static event Action OnShoot;

    public static void TriggerRestart() => OnRestart?.Invoke();
    public static void TriggerStartCharging() => OnStartCharging?.Invoke();
    public static void TriggerShoot() => OnShoot?.Invoke();

}