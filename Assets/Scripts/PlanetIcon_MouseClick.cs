using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetIcon_MouseClick : MonoBehaviour
{
	private FocusManager focus;

	void Awake()
	{
		focus = GameObject.FindGameObjectWithTag("FocusManager").GetComponent<FocusManager>();
	}

	void Update()
	{
		if(Input.GetMouseButton(0)) //left click
		{
			Rect rect = GetComponent<GUITexture>().GetScreenRect();
			if(rect.Contains(Input.mousePosition))
			{
				focus.focus = gameObject.transform.parent.gameObject;
			}
		}
	}
}
