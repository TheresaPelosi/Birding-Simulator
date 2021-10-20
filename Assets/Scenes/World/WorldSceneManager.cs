using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSceneManager : PocketDroidsSceneManager {
	private GameObject droid;
	private AsyncOperation loadScene;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void playerTapped(GameObject player) {
		
	}

	public override void droidTapped(GameObject droid) {
        DontDestroyOnLoad(droid);
		List<GameObject> objects = new List<GameObject>();
		objects.Add(droid);
		SceneTransitionManager.Instance.
			GoToScene(PocketDroidsConstants.SCENE_SNAP, objects);
	}
}
