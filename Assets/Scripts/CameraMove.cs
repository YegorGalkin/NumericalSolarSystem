using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	public float speed;
	public float mouseSpeed;

	void Update()
	{
		GetComponent<Transform>().position += GetComponent<Transform>().right * Time.deltaTime * Input.GetAxis("Horizontal") * speed;
		GetComponent<Transform>().position += GetComponent<Transform>().up * Time.deltaTime * Input.GetAxis("Vertical") * speed;

		GetComponent<Camera>().orthographicSize -= Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * mouseSpeed;
		GetComponent<Camera>().orthographicSize -= Time.deltaTime * Input.GetAxis("MoveUp") * speed;
	}
}
