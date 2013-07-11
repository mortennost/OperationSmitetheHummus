using UnityEngine;
using System.Collections;

public class LRVisualizer : MonoBehaviour {
	
	private AudioSource aSource;
	public float[] samples = new float[64];
	private LineRenderer lr;
	public GameObject cube;
	private Transform goTransform;
	private Vector3 cubePos;
	private Transform[] cubesTransform;
	private Vector3 gravity = new Vector3(0.0f, 0.025f, 0.0f);
	
	void Awake()
	{
		this.aSource = GetComponent<AudioSource>();
		this.lr = GetComponent<LineRenderer>();
		this.goTransform = GetComponent<Transform>();
	}
	
	// Use this for initialization
	void Start () 
	{
		lr.SetVertexCount(samples.Length / 8);
		cubesTransform = new Transform[samples.Length];
		goTransform.position = new Vector3(goTransform.position.x, goTransform.position.y, goTransform.position.z); //-samples.Length/2
		
		GameObject tempCube;
		
		for(int i = 0; i < samples.Length / 8; i++)
		{ 
			tempCube = (GameObject) Instantiate(cube, new Vector3(goTransform.position.x + i / 2, goTransform.position.y, goTransform.position.z), Quaternion.identity);
			cubesTransform[i] = tempCube.GetComponent<Transform>();
			cubesTransform[i].parent = goTransform;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		aSource.GetSpectrumData(this.samples, 0, FFTWindow.BlackmanHarris);
		
		for(int i = 1; i < samples.Length; i++)
		{
			cubePos.Set(cubesTransform[i].position.x, Mathf.Clamp(samples[i]*(10+i*i), 1, 10), cubesTransform[i].position.z);
			
			if(cubePos.y >= cubesTransform[i].position.y)
			{
				cubesTransform[i].position = cubePos;
			}
			else
			{
				cubesTransform[i].position -= gravity;
			}
			
			lr.SetPosition(i / 8, cubePos - goTransform.position);
			lr.SetColors(new Color(Mathf.Clamp(samples[i]*(255+i*i), 0, 255), 1, 1, 1.0f), new Color(1, Mathf.Clamp(samples[i]*(255+i*i), 0, 255), 1, 1.0f));
		}
	}
}
