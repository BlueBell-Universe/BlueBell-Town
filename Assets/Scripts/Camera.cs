using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	GameObject player;
	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	void Update()
	{

	}

	void LateUpdate()
	{

		transform.position = new Vector3(player.transform.position.x, 0.5f, -2f);
	}
}
