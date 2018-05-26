using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenResolution : MonoBehaviour {

	public bool maintainWidth = false;
	[Range (-1,1)]
	public int adaptPosition;
	float defaultWidth;
	float defaultHeight;
	Vector3 cameraPos;
	// Use this for initialization
	void Start () {
		defaultHeight = 5;//Camera.main.orthographicSize; 
		defaultWidth = defaultHeight * 1.5f;//Camera.main.aspect; // handling screen resolution with 1.5 aspect ration
		cameraPos = Camera.main.transform.position;
		adaptPosition = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if(maintainWidth) 
		{
			Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
			float y = adaptPosition * (defaultHeight - Camera.main.orthographicSize );
			Camera.main.transform.position = new Vector3(cameraPos.x, y, cameraPos.z);
		}
		else
		{
			float x = adaptPosition * (defaultWidth - (Camera.main.orthographicSize * Camera.main.aspect));
			Camera.main.transform.position = new Vector3( x, cameraPos.y, cameraPos.z);
		}
	}
}
