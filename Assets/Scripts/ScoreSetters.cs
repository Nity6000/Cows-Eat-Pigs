using UnityEngine.UI;
using UnityEngine;

public class ScoreSetters : MonoBehaviour {

    public Text easy;
    public Text normal;
    public Text hard;

    void Start ()
    {
        //string easy1 = PlayerPrefs.GetString("BestTimeEasy");
        string normal1 = PlayerPrefs.GetString("BestTimeNormal");
        string hard1 = PlayerPrefs.GetString("BestTimeHard");

        //easy.text = "Best Score: " + easy1;
        normal.text = "Best Score: " + normal1;
        hard.text = "Best Score: " + hard1;
    }    
}
