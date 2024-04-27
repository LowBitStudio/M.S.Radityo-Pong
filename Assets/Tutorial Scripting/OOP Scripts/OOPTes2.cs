using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPTes2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Car2 Kijang = new Car2("Kijang", 80f, "Yellow", "A M3L1 A", 6);
        Horse Stallion = new Horse("Calli", 100f, "Black", 12);

        Debug.Log(Stallion.Name);
        Debug.Log(Kijang.Name);
        Debug.Log(Stallion.Age);
        Debug.Log(Kijang.LicenseNum);

        Stallion.Move();
        Kijang.Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Transport
{
    public string Name;
    public float Speed;
    public string Color;
    
    public Transport(string name, float speed, string color){
        Name = name;
        Speed = speed;
        Color = color;
    }

    public void Move(){
        Debug.Log(Color + " " + Name + " Is moving in " + Speed + " kmph.");
    }
}

public class Car2 : Transport
{
    public string LicenseNum;
    public int Seat;

    public Car2(string name, float speed, string color, string licenseNum, int seat) :base(name,speed,color)
    {
        LicenseNum = licenseNum;
        Seat = seat;
    }
}

public class Horse : Transport
{
    public int Age;

    public Horse(string name, float speed, string color, int age):base(name,speed,color)
    {
        Age = age;
    }
}
