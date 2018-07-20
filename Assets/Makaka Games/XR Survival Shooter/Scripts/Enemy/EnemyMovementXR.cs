using UnityEngine;
using System.Collections;

public class EnemyMovementXR : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	PlayerHealthXR playerHealth;      // Reference to the player's health.
	EnemyHealthXR enemyHealth;        // Reference to this enemy's health.
	UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
	public GameObject[] destPoint;		// An array of the destination points this enemy can walk to
	private int destPointInt;
	private TimeManagerXR timer;
	public bool isOnNavMesh;

	void Start(){
		destPoint = GameObject.FindGameObjectsWithTag ("destPoint");
		destPointInt = Random.Range (0, destPoint.Length);
		timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<TimeManagerXR>();

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
		isOnNavMesh = nav.isOnNavMesh;
		if (!isOnNavMesh && GetComponent<EnemyHealthXR>().currentHealth > 0){
			DestroyObject (gameObject);
			Debug.Log ("this object is not on nav mesh!");
		}
		// If the enemy and the player have health left...
		if(enemyHealth.currentHealth > 0 && timer.timeLeft > 0)
		{
			// ... set the destination of the nav mesh agent to the player.
			nav.enabled = true;
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
		//Debug.Log ("distance is " + Vector3.Distance (this.transform.localPosition, destPoint [destPointInt].transform.localPosition));
		if (Vector3.Distance (this.transform.localPosition, destPoint [destPointInt].transform.localPosition) >= 0.1) {
			// haven't reached the point

		} else {
			// reached the point and changed destination randomly
			destPointInt = Random.Range (0, destPoint.Length);
		}
		nav.SetDestination (destPoint [destPointInt].transform.position);
		//nav.destination = destPoint [destPointInt].transform.localPosition;
	}

}
