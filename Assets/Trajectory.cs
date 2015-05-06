using UnityEngine;
using System.Collections;

public class Trajectory : MonoBehaviour
{
	private Controller controller;
	private LineRenderer line;

	public void Awake()
	{
		controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
		line = GetComponent<LineRenderer>();
	}

	public void Update()
	{
		line.SetPosition(0, transform.parent.position);
		line.SetPosition(1, controller.GetPlanetCoords(transform.parent.gameObject, controller.time + 100));
	}
}
