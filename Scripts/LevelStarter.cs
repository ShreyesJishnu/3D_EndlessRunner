using System.Collections;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGO;
    public GameObject fadeIN;
    public AudioSource readyFX;
    //public AudioSource goFX;

    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDownGO.SetActive(true);
        PlayerMovement.canMove = true;
    }

}
