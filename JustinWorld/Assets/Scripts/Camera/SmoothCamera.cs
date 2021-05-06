using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {

    //Variables that are used for camera speed and target
    public Transform camTarget;
    public float trackingSpeed;

    //Set the borders the camera can go
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //This runs every frame
    private void FixedUpdate() {
        if(camTarget != null) {
            //Lerp allows it to be a slow tracking
            var newPos = Vector2.Lerp(transform.position, camTarget.position, Time.deltaTime * trackingSpeed);
            var camPos = new Vector3(newPos.x, newPos.y, -10f);

            //Sets up clamps that will ensure our camera border works
            var clampX = Mathf.Clamp(camPos.x, minX, maxX);
            var clampY = Mathf.Clamp(camPos.y, minY, maxY);

            transform.position = new Vector3(clampX, clampY, -10f);

        }
    }

}
