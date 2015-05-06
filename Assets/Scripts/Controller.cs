using UnityEngine;
using System.Collections;
//using NumericalMethods;

public class Controller : MonoBehaviour
{
	public GameObject[] planets;
	public double time = 0;
	public double timeSpeed = 1;
	public double timePerStep;
	public int stepNum;

	private int currentStep;
	private int currentStep_model1;

	private Storages.VectorMegaStorage storage1;

	void Start()
	{
		currentStep_model1 = 0;
		storage1 = new Storages.VectorMegaStorage(timePerStep,stepNum);
		storage1.Initialise();
	}

	void FixedUpdate()
	{
		// Двигаем время
		time += timeSpeed * Time.deltaTime;
		//currentStep = (int)(time / timePerStep);

		//while (currentStep > currentStep_model1)
		//{
		//	model1.NextStep();
		//	currentStep_model1++;
		//}

		var v = storage1.GetCoordinatesAtTime((float)time,0);

		int l = planets.Length;
		for(int i = 0; i < l; i++)
		{
			//planets[i].GetComponent<Transform>().position = new Vector3(i * Mathf.Cos((float)((l - i) * time)), i * Mathf.Sin((float)((l - i) * time)), 0);
			planets[i].GetComponent<Transform>().position = new Vector3(v[i * 3], v[i * 3 + 1], v[i * 3 + 2]);
		}
	}
}
