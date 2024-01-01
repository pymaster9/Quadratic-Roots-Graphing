using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int moveSpeed;
    public int rotateSpeed;
    public bool rotate;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, Input.GetAxis("UpDown") * moveSpeed * Time.deltaTime, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, Space.Self);
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation += new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * rotateSpeed;
            transform.rotation = Quaternion.Euler(rotation);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            rotate = !rotate;
        }
    }
}
