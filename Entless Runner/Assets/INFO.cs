using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INFO : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenInstagramAccount()
    {
        // Replace "YOUR_INSTAGRAM_USERNAME" with your actual Instagram username
        string instagramURL = "https://www.instagram.com/midhunnx?igsh=MXV5aTVhbG9pNHo3cg==";

        // Open the Instagram URL
        Application.OpenURL(instagramURL);
    }
}

