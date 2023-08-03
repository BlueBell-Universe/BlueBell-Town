using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	GameObject player;
	float offset = 0.5f;
	void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	void Update()
	{

	}

	void LateUpdate()
	{

		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset, -2f);
	}
}
