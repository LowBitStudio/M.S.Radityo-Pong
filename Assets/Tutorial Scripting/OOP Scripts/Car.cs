using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car
{
    public string Name, LicenseNum, Color;
    public float Speed;
    public Car(string name, float speed, string licensenum, string color){
        Name = name;
        Speed = speed;
        LicenseNum = licensenum;
        Color = color;
    }

    public void Move(){
        Debug.Log(Color + " " + Name + " " + LicenseNum + " is moving at " + Speed + " mph.");
    }

    public void Break(){
        Debug.Log(Color + " " + Name + " " + LicenseNum + " is breaking.");
    }

    public void ChangeColor(string NewColor){
        Color = NewColor;
        Debug.Log(Name + " " + LicenseNum + " changing color to " + NewColor);
    }
}
