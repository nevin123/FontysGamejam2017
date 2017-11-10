using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class CameraManager : MonoBehaviour {

	/// <summary>
	/// The duration it takes to zoom in and out.
	/// </summary>
	public float ZoomDuration;

	/// <summary>
	/// The duration to wait after zooming in.
	/// </summary>
	public float WaitDuration;

	/// <summary>
	/// The size of the zoom.
	/// </summary>
	public float ZoomSize;

	/// <summary>
	/// The original position.
	/// </summary>
	private Vector3 originalPosition;

	/// <summary>
	/// The size of the original.
	/// </summary>
	private float originalSize;

	/// <summary>
	/// The camera component.
	/// </summary>
	private Camera _camera;

	/// <summary>
	/// The size of the target.
	/// </summary>
	private float targetSize;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		_camera = GetComponent<Camera> ();
		originalPosition = _camera.transform.position;
		originalSize = _camera.orthographicSize;
		targetSize = originalSize;

	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		_camera.orthographicSize = Mathf.Lerp (_camera.orthographicSize, targetSize, 0.05f);;
	}

	/// <summary>
	/// Zooms to.
	/// </summary>
	/// <param name="transform">Transform.</param>
	/// <param name="newScale">New scale.</param>
	public void ZoomTo(float x, float y) {
		StartCoroutine (zoomTo (new Vector3(x, y, _camera.transform.position.z)));
	}

	/// <summary>
	/// Zooms to.
	/// </summary>
	/// <returns>The to.</returns>
	/// <param name="transform">Transform.</param>
	/// <param name="newScale">New scale.</param>
	private IEnumerator zoomTo(Vector3 newPosition) {
		_camera.transform.DOMove(newPosition, ZoomDuration);
		targetSize = ZoomSize;

		yield return new WaitForSeconds (ZoomDuration + WaitDuration);

		_camera.transform.DOMove(originalPosition, ZoomDuration);
		targetSize = originalSize;
	}
}
