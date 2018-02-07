using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIControl : MonoBehaviour {

    public static int difficulty;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WipeData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetDifficulty(int level)
    {
        difficulty = level;
    }

}
