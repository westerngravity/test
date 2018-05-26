using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {

    static GameManager instance = null;
	int mNoOfTilesToDestroy;
	// Use this for initialization
	void Start () {
            instance = this;
			mNoOfTilesToDestroy = 4; // no of tiles in second scene
	}
	public static GameManager Instance{
        get{
            return instance;
        }
    }
	public void TileDestroyed()
	{
		mNoOfTilesToDestroy--;
		if(!CanDrag()) //load image
		{
			LoadAssetbundle();
		}
	}
	void LoadAssetbundle() 
	{
		var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath,"refimage"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
		var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("ref_image");
		if(prefab != null)
		{
			Instantiate(prefab);
		}
    
        myLoadedAssetBundle.Unload(false);
	}
	public bool CanDrag()
	{
		return (mNoOfTilesToDestroy > 0); // can not drag if all tile destoyed 
	} 
}
