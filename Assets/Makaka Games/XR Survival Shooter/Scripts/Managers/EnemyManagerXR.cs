using UnityEngine;

public class EnemyManagerXR : MonoBehaviour
{
    public PlayerHealthXR playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 5f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
	public TimeManagerXR timer;
	private GameObject floor;

    void Start ()
    {
		floor = GameObject.FindGameObjectWithTag ("ARPlayground");
		// Prevent spawn before image target first found, which will cause enemy floating on screens

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }
		

    void Spawn ()
    {
		if (floor.GetComponent<BoxCollider> ().enabled) {
		

			// If the player has no health left...
			if (timer.timeLeft <= 0) {
				// ... exit the function.
				return;
			}

			// Find a random index between zero and one less than the number of spawn points.
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			//GameObject ob = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			GameObject ob = Instantiate (enemy);
			ob.transform.SetParent (GameObject.FindGameObjectWithTag ("enemy").transform);
			ob.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			ob.transform.localRotation = spawnPoints [spawnPointIndex].rotation;
			//ob.transform.localPosition = new Vector3 (0f, 0f, 0f);
			ob.transform.position = spawnPoints [spawnPointIndex].position;

		}
	}
}