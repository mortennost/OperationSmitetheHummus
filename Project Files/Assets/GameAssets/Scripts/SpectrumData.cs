using UnityEngine;
using System.Collections;

public class SpectrumData : MonoBehaviour 
{
	private AudioSource aSource;
	
	private float[] samples = new float[512];
	
	public float[] values = new float[8];
	
	void Awake()
	{
		this.aSource = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//aSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
		aSource.GetOutputData(samples, 0);
		
		for(int i = 0; i < values.Length; i++)
		{
			float average = 0.0f;
			
			for(int j = 0; j < samples.Length; j++)
			{
				average += samples[j] * (j + 1);
			}
			
			//average /= sampleCount;
			values[i] = Mathf.Clamp(samples[i]*(255+i*i), 0, 255); //average * 10
		}
	}
}
