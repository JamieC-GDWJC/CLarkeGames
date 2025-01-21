using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textController : MonoBehaviour
{
    [SerializeField] TMP_Text textbox;
    [SerializeField] List<Dialog> dialog;
    
    private int index = 0;
    public float typingSpeed = .1f;
    public bool CanGoNext;

    private Coroutine typeTextCo = null;
    
    //audio
    private AudioSource aSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clear();
        aSource = GetComponent<AudioSource>();
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
        if(typeTextCo != null)
            StopCoroutine(typeTextCo);
        typeTextCo = StartCoroutine(TypeTextCoroutine(dialog[index].text));
    }

    public void clear()
    {
        textbox.text = "";
    }

    IEnumerator TypeTextCoroutine(string fullText)
    {
        aSource.Play();
        textbox.text = "";  // Clear text at the start
        foreach (char letter in fullText)
        {
            textbox.text += letter; // Add one letter at a time
            aSource.pitch = 1f + Random.Range(-.2f, .2f);
            yield return new WaitForSeconds(typingSpeed);
        }
        aSource.Stop();
    }

}

[System.Serializable]
public class Dialog
{
    public int index;
    public string text;
}
