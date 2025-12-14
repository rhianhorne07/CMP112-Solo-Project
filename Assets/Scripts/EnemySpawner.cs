using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        int numEnemies = Random.Range(5, 10);      //will spawn between 5 and 9 enemies
        //will randomly chose spawn point

        for (int x = 0; x < numEnemies; x++)
        {
            int PlaceToSpawn = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[PlaceToSpawn];

            if (spawnPoints[PlaceToSpawn] == null)
            {
                x--;  //try again
            }
            else
            {
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                spawnPoints[PlaceToSpawn] = null; //mark this spawn point as used
            }



        }

    }
}
