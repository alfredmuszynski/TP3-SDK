using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;


public static class APIHelper
{
    public static Gender GetDonneGender()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://catfact.ninja/fact");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<Gender>(json);
    }
}

