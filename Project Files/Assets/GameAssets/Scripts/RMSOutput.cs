using UnityEngine;
using System.Collections;

public class RMSOutput : MonoBehaviour 
{
	public float vol;
	public float sampleRate;
	public float timeWindow;
	public ParticleSystem[] ps;
	
	private int numSamples;
	private float[] window;

	// Use this for initialization
	void Start () 
	{
		numSamples = (int)sampleRate * (int)timeWindow;
		window = new float[numSamples];
		//InvokeRepeating("UpdateVolume", 0, timeWindow);
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateVolume();
		if(vol > 0.3f)
		{
			ps[1].startSpeed = 50.0f;
			ps[1].Emit(100);
		}
	}
	
	void UpdateVolume()
	{
		audio.GetOutputData(window, 0);
		vol = RMS(window);
	}
	
	float RMS(float[] data)
	{
		float result = 0.0f;
		
		for(int i = 0; i < data.Length; i++)
		{
			result += data[i] * data[i];
		}
		
		result /= data.Length;
		
		return Mathf.Sqrt(result);
	}
}
