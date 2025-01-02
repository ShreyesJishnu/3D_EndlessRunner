using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectionManager : MonoBehaviour
{
    public static int coinCount;
    public GameObject cointCountDisplay;
    public GameObject coinEndDisplay;

    void Update()
    {
        cointCountDisplay.GetComponent<TextMeshProUGUI>().text = ""+  coinCount;
        coinEndDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinCount;
    }
}
