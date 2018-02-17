using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Main : MonoBehaviour {

    public static Stopwatch timer = new Stopwatch();
    public AudioSource BGMusic;
    private static bool execute;
    private string elapsed;
    private int check;
    private Text Stopwatch;

    private void Awake()
    {
        timer.Start();
        execute = true;
    }

    void FixedUpdate()
    {
        
        if (execute == true)
        {
            DoStuff();
            OtherStuff();
        }
    }

    public void DoStuff()
    {
        elapsed = timer.Elapsed.Duration().ToString().Substring(0, 11);
        
        PlayerPrefs.SetString("savedTime", elapsed);

        Stopwatch = this.GetComponent<Text>();

        Stopwatch.text = PlayerPrefs.GetString("savedTime");

        if (timer.ElapsedMilliseconds >= 18000)
        {
            BGMusic.pitch = 1.5f;
            Stopwatch.color = Color.red;
            Stopwatch.fontSize = 56;
        }
    }

    public void OtherStuff()
    {
        check = (int) timer.ElapsedMilliseconds;
        PlayerPrefs.SetInt("theTime", check);
    }
    
    public void StopTimer()
    {
        execute = false;
        timer.Stop();
        timer.Reset();
    }

    public void SaveData()
    {
        int newTime = PlayerPrefs.GetInt("theTime");
        Debug.Log(PlayerPrefs.GetInt("ReferenceNormal"));

        // Normal Mode
        if (UIControl.difficulty.Equals(2))
        {
            if (PlayerPrefs.GetInt("ReferenceNormal") > newTime)
            {
                PlayerPrefs.SetInt("ReferenceNormal", newTime);           

                PlayerPrefs.SetString("BestTimeNormal", PlayerPrefs.GetString("savedTime"));
            }
            else
            {

                if (PlayerPrefs.GetInt("ReferenceNormal") == 0)
                {
                    PlayerPrefs.SetInt("ReferenceNormal", newTime);
                    PlayerPrefs.SetString("BestTimeNormal", PlayerPrefs.GetString("savedTime"));
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Hard Mode
        if (UIControl.difficulty.Equals(3))
        {
            if (PlayerPrefs.GetInt("ReferenceHard") > newTime)
            {
                PlayerPrefs.SetInt("ReferenceHard", newTime);
                
                PlayerPrefs.SetString("BestTimeHard", PlayerPrefs.GetString("savedTime"));               

            }
            else
            {
                if (PlayerPrefs.GetInt("ReferenceHard") == 0) {

                    PlayerPrefs.SetInt("ReferenceHard", newTime);
                    PlayerPrefs.SetString("BestTimeHard", PlayerPrefs.GetString("savedTime"));
                }                    
            }
        }

    }
}
