using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	PlayerHealthXR playerHealth;      // Reference to the player's health.
	EnemyHealthXR enemyHealth;        // Reference to this enemy's health.
	UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
	public GameObject[] destPoint;		// An array of the destination points this enemy can walk to
	private int destPointInt;
	public TimeManagerXR timer;

	void Start(){
		destPoint = GameObject.FindGameObjectsWithTag ("destPoint");
		destPointInt = Random.Range (0, destPoint.Length);

	}

	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <PlayerHealthXR> ();
		enemyHealth = GetComponent <EnemyHealthXR> ();
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}


	void Update ()
	{
		// If the enemy and the player have health left...
		if(enemyHealth.currentHealth > 0 && timer.timeLeft > 0)
		{
			// ... set the destination of the nav mesh agent to the player.
			Patrol();

		}
		// Otherwise...
		else
		{
			// ... disable the nav mesh agent.
			nav.enabled = false;
		}
	}

	void Patrol()
	{
		Debug.Log ("distance is " + Vector3.Distance (this.transform.position, destPoint [destPointInt].transform.position));
		if (Vector3.Distance (this.transform.position, destPoint [destPointInt].transform.position) >= 0.02) {

		} else {
			destPointInt = Random.Range (0, destPoint.Length);
		}
		nav.SetDestination (destPoint [destPointInt].transform.position);
	}

}
