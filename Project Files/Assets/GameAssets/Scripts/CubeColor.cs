using UnityEngine;
using System.Collections;

public class CubeColor : MonoBehaviour 
{
	public int valueNumber;
	private Color dynamicColor;
	private SpectrumData sData;
	private Vector3 cubeScale = new Vector3(1.0f, 1.0f, 1.0f);
	private Vector3 newPos;
	private RMSOutput rms;
	private float gravity = 0.25f;
	
	// Use this for initialization
	void Start () 
	{
		sData = GameObject.Find("AudioData").GetComponent<SpectrumData>();
		rms = GameObject.Find("AudioData").GetComponent<RMSOutput>();
		dynamicColor.a = 1.0f;
		newPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		dynamicColor.r += sData.values[valueNumber] + Random.Range(0, 200); //sData.values[valueNumber + Random.Range(0, 8)]
		dynamicColor.g += sData.values[valueNumber] + Random.Range(0, 200);
		dynamicColor.b += sData.values[valueNumber] + Random.Range(0, 200);
		
		renderer.material.color = dynamicColor;
		
		cubeScale.y = rms.vol;
		
		if(cubeScale.y > 0.0f)
		{
			cubeScale.y -= gravity;
		}
		
		transform.localScale = cubeScale;
		newPos.y = cubeScale.y / 2;
		transform.position = newPos;
	}
}
