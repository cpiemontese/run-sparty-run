using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text totalCoins;

    public Text doubleJumpCostText;
    public Button doubleJumpButton;

    public Text speedCostText;
    public Button[] speedButtons;

    public Text jumpForceCostText;
    public Button[] jumpForceButtons;

    public int doubleJumpCost = 5;
    public int[] speedCosts = { 5, 10, 15 };
    public int[] jumpForceCosts = { 5, 10, 15 };

    // Start is called before the first frame update
    void Awake()
    {
        UpdateCoins();
        UpdateDoubleJump();
        UpdateSpeed();
        UpdateJumpForce();
    }

    public void UnlockDoubleJump()
    {
        UnlockAbility("Double Jump", 1);
    }

    public void UnlockSpeed(int level)
    {
        UnlockAbility("Speed", level);
    }

    public void UnlockJumpForce(int level)
    {
        UnlockAbility("Jump Force", level);
    }

    void UnlockAbility(string name, int level)
    {
        int currentLevel;
        var availableCoins = PlayerPrefsManager.GetCoins();

        switch (name)
        {
            case "Double Jump":
                currentLevel = PlayerStatsManager.GetDoubleJumpLevel();
                if (level == currentLevel + 1 && availableCoins >= doubleJumpCost)
                {
                    PlayerStatsManager.SetDoubleJumpLevel(level);
                    PlayerPrefsManager.SetCoins(availableCoins - doubleJumpCost);
                }
                UpdateDoubleJump();
                break;
            case "Speed":
                currentLevel = PlayerStatsManager.GetSpeedLevel();
                if (level == currentLevel + 1 && level - 1 < speedCosts.Length && availableCoins >= speedCosts[level - 1])
                {
                    PlayerStatsManager.SetSpeedLevel(level);
                    PlayerPrefsManager.SetCoins(availableCoins - speedCosts[level - 1]);
                }
                UpdateSpeed();
                break;
            case "Jump Force":
                currentLevel = PlayerStatsManager.GetJumpForceLevel();
                if (level == currentLevel + 1 && level - 1 < jumpForceCosts.Length && availableCoins >= jumpForceCosts[level - 1])
                {
                    PlayerStatsManager.SetJumpForceLevel(level);
                    PlayerPrefsManager.SetCoins(availableCoins - jumpForceCosts[level - 1]);
                }
                UpdateJumpForce();
                break;
            default:
                Debug.LogError("Ability " + name + " not recognized");
                break;
        }
        UpdateCoins();
    }

    void UpdateCoins()
    {
        totalCoins.text = "Total coins: " + PlayerPrefsManager.GetCoins();
    }

    void UpdateDoubleJump()
    {
        var doubleJumpLevel = PlayerStatsManager.GetDoubleJumpLevel();
        if (doubleJumpLevel == 1)
        {
            doubleJumpButton.interactable = false;
        }
        doubleJumpCostText.text = doubleJumpCost.ToString();
    }

    void UpdateSpeed()
    {
        var speedLevel = PlayerStatsManager.GetSpeedLevel();
        for (int i = 0; i < speedLevel; i++)
        {
            speedButtons[i].interactable = false;
        }
        speedCostText.text = speedCosts[speedLevel].ToString();
    }

    void UpdateJumpForce()
    {
        var jumpForceLevel = PlayerStatsManager.GetJumpForceLevel();
        for (int i = 0; i < jumpForceLevel; i++)
        {
            jumpForceButtons[i].interactable = false;
        }
        jumpForceCostText.text = jumpForceCosts[jumpForceLevel].ToString();
    }
}
