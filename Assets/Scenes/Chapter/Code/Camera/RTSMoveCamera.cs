using UnityEngine;

// use RTS style camera movement
[RequireComponent(typeof(Camera))]
public class RTSMoveCamera : MonoBehaviour {

    public Camera Camera;
    // Speed at which the Camera moves
    public int Speed;
    // Distance where mouse will start moving the camera
    public float Sensitivity;

    private Vector3 cameraVel = Vector3.zero;

    private void Awake()
    {
        Camera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update () {
        // Preempt the zero velocity
        cameraVel = Vector3.zero;
        
        if(Input.mousePosition.y >= Screen.height - Sensitivity)
        {
            cameraVel += Vector3.up;
        }
        if(Input.mousePosition.x >= Screen.width - Sensitivity)
        {
            cameraVel += Vector3.right;
        }
        if(Input.mousePosition.y <= Sensitivity)
        {
            cameraVel += Vector3.down;
        }
        if(Input.mousePosition.x <= Sensitivity)
        {
            cameraVel += Vector3.left;
        }

        cameraVel = Vector3.Normalize(cameraVel) * Speed * Time.deltaTime;

        Camera.transform.Translate(cameraVel);
	}
}
