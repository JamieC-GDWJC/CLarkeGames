using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textController : MonoBehaviour
{
    [SerializeField] TMP_Text textbox;
    [SerializeField] List<Dialog> dialog;
    
    private int index = 0;
    public bool CanGoNext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !CanGoNext)
        {
            CanGoNext= true;
            UpdateLine(index);
        }
        else if (CanGoNext && Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
        else if (CanGoNext && Input.GetMouseButtonDown(1))
        {
            PreviousLine();
        }
    }

    public void NextLine()
    {
        if (index >= dialog.Count-1)
        {
            return;
        }
        index++;
        UpdateLine(index);

    }
    public void PreviousLine()
    {
        if (index <= 0)
        {
            return;
        }
        index--;
        UpdateLine(index);

    }

    private void UpdateLine(int index)
    {
        textbox.text = dialog[index].text;
    }

    public void clear()
    {
        textbox.text = "";
    }

}

[System.Serializable]
public class Dialog
{
    public int index;
    public string text;
}
