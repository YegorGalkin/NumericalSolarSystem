﻿using UnityEngine;
using System.Collections;
//using NumericalMethods;

public class Controller : MonoBehaviour
{
	public GameObject[] planets;
	public double time = 0;
	public double timeSpeed = 1;
	public double timePerStep;
	public int stepNum;
	public float trajectoryStep = 100;
	public int trajectoryStepNum = 10;

	private int currentStep;
	private int currentStep_model1;

	private Storages.VectorMegaStorage storage1;

	void Start()
	{
		currentStep_model1 = 0;
		storage1 = new Storages.VectorMegaStorage(timePerStep, stepNum);
		storage1.Initialise();
		for (int k = 0; k < planets.Length; k++)
		{
			planets[k].GetComponent<LineRenderer>().SetVertexCount(2 * trajectoryStepNum + 3);
		}
	}

	void FixedUpdate()
	{
		// Двигаем время
		time += timeSpeed * Time.deltaTime;

		// Рисуем траекторию
		int j = 0;
		var lastV = storage1.GetCoordinatesAtTime(0, 0);
		for (int i = -trajectoryStepNum; i < trajectoryStepNum; i++)
		{
			try
			{
				var v = storage1.GetCoordinatesAtTime((float)time + i * trajectoryStep, 0);
				for (int k = 0; k < planets.Length; k++)
				{
					planets[k].GetComponent<LineRenderer>().SetPosition(j, new Vector3(v[k * 3], v[k * 3 + 1], v[k * 3 + 2]));
					lastV = v;
				}
				j++;
			}
			catch (System.Exception ex) { }
			finally { }
		}
		while (j < 2 * trajectoryStepNum + 3)
		{
			for (int k = 0; k < planets.Length; k++)
			{
				planets[k].GetComponent<LineRenderer>().SetPosition(j, new Vector3(lastV[k * 3], lastV[k * 3 + 1], lastV[k * 3 + 2]));
			}
			j++;
		}

		// Выставляем координаты
		var f = storage1.GetCoordinatesAtTime((float)time, 0);
		int l = planets.Length;
		for (int i = 0; i < l; i++)
		{
			planets[i].GetComponent<Transform>().position = new Vector3(f[i * 3], f[i * 3 + 1], f[i * 3 + 2]);
		}
	}
}
