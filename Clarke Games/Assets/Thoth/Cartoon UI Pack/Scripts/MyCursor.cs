using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour
{
    public Texture2D myCursor;          // Normal cursor texture
    public Texture2D myCursorDark;      // Darker cursor texture for click state
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        // Set the default cursor at the start
        Cursor.SetCursor(myCursor, hotSpot, CursorMode.Auto);
        Cursor.visible = true;
    }

    void Update()
    {
        // Check for mouse click (left button)
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(myCursorDark, hotSpot, CursorMode.Auto);
        }

        // Check for mouse release
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(myCursor, hotSpot, CursorMode.Auto);
        }
    }
}
