using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileController : MonoBehaviour {

    private GameObject fileInputText;

	// Use this for initialization
	void Start () {
        fileInputText = GameObject.Find("Keyboard").transform.Find("Input").gameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Function that saves files.
    /// </summary>
    public void LoadFile()
    {
        string path = "Assets/Resources/SampleText.txt";

        // TextAsset textAsset = Resources.Load("SampleText") as TextAsset;
        Text fileInputTextComponent = fileInputText.GetComponent<Text>();
        fileInputTextComponent.text = File.ReadAllText(path);
    }

    /// <summary>
    /// Write to a text file.
    /// </summary>
    public void SaveFile()
    {
        string path = "Assets/Resources/SampleText.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        // Current text in the editor.
        Text fileInputTextComponent = fileInputText.GetComponent<Text>();

        writer.WriteLine(fileInputTextComponent.text);
        writer.Close();

        LoadFile();
    }

    
    public static void DeleteLastLine(string filepath)
    {
        List<string> lines = new List<string>(File.ReadAllLines(filepath));

        File.WriteAllLines(filepath, lines.GetRange(0, lines.Count - 1).ToArray());

    }
}
