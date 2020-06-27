using UnityEngine;

public static class PlayerStatsManager
{
    static readonly int[] _speedLevels = { 3, 4, 5, 6 };

    static readonly int[] _jumpForceLevels = { 600, 635, 670, 700 };

    public static int GetSpeed()
    {
        var level = PlayerPrefs.GetInt("Speed Level", 0);
        return _speedLevels[level];
    }

    public static int GetSpeedLevel()
    {
        return PlayerPrefs.GetInt("Speed Level", 0);
    }

    public static void SetSpeedLevel(int speedLevel)
    {
        PlayerPrefs.SetInt("Speed Level", speedLevel);
    }


    public static int GetJumpForce()
    {
        var level = PlayerPrefs.GetInt("Jump Force Level", 0);
        return _jumpForceLevels[level];
    }

    public static int GetJumpForceLevel()
    {
        return PlayerPrefs.GetInt("Jump Force Level", 0);
    }

    public static void SetJumpForceLevel(int jumpForceLevel)
    {
        PlayerPrefs.SetInt("Jump Force Level", jumpForceLevel);
    }

    public static bool GetDoubleJump()
    {
        return PlayerPrefs.GetInt("Double Jump Level", 0) > 0;
    }

    public static int GetDoubleJumpLevel()
    {
        return PlayerPrefs.GetInt("Double Jump Level", 0);
    }


    public static void SetDoubleJumpLevel(int doubleJumpLevel)
    {
        PlayerPrefs.SetInt("Double Jump Level", doubleJumpLevel);
    }

    // store the current player stats info into PlayerPrefs
    public static void SavePlayerStats(int speedLevel, int jumpForceLevel, int doubleJumpLevel)
    {
        SetSpeedLevel(speedLevel);
        SetJumpForceLevel(jumpForceLevel);
        SetDoubleJumpLevel(doubleJumpLevel);
    }

    // reset stored player stats and variables back to defaults
    public static void ResetPlayerStats()
    {
        Debug.Log("Player Stats reset.");
        SetSpeedLevel(-1);
        SetJumpForceLevel(-1);
        SetDoubleJumpLevel(0);
    }

    // output the defined Player Prefs to the console
    public static void ShowPlayerStats()
    {
        // store the PlayerPref keys to output to the console
        string[] values = { "Speed Level", "Jump Force Level", "Double Jump Level" };

        // loop over the values and output to the console
        foreach (string value in values)
        {
            if (PlayerPrefs.HasKey(value))
            {
                Debug.Log(value + " = " + PlayerPrefs.GetInt(value));
            }
            else
            {
                Debug.Log(value + " is not set.");
            }
        }
    }
}
