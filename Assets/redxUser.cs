using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class redxUser : MonoBehaviour { 
	public redxSphereAudioSource SphereAudio;

	public static SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);
	public string message2;
	float timePassed = 0.0f;
	bool VIBRATION = false;

	public static int count;
	// Use this for initialization
	void Start () {
		SphereAudio = new redxSphereAudioSource ();
		if(VIBRATION==true)
			OpenConnection();
	}

	public static int sendVibration=1;
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;
		GameObject audioSource;
		int forwardThreshold = 100;
		int sideThreshold = 2;


		//Forward
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast (transform.position, fwd, out hit)) 
		{
			audioSource = GameObject.Find("Sphere");
			print("hit distance " + hit.distance);
			if(hit.distance < forwardThreshold)
			{
				//SphereAudio.mute1(true);
				count = count + 1;
				print("coor "+hit.point.x+ " " + hit.point.y);
				Vector3 audioSourceLocation = new Vector3(hit.point.x,hit.point.y,hit.point.z);
				audioSource.transform.position = audioSourceLocation;
				//if(sendVibration==10)
				//{
						//sp.Write("v");
				//	sendVibration=1;
				//}
				//else
				//	sendVibration=sendVibration+1;
				//audioSource.GetComponent<redxSphereunAudioSource>().mute1(true);
				//SphereAudio.mute1(true);
			}
			else
			{
				Vector3 audioSourceLocation = new Vector3(999,999,999);
				audioSource.transform.position = audioSourceLocation; 
			}
		}

		if (Physics.Raycast (transform.position, fwd, out hit)) 
		{
			if(hit.distance < 1 && VIBRATION==true)
			{
				sp.Write("v");
			}
		}

		//Left
		Vector3 left = transform.TransformDirection(Vector3.left);
		if (Physics.Raycast (transform.position, left, out hit)) 
		{
			audioSource = GameObject.Find("audioLeft");
			print("hit distance " + hit.distance);
			if(hit.distance < sideThreshold)
			{
				//SphereAudio.mute1(true);
				count = count + 1;
				print("coor "+hit.point.x+ " " + hit.point.y);
				Vector3 audioSourceLocation = new Vector3(hit.point.x,hit.point.y,hit.point.z);
				audioSource.transform.position = audioSourceLocation; 
				
				//audioSource.GetComponent<redxSphereAudioSource>().mute1(true);
				//SphereAudio.mute1(true);
			}
			else
			{
				Vector3 audioSourceLocation = new Vector3(999,999,999);
				audioSource.transform.position = audioSourceLocation; 
			}
		}

		//Right
		Vector3 right = transform.TransformDirection(Vector3.right);
		if (Physics.Raycast (transform.position, right, out hit)) 
		{
			audioSource = GameObject.Find("audioRight");
			print("hit distance " + hit.distance);
			if(hit.distance < sideThreshold)
			{
				//SphereAudio.mute1(true);
				count = count + 1;
				print("coor "+hit.point.x+ " " + hit.point.y);
				Vector3 audioSourceLocation = new Vector3(hit.point.x,hit.point.y,hit.point.z);
				audioSource.transform.position = audioSourceLocation; 
				
				//audioSource.GetComponent<redxSphereAudioSource>().mute1(true);
				//SphereAudio.mute1(true);
			}
			else
			{
				Vector3 audioSourceLocation = new Vector3(999,999,999);
				audioSource.transform.position = audioSourceLocation; 
			}
		}


	}

	public void OpenConnection() 
	{
		if (sp != null) 
		{
			if (sp.IsOpen) 
			{
				sp.Close();
				print("Closing port, because it was already open!");
			}
			else 
			{
				sp.Open();  // opens the connection
				sp.ReadTimeout = 50;  // sets the timeout value before reporting error
				print("Port Opened!");
				//		message = "Port Opened!";
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else 
			{
				print("Port == null");
			}
		}
	}

	void OnApplicationQuit() 
	{
		sp.Close();
	}


}
