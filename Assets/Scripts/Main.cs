using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine;

public class Main : MonoBehaviour {

    public static Stopwatch timer = new Stopwatch();
    public AudioSource BGMusic;
    public static bool execute;
    public static string elapsed;
    public static int check;

    void Start()
    {
        execute = true;
        timer.Start();
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
        Text Stopwatch = this.GetComponent<Text>();

        elapsed = timer.Elapsed.Duration().ToString().Substring(0, 11);

        PlayerPrefs.SetString("savedTime", elapsed);

        

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

    public static void SaveData()
    {

        execute = false;
        elapsed = null;
        timer.Reset();

        if (PlayerPrefs.GetInt("ReferenceNormal") > PlayerPrefs.GetInt("theTime"))
        {
            PlayerPrefs.SetInt("ReferenceNormal", PlayerPrefs.GetInt("theTime"));

            // Normal Mode
            if (UIControl.difficulty.Equals(2))
            {
                PlayerPrefs.SetString("BestTimeNormal", PlayerPrefs.GetString("savedTime"));
            }
            
        }
        else
        {
            if (PlayerPrefs.GetInt("ReferenceNormal") <= 0)
            {
                PlayerPrefs.SetInt("ReferenceNormal", 999999999);
            }
            
        }
    

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    if (PlayerPrefs.GetInt("ReferenceHard") > PlayerPrefs.GetInt("theTime"))
        {

            PlayerPrefs.SetInt("ReferenceHard", PlayerPrefs.GetInt("theTime"));

            // Normal Mode
            if (UIControl.difficulty.Equals(3))
            {
                PlayerPrefs.SetString("BestTimeHard", PlayerPrefs.GetString("savedTime"));
            }
            
        }
        else
        {
            if (PlayerPrefs.GetInt("ReferenceHard") <= 0)
            {
                PlayerPrefs.SetInt("ReferenceHard", 999999999);
            }
            
        }


    }

    public static void Print(string thing)
    {
        UnityEngine.Debug.Log(thing);
    }
}
