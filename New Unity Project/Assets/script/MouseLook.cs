using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MouseLook : MonoBehaviour
{

     void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }


    public enum RotationAxes
  
    {
        MouseXAndY=0,
        MouseX=1,
        MouseY=2   
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minimunvert = -45.0f;
    public float maximunvert = 45.0f;
    private float _rotationx = 0;

    public float speed = 6.0f;
    void Update()
    {
        
        if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("MouseX") * sensitivityHor, 0);
        }

        else if (axes == RotationAxes.MouseY)
        {
            _rotationx -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationx = Mathf.Clamp(_rotationx, minimunvert, maximunvert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationx, rotationY, 0);
        }
        else
        {
            _rotationx -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationx = Mathf.Clamp(_rotationx, minimunvert, maximunvert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationx, rotationY, 0);
        }




    }
   
}
