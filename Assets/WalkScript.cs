using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkScript : MonoBehaviour

{
    // Unity側のコンソールでSpeedの項目があるので、そこを書き換えて調整
    public float speed = 1.0f;
    public float rotateSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) {
            // 前進
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if ((Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) && Keyboard.current.shiftKey.isPressed) {
            // 水平移動(左)
            transform.position -= transform.right * speed * Time.deltaTime;
        } else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) {
            // 左回転
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }

        if ((Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) && Keyboard.current.shiftKey.isPressed) {
            // 水平移動(右)
            transform.position += transform.right * speed * Time.deltaTime;
        } else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) {
            // 右回転
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) {
            // 後退
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
    }
}
