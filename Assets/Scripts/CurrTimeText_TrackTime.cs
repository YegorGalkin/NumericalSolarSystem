using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrTimeText_TrackTime : MonoBehaviour
{
	private Controller model;

	void Awake()
	{
		model = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
	}

	void LateUpdate()
	{
		GetComponent<Text>().text = model.time.ToString("0.00");
	}
}
