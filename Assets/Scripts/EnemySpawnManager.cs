using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public GameObject zombiePrefab;
    public float spawnRadius = 5f;
    public int numberOfZombies = 6;
    public float spawnDelay = 0.5f;

    public float aRange = -1f;
    public float bRange = 1f;

    private bool hasSpawned = false;


    // Update is called once per frame
    void Update()
    {
        if (!hasSpawned && PlayerInRange())
        {
            StartCoroutine(SpawnZombies());
        }
    }


    //Method to check if player is in range of spawn point
    private bool PlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("Player object not found. Ensure the Player is tagged correctly.");
            return false;
        }

        // Calculate distance between this spawner and the player
        float distance = Vector3.Distance(transform.position, player.transform.position);

        return distance <= spawnRadius;
    }


    //couroutine
    private System.Collections.IEnumerator SpawnZombies()
    {
        hasSpawned = true;

        for (int i = 0; i < numberOfZombies; i++)
        {
            if (zombiePrefab != null)
            {
                Vector3 spawnPosition = transform.position + new Vector3(Random.Range(aRange, bRange), 0, Random.Range(aRange, bRange));
                Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                Debug.Log("Zomb prefab not assigned!");
                break;
            }
        }
        Debug.Log($"Spawned {numberOfZombies} zombies at {transform.position}");
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
