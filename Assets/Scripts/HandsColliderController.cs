using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKeyboard.Utils;
using UnityEngine.UI;

public class HandsColliderController : MonoBehaviour
{

    KeyboardManager keyboardManagerScript;
    FileController fileControllerScript;

    private bool lockBetweenPunches = false;
    private float lockTime = 0.5f;
    private float lockTimeCheck;

    // Use this for initialization
    void Start()
    {
        keyboardManagerScript = GameObject.Find("Keyboard").GetComponent<KeyboardManager>();
        fileControllerScript = GameObject.Find("FileController").GetComponent<FileController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lockTimeCheck)
        {
            lockBetweenPunches = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!lockBetweenPunches)
        {
            // If it is a Character:
            if (collider.transform.parent.name == "Characters")
            {
                Text characterText = collider.GetComponentInChildren<Text>();
                keyboardManagerScript.GenerateInput(characterText.text);
                // Debug.Log("Collision entered: " + collider.name);
            }

            if (collider.transform.name == "CapsLock")
            {
                keyboardManagerScript.CapsLock();
            }

            if (collider.transform.name == "Back")
            {
                keyboardManagerScript.Backspace();
            }

            if (collider.transform.name == "Clear")
            {
                keyboardManagerScript.Clear();
            }

            if (collider.transform.name == "LoadFile")
            {
                fileControllerScript.LoadFile();
            }

            if (collider.transform.name == "SaveFile")
            {
                fileControllerScript.SaveFile();
            }

            lockBetweenPunches = true;
            lockTimeCheck = Time.time + lockTime;
        }
    }
}
