using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CraneObject : MonoBehaviour {

	// Use this for initialization
	void Start () {

        var _asset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/CRANE.FBX");
        AnimationClip[] animations = AnimationUtility.GetAnimationClips(_asset);

        AnimationClip grabAnim = animations[0];

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
