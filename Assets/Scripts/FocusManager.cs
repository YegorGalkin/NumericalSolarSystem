using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FocusManager : MonoBehaviour
{
	public GameObject focus;

	public Text name;
	public Text x;
	public Text y;
	public Text z;

	void Update()
	{
		if(focus)
		{
			name.text = focus.name;
			x.text = focus.GetComponent<Transform>().position.x.ToString();
			y.text = focus.GetComponent<Transform>().position.y.ToString();
			z.text = focus.GetComponent<Transform>().position.z.ToString();
		}
	}
}
