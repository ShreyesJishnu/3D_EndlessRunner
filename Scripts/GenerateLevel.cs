using System.Collections;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sections;
    public int zPos = 50;
    public float generationInterval = 5f;

    private Coroutine generationCoroutine;

    void Start()
    {
        // Start the level generation coroutine when the game begins
        if (sections.Length > 0)
        {
            generationCoroutine = StartCoroutine(GenerateSections());
        }
        else
        {
            Debug.LogError("No sections assigned for generation.");
        }
    }

    void OnDestroy()
    {
        // Stop the coroutine if the object is destroyed
        if (generationCoroutine != null)
        {
            StopCoroutine(generationCoroutine);
        }
    }

    IEnumerator GenerateSections()
    {
        while (true)
        {
            GenerateSection();
            yield return new WaitForSeconds(generationInterval);
        }
    }

    private void GenerateSection()
    {
        int sectionIndex = Random.Range(0, sections.Length);
        Vector3 spawnPosition = new Vector3(0, 0, zPos);

        Instantiate(sections[sectionIndex], spawnPosition, Quaternion.identity);
        zPos += 50;
    }
}