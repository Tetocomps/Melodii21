using UnityEngine;

namespace HellTap.LDC
{
	[RequireComponent(typeof(LineRenderer))]
	public class DialogWorldSpaceLineRenderer : MonoBehaviour
	{
		private LineRenderer _lr;

		public Renderer hitPointRenderer;

		private void Start()
		{
			_lr = GetComponent<LineRenderer>();
			_lr.SetPositions(new Vector3[2]
			{
				Vector3.zero,
				Vector3.zero
			});
		}

		private void LateUpdate()
		{
			if (!DialogUI.ended && DialogWorldSpaceGUI.com != null && DialogOnGUI.com.renderMode == OnGuiRenderMode.Material && DialogWorldSpaceGUI.com.inputMode == DialogWorldSpaceGUI.InputMode.Transform)
			{
				_lr.SetPosition(0, DialogWorldSpaceGUI.rayStartPoint);
				_lr.SetPosition(1, DialogWorldSpaceGUI.rayEndPoint);
				if (!_lr.enabled)
				{
					_lr.enabled = true;
				}
				if (!(hitPointRenderer != null))
				{
					return;
				}
				if (DialogWorldSpaceGUI.SimulatedMouseIsWithinScreen())
				{
					hitPointRenderer.transform.position = DialogWorldSpaceGUI.rayEndPoint;
					if (!hitPointRenderer.enabled)
					{
						hitPointRenderer.enabled = true;
					}
				}
				else if (hitPointRenderer.enabled)
				{
					hitPointRenderer.enabled = false;
				}
			}
			else
			{
				if (_lr.enabled)
				{
					_lr.enabled = false;
				}
				if (hitPointRenderer != null && hitPointRenderer.enabled)
				{
					hitPointRenderer.enabled = false;
				}
			}
		}
	}
}
