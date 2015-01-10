﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Texture2D crosshair;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.GetComponent<Enemy>()) {
					hit.collider.GetComponent<Enemy>().Damage(1);
				}
			}
		}
	}

	void OnGUI() {
		Vector2 targetSize = new Vector2(20, 20);
		GUI.DrawTexture(new Rect(Input.mousePosition.x - targetSize.x / 2, Screen.height - Input.mousePosition.y - targetSize.y / 2, targetSize.x, targetSize.y), this.crosshair);
	}
}
