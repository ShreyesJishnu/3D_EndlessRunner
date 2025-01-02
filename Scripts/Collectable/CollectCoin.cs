using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinSFX;
    void OnTriggerEnter(Collider other)
    {
        coinSFX.Play();
        CollectionManager.coinCount++;
        this.gameObject.SetActive(false);
    }
}
