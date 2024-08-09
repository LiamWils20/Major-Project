using UnityEngine;
using System;

public class TakeScreenshot : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] bool canTakePicture;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!canTakePicture)
            {
                canTakePicture = true;
                canvas.SetActive(false);
            }
            else if (canTakePicture)
            {
                canTakePicture = false;
                canvas.SetActive(true);
            }
        }

        if (canTakePicture)
        {
            CanTakePicture();
        }
            
    }

    void CanTakePicture()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ScreenCapture.CaptureScreenshot("MyCity-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", 4);
        }
    }
}
