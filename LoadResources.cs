using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadResources : MonoBehaviour {
    Texture2D myTexture;
    // Use this for initialization
    void Start () {
        myTexture = Resources.Load("TestImage") as Texture2D;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI(Texture2D mytexture)
    {
        GUI.DrawTexture(new Rect(0, 0, 50, 50), mytexture);
    }
}
