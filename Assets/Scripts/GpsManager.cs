using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GpsManager : MonoBehaviour
{
    public GameObject compassImg;
    string text;

    public void Start()
    {
        Input.location.Start(0.3f);
        Input.compass.enabled = true;
        if (SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;
    }

    private void Update()
    {
        GetCoordinates();
    }

    public void GetCoordinates()
    {

        if (Input.location.isEnabledByUser)
        {
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;

            text= "Depart lat: " + lat + " lon: " + lon+"\n";
            text += "Acc: "+Input.acceleration +"\n";
            text += "Compass: "+Input.compass.trueHeading + "\n";
            text += "Gyroscope: " + Input.gyro.attitude;
           
            SetCompass();

        }
        else
            text = "Gps is off or system doesnt support gyroscope";
    }

    private void SetCompass()
    {
        Text singleText = GameObject.Find("Position_txt").GetComponentInChildren<Text>();
        var rot = compassImg.transform.eulerAngles;
        rot = new Vector3(rot.x, rot.y,Mathf.Ceil(Input.compass.trueHeading));
        compassImg.transform.rotation = Quaternion.Euler(rot);
        text += "Setting compass";
        singleText.text = text;
    }


}
