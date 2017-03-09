using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float factor;
    public float MaxSpeedX;
    public float MinSpeedX;
    public float MaxSpeedZ;
    public float MinSpeedZ;
    public float JumpSpeed;

    public float GravityFactor;

    public bool isZLocked = true;

    private int dirReversal = -1;

    public bool inJump = false;
    public bool onGround = true;
    public Transform GroundCheckObject;
    private float GroundCheckRadius = 0.2f;
    public LayerMask GroundLayerMask; // All the Platforms should be in this layer.

    private float gravity = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Collider[] kap = Physics.OverlapSphere(GroundCheckObject.position, GroundCheckRadius, GroundLayerMask);
        //onGround = kap.Length > 0 ? true : false;

        onGround = Physics.Raycast(GroundCheckObject.position, Vector3.down, GroundCheckRadius, GroundLayerMask);

        float moveX = dirReversal * Clamp(Input.GetAxis("Horizontal"), 0) * factor;
        float moveZ = dirReversal * ((!isZLocked) ? Clamp(Input.GetAxis("Vertical"), 1) * factor : 0.0f);

        Vector3 MoveVec = new Vector3(moveX, 0.0f, moveZ);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //Jump
            //onGround = false;
            inJump = true;
        }else if ( onGround)
        {
            inJump = false;
            gravity = 0;
        }

        if ( inJump)
        {
            MoveVec.y = JumpSpeed;
        }
        
        if ( !onGround)
        {
            gravity += Physics.gravity.y * Time.deltaTime * GravityFactor;
            MoveVec.y += gravity;
        }

        GetComponent<CharacterController>().Move(MoveVec);

    }

    float Clamp(float _input, int Axis) // Axis -- 0 for X and 1 For Z
    {
        return (( _input < 0.0f ) ? ( -1.0f) : (1.0f) ) * ((Axis == 0) ? Mathf.Clamp(Mathf.Abs(_input), MinSpeedX, MaxSpeedX) : Mathf.Clamp(Mathf.Abs(_input), MinSpeedX, MaxSpeedX));
    }


}