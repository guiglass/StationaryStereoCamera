using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StereoCameraPreRender : MonoBehaviour {

	[SerializeField]
	[Tooltip("The renderTexture for the left stereo camera.")]
	public RenderTexture texLeft = null;

	[SerializeField]
	[Tooltip("The renderTexture for the right stereo camera.")]
	public RenderTexture texRight = null;
		
	[SerializeField]
	[Tooltip("The material used by Blit to overlay texLeft and texRight on this camera.")]
	Material mat;

	// Postprocess the image and add the HUD renderTextures from the HUD CameraLeft and CameraRight buffers.
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit (source, destination); // first apply the renderTexture from all lower depth cameras (placing below HUD texture, done next).
		if (destination) { //destination is null in edit mode only, otherwise it sould be something like: "RTEyeTextureRight0" -or- "RTEyeTextureLeft0".
			string matchname = "RTEyeTextureRight"; //The name of the destination renderTexture (could be for either Right or Left eye).
			source = destination.name.Substring (0, destination.name.Length - 1) == matchname ? texRight : texLeft; //get the proper renderTexture for the coorisponding destination eye.
			Graphics.Blit (source, destination, mat); // now apply the renderTexture from the coorisponding HUD camera.
		}
	}

}

