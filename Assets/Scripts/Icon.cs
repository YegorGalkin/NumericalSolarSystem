using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Icon : MonoBehaviour
{
	public GameObject objectToFollow;
	public Slider iconSize;

	void Start()
	{
		

		//Debug.Log(GetComponent<GUITexture>().texture.width);
		//Debug.Log(GetComponent<GUITexture>().texture.height);
		//Debug.Log(TexWtoH);

		//Debug.Log(Screen.width);
		//Debug.Log(Screen.height);
		//Debug.Log(ScrWtoH);

		//Debug.Log(GetComponent<Transform>().localScale.y * TexWtoH / ScrWtoH);
		//Debug.Log(GetComponent<Transform>().localScale.y);
	}

	void LateUpdate()
	{
		// Масштаб иконки ориентируется на iconSize и сохраняет все пропорции
		float TexWtoH = (float)GetComponent<GUITexture>().texture.width / (float)GetComponent<GUITexture>().texture.height;
		float ScrWtoH = (float)Screen.width / (float)Screen.height;
		GetComponent<Transform>().localScale = new Vector3(
			iconSize.value / (float)GetComponent<GUITexture>().texture.width * TexWtoH / ScrWtoH,
			iconSize.value / (float)GetComponent<GUITexture>().texture.height,
			GetComponent<Transform>().localScale.z);

		// Перемещение иконки вслед за объектом
		Vector3 ScreenCoords = Camera.main.WorldToScreenPoint(objectToFollow.transform.position);
		Vector3 ViewCoords = new Vector3(ScreenCoords.x/Screen.width,ScreenCoords.y/Screen.height,0);
		GetComponent<Transform>().position = ViewCoords;
	}
}
