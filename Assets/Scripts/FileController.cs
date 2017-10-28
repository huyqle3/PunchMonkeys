using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileController : MonoBehaviour
{
    // This represents the Input GameObject.
    private GameObject fileInputText;

	// Use this for initialization
	void Start () {
        fileInputText = GameObject.Find("Keyboard").transform.Find("Input").gameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Function that saves files. This is triggered as part of the LoadFile button.
    /// </summary>
    public void LoadFile()
    {
        // Currently, I'm using an explicitly declared file located here.
        string path = "Assets/Resources/SampleText.txt";

        // Not the best naming convention, but fileInputTextComponent is the Input GameObject's Text Component.
        Text fileInputTextComponent = fileInputText.GetComponent<Text>();
        // Replace the text inside the Input Text component with the file's text.
        fileInputTextComponent.text = File.ReadAllText(path);

        // For some reason, it comes with a new line, so this is a temporary fix to delete the new, extra line.
        fileInputTextComponent.text = fileInputTextComponent.text.Substring(0, fileInputTextComponent.text.LastIndexOf("\r\n"));
    }

    /// <summary>
    /// Write to a text file. Save whatever is currently in the Input to the text file.
    /// </summary>
    public void SaveFile()
    {
        string path = "Assets/Resources/SampleText.txt";

        // Open the file for writing.
        StreamWriter writer = new StreamWriter(path, false);
  
        // Current text inside the Input section.
        Text fileInputTextComponent = fileInputText.GetComponent<Text>();

        // Write to the text file whatever is currently inside the Text Input section.
        writer.WriteLine(fileInputTextComponent.text);
        writer.Close();

        // Re-load the text in the Input section.
        LoadFile();
    }
}
