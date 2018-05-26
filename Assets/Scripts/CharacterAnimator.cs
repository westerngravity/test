using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {

	Animator mZoombiAnimator;

	// Use this for initialization
	void Start () {
		mZoombiAnimator = this.GetComponent<Animator>();
		DontDestroyOnLoad(this.gameObject); // do not destroyed on scene switch
	}
	
	// this will called when click on character
	void OnMouseDown() { 
		if(!mZoombiAnimator.GetCurrentAnimatorStateInfo(0).IsName("idle")) // if not in idle state mean some animation is playing so return 
			return;
		mZoombiAnimator.SetTrigger(GetRandomStateName()); //get random name 
	}

	string GetRandomStateName()
	{
		int randValue = UnityEngine.Random.Range(0,3); // 
		switch(randValue)
		{
			case 0:
				return "walk";
			case 1:
				return "attack";
			case 2:
				return "fall_back";
		}
		return "walk";
	}
}
