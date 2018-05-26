using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColorChanger : MonoBehaviour {

	public GameObject []mTiles;
	int mNoOftiles;
	int mNoOfColorTiles;
	int mCurrentTileIndex; 
	// Use this for initialization
	void Start () {
		mNoOftiles = 3;
		//mTiles = new GameObject[mNoOftiles]; //using array to save ref of tiles, so that easily access tiles   
		//ShowTiles(); // can do this all using editor but did through script ,because can add n tiles with scripts with minor changes  
	}
	
	void DisableTilesClick(){ // if tap on any tile then disbale all tiles so that can not be tap again
		for(int i = 0; i < mNoOftiles; i++)
		{
			GameObject tile = mTiles[i];
			Button tileBtn = tile.transform.GetComponent<Button>();
			ColorBlock cb = tileBtn.colors;
			cb.disabledColor = new Color(1,1,1,1);;
			tileBtn.colors = cb;
			tileBtn.interactable = false;
		}
	}
	public void TileClick(int index)
	{
		DisableTilesClick();
		mNoOfColorTiles = 0;
		mCurrentTileIndex = index;
		InvokeRepeating("ChnageColorOfTile",0,1); // call this method "ChnageColorOfTile " with interval of 1 sec 
	}

	public void ChnageColorOfTile()
	{
		if(mNoOfColorTiles >= mNoOftiles)// all tiles color have been changes so switch scene, cancel invokerepeating
		{
			CancelInvoke();
			SceneManager.LoadScene("scene2");
			return;
		}
		GameObject tile = mTiles[mCurrentTileIndex];
		float red = UnityEngine.Random.Range(0f,1f);
		float green = UnityEngine.Random.Range(0f,1f);
		float blue = UnityEngine.Random.Range(0f,1f);
		tile.GetComponent<Image>().color = new Color(red,green,blue); // randomly making color 
		mCurrentTileIndex = (mCurrentTileIndex+1)%mNoOftiles;
		mNoOfColorTiles++;
	}

	/* 
		CAN BE DONE THROUGH CODE TOO,  JUST UNCOMMENT THE CODE, also UNCOMMENT code in start method */
	/*
	
	void ShowTiles(){
		
		Transform canvas = GameObject.Find("Canvas").transform;
		if(canvas==null)
			return;
		GameObject tilePrefeb = Resources.Load<GameObject>("tile");
		if(tilePrefeb == null) 
			return;
		for(int i = 0; i< mNoOftiles; i++)
			MakeTile(ref canvas, ref tilePrefeb, i);
				

	}
	void MakeTile(ref Transform canvas,ref GameObject tilePrefeb, int index)
	{
		GameObject tile = Instantiate(tilePrefeb); 
		tile.transform.SetParent(canvas);
		AddListnerOnTile(tile,index);
		mTiles[index] = tile;
		switch(index)
		{
			case 0:
				SetTileAtTopLeft(tile);
				break;
			case 1:
				SetTileAtTopMiddle(tile);
				break;
			case 2:
				SetTileAtTopRight(tile);
				break;
			default:
				SetTileAtTopMiddle(tile);
				break;
				
		}
	}
	void SetTileAtTopLeft(GameObject tile)
	{
		SetAnchorOfTile(tile,Vector2.zero);
		tile.transform.position = new Vector3(512-320,600,0);
	}
	void SetTileAtTopMiddle(GameObject tile)
	{
		SetAnchorOfTile(tile,new Vector2(0.5f,1));
		tile.transform.position = new Vector3(512,600,0);		
	}
	
	void SetTileAtTopRight(GameObject tile)
	{
		SetAnchorOfTile(tile,Vector2.one);
		tile.transform.position = new Vector3(512+320,600,0);
	}

	void SetAnchorOfTile(GameObject tile, Vector2 point)
	{
		RectTransform tileRect = tile.transform.GetComponent<RectTransform>();
		tileRect.anchorMin = point;
		tileRect.anchorMax = point;
	}

	void AddListnerOnTile(GameObject tile, int index)
	{
		Button tileBtn = tile.AddComponent<Button>();
		tileBtn.onClick.RemoveAllListeners();
		tileBtn.onClick.AddListener(()=>TileClick(index));
		
	}
	 */

}
