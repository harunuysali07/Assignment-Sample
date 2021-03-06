using UnityEngine;

public class DataManager
{
    public static int CurrentLevel
    {
        get => PlayerPrefs.GetInt(PlayerPrefKeys.PlayerLevel, 0);

        set => PlayerPrefs.SetInt(PlayerPrefKeys.PlayerLevel, value);

    }

    private struct PlayerPrefKeys
    {
        public const string PlayerLevel = "PlayerLevel";
    }
}
