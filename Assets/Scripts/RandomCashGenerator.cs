using System;
using UnityEngine;
using UnityEngine.UI;

public class RandomCashGenerator : MonoBehaviour
{ 
    System.Random randomNumGenerator = new System.Random();

    void Start()
    {
        int money = randomNumGenerator.Next(0, 50000); 
        transform.GetComponent<Text>().text = money.ToString();
    }

}

