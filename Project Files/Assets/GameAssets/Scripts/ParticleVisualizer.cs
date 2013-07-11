using UnityEngine;
using System.Collections;

public class ParticleVisualizer : MonoBehaviour 
{
	private float[] samples = new float[512];
	private AudioSource aSource;
	private ParticleSystem ps;
	private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[512];
	
	//public Particle[] particles;
	
	// Use this for initialization
	void Start () 
	{
		this.aSource = GetComponent<AudioSource>();
		this.ps = GetComponent<ParticleSystem>(); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		aSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
		
		SomeFunction();
		
		for(int i = 0; i < samples.Length; i++)
		{
			if(samples[i] > 0.2f)
			{
				ps.Emit(1);
			}
		}
	}
	
	void SomeFunction()
	{
		int length = ps.GetParticles(particles);
		
		for(int i = 0; i < length; i++)
		{
			//particles[i].color = new Color(r, r, r, 1.0f);
			particles[i].color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
		}
		
		ps.SetParticles(particles, length);
	}
}
