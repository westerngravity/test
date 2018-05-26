using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDragController : MonoBehaviour {

	GameObject mTile; // use for draged tile ref

	// Update is called once per frame
	void Update () {
		if(!GameManager.Instance.CanDrag())// if all tiles destroyed retuen 
			return;
		#if !UNITY_EDITOR
			if (Input.touchCount != 1) {
				return;
			}
			Touch touch = Input.touches [0];
			Vector3 touch_pos = touch.position;
			bool began = (touch.phase == TouchPhase.Began) ? true : false;
			bool end = (touch.phase == TouchPhase.Ended) ? true : false;
			bool move = (touch.phase == TouchPhase.Moved) ? true : false;
		#else
			Vector3 touch_pos = Input.mousePosition;
			bool began = (Input.GetMouseButtonDown(0)) ? true : false;
			bool end = (Input.GetMouseButtonUp(0)) ? true : false;
			bool move =  (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0) ? true : false;
		#endif
		if(began)
		{
			TouchBegan(touch_pos); 
		}
		if(move)
		{
			TouchMove(touch_pos);
		}
		if(end)
		{
			TouchEnd(touch_pos);
		}
	}
	void TouchBegan(Vector3 touchPosition)
	{
		Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(touchPosition);		
		Ray ray = new Ray(touchPosWorld,Camera.main.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(touchPosWorld,Vector3.forward, out hit))
		{
			if(hit.collider.tag == "righttile") // if tap on right tiles
			{
				GameObject gob = hit.collider.gameObject;
				if(gob != null)
				{	
					MakeTileClone(gob);
				}
			}
		}
	}
	void TouchMove(Vector3 touchPosition)
	{
		if(mTile!=null){
			Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(touchPosition);		
			mTile.transform.localPosition = touchPosWorld;
		}
	}
	void TouchEnd(Vector3 touchPosition)
	{
		if(mTile!=null){
			mTile.GetComponent<DestroyTile>().DestroyTileObject();
		}
	}
	void MakeTileClone(GameObject tileObj)
	{
		mTile = Instantiate(tileObj);
		mTile.name = tileObj.name;
		mTile.transform.SetParent(tileObj.transform.parent);
		mTile.GetComponent<SpriteRenderer>().sortingOrder = 2; // set sorting order at top of all
	}
}
