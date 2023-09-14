using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorCountText : MonoBehaviour
{
    Text CountText;
    // Start is called before the first frame update
    void Start()
    {
        CountText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        CountText.text = "Meteor Count : " + GameManager.Meteorcount.ToString("0");
    }
}
