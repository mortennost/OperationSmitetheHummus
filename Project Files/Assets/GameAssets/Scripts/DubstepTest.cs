using UnityEngine;
using System.Collections;

public class DubstepTest : MonoBehaviour 
{
	private AudioSource audioSource;
	private Transform goTransform;
	private LineRenderer lr;
	
	private Vector3 dVector;
	private Transform[] vertexTransform;
	
	public float[] samples = new float[64];
	//private Vector3 gravity = new Vector3(0.0f, 0.025f, 0.0f);
	
	void Awake()
	{
		this.audioSource = GetComponent<AudioSource>();
		this.goTransform = GetComponent<Transform>();
		this.lr = GetComponent<LineRenderer>();
	}
	
	// Use this for initialization
	void Start() 
	{
		lr.SetVertexCount(samples.Length / 8 + 1);
	}
	
	// Update is called once per frame
	void Update() 
	{
		audioSource.GetSpectrumData(this.samples, 0, FFTWindow.BlackmanHarris);
		
		for(int i = 1; i < samples.Length / 8 + 1; i++)
		{
			dVector.Set(0.25f * i, Mathf.Clamp(samples[i], -10, 1), 0.0f);
			
			lr.SetPosition(i, dVector); //new Vector3(0.25f * i, Mathf.Clamp(samples[i]*(50+i*i) ,0 ,50 ), 0.0f)
		}
	}
}
