using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MousePerspective : MonoBehaviour
{

    public float x, z;
    public float mouse_speed = 2.0f;

    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 2f, Ysensityvity = 2f;

    bool cursorLock = true;

    float minX = -90f, maxX = 90f;

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
      float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
      float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

      cameraRot *= Quaternion.Euler(-yRot, 0, 0);
      characterRot *= Quaternion.Euler(0, xRot, 0);

      // cameraRot = ClampRotation(cameraRot);

      cam.transform.localRotation = cameraRot;
      transform.localRotation = characterRot;

      UpdateCursorLock();
    }

    // 定期的に実行するUPdate
    private void FixedUpdate() {
      x = 0;
      z = 0;

      x = Input.GetAxisRaw("Horizontal") * mouse_speed;
      z = Input.GetAxisRaw("Vertical") * mouse_speed;

      // transform.position += cam.transform.forward * z + cam.transform.right * x;
    }

    public void UpdateCursorLock()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        cursorLock = false;
      }
      else if(Input.GetMouseButton(0))
      {
        cursorLock = false;
      }

      if (cursorLock)
      {
        Cursor.lockState = CursorLockMode.Locked;
      }
      else if(!cursorLock)
      {
        Cursor.lockState = CursorLockMode.None;
      }
    }
}
