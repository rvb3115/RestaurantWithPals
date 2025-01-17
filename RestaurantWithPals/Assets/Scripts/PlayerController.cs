using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public new Camera camera;
    
    [Header("Configurations")]
    public float walkspeed;
    public float runspeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
    }

    void FixedUpdate() {
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runspeed : walkspeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = newVelocity;
    }

    void LateUpdate() {
        //vertical rotation
      Vector3 e = head.eulerAngles;
      e.x -= Input.GetAxis("Mouse y") * 2f;
      e.x = RestrictAngle(e.x, -85f, 85f);
      head.eulerAngles = e;
    }

    //clamp vertical head rotation (prevent bending backwards)
    public static float RestrictAngle(float angle, float min, float max) {
        if (angle > 180f) 
        angle -= 360;
        if (angle < -180f)
        angle += 360;
        return Mathf.Clamp(angle, min, max);

    }
}
