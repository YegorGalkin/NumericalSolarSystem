using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewTimeBtn : MonoBehaviour
{
	public Text sourceText;

	private Controller model;

	void Start()
	{
		model = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
		GetComponent<Button>().onClick.AddListener(onClickHandler);
	}

	void onClickHandler()
	{
		model.time = float.Parse(sourceText.text);
	}
}
