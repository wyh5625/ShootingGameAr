using UnityEngine;

public class EnemyManagerXR : MonoBehaviour
{
    public PlayerHealthXR playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 30f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start ()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }
		

    void Spawn ()
    {
        // If the player has no health left...
        if(playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //GameObject ob = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		GameObject ob = Instantiate (enemy);
		ob.transform.SetParent(GameObject.FindGameObjectWithTag("ARPlayground").transform);
		ob.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		ob.transform.localRotation = spawnPoints[spawnPointIndex].rotation;
		//ob.transform.localPosition = new Vector3 (0f, 0f, 0f);
		ob.transform.position = spawnPoints [spawnPointIndex].position;
		//ob.transform.position = new Vector3 (-8f, -8f, -8f);

		/*
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.SetParent(GameObject.FindGameObjectWithTag("ARPlayground").transform);

		cube.transform.localRotation = spawnPoints[spawnPointIndex].rotation;
		cube.transform.localPosition = spawnPoints [spawnPointIndex].position;
		//ob.transform.localRotation = ob.transform.rota
		//ob.transform.localPosition = new Vector3 (0f, 0f, 0f);
		*/
	}
}