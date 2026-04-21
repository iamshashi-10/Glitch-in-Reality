using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class examplescene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RenderSettings.skybox = (Material)Resources.Load("Skybox6");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		int x = 50;
		int y = 50;
		int dy = 40;
		int cnt = 0;
		int sx = 300;
		int sy = 30;
		if (GUI.Button(new Rect(x, y+dy*cnt++, sx, sy), "Led to the formation of dust clouds")) {
			RenderSettings.skybox = (Material)Resources.Load("Skybox6");
		}
		if (GUI.Button(new Rect(x, y+dy*cnt++, sx, sy), "Stars formed from dust/matter clouds")) {
			RenderSettings.skybox = (Material)Resources.Load("Skybox2");
		}
		if (GUI.Button(new Rect(x, y+dy*cnt++, sx, sy), "After millions of years galaxies formed")) {
			RenderSettings.skybox = (Material)Resources.Load("Skybox1");
		}
		// if (GUI.Button(new Rect(x, y+dy*cnt++, sx, sy), "Skybox 3 - Large blueish galaxy")) {
		// 	RenderSettings.skybox = (Material)Resources.Load("Skybox3");
		// }
		// if (GUI.Button(new Rect(x, y+dy*cnt++, sx, sy), "After millions of years galaxies formed")) {
		// 	RenderSettings.skybox = (Material)Resources.Load("Skybox5");
		// }	
		if (GUI.Button(new Rect(x, y+dy*cnt++, sx, sy), "Observe our Milkyway galaxy")) {
			RenderSettings.skybox = (Material)Resources.Load("Skybox4");
		}
		if (GUI.Button(new Rect(x, y+dy*cnt++, sx, sy), "Exit")) {
			SceneManager.LoadScene("Spacecraft_interaction");
		}	
	}
}
