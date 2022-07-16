using UnityEngine;
using System.Collections;

public class OldCameraFollowScript : MonoBehaviour 
{
	[SerializeField] private GameObject PlayerCar;
	[SerializeField] private float OffSetX;
	[SerializeField] private float OffSetY;
	
	private bool Follow;

	void Start () 
	{
		Follow = true;
	}

	void FixedUpdate () 
	{
		if(Follow)
		transform.position = new Vector3 (PlayerCar.transform.position.x + OffSetX, PlayerCar.transform.position.y + OffSetY, -10.0f);	
	}
}
