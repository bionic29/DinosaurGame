using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeControlForBig : MonoBehaviour
{
    public static bool Incoming;
    Meteor Mtr;
    // Start is called before the first frame update
    void Start()
    {
        Mtr = GetComponent<Meteor>();
        Incoming = false;
        Invoke(nameof(InitiateCtrl), Mtr.TimeofSend);
    }

    void InitiateCtrl()
    {
        Incoming = true;
        Invoke(nameof(Cancel), Mtr.TimeofImpact+1);
    }
    void Cancel()
    {
        Incoming = false;
    }

}
