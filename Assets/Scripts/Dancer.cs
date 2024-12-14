using SonicBloom.Koreo;
using UnityEngine;

public class Dancer : MonoBehaviour
{
	public Animator dancer;

	[EventID]
	public string Beat;

	private void Start()
	{
		Koreographer.Instance.RegisterForEvents(Beat, On_Beat);
	}

	private void On_Beat(KoreographyEvent evt)
	{
		dancer.SetTrigger("bop");
	}
}
