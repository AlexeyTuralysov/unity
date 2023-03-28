using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {

    private CharacterController _charController;
	// Use this for initialization
	void Start () {
        _charController = GetComponent<CharacterController>();

    }

    public float gravity = -9.9f;
    public float speed = 6.0f;

	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertival") * speed;
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;



        movement = transform.TransformDirection(movement); //
        _charController.Move(movement); //2acram ator eecTop



    }
}
