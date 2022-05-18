using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public float h;
    public float v;
    public bool t1;
    public bool t2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = UltimateJoystick.GetHorizontalAxis( "Ryul" );
        v = UltimateJoystick.GetVerticalAxis( "Ryul" );
        t1 = UltimateJoystick.GetJoystickState( "Ryul" );
        t2 = UltimateJoystick.GetTapCount( "Ryul" );
    }
}
