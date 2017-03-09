using UnityEngine;
using System.Collections;

public class MoveLight : MonoBehaviour {


    public VolumetricLight viewpoint;
    public float rotationSpeed;
    private CapsuleCollider myCollider;
	// Use this for initialization
	void Start () {
        myCollider = gameObject.GetComponent<CapsuleCollider>();
        viewpoint.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (float)(myCollider.height / 2), gameObject.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.RightArrow))
        {
            var distance = Time.deltaTime * rotationSpeed;
            viewpoint.transform.Rotate(distance, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var distance = Time.deltaTime * -rotationSpeed;
            viewpoint.transform.Rotate(distance, 0, 0);
        }
	}
}
