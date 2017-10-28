using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKeyboard.Utils;
using UnityEngine.UI;

public class HandsColliderController : MonoBehaviour
{
    // We use variables from these scripts.
    KeyboardManager keyboardManagerScript;
    FileController fileControllerScript;

    // Don't allow hitting the keys in between punches.
    // This lock blocks accidentally hitting multiple keys simultaneously.
    // Give a 0.5 second buffer time between hits, so that you only hit one key at a time.
    private bool lockBetweenPunches = false;

    private float lockTime = 0.5f;
    // We use lockTimeCheck to compare current time with the time 0.5 seconds from now.
    // Used in the Update() function.
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
        // Give a buffer time of 0.5 seconds in between punches.
        // Punches trigger the OnTriggerEnter. LOCK.
        // After 0.5 seconds after a punch hits a button, we will UNLOCK and allow more punches.
        if (Time.time > lockTimeCheck)
        {
            lockBetweenPunches = false;
        }
    }

    /// <summary>
    /// When your fist hits a keyboard button, you will trigger that button.
    /// Punch your way to victory. Punch the keys on the keyboard in front of you.
    /// </summary>
    /// <param name="collider"></param>
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

            // The KeyboardManager script contains character buttons.
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

            // The FileController script contains load and save buttons.
            if (collider.transform.name == "LoadFile")
            {
                fileControllerScript.LoadFile();
            }

            if (collider.transform.name == "SaveFile")
            {
                fileControllerScript.SaveFile();
            }

            // OK. We hit a button with our punch. LOCK.
            // The update function will UNLOCK after 0.5 seconds.
            lockBetweenPunches = true;
            lockTimeCheck = Time.time + lockTime;
        }
    }
}
