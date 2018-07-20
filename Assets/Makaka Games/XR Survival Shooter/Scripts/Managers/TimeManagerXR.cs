using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using TMPro;

public class TimeManagerXR : MonoBehaviour
{
	public int timeLeft; // in unit of second
	private static int timeLeft_Prev;

	//TextMeshPro text; // VR version
	TextMeshProUGUI text; // AR version

	static bool isTimeChanged = false;

	void Awake ()
	{
		// Set up the reference.
		//text = GetComponent <TextMeshPro> (); // VR version
		text = GetComponent <TextMeshProUGUI> (); // AR version

		// Reset the score.
		timeLeft_Prev = timeLeft = 30;
		UpdateUI ();
		Time.timeScale = 1;
		StartCoroutine ("LoseTime");

	}



	void UpdateUI()
	{
		text.text = timeLeft.ToString();

		isTimeChanged = false;
	}

	void Update()
	{
		if (timeLeft != timeLeft_Prev) {
			isTimeChanged = true;
			timeLeft_Prev = timeLeft;
		}
		if (isTimeChanged)
		{
			UpdateUI();
		}
	}

	IEnumerator LoseTime()
	{
		while(true)
		{
			yield return new WaitForSeconds (1);
			if(timeLeft > 0)
				timeLeft--;
		}
	}
}