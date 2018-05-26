using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour {

	public bool mCollided = false;
	GameObject mTile;
 	void OnCollisionStay(Collision col) { // 
		 GameObject tile = col.gameObject;
		 if(IsTypeOf(tile.name, tile.tag)) // if same tile overlap
		 {
			 float distance = (this.transform.position - tile.transform.position).magnitude;
			 if(distance < 1f) // if tile closer to each other  
			 {
				 mTile = tile;	
				 mCollided = true;			 
				 Invoke("DestroyObject",0.25f); // destroy tile after .25 ssec inwhile tile destroy effect animation will play
				 tile.transform.Find("destroy_effect").gameObject.SetActive(true);				 
				 this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0); // set visible false sprite of this tile
			 }
			 	
		 }
	}
	bool IsTypeOf(string name, string tag)
	{
		return (name == this.gameObject.name & tag!= this.gameObject.tag); 
	}
	void DestroyObject() // destro the similar tile that collide with this tile
	{
		if(mTile!=null){
			Destroy(mTile);
			GameManager.Instance.TileDestroyed();
			mCollided = false;
			DestroyTileObject();
		}
	}
	public void DestroyTileObject()
	{
		if(!mCollided)
			Destroy(this.gameObject);
		else
			this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);

	} 
}
