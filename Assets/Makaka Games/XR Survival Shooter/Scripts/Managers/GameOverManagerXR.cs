using UnityEngine;
using UnityEngine.Events;

public class GameOverManagerXR : MonoBehaviour
{
    public PlayerHealthXR playerHealth;       // Reference to the player's health.
    public Animator animator;                          // Reference to the animator component.
    public UnityEvent OnGameOver;
	public TimeManagerXR timer;
	public PlayerShootingXR shootingXR;

    void Update ()
    {

        // If the player has run out of health...
		if(timer.timeLeft <= 0)
        {
			shootingXR.enabled = false;
            // ... tell the animator the game is over.
            animator.SetTrigger ("GameOver");
        }

    }

    public void GameOver()
    {
        OnGameOver.Invoke();
    }
}