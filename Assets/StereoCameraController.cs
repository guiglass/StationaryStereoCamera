using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StereoCameraController : MonoBehaviour {

	[SerializeField]
	[Tooltip("The camera used for the left eye.")]
	Transform cameraLeft;

	[SerializeField]
	[Tooltip("The camera used for the right eye.")]
	Transform cameraRight;

	[SerializeField]
	[Tooltip("Field of view (default is for HTC Vive and SteamVR).")]
	float fieldOfView = 111.853f;

	[SerializeField]
	[Tooltip("The distance where a ray emitted from the right and left camera would intersect.")]
	float convergencePlane = 85.0f;

	[SerializeField]
	[Tooltip("Eye (local x axis) spacing/separation for left and right camera placment.")]
	float stereoSeparation = 2.22f;

	[SerializeField]
	[Tooltip("The aspect ratio (width divided by height).")]
	float aspect = 1.0f;

	void Start () 
	{
		UpdateParams (); //set the cameras initial position and rotation.
	}

	void OnValidate () 
	{
		/*
		 * Called when a value is changed.
		 */ 
		UpdateParams (); //set the cameras position and rotation. 
	}

	float CalcCameraAngleDegrees() 
	{
		/*given a convergencePlane distance (Oppisite length) 
		 *and half the stereoSeparation distance (Adjacent length) 
		 *we will use trig to calculate the angle for the cameras so 
		 *that they're forward rays intersect at the desired convergence point.
		 */
		var opposite = convergencePlane;
		var adjacent = stereoSeparation / 2.0f;
		return Mathf.Atan (opposite / adjacent) * Mathf.Rad2Deg;
	}

	void RotateCamera(Transform camera, float angle)
	{
		/* 
		 * Helper method for rotating a camera 
		*/
		camera.localRotation = Quaternion.Euler (0, angle, 0);
	}



	void UpdateParams () 
	{
		/* 
		 * Called to set the position and rotation of the stereo cameras. 
		*/
		Camera cam_L = cameraLeft.GetComponent<Camera> ();
		Camera cam_R = cameraRight.GetComponent<Camera> ();

		cam_R.aspect = cam_L.aspect = aspect; //set the field of view for each camera.

		cam_R.fieldOfView = cam_L.fieldOfView = fieldOfView; //set the field of view for each camera.

		var centerSeperation = stereoSeparation / 2.0f;
		cameraRight.transform.localPosition = new Vector3 (centerSeperation, 0, 0); //apply the seperation distance from the ceter to the camera.
		cameraLeft.transform.localPosition = new Vector3 (-centerSeperation, 0, 0); //apply the inverse seperation distance from the ceter to the camera. 

		var cameraAngleDeg = CalcCameraAngleDegrees() - 90.0f; //get the angle for the convergence point, given two sides of a triangle (Atan(convergencePlane / 1/2*stereoSeparation).
		print(cameraAngleDeg);
		RotateCamera (cameraRight, cameraAngleDeg); //apply the angle to the camera.
		RotateCamera (cameraLeft, -cameraAngleDeg); //apply the inverse angle to the camera.
	}


}
