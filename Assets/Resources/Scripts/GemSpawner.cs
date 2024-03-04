using UnityEngine;
using System.Collections;

public class GemSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    bool first = true;

    // Use this for initialization
    void Start()
    {
        // infinite gem spawning function, asynchronous
        StartCoroutine(SpawnGem());
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator SpawnGem()
    {
        while (true)
        {
            // Prevent a gem from spawning at the start of the game
            if (first)
            {
                first = false;
            }
            else
            {
                // instantiate a gem in this row at a random height
                Instantiate(
                    prefabs[Random.Range(0, prefabs.Length)],
                    new Vector3(26, Random.Range(-10, 10), 10),
                    Quaternion.identity
                );
            }

            // pause 5-8 seconds until the next gem spawns
            yield return new WaitForSeconds(Random.Range(5, 8));
        }
    }
}
