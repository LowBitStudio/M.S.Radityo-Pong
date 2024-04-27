using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPTes : MonoBehaviour
{
    public Car Avanza = new Car("Avanza", 100, "B 7808 STY", "Hitam");
    public Car Innova = new Car("Innova", 80, "BI 1987 TE", "Hitam");

    void Start()
    {
        Debug.Log(Avanza.Name); //Memunculkan nama Avanza
        Innova.LicenseNum = "BI 1985 TE"; //Change license plate
        Avanza.Move(); //Gerakkan mobil avanza
        Avanza.Break(); //Stop mobil avanza
        Innova.ChangeColor("Putih"); //Ganti warna mobil innova
    }
}
