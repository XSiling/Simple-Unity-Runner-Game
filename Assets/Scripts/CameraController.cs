using UnityEngine;
using System.Collections;
 
/// <summary>
/// Third person camera.
/// </summary>
public class CameraController : MonoBehaviour
{
	public float distanceAway=2.7f;			
	public float distanceUp=2.2f;			
	public float smooth=2f;				// how smooth the camera movement is
		
	private Vector3 m_TargetPosition;		// the position the camera is trying to be in)
	
	Transform follow;        //the position of Player
	
	void Start(){
		follow = GameObject.Find("Player").transform;
		//Debug.Log(follow);
	}
	
	void LateUpdate ()
	{
		// setting the target position to be the correct offset from the 
		m_TargetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
		//Debug.Log(Vector3.up);
		//Debug.Log(Vector3.up*distanceUp);
		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);
		
		// make sure the camera is looking the right way!
		transform.LookAt(follow);
	}
}