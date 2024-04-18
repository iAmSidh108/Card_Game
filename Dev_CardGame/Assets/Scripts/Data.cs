using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Data : MonoBehaviour
{
    public List<string> deck { get; set; }
}

public class Root
{
    public Data data { get; set; }
}
