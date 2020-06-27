using UnityEngine;
using System.Collections;
using UnityEditor; // include UnityEditor since this is an editor script

// this is a script that enhances the Unity Editor (aka, Editor Script)
public class PlayerPrefsEditor : ScriptableObject
{

    // Delete the PlayerPrefs after a confirmation dialog
    [MenuItem("Editor/Delete Player Prefs")]
    static void DeletePrefs()
    {
        if (EditorUtility.DisplayDialog("Delete all player preferences?",
                                       "Are you sure you want to delete all the player preferences, this action cannot be undone?",
                                       "Yes",
                                       "No"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    [MenuItem("Editor/Add 10 Coins")]
    static void AddCoins()
    {
        PlayerPrefsManager.SetCoins(PlayerPrefsManager.GetCoins() + 10);
        Debug.Log("Added 10 coins, new total: " + PlayerPrefsManager.GetCoins());
    }
}