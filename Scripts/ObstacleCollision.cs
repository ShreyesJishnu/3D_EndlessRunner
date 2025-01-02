using System.Collections;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject Player;
    public GameObject charModel;
    public AudioSource collision;
    public GameObject mainCamera;
    public GameObject LevelControl;
    public AudioSource background;

    private LevelDistance levelDistance;


    private void Start()
    {
        levelDistance = LevelControl.GetComponent<LevelDistance>();
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        collision.Play();
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        Player.GetComponent<PlayerMovement>().enabled = false;
        // Stop distance updates
        levelDistance.StopUpdating();

        mainCamera.GetComponent<Animator>().enabled = true;
        LevelControl.GetComponent<LevelDistance>().enabled = false;
        LevelControl.GetComponent<EndRunSequence>().enabled = true;
        StartCoroutine(StopMusic());
    }

    IEnumerator StopMusic()
    {
        yield return new WaitForSeconds(3f);
        background.Stop();
    }
}
