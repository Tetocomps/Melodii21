using System;

namespace HellTap.LDC
{
	[Serializable]
	public class DUICachedInjectorsForScreen
	{
		public DUICachedInjectors[] dialogTitleInjectors = new DUICachedInjectors[0];

		public DUICachedInjectors[] dialogTextInjectors = new DUICachedInjectors[0];

		public DUICachedInjectors[] customButton1Injectors = new DUICachedInjectors[0];

		public DUICachedInjectors[] customButton2Injectors = new DUICachedInjectors[0];

		public DUICachedInjectorsForScreenMultipleButton[] multipleButtonInjectors = new DUICachedInjectorsForScreenMultipleButton[0];

		public DUICachedInjectorsForScreenMultipleButton[] multipleButtonEvaluatedInjectors = new DUICachedInjectorsForScreenMultipleButton[0];

		public DUICachedInjectorsForScreenIconGrids[] iconGridInjectors = new DUICachedInjectorsForScreenIconGrids[0];

		public DUICachedInjectorsForScreenIconGrids[] iconGridEvaluatedInjectors = new DUICachedInjectorsForScreenIconGrids[0];

		public string dialogTitle = "";

		public string dialogText = "";

		public string customButton1 = "";

		public string customButton2 = "";

		public string[] multipleButtons = new string[0];

		public string[] multipleButtonsEvaluated = new string[0];

		public string[] iconGridTitles = new string[0];

		public string[] iconGridLabels = new string[0];

		public string[] iconGridFailedLabels = new string[0];

		public string[] iconGridTitlesEvaluated = new string[0];

		public string[] iconGridLabelsEvaluated = new string[0];

		public string[] iconGridFailedLabelsEvaluated = new string[0];
	}
}
