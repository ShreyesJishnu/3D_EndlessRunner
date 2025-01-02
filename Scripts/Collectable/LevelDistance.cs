using UnityEngine;
using TMPro;
using System.Collections;

public class LevelDistance : MonoBehaviour
{
    public TextMeshProUGUI disCountDisplay;
    public TextMeshProUGUI disEndDisplay;
    public int disRun;
    public float disDelay = 0.5f;
    public float finalDistance;


    private Coroutine distanceCoroutine;
    public bool isCounting = true;

    void Start()
    {
        // Start the coroutine when the game begins
        distanceCoroutine = StartCoroutine(UpdateDistance());
    }

    void OnDestroy()
    {
        // Stop the coroutine when the object is destroyed to avoid errors
        if (distanceCoroutine != null)
        {
            StopCoroutine(distanceCoroutine);
        }
    }

    private void OnTriggerEnter()
    {
        // Stop counting when the character collides with an object
        isCounting = false;

        // Optionally, stop the coroutine explicitly (not necessary, since the loop will stop naturally)
        if (distanceCoroutine != null)
        {
            StopCoroutine(distanceCoroutine);
            distanceCoroutine = null;
        }
    }

    IEnumerator UpdateDistance()
    {
        while (isCounting)
        {
            disRun++;
            UpdateDisplay();
            finalDistance = disRun;
            yield return new WaitForSeconds(disDelay);
        }
    }

    public void UpdateDisplay()
    {
        if (disCountDisplay != null)
        {
            disCountDisplay.text = disRun.ToString();
        }

        // Update disEndDisplay only when the end screen is active
        if (disEndDisplay != null )
        {
            disEndDisplay.text = finalDistance.ToString();
        }
    }

    private bool EndRunSequenceIsActive()
    {
        EndRunSequence endRunSequence = FindObjectOfType<EndRunSequence>();
        return endRunSequence != null && endRunSequence.endScreen != null && endRunSequence.endScreen.activeSelf;
    }

    public void StopUpdating()
    {
        isCounting = false; // Stops distance updates
    }

}