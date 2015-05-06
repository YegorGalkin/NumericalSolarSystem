using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeBtnScript : MonoBehaviour
{
	private Controller model;

	void Start()
	{
		model = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
		GetComponent<Button>().onClick.AddListener(onClickHandler);
	}

	void onClickHandler()
	{
		model.time = 0f;
	}
}