using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextPulse : MonoBehaviour
{

    private float approachSpeed = 0.01f;
    private float growthBound = 0.5f;
    private float shrinkBound = 0.85f;
    private float currentRatio = 1;

    private Text text;
    private float originalFontSize;

    private Coroutine routine;
    private bool keepGoing = true;

    void Awake()
    {
        this.text = this.gameObject.GetComponent<Text>();

        this.routine = StartCoroutine(this.Pulse());
    }

    IEnumerator Pulse()
    {
        while (keepGoing)
        {
            while (this.currentRatio != this.growthBound)
            {
                currentRatio = Mathf.MoveTowards(currentRatio, growthBound, approachSpeed);

                this.text.transform.localScale = Vector3.one * currentRatio;
                this.text.text = "Press Play to Start!";

                yield return new WaitForEndOfFrame();
            }

            while (this.currentRatio != this.shrinkBound)
            {
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                this.text.transform.localScale = Vector3.one * currentRatio;
                this.text.text = "This game saves your data!";

                yield return new WaitForEndOfFrame();
            }
        }
    }
}