using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Transform PlayerTransform;

    public float YOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 CamPos = GetComponent<Transform>().position;
        GetComponent<Transform>().position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + YOffset, CamPos.z);
	}
}
