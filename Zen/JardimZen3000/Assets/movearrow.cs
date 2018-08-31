using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movearrow : MonoBehaviour {
    public float rotationSpeed = 8;  //This will determine max rotation speed, you can adjust in the inspector

    Camera cam;  //Drag the camera object here

    public void StartGame()
    {
        Time.timeScale = 1F;
    }

    // Use this for initialization
    void Start () {
        cam = Camera.main;
        Time.timeScale = 0F;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(Input.GetAxis("Horizontal")*Vector3.right+Input.GetAxis("Vertical")*Vector3.forward);
        //Get mouse position
        Vector3 mousePos = Input.mousePosition;

        //Adjust mouse z position
        mousePos.z = cam.transform.position.y - transform.position.y;

        //Get a world position for the mouse
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos);

        //Get the angle to rotate and rotate
        float angle = -Mathf.Atan2(transform.position.z - mouseWorldPos.z, transform.position.x - mouseWorldPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, angle, 0), rotationSpeed * Time.deltaTime);
    
}
}
