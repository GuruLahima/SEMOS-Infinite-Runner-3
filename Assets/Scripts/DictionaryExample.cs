using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DictionaryExample : MonoBehaviour
{
    public TMP_InputField studentNameField;
    public Button someButton;
    public Slider someSlider;
    public Toggle someToggle;

    public List<string> someList = new List<string>();
    public Dictionary<string, int> gradesDictionary = new Dictionary<string, int>();

    private void OnEnable()
    {
        studentNameField.onEndEdit.AddListener(OnEntrySubmitted);

        // someSlider.onValueChanged.AddListener(OnMusicVolumeUpdated);

        // someToggle.onValueChanged.AddListener(OnFullScreenToggled);
    }


    public void OnEntrySubmitted(string input)
    {
        gradesDictionary.Add(input, 0);

        studentNameField.text = "";

        foreach (KeyValuePair<string, int> zapis in gradesDictionary)
        {
            //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            Debug.LogFormat("Key = {0}, Value = {1}", zapis.Key, zapis.Value);
        }
    }

    public void OnMusicVolumeUpdated(float newValue)
    {
        Debug.Log("The value was changed to " + newValue);
    }

    public void OnFullScreenToggled(bool value)
    {
        Debug.Log("The screen was maximized: " + value);

    }


}
