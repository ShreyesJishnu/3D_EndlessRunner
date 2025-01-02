using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject livePoints;
    public GameObject liveDis;
    public GameObject endScreen;
    public GameObject fadeOUT;


    private LevelDistance levelDistance;


    void Start()
    {
        StartCoroutine(EndSequence());
        // Find the LevelDistance script to trigger display updates if necessary
        levelDistance = FindObjectOfType<LevelDistance>();

    }
    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(3f);
        livePoints.SetActive(false);
        liveDis.SetActive(false);

        


        endScreen.SetActive(true);



        yield return new WaitForSeconds(3f);
       
        fadeOUT.SetActive(true);




        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);




    }
}

   

