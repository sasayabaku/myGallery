using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftStickTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 現在のゲームパッド情報
        var current = Gamepad.current;
        if (current == null)
          return;

        // 左スティック入力取得
        var leftStickValue = current.leftStick.ReadValue();
        Debug.Log($"移動量：{leftStickValue}");
    }
}
