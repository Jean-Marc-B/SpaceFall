using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class TCPServer : MonoBehaviour
{
	private TcpListener tcpListener; // TCPListener to listen for incomming TCP connection 	
	private Thread tcpListenerThread; // Background thread for TcpServer workload. 	
	private int port = 8052;
	private IPAddress ipAddress = IPAddress.Parse("192.168.1.70");


	private List<float> hrs = new List<float>();
	private List<float> hrvs = new List<float>();
	private List<float> edas = new List<float>();
	private List<DateTime> timestamps = new List<DateTime>();
	private String filePath = @"E:\SpaceFall\Data\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + @"\physiologicalData.csv";



	void Start()
	{
		tcpListenerThread = new Thread(new ThreadStart(ListenForMessages));
		tcpListenerThread.IsBackground = true;
		tcpListenerThread.Start();
	}

	void OnApplicationQuit()
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.AppendLine("Time,HR,HRV,EDA");
		for (int i = 0; i < hrvs.Count; i++)
		{
			sb.AppendLine(timestamps[i] + "," + hrs[i].ToString() + "," + hrvs[i].ToString() + "," + edas[i].ToString());
		}
		System.IO.FileInfo file = new System.IO.FileInfo(filePath);
		file.Directory.Create();
		System.IO.File.WriteAllText(
			file.FullName,
			sb.ToString());
		tcpListener.Stop();
		Debug.Log("Server is now stopped");
	}

	// Runs in background TcpServerThread; Handles incomming TcpClient requests 	
	private void ListenForMessages()
	{
		try
		{
			// Create listener on localhost port 8052. 	
			tcpListener = new TcpListener(ipAddress, port);
			tcpListener.Start();
			Debug.Log("Server is listening on port " + port.ToString());
			Byte[] bytes = new Byte[1024];
			while (true)
			{
				Socket socket = tcpListener.AcceptSocket();
				byte[] b = new byte[500];
				int k = socket.Receive(b);

				char cc = ' ';
				string message = null;
				for (int i = 0; i < k - 1; i++)
				{
					cc = Convert.ToChar(b[i]);
					message += cc.ToString();
				}
				string[] values = message.Split('A');
				float hr = float.Parse(values[0].Replace(',', '.'));
				float hvr = float.Parse(values[1].Replace(',', '.'));
				float eda = float.Parse(values[2].Replace(',', '.'));

				hrs.Add(hr);
				hrvs.Add(hvr);
				edas.Add(eda);
				timestamps.Add(DateTime.Now);
			}
		}
		catch (SocketException socketException)
		{
			Debug.Log("SocketException " + socketException.ToString());
		}
	}

	public float getLastHRV()
    {
		if (hrvs.Count > 0)
		{
			return hrvs[hrvs.Count - 1];
		} else
        {
			return -1;
        }
	}

	public int getLastHR()
	{
		if (hrs.Count > 0)
		{
			return (int) hrs[hrs.Count - 1];
		}
		else
		{
			return -1;
		}
	}
}