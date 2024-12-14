using UnityEngine;

public class ES3Defaults : ScriptableObject
{
	[SerializeField]
	public ES3SerializableSettings settings = new ES3SerializableSettings();

	public bool addMgrToSceneAutomatically;

	public bool autoUpdateReferences = true;

	public bool addAllPrefabsToManager = true;

	public bool logDebugInfo;

	public bool logWarnings = true;

	public bool logErrors = true;
}
