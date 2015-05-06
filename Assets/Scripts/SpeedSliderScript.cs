using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedSliderScript : MonoBehaviour
{
	public float mmm;
	public float mm;
	public float m;
	public float z;
	public float p;
	public float pp;
	public float ppp;

	private Controller model;

	void Start()
	{
		model = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
		GetComponent<Slider>().onValueChanged.AddListener(OnValueChangedHandler);
	}

	void OnValueChangedHandler(float f)
	{
		int value = (int)f;
		switch (value)
		{
			case -3:
				model.timeSpeed = mmm;
				break;
			case -2:
				model.timeSpeed = mm;
				break;
			case -1:
				model.timeSpeed = m;
				break;
			case 0:
				model.timeSpeed = z;
				break;
			case 1:
				model.timeSpeed = p;
				break;
			case 2:
				model.timeSpeed = pp;
				break;
			case 3:
				model.timeSpeed = ppp;
				break;
		}
	}
}
