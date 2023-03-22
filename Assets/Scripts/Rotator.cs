using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	[SerializeField] private int rotateSpeed;
	
	private void Update () 
	{
		SpinAroundAxis();
	}

	private void SpinAroundAxis()
    {
		transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
	}
}