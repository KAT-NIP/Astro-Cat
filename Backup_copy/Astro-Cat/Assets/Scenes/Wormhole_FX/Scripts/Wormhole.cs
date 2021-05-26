using UnityEngine;
using System.Collections;


public class Wormhole : MonoBehaviour
{

	public float tunnelTextureTwist = -0.1f;
	public float tunnelTextureSpeed = -1.0f;

    public float tunnelMeshAnimSpeed = 1.0f;
    public GameObject tunnel;

    private Renderer _myRenderer;

	private bool scroll = true;

	void Start () 
	{
		_myRenderer = GetComponent<Renderer>();
		if(_myRenderer == null)
			enabled = false;


        Animator anim = tunnel.GetComponent<Animator>();
        anim.speed = tunnelMeshAnimSpeed;

    }

	public void FixedUpdate()
	{
		if (scroll)
		{
			float verticalOffset = Time.time * tunnelTextureSpeed;
			float horizontalOffset = Time.time * tunnelTextureTwist;
			_myRenderer.material.mainTextureOffset = new Vector2(horizontalOffset, verticalOffset);
		}
	}

	public void DoActivateTrigger()
	{
		scroll = !scroll;
	}

}