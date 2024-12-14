using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HellTap.LDC
{
	[RequireComponent(typeof(DialogController))]
	public class DialogScreen : MonoBehaviour
	{
		public DialogController dc;

		public bool isActive;

		public int dialogID = 1;

		public string note = "Empty Note";

		public bool useAutoNotes = true;

		private bool backupEnglishLimiter;

		public DS_Screen screen = new DS_Screen();

		public DS_Localizations localization = new DS_Localizations();

		public DS_Navigation navigation = new DS_Navigation();

		public DS_Actions actions = new DS_Actions();

		public DUICachedInjectorsForScreen injectors = new DUICachedInjectorsForScreen();

		public void Start()
		{
			if (!backupEnglishLimiter)
			{
				backupEnglishLimiter = true;
				BackupEnglish();
			}
			dc = GetComponent<DialogController>();
			if (typeof(DialogUI) != null && DialogUI.dui != null)
			{
				actions.music.source = DialogUI.dui.musicSource;
				actions.sfx1.source = DialogUI.dui.sfx1Source;
				actions.sfx2.source = DialogUI.dui.sfx2Source;
				actions.sfx3.source = DialogUI.dui.sfx3Source;
			}
			Localize();
		}

		public bool StringArrayIsEmpty(string[] arr)
		{
			bool result = true;
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] != "")
				{
					result = false;
				}
			}
			return result;
		}

		public void LocalizeTokens()
		{
			DSTokenActions[] tokens = actions.tokens;
			foreach (DSTokenActions dSTokenActions in tokens)
			{
				if (dSTokenActions.localize)
				{
					if (DialogLocalization.language == "English" && dSTokenActions.localizedArgument.english != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.english;
					}
					else if (DialogLocalization.language == "Chinese" && dSTokenActions.localizedArgument.chinese != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.chinese;
					}
					else if (DialogLocalization.language == "Korean" && dSTokenActions.localizedArgument.korean != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.korean;
					}
					else if (DialogLocalization.language == "Japanese" && dSTokenActions.localizedArgument.japanese != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.japanese;
					}
					else if (DialogLocalization.language == "German" && dSTokenActions.localizedArgument.german != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.german;
					}
					else if (DialogLocalization.language == "French" && dSTokenActions.localizedArgument.french != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.french;
					}
					else if (DialogLocalization.language == "Spanish" && dSTokenActions.localizedArgument.spanish != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.spanish;
					}
					else if (DialogLocalization.language == "Italian" && dSTokenActions.localizedArgument.italian != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.italian;
					}
					else if (DialogLocalization.language == "Portuguese" && dSTokenActions.localizedArgument.portuguese != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.portuguese;
					}
					else if (DialogLocalization.language == "Russian" && dSTokenActions.localizedArgument.russian != "")
					{
						dSTokenActions.argument = dSTokenActions.localizedArgument.russian;
					}
				}
			}
		}

		public void BackupEnglish()
		{
			localization.english.actorName = screen.actorName;
			localization.english.dialogText = screen.dialogText;
			localization.english.soundToLoad = screen.soundToLoad;
			localization.english.soundPitch = screen.soundPitch;
			localization.english.changeAudio = false;
			localization.english.customButton1 = screen.customButton1;
			localization.english.customButton2 = screen.customButton2;
			localization.english.dataEntryDefaultValue = screen.dataEntryDefaultValue;
			localization.english.passwordAnswer = screen.passwordAnswer;
			localization.english.multipleButtons = screen.multipleButtons;
			if (screen.logicStatements != null && screen.logicStatements.Length != 0)
			{
				localization.english.logicStatementCompare = new string[screen.logicStatements.Length];
				for (int i = 0; i < localization.english.logicStatementCompare.Length; i++)
				{
					localization.english.logicStatementCompare[i] = screen.logicStatements[i].compare;
				}
			}
			if (actions.tokens.Length != 0)
			{
				DSTokenActions[] tokens = actions.tokens;
				foreach (DSTokenActions dSTokenActions in tokens)
				{
					dSTokenActions.localizedArgument.english = dSTokenActions.argument;
				}
			}
			if (screen.IG_buttons == null || screen.IG_buttons.Length == 0)
			{
				return;
			}
			IconGridButtons[] iG_buttons = screen.IG_buttons;
			foreach (IconGridButtons iconGridButtons in iG_buttons)
			{
				if (iconGridButtons != null)
				{
					iconGridButtons.localizedTitle.english = iconGridButtons.title;
				}
			}
		}

		public void Localize()
		{
			LocalizeTokens();
			int num = 0;
			if (DialogLocalization.language == "English")
			{
				if (localization.english.actorName != "")
				{
					screen.actorName = localization.english.actorName;
				}
				if (localization.english.dialogText != "")
				{
					screen.dialogText = localization.english.dialogText;
				}
				if (localization.english.changeAudio)
				{
					screen.soundToLoad = localization.english.soundToLoad;
					screen.soundPitch = localization.english.soundPitch;
				}
				if (localization.english.customButton1 != "")
				{
					screen.customButton1 = localization.english.customButton1;
				}
				if (localization.english.customButton2 != "")
				{
					screen.customButton2 = localization.english.customButton2;
				}
				if (localization.english.dataEntryDefaultValue != "")
				{
					screen.dataEntryDefaultValue = localization.english.dataEntryDefaultValue;
				}
				if (localization.english.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.english.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.english.multipleButtons))
				{
					screen.multipleButtons = localization.english.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.english.logicStatementCompare != null && localization.english.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements2 in logicStatements)
					{
						if (logicStatements2 != null && localization.english.logicStatementCompare[num] != "")
						{
							logicStatements2.compare = localization.english.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons in iG_buttons)
					{
						if (iconGridButtons != null && iconGridButtons.localizeTitle && iconGridButtons.localizedTitle.english != "")
						{
							iconGridButtons.title = iconGridButtons.localizedTitle.english;
						}
					}
				}
			}
			if (DialogLocalization.language == "Chinese")
			{
				if (localization.chinese.actorName != "")
				{
					screen.actorName = localization.chinese.actorName;
				}
				if (localization.chinese.dialogText != "")
				{
					screen.dialogText = localization.chinese.dialogText;
				}
				if (localization.chinese.changeAudio)
				{
					screen.soundToLoad = localization.chinese.soundToLoad;
					screen.soundPitch = localization.chinese.soundPitch;
				}
				if (localization.chinese.customButton1 != "")
				{
					screen.customButton1 = localization.chinese.customButton1;
				}
				if (localization.chinese.customButton2 != "")
				{
					screen.customButton2 = localization.chinese.customButton2;
				}
				if (localization.chinese.dataEntryDefaultValue != "")
				{
					screen.dataEntryDefaultValue = localization.chinese.dataEntryDefaultValue;
				}
				if (localization.chinese.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.chinese.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.chinese.multipleButtons))
				{
					screen.multipleButtons = localization.chinese.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.chinese.logicStatementCompare != null && localization.chinese.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements3 in logicStatements)
					{
						if (logicStatements3 != null && localization.chinese.logicStatementCompare[num] != "")
						{
							logicStatements3.compare = localization.chinese.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons2 in iG_buttons)
					{
						if (iconGridButtons2 != null && iconGridButtons2.localizeTitle && iconGridButtons2.localizedTitle.chinese != "")
						{
							iconGridButtons2.title = iconGridButtons2.localizedTitle.chinese;
						}
					}
				}
			}
			else if (DialogLocalization.language == "Korean")
			{
				if (localization.korean.actorName != "")
				{
					screen.actorName = localization.korean.actorName;
				}
				if (localization.korean.dialogText != "")
				{
					screen.dialogText = localization.korean.dialogText;
				}
				if (localization.korean.changeAudio)
				{
					screen.soundToLoad = localization.korean.soundToLoad;
					screen.soundPitch = localization.korean.soundPitch;
				}
				if (localization.korean.customButton1 != "")
				{
					screen.customButton1 = localization.korean.customButton1;
				}
				if (localization.korean.customButton2 != "")
				{
					screen.customButton2 = localization.korean.customButton2;
				}
				if (localization.korean.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.korean.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.korean.multipleButtons))
				{
					screen.multipleButtons = localization.korean.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.korean.logicStatementCompare != null && localization.korean.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements4 in logicStatements)
					{
						if (logicStatements4 != null && localization.korean.logicStatementCompare[num] != "")
						{
							logicStatements4.compare = localization.korean.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons3 in iG_buttons)
					{
						if (iconGridButtons3 != null && iconGridButtons3.localizeTitle && iconGridButtons3.localizedTitle.korean != "")
						{
							iconGridButtons3.title = iconGridButtons3.localizedTitle.korean;
						}
					}
				}
			}
			else if (DialogLocalization.language == "Japanese")
			{
				if (localization.japanese.actorName != "")
				{
					screen.actorName = localization.japanese.actorName;
				}
				if (localization.japanese.dialogText != "")
				{
					screen.dialogText = localization.japanese.dialogText;
				}
				if (localization.japanese.changeAudio)
				{
					screen.soundToLoad = localization.japanese.soundToLoad;
					screen.soundPitch = localization.japanese.soundPitch;
				}
				if (localization.japanese.customButton1 != "")
				{
					screen.customButton1 = localization.japanese.customButton1;
				}
				if (localization.japanese.customButton2 != "")
				{
					screen.customButton2 = localization.japanese.customButton2;
				}
				if (localization.japanese.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.japanese.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.japanese.multipleButtons))
				{
					screen.multipleButtons = localization.japanese.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.japanese.logicStatementCompare != null && localization.japanese.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements5 in logicStatements)
					{
						if (logicStatements5 != null && localization.japanese.logicStatementCompare[num] != "")
						{
							logicStatements5.compare = localization.japanese.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons4 in iG_buttons)
					{
						if (iconGridButtons4 != null && iconGridButtons4.localizeTitle && iconGridButtons4.localizedTitle.japanese != "")
						{
							iconGridButtons4.title = iconGridButtons4.localizedTitle.japanese;
						}
					}
				}
			}
			else if (DialogLocalization.language == "Spanish")
			{
				if (localization.spanish.actorName != "")
				{
					screen.actorName = localization.spanish.actorName;
				}
				if (localization.spanish.dialogText != "")
				{
					screen.dialogText = localization.spanish.dialogText;
				}
				if (localization.spanish.changeAudio)
				{
					screen.soundToLoad = localization.spanish.soundToLoad;
					screen.soundPitch = localization.spanish.soundPitch;
				}
				if (localization.spanish.customButton1 != "")
				{
					screen.customButton1 = localization.spanish.customButton1;
				}
				if (localization.spanish.customButton2 != "")
				{
					screen.customButton2 = localization.spanish.customButton2;
				}
				if (localization.spanish.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.spanish.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.spanish.multipleButtons))
				{
					screen.multipleButtons = localization.spanish.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.spanish.logicStatementCompare != null && localization.spanish.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements6 in logicStatements)
					{
						if (logicStatements6 != null && localization.spanish.logicStatementCompare[num] != "")
						{
							logicStatements6.compare = localization.spanish.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons5 in iG_buttons)
					{
						if (iconGridButtons5 != null && iconGridButtons5.localizeTitle && iconGridButtons5.localizedTitle.spanish != "")
						{
							iconGridButtons5.title = iconGridButtons5.localizedTitle.spanish;
						}
					}
				}
			}
			else if (DialogLocalization.language == "Italian")
			{
				if (localization.italian.actorName != "")
				{
					screen.actorName = localization.italian.actorName;
				}
				if (localization.italian.dialogText != "")
				{
					screen.dialogText = localization.italian.dialogText;
				}
				if (localization.italian.changeAudio)
				{
					screen.soundToLoad = localization.italian.soundToLoad;
					screen.soundPitch = localization.italian.soundPitch;
				}
				if (localization.italian.customButton1 != "")
				{
					screen.customButton1 = localization.italian.customButton1;
				}
				if (localization.italian.customButton2 != "")
				{
					screen.customButton2 = localization.italian.customButton2;
				}
				if (localization.italian.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.italian.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.italian.multipleButtons))
				{
					screen.multipleButtons = localization.italian.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.italian.logicStatementCompare != null && localization.italian.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements7 in logicStatements)
					{
						if (logicStatements7 != null && localization.italian.logicStatementCompare[num] != "")
						{
							logicStatements7.compare = localization.italian.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons6 in iG_buttons)
					{
						if (iconGridButtons6 != null && iconGridButtons6.localizeTitle && iconGridButtons6.localizedTitle.italian != "")
						{
							iconGridButtons6.title = iconGridButtons6.localizedTitle.italian;
						}
					}
				}
			}
			else if (DialogLocalization.language == "German")
			{
				if (localization.german.actorName != "")
				{
					screen.actorName = localization.german.actorName;
				}
				if (localization.german.dialogText != "")
				{
					screen.dialogText = localization.german.dialogText;
				}
				if (localization.german.changeAudio)
				{
					screen.soundToLoad = localization.german.soundToLoad;
					screen.soundPitch = localization.german.soundPitch;
				}
				if (localization.german.customButton1 != "")
				{
					screen.customButton1 = localization.german.customButton1;
				}
				if (localization.german.customButton2 != "")
				{
					screen.customButton2 = localization.german.customButton2;
				}
				if (localization.german.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.german.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.german.multipleButtons))
				{
					screen.multipleButtons = localization.german.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.german.logicStatementCompare != null && localization.german.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements8 in logicStatements)
					{
						if (logicStatements8 != null && localization.german.logicStatementCompare[num] != "")
						{
							logicStatements8.compare = localization.german.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons7 in iG_buttons)
					{
						if (iconGridButtons7 != null && iconGridButtons7.localizeTitle && iconGridButtons7.localizedTitle.german != "")
						{
							iconGridButtons7.title = iconGridButtons7.localizedTitle.german;
						}
					}
				}
			}
			else if (DialogLocalization.language == "French")
			{
				if (localization.french.actorName != "")
				{
					screen.actorName = localization.french.actorName;
				}
				if (localization.french.dialogText != "")
				{
					screen.dialogText = localization.french.dialogText;
				}
				if (localization.french.changeAudio)
				{
					screen.soundToLoad = localization.french.soundToLoad;
					screen.soundPitch = localization.french.soundPitch;
				}
				if (localization.french.customButton1 != "")
				{
					screen.customButton1 = localization.french.customButton1;
				}
				if (localization.french.customButton2 != "")
				{
					screen.customButton2 = localization.french.customButton2;
				}
				if (localization.french.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.french.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.french.multipleButtons))
				{
					screen.multipleButtons = localization.french.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.french.logicStatementCompare != null && localization.french.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements9 in logicStatements)
					{
						if (logicStatements9 != null && localization.french.logicStatementCompare[num] != "")
						{
							logicStatements9.compare = localization.french.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons8 in iG_buttons)
					{
						if (iconGridButtons8 != null && iconGridButtons8.localizeTitle && iconGridButtons8.localizedTitle.french != "")
						{
							iconGridButtons8.title = iconGridButtons8.localizedTitle.french;
						}
					}
				}
			}
			else if (DialogLocalization.language == "Portuguese")
			{
				if (localization.portuguese.actorName != "")
				{
					screen.actorName = localization.portuguese.actorName;
				}
				if (localization.portuguese.dialogText != "")
				{
					screen.dialogText = localization.portuguese.dialogText;
				}
				if (localization.portuguese.changeAudio)
				{
					screen.soundToLoad = localization.portuguese.soundToLoad;
					screen.soundPitch = localization.portuguese.soundPitch;
				}
				if (localization.portuguese.customButton1 != "")
				{
					screen.customButton1 = localization.portuguese.customButton1;
				}
				if (localization.portuguese.customButton2 != "")
				{
					screen.customButton2 = localization.portuguese.customButton2;
				}
				if (localization.portuguese.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.portuguese.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.portuguese.multipleButtons))
				{
					screen.multipleButtons = localization.portuguese.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.portuguese.logicStatementCompare != null && localization.portuguese.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements10 in logicStatements)
					{
						if (logicStatements10 != null && localization.portuguese.logicStatementCompare[num] != "")
						{
							logicStatements10.compare = localization.portuguese.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons9 in iG_buttons)
					{
						if (iconGridButtons9 != null && iconGridButtons9.localizeTitle && iconGridButtons9.localizedTitle.portuguese != "")
						{
							iconGridButtons9.title = iconGridButtons9.localizedTitle.portuguese;
						}
					}
				}
			}
			else if (DialogLocalization.language == "Russian")
			{
				if (localization.russian.actorName != "")
				{
					screen.actorName = localization.russian.actorName;
				}
				if (localization.russian.dialogText != "")
				{
					screen.dialogText = localization.russian.dialogText;
				}
				if (localization.russian.changeAudio)
				{
					screen.soundToLoad = localization.russian.soundToLoad;
					screen.soundPitch = localization.russian.soundPitch;
				}
				if (localization.russian.customButton1 != "")
				{
					screen.customButton1 = localization.russian.customButton1;
				}
				if (localization.russian.customButton2 != "")
				{
					screen.customButton2 = localization.russian.customButton2;
				}
				if (localization.russian.passwordAnswer != "")
				{
					screen.passwordAnswer = localization.russian.passwordAnswer;
				}
				if (!StringArrayIsEmpty(localization.russian.multipleButtons))
				{
					screen.multipleButtons = localization.russian.multipleButtons;
				}
				if (screen.logicStatements != null && screen.logicStatements.Length != 0 && localization.russian.logicStatementCompare != null && localization.russian.logicStatementCompare.Length == screen.logicStatements.Length)
				{
					num = 0;
					LogicStatements[] logicStatements = screen.logicStatements;
					foreach (LogicStatements logicStatements11 in logicStatements)
					{
						if (logicStatements11 != null && localization.russian.logicStatementCompare[num] != "")
						{
							logicStatements11.compare = localization.russian.logicStatementCompare[num];
						}
						num++;
					}
				}
				if (screen.IG_buttons != null && screen.IG_buttons.Length != 0)
				{
					IconGridButtons[] iG_buttons = screen.IG_buttons;
					foreach (IconGridButtons iconGridButtons10 in iG_buttons)
					{
						if (iconGridButtons10 != null && iconGridButtons10.localizeTitle && iconGridButtons10.localizedTitle.russian != "")
						{
							iconGridButtons10.title = iconGridButtons10.localizedTitle.russian;
						}
					}
				}
			}
			else if (DialogLocalization.language != "English" && DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
			{
				Debug.Log(base.gameObject.name + " (DialogScreen ID: " + dialogID + ") - Localization defaulting to English.");
			}
			SetupInjectors();
		}

		public IEnumerator Setup()
		{
			yield return null;
			if (!isActive || !(DialogUI.dui != null) || DialogUI.dui.forceClose || (DialogUI.status != DUISTATUS.ENDED && DialogUI.status != DUISTATUS.WAITFORSCREEN))
			{
				yield break;
			}
			if (screen.dialogStyle == DIALOGSTYLE.Logic)
			{
				LogicSetup();
				yield break;
			}
			if (actions.setNewLanguage != 0)
			{
				DialogUI.ChangeLanguage(actions.setNewLanguage, actions.updateGUISkins);
			}
			DialogUI.dui.options.autoScrollingValue = Vector2.zero;
			DialogUI.dui.TokenActions(actions.tokens);
			DialogUI.actorName = screen.actorName;
			DialogUI.dialogText = screen.dialogText;
			DialogUI.portrait = screen.portrait;
			if (screen.animatedPortrait != new Vector2(-1f, -1f) && DialogCast.com != null && DialogCast.GetAnimation((int)screen.animatedPortrait.x, (int)screen.animatedPortrait.y) != null)
			{
				DialogUI.portraitAnimation = DialogCast.GetAnimation((int)screen.animatedPortrait.x, (int)screen.animatedPortrait.y);
			}
			else
			{
				DialogUI.portraitAnimation = null;
			}
			DialogUI.popupImage = screen.popupImage;
			DialogUI.popupSizeX = screen.popupSizeX;
			DialogUI.popupSizeY = screen.popupSizeY;
			DialogUI.popupButtonSizeX = screen.popupButtonSizeX;
			DialogUI.popupButtonSizeY = screen.popupButtonSizeY;
			DialogUI.popupButtonSpacer = screen.popupButtonSpacer;
			DialogUI.popupBackgroundAlpha = screen.popupBackgroundAlpha;
			DialogUI.popupOptions = screen.popupOptions;
			if (screen.popupImageAnim != new Vector2(-1f, -1f) && DialogScenes.com != null && DialogScenes.GetAnimation((int)screen.popupImageAnim.x, (int)screen.popupImageAnim.y) != null)
			{
				DialogUI.popupImageAnimation = DialogScenes.GetAnimation((int)screen.popupImageAnim.x, (int)screen.popupImageAnim.y);
			}
			else
			{
				DialogUI.popupImageAnimation = null;
			}
			DialogUI.scrollPosition = Vector2.zero;
			DialogUI.IG_WindowSizeX = screen.IG_WindowSizeX;
			DialogUI.IG_WindowSizeY = screen.IG_WindowSizeY;
			DialogUI.IG_WindowOffsetX = screen.IG_WindowOffsetX;
			DialogUI.IG_WindowOffsetY = screen.IG_WindowOffsetY;
			DialogUI.IG_WindowShowTitle = screen.IG_WindowShowTitle;
			DialogUI.IG_WindowShowSubtitle = screen.IG_WindowShowSubtitle;
			DialogUI.IG_AddSpaceBetweenSubtitleAndContent = screen.IG_AddSpaceBetweenSubtitleAndContent;
			DialogUI.IG_useXScrolling = screen.IG_useXScrolling;
			DialogUI.IG_useYScrolling = screen.IG_useYScrolling;
			DialogUI.IG_BackgroundAlpha = screen.IG_BackgroundAlpha;
			DialogUI.IG_showPanelBG = screen.IG_showPanelBG;
			DialogUI.IG_iconSizeX = screen.IG_iconSizeX;
			DialogUI.IG_iconSizeY = screen.IG_iconSizeY;
			DialogUI.IG_iconsPerRow = screen.IG_iconsPerRow;
			DialogUI.IG_IconSpacer = screen.IG_IconSpacer;
			DialogUI.IG_AddInnerIconSpacing = screen.IG_AddInnerIconSpacing;
			DialogUI.IG_showIconLabels = screen.IG_showIconLabels;
			DialogUI.IG_iconLabelSize = screen.IG_iconLabelSize;
			DialogUI.IG_firstIconIsCloseButton = screen.IG_firstIconIsCloseButton;
			DialogUI.IG_closeButtonSize = screen.IG_closeButtonSize;
			DialogUI.IG_showButtonBackgrounds = screen.IG_showButtonBackgrounds;
			DialogUI.IG_buttonAllignment = screen.IG_buttonAllignment;
			DialogUI.IG_buttonImagePosition = screen.IG_buttonImagePosition;
			SetupIconGrid();
			DialogUI.screenDuration = navigation.secondsToDisplay;
			DialogUI.isActive = true;
			DialogUI.screen = this;
			DialogUI.dialogStyle = screen.dialogStyle;
			DialogUI.customButton1 = screen.customButton1;
			DialogUI.customButton2 = screen.customButton2;
			SetupMultipleButtons();
			DialogUI.typeWriterOptions = screen.typeWriterOptions;
			DialogUI.scrollingOptions = screen.scrollingOptions;
			SetupCustomButtonIcons();
			DialogUI.dataEntryToken = screen.dataEntryToken;
			DialogUI.dataEntryFormat = screen.dataEntryFormat;
			DialogUI.dataEntryCharacterLimit = screen.dataEntryCharacterLimit;
			DialogUI.dataEntryDefaultValue = screen.dataEntryDefaultValue;
			DialogUI.dataEntryString = screen.dataEntryDefaultValue;
			DialogUI.dataEntryAnchor = screen.dataEntryAnchor;
			DialogUI.passwordMatchToToken = screen.passwordMatchToToken;
			DialogUI.passwordAnswer = screen.passwordAnswer;
			DialogUI.passwordCaseSensitive = screen.passwordCaseSensitive;
			DialogUI.passwordMask = screen.passwordMask;
			DialogUI.hideNextButton = navigation.hideNextButton;
			DialogUI.noPortraitFadeIn = navigation.noPortraitFadeIn;
			DialogUI.noPortraitFadeOut = navigation.noPortraitFadeOut;
			DialogUI.setupTextField = true;
			DialogUI.titleOffset = screen.titleOffset;
			DialogUI.overrideTitleFont = screen.overrideTitleFont;
			DialogUI.titleSize = screen.titleSize;
			DialogUI.titleColor = screen.titleColor;
			DialogUI.titleFontSize = screen.titleFontSize;
			DialogUI.titleAllignment = screen.titleAllignment;
			DialogUI.subtitleOffset = screen.subtitleOffset;
			DialogUI.overrideSubtitleFont = screen.overrideSubtitleFont;
			DialogUI.subtitleSize = screen.subtitleSize;
			DialogUI.subtitleColor = screen.subtitleColor;
			DialogUI.subtitleFontSize = screen.subtitleFontSize;
			DialogUI.subtitleAllignment = screen.subtitleAllignment;
			DialogUI.hideDialogBackground = navigation.hideDialogBackground;
			DialogUI.status = DUISTATUS.SHOW;
			SetupBackgroundLayers();
			SetupActorLayers();
			SetupAudioActions();
			if (screen.soundToLoad != string.Empty && DialogUI.dui != null)
			{
				StartCoroutine(DialogUI.dui.PlayAudio(screen.soundToLoad, screen.soundPitch));
			}
			CreateObjectsAtStartOfScreen();
			ActivateObjectsAtStartOfScreen();
			DeactivateObjectsAtStartOfScreen();
			SendMessageAtStart();
			DoConsoleMessages(actions.showMessageInConsoleAtStart);
			DestroyObjectsAtStartOfScreen();
			DialogUI.dui.SetupDialogTextEffects();
			ThirdPartyStart();
			DoPlayerPrefsActions();
			if (actions.tokenFileManagement == DSTokenFileManagementActions.SaveToPlayerPrefs)
			{
				DialogUI.SaveTokensToDisk();
			}
			else if (actions.tokenFileManagement == DSTokenFileManagementActions.LoadFromPlayerPrefs)
			{
				DialogUI.LoadTokensFromDisk();
			}
			else if (actions.tokenFileManagement == DSTokenFileManagementActions.DeleteFromPlayerPrefs)
			{
				DialogUI.DeleteTokensFromDisk();
			}
			SetupUIButtonFocus();
			DialogUI.injectors = injectors;
			DoAPICallBacksAtStart();
			SetupTransitions(navigation.screenTransitionIn);
		}

		public void DoConsoleMessages(string[] sArray)
		{
			if (sArray == null || sArray.Length == 0)
			{
				return;
			}
			foreach (string text in sArray)
			{
				if (text != null && text != "")
				{
					Debug.Log(DialogUI.dui.ApplyTokens(text));
				}
			}
		}

		public void SetupTransitions(DIALOG_OVERRIDE_TRANSITION setting)
		{
			if (setting == DIALOG_OVERRIDE_TRANSITION.UseDefault)
			{
				if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.None)
				{
					DialogUI.transition = DUI_TransitionEffects.None;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.PushLeft)
				{
					DialogUI.transition = DUI_TransitionEffects.PushLeft;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.PushRight)
				{
					DialogUI.transition = DUI_TransitionEffects.PushRight;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.PushDown)
				{
					DialogUI.transition = DUI_TransitionEffects.PushDown;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.PushUp)
				{
					DialogUI.transition = DUI_TransitionEffects.PushUp;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.InAndOutFromLeft)
				{
					DialogUI.transition = DUI_TransitionEffects.InAndOutFromLeft;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.InAndOutFromRight)
				{
					DialogUI.transition = DUI_TransitionEffects.InAndOutFromRight;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.InAndOutFromTop)
				{
					DialogUI.transition = DUI_TransitionEffects.InAndOutFromTop;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.InAndOutFromBottom)
				{
					DialogUI.transition = DUI_TransitionEffects.InAndOutFromBottom;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.Popup)
				{
					DialogUI.transition = DUI_TransitionEffects.Popup;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.Eyelids)
				{
					DialogUI.transition = DUI_TransitionEffects.Eyelids;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.BarnDoors)
				{
					DialogUI.transition = DUI_TransitionEffects.BarnDoors;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.Zoom)
				{
					DialogUI.transition = DUI_TransitionEffects.Zoom;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.ZoomHorizontal)
				{
					DialogUI.transition = DUI_TransitionEffects.ZoomHorizontal;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.ZoomVertical)
				{
					DialogUI.transition = DUI_TransitionEffects.ZoomVertical;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.Spin)
				{
					DialogUI.transition = DUI_TransitionEffects.Spin;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.SpinPopup)
				{
					DialogUI.transition = DUI_TransitionEffects.SpinPopup;
				}
				else if (DialogUI.dui.options.defaultScreenTransition == DUI_TransitionEffects.SpinZoom)
				{
					DialogUI.transition = DUI_TransitionEffects.SpinZoom;
				}
			}
			switch (setting)
			{
			case DIALOG_OVERRIDE_TRANSITION.None:
				DialogUI.transition = DUI_TransitionEffects.None;
				break;
			case DIALOG_OVERRIDE_TRANSITION.PushLeft:
				DialogUI.transition = DUI_TransitionEffects.PushLeft;
				break;
			case DIALOG_OVERRIDE_TRANSITION.PushRight:
				DialogUI.transition = DUI_TransitionEffects.PushRight;
				break;
			case DIALOG_OVERRIDE_TRANSITION.PushDown:
				DialogUI.transition = DUI_TransitionEffects.PushDown;
				break;
			case DIALOG_OVERRIDE_TRANSITION.PushUp:
				DialogUI.transition = DUI_TransitionEffects.PushUp;
				break;
			case DIALOG_OVERRIDE_TRANSITION.InAndOutFromLeft:
				DialogUI.transition = DUI_TransitionEffects.InAndOutFromLeft;
				break;
			case DIALOG_OVERRIDE_TRANSITION.InAndOutFromRight:
				DialogUI.transition = DUI_TransitionEffects.InAndOutFromRight;
				break;
			case DIALOG_OVERRIDE_TRANSITION.InAndOutFromTop:
				DialogUI.transition = DUI_TransitionEffects.InAndOutFromTop;
				break;
			case DIALOG_OVERRIDE_TRANSITION.InAndOutFromBottom:
				DialogUI.transition = DUI_TransitionEffects.InAndOutFromBottom;
				break;
			case DIALOG_OVERRIDE_TRANSITION.Popup:
				DialogUI.transition = DUI_TransitionEffects.Popup;
				break;
			case DIALOG_OVERRIDE_TRANSITION.Eyelids:
				DialogUI.transition = DUI_TransitionEffects.Eyelids;
				break;
			case DIALOG_OVERRIDE_TRANSITION.BarnDoors:
				DialogUI.transition = DUI_TransitionEffects.BarnDoors;
				break;
			case DIALOG_OVERRIDE_TRANSITION.Zoom:
				DialogUI.transition = DUI_TransitionEffects.Zoom;
				break;
			case DIALOG_OVERRIDE_TRANSITION.ZoomHorizontal:
				DialogUI.transition = DUI_TransitionEffects.ZoomHorizontal;
				break;
			case DIALOG_OVERRIDE_TRANSITION.ZoomVertical:
				DialogUI.transition = DUI_TransitionEffects.ZoomVertical;
				break;
			case DIALOG_OVERRIDE_TRANSITION.Spin:
				DialogUI.transition = DUI_TransitionEffects.Spin;
				break;
			case DIALOG_OVERRIDE_TRANSITION.SpinPopup:
				DialogUI.transition = DUI_TransitionEffects.SpinPopup;
				break;
			case DIALOG_OVERRIDE_TRANSITION.SpinZoom:
				DialogUI.transition = DUI_TransitionEffects.SpinZoom;
				break;
			}
		}

		public void SetupUIButtonFocus()
		{
			if (!(typeof(DialogUI) != null))
			{
				return;
			}
			switch (screen.dialogStyle)
			{
			case DIALOGSTYLE.NextButton:
				DialogUI.buttonNames = new string[1] { DialogUI.dui.LocalizeNextButton() };
				break;
			case DIALOGSTYLE.OneButton:
				DialogUI.buttonNames = new string[1] { screen.customButton1 };
				break;
			case DIALOGSTYLE.YesOrNo:
				DialogUI.buttonNames = new string[2]
				{
					DialogUI.dui.LocalizeYesButton(),
					DialogUI.dui.LocalizeNoButton()
				};
				break;
			case DIALOGSTYLE.TwoButtons:
				DialogUI.buttonNames = new string[2] { screen.customButton1, screen.customButton2 };
				break;
			case DIALOGSTYLE.MultipleButtons:
				DialogUI.buttonNames = screen.multipleButtonsEvaluated;
				break;
			case DIALOGSTYLE.DataEntry:
				DialogUI.buttonNames = new string[2] { "TextField", "Submit" };
				break;
			case DIALOGSTYLE.Password:
				DialogUI.buttonNames = new string[2] { "TextField", "Submit" };
				break;
			case DIALOGSTYLE.Logic:
				DialogUI.buttonNames = new string[1] { "" };
				break;
			case DIALOGSTYLE.Popup:
				if (screen.popupOptions == POPUP_OPTIONS.TwoButtons)
				{
					DialogUI.buttonNames = new string[2] { screen.customButton1, screen.customButton2 };
				}
				else if (screen.popupOptions == POPUP_OPTIONS.OneButton)
				{
					DialogUI.buttonNames = new string[1] { screen.customButton1 };
				}
				break;
			case DIALOGSTYLE.IconGrid:
			{
				string[] array = new string[screen.IG_buttonsEvaluated.Length];
				for (int i = 0; i < screen.IG_buttonsEvaluated.Length; i++)
				{
					array[i] = i.ToString();
				}
				DialogUI.buttonNames = array;
				break;
			}
			}
			if (screen.dialogStyle == DIALOGSTYLE.DataEntry && DialogOnGUI.com != null)
			{
				DialogOnGUI.com.CheckDataEntryVR();
			}
			if (screen.dialogStyle == DIALOGSTYLE.Password && DialogOnGUI.com != null)
			{
				DialogOnGUI.com.CheckPasswordVR();
			}
			if (DialogOnGUI.com.renderMode == OnGuiRenderMode.Material && (DialogWorldSpaceGUI.com.inputMode == DialogWorldSpaceGUI.InputMode.Transform || DialogWorldSpaceGUI.com.inputMode == DialogWorldSpaceGUI.InputMode.Disabled))
			{
				DialogUI.currentSelection = -1;
			}
			else
			{
				DialogUI.currentSelection = 0;
			}
			DialogUI.buttons = new bool[DialogUI.buttonNames.Length];
		}

		public void SetupMultipleButtons()
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			ArrayList arrayList4 = new ArrayList();
			ArrayList arrayList5 = new ArrayList();
			ArrayList arrayList6 = new ArrayList();
			arrayList.Clear();
			arrayList2.Clear();
			arrayList3.Clear();
			arrayList4.Clear();
			arrayList5.Clear();
			arrayList6.Clear();
			if (screen.dialogStyle == DIALOGSTYLE.MultipleButtons && screen.multipleButtons.Length != 0 && screen.multipleButtons.Length == navigation.multipleButtons.Length && screen.multipleButtons.Length == screen.multipleButtonsIcon.Length && screen.multipleButtons.Length == screen.animatedMultipleButtonsIcon.Length && screen.multipleButtons.Length == injectors.multipleButtonInjectors.Length)
			{
				for (int i = 0; i < screen.multipleButtons.Length; i++)
				{
					if (!screen.multipleRequiresLogic[i] || ProcessTokenLogicEventWithExtraConditions(screen.multipleLogic[i]))
					{
						arrayList.Add(screen.multipleButtons[i]);
						arrayList2.Add(navigation.multipleButtons[i]);
						arrayList3.Add(screen.multipleButtonsIcon[i]);
						arrayList4.Add(screen.animatedMultipleButtonsIcon[i]);
						arrayList5.Add(injectors.multipleButtonInjectors[i]);
						arrayList6.Add(screen.multipleButtons[i]);
					}
				}
			}
			screen.multipleButtonsEvaluated = arrayList.ToArray(typeof(string)) as string[];
			navigation.multipleButtonsEvaluated = arrayList2.ToArray(typeof(int)) as int[];
			screen.multipleButtonsIconEvaluated = arrayList3.ToArray(typeof(Texture2D)) as Texture2D[];
			screen.animatedMultipleButtonsIconEvaluated = arrayList4.ToArray(typeof(Vector2)) as Vector2[];
			injectors.multipleButtonEvaluatedInjectors = arrayList5.ToArray(typeof(DUICachedInjectorsForScreenMultipleButton)) as DUICachedInjectorsForScreenMultipleButton[];
			injectors.multipleButtonsEvaluated = arrayList6.ToArray(typeof(string)) as string[];
			DialogUI.multipleButtons = screen.multipleButtonsEvaluated;
		}

		public void SetupIconGrid()
		{
			if (screen.dialogStyle != DIALOGSTYLE.IconGrid)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			arrayList.Clear();
			ArrayList arrayList2 = new ArrayList();
			arrayList2.Clear();
			ArrayList arrayList3 = new ArrayList();
			arrayList3.Clear();
			ArrayList arrayList4 = new ArrayList();
			arrayList4.Clear();
			ArrayList arrayList5 = new ArrayList();
			arrayList5.Clear();
			if (screen.dialogStyle == DIALOGSTYLE.IconGrid && screen.IG_buttons.Length != 0 && injectors.iconGridInjectors != null && injectors.iconGridInjectors.Length != 0 && injectors.iconGridInjectors.Length == screen.IG_buttons.Length && injectors.iconGridTitles.Length == screen.IG_buttons.Length && injectors.iconGridLabels.Length == screen.IG_buttons.Length && injectors.iconGridFailedLabels.Length == screen.IG_buttons.Length)
			{
				int num = 0;
				IconGridButtons[] iG_buttons = screen.IG_buttons;
				foreach (IconGridButtons iconGridButtons in iG_buttons)
				{
					if (!iconGridButtons.requiresLogic || ProcessTokenLogicEventWithExtraConditions(iconGridButtons.logicStatements))
					{
						if (iconGridButtons.ifLogicSucceeds == LDC_IFLOGICSUCCEEDS.DisableButton)
						{
							iconGridButtons.logicFailed = true;
						}
						else
						{
							iconGridButtons.logicFailed = false;
						}
						arrayList.Add(iconGridButtons);
						arrayList2.Add(injectors.iconGridInjectors[num]);
						arrayList3.Add(injectors.iconGridTitles[num]);
						arrayList4.Add(injectors.iconGridLabels[num]);
						arrayList5.Add(injectors.iconGridFailedLabels[num]);
					}
					else if (iconGridButtons.ifLogicFails == LDC_IFLOGICFAILS.DisableButton)
					{
						iconGridButtons.logicFailed = true;
						arrayList.Add(iconGridButtons);
						arrayList2.Add(injectors.iconGridInjectors[num]);
						arrayList3.Add(injectors.iconGridTitles[num]);
						arrayList4.Add(injectors.iconGridLabels[num]);
						arrayList5.Add(injectors.iconGridFailedLabels[num]);
					}
					num++;
				}
			}
			else
			{
				Debug.LogWarning("LDC: Problem with Icon Grid Button Consistency. Dialog Screen ID: " + dialogID);
			}
			screen.IG_buttonsEvaluated = arrayList.ToArray(typeof(IconGridButtons)) as IconGridButtons[];
			injectors.iconGridEvaluatedInjectors = arrayList2.ToArray(typeof(DUICachedInjectorsForScreenIconGrids)) as DUICachedInjectorsForScreenIconGrids[];
			injectors.iconGridTitlesEvaluated = arrayList3.ToArray(typeof(string)) as string[];
			injectors.iconGridLabelsEvaluated = arrayList4.ToArray(typeof(string)) as string[];
			injectors.iconGridFailedLabelsEvaluated = arrayList5.ToArray(typeof(string)) as string[];
			DialogUI.IG_buttons = screen.IG_buttonsEvaluated;
		}

		public void LogicSetup()
		{
			if (screen.logicStatements != null && screen.logicStatements.Length != 0 && typeof(DialogUI) != null && DialogUI.dui != null)
			{
				bool flag = false;
				LogicStatements[] logicStatements = screen.logicStatements;
				foreach (LogicStatements logicStatements2 in logicStatements)
				{
					if (logicStatements2 == null || !ProcessTokenLogicEventWithExtraConditions(logicStatements2))
					{
						continue;
					}
					flag = true;
					if (logicStatements2.endDialogAfterThis)
					{
						isActive = false;
						DialogUI.isActive = false;
						DialogUI.status = DUISTATUS.ENDED;
						DialogUI.screenDuration = 0f;
						dc.status = DCSTATUS.ENDED;
						dc.currentScreen = null;
						dc.currentID = 0;
						if (logicStatements2.destroyAtEnd)
						{
							Object.Destroy(base.gameObject);
						}
						break;
					}
					dc.status = DCSTATUS.NEXT;
					if (logicStatements2.navigate == LogicStatementNavigation.GoToScreen)
					{
						dc.nextID = logicStatements2.goToScreen;
					}
					else if (logicStatements2.navigate == LogicStatementNavigation.RandomRange)
					{
						dc.nextID = Mathf.Clamp(Random.Range(logicStatements2.goToScreenRandomRangeMin, logicStatements2.goToScreenRandomRangeMax + 1), logicStatements2.goToScreenRandomRangeMin, logicStatements2.goToScreenRandomRangeMax);
					}
					else if (logicStatements2.navigate == LogicStatementNavigation.Token)
					{
						floatRef floatRef2 = new floatRef();
						if (DialogUI.ParseTokenAsFloat(DialogUI.dui.tokens[logicStatements2.goToScreenUsingToken].value, floatRef2))
						{
							dc.nextID = (int)floatRef2.value;
						}
						else
						{
							if (DialogUI.dui != null && DialogUI.dui.options.debugSystemMessagesInConsole)
							{
								Debug.Log("DIALOG SCREEN: (Logic Token) Couldn't convert Token into a float. Returned 0.");
							}
							dc.nextID = 0;
						}
					}
					isActive = false;
					DialogUI.status = DUISTATUS.FADEOUT;
					break;
				}
				if (flag)
				{
					return;
				}
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC LOGIC: Using default navigation");
				}
				if (navigation.endDialogAfterThis)
				{
					isActive = false;
					DialogUI.isActive = false;
					DialogUI.status = DUISTATUS.ENDED;
					DialogUI.screenDuration = 0f;
					dc.status = DCSTATUS.ENDED;
					dc.currentScreen = null;
					dc.currentID = 0;
					if (navigation.destroyAtEnd)
					{
						Object.Destroy(base.gameObject);
					}
					return;
				}
				dc.status = DCSTATUS.NEXT;
				if (navigation.logicDefaultNavigate == LogicStatementNavigation.GoToScreen)
				{
					dc.nextID = navigation.logicDefaultNavigation;
				}
				else if (navigation.logicDefaultNavigate == LogicStatementNavigation.RandomRange)
				{
					dc.nextID = Mathf.Clamp(Random.Range(navigation.logicDefaultGoToScreenRandomRangeMin, navigation.logicDefaultGoToScreenRandomRangeMax + 1), navigation.logicDefaultGoToScreenRandomRangeMin, navigation.logicDefaultGoToScreenRandomRangeMax);
				}
				else if (navigation.logicDefaultNavigate == LogicStatementNavigation.Token)
				{
					floatRef floatRef3 = new floatRef();
					if (DialogUI.ParseTokenAsFloat(DialogUI.dui.tokens[navigation.logicDefaultGoToScreenUsingToken].value, floatRef3))
					{
						dc.nextID = (int)floatRef3.value;
					}
					else
					{
						if (DialogUI.dui != null && DialogUI.dui.options.debugSystemMessagesInConsole)
						{
							Debug.Log("DIALOG SCREEN: (Logic Token) Couldn't convert Token into a float. Returned 0.");
						}
						dc.nextID = 0;
					}
				}
				isActive = false;
				DialogUI.status = DUISTATUS.FADEOUT;
				return;
			}
			if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
			{
				Debug.Log("LDC LOGIC: Using default navigation");
			}
			if (navigation.endDialogAfterThis)
			{
				isActive = false;
				DialogUI.isActive = false;
				DialogUI.status = DUISTATUS.ENDED;
				DialogUI.screenDuration = 0f;
				dc.status = DCSTATUS.ENDED;
				dc.currentScreen = null;
				dc.currentID = 0;
				if (navigation.destroyAtEnd)
				{
					Object.Destroy(base.gameObject);
				}
				return;
			}
			dc.status = DCSTATUS.NEXT;
			if (navigation.logicDefaultNavigate == LogicStatementNavigation.GoToScreen)
			{
				dc.nextID = navigation.logicDefaultNavigation;
			}
			else if (navigation.logicDefaultNavigate == LogicStatementNavigation.RandomRange)
			{
				Debug.Log("HERE!");
				dc.nextID = Mathf.Clamp(Random.Range(navigation.logicDefaultGoToScreenRandomRangeMin, navigation.logicDefaultGoToScreenRandomRangeMax + 1), navigation.logicDefaultGoToScreenRandomRangeMin, navigation.logicDefaultGoToScreenRandomRangeMax);
			}
			else if (navigation.logicDefaultNavigate == LogicStatementNavigation.Token)
			{
				floatRef floatRef4 = new floatRef();
				if (DialogUI.ParseTokenAsFloat(DialogUI.dui.tokens[navigation.logicDefaultGoToScreenUsingToken].value, floatRef4))
				{
					dc.nextID = (int)floatRef4.value;
				}
				else
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugSystemMessagesInConsole)
					{
						Debug.Log("DIALOG SCREEN: (Logic Token) Couldn't convert Token into a float. Returned 0.");
					}
					dc.nextID = 0;
				}
			}
			isActive = false;
			DialogUI.status = DUISTATUS.FADEOUT;
		}

		public bool ProcessTokenLogicEventWithExtraConditions(LogicStatements event_cs2)
		{
			bool result = true;
			if (event_cs2 != null)
			{
				if ((event_cs2.logicType == DS_LOGIC_TYPE.Token && DialogUI.dui.tokens != null && DialogUI.dui.tokens.Length != 0 && DialogUI.dui.tokens[event_cs2.token] != null && ProcessTokenLogicEvent(event_cs2)) || (event_cs2.logicType != 0 && ProcessPlayerPrefsLogicEvent(event_cs2)))
				{
					if (event_cs2.extraConditions != null && event_cs2.extraConditions.Length != 0)
					{
						LogicStatementsExtra[] extraConditions = event_cs2.extraConditions;
						foreach (LogicStatementsExtra logicStatementsExtra in extraConditions)
						{
							if (logicStatementsExtra != null)
							{
								if ((logicStatementsExtra.logicType != 0 || DialogUI.dui.tokens == null || DialogUI.dui.tokens.Length == 0 || DialogUI.dui.tokens[logicStatementsExtra.token] == null || !ProcessTokenLogicEvent(logicStatementsExtra)) && (logicStatementsExtra.logicType == DS_LOGIC_TYPE.Token || !ProcessPlayerPrefsLogicEvent(logicStatementsExtra)))
								{
									result = false;
									break;
								}
								continue;
							}
							result = false;
							break;
						}
					}
					else
					{
						result = true;
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool ProcessTokenLogicEvent(LogicStatements event_cs3)
		{
			string value = DialogUI.dui.tokens[event_cs3.token].value;
			floatRef floatRef2 = new floatRef();
			floatRef floatRef3 = new floatRef();
			bool flag = false;
			bool flag2 = false;
			if (event_cs3.theOperator == DS_LOGIC_OPERATOR.Equals)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs3.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs3.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value == floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " == " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && value == event_cs3.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + value + " == " + event_cs3.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs3.theOperator == DS_LOGIC_OPERATOR.IsNot)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs3.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs3.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value != floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " != " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && value != event_cs3.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + value + " != " + event_cs3.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs3.theOperator == DS_LOGIC_OPERATOR.GreaterThan)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs3.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs3.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value > floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " > " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			else if (event_cs3.theOperator == DS_LOGIC_OPERATOR.LessThan)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs3.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs3.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value < floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " < " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			if (flag2)
			{
				return true;
			}
			return false;
		}

		public bool ProcessTokenLogicEvent(LogicStatementsExtra event_cs4)
		{
			string value = DialogUI.dui.tokens[event_cs4.token].value;
			floatRef floatRef2 = new floatRef();
			floatRef floatRef3 = new floatRef();
			bool flag = false;
			bool flag2 = false;
			if (event_cs4.theOperator == DS_LOGIC_OPERATOR.Equals)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs4.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs4.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value == floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " == " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && value == event_cs4.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + value + " == " + event_cs4.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs4.theOperator == DS_LOGIC_OPERATOR.IsNot)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs4.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs4.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value != floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " != " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && value != event_cs4.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + value + " != " + event_cs4.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs4.theOperator == DS_LOGIC_OPERATOR.GreaterThan)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs4.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs4.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value > floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " > " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			else if (event_cs4.theOperator == DS_LOGIC_OPERATOR.LessThan)
			{
				if (!DialogUI.ParseTokenAsFloat(value, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + value);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs4.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs4.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value < floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " < " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			if (flag2)
			{
				return true;
			}
			return false;
		}

		public bool ProcessPlayerPrefsLogicEvent(LogicStatements event_cs5)
		{
			if (event_cs5.ppKey == "" || (event_cs5.ppOperator != DS_PLAYERPREF_LOGIC_OPERATOR.DoesNotExist && !PlayerPrefs.HasKey(event_cs5.ppKey)))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs Key (\"" + event_cs5.ppKey + "\") Does not exist or is blank - logic returned false.");
				}
				return false;
			}
			if (event_cs5.logicType == DS_LOGIC_TYPE.PrefString && (event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.GreaterThan || event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.LessThan))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs strings are not compatible with greater than / less than operators - logic returned false.");
				}
				return false;
			}
			if (event_cs5.ppKey != "" && event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.DoesNotExist && !PlayerPrefs.HasKey(event_cs5.ppKey))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs Key (\"" + event_cs5.ppKey + "\") Does not exist - logic returned true.");
				}
				return true;
			}
			if (event_cs5.ppKey != "" && event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.Exists && PlayerPrefs.HasKey(event_cs5.ppKey))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs Key (\"" + event_cs5.ppKey + "\") Exists - logic returned true.");
				}
				return true;
			}
			string text = null;
			if (event_cs5.logicType == DS_LOGIC_TYPE.PrefString)
			{
				text = PlayerPrefs.GetString(event_cs5.ppKey);
			}
			else if (event_cs5.logicType == DS_LOGIC_TYPE.PrefFloat)
			{
				text = PlayerPrefs.GetFloat(event_cs5.ppKey).ToString();
			}
			else if (event_cs5.logicType == DS_LOGIC_TYPE.PrefInt)
			{
				text = PlayerPrefs.GetInt(event_cs5.ppKey).ToString();
			}
			floatRef floatRef2 = new floatRef();
			floatRef floatRef3 = new floatRef();
			bool flag = false;
			bool flag2 = false;
			if (event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.Equals)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs5.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs5.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value == floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " == " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && text == event_cs5.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + text + " == " + event_cs5.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.IsNot)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs5.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs5.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value != floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " != " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && text != event_cs5.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + text + " != " + event_cs5.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.GreaterThan)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs5.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs5.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value > floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " > " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			else if (event_cs5.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.LessThan)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs5.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs5.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value < floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " < " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			if (flag2)
			{
				return true;
			}
			return false;
		}

		public bool ProcessPlayerPrefsLogicEvent(LogicStatementsExtra event_cs6)
		{
			if (event_cs6.ppKey == "" || (event_cs6.ppOperator != DS_PLAYERPREF_LOGIC_OPERATOR.DoesNotExist && !PlayerPrefs.HasKey(event_cs6.ppKey)))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs Key (\"" + event_cs6.ppKey + "\") Does not exist or is blank - logic returned false.");
				}
				return false;
			}
			if (event_cs6.logicType == DS_LOGIC_TYPE.PrefString && (event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.GreaterThan || event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.LessThan))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs strings are not compatible with greater than / less than operators - logic returned false.");
				}
				return false;
			}
			if (event_cs6.ppKey != "" && event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.DoesNotExist && !PlayerPrefs.HasKey(event_cs6.ppKey))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs Key (\"" + event_cs6.ppKey + "\") Does not exist - logic returned true.");
				}
				return true;
			}
			if (event_cs6.ppKey != "" && event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.Exists && PlayerPrefs.HasKey(event_cs6.ppKey))
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
				{
					Debug.Log("LDC: PlayerPrefs Key (\"" + event_cs6.ppKey + "\") Exists - logic returned true.");
				}
				return true;
			}
			string text = null;
			if (event_cs6.logicType == DS_LOGIC_TYPE.PrefString)
			{
				text = PlayerPrefs.GetString(event_cs6.ppKey);
			}
			else if (event_cs6.logicType == DS_LOGIC_TYPE.PrefFloat)
			{
				text = PlayerPrefs.GetFloat(event_cs6.ppKey).ToString();
			}
			else if (event_cs6.logicType == DS_LOGIC_TYPE.PrefInt)
			{
				text = PlayerPrefs.GetInt(event_cs6.ppKey).ToString();
			}
			floatRef floatRef2 = new floatRef();
			floatRef floatRef3 = new floatRef();
			bool flag = false;
			bool flag2 = false;
			if (event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.Equals)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs6.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs6.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value == floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " == " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && text == event_cs6.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + text + " == " + event_cs6.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.IsNot)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs6.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs6.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value != floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " != " + floatRef3.value);
					}
					flag2 = true;
				}
				else if (flag && text != event_cs6.compare)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + text + " != " + event_cs6.compare);
					}
					flag2 = true;
				}
			}
			else if (event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.GreaterThan)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs6.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs6.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value > floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " > " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			else if (event_cs6.ppOperator == DS_PLAYERPREF_LOGIC_OPERATOR.LessThan)
			{
				if (!DialogUI.ParseTokenAsFloat(text, floatRef2))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + text);
					}
					flag = true;
				}
				if (!DialogUI.ParseTokenAsFloat(event_cs6.compare, floatRef3))
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC: Unable to parse '{0}'." + event_cs6.compare);
					}
					flag = true;
				}
				if (!flag && floatRef2.value < floatRef3.value)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugLogicMessagesInConsole)
					{
						Debug.Log("LDC LOGIC MATCH: " + floatRef2.value + " < " + floatRef3.value);
					}
					flag2 = true;
				}
			}
			if (flag2)
			{
				return true;
			}
			return false;
		}

		public bool IsLogicTrue(LogicStatements event_cs7)
		{
			if ((event_cs7.logicType == DS_LOGIC_TYPE.Token && DialogUI.dui.tokens.Length != 0 && ProcessTokenLogicEvent(event_cs7)) || (event_cs7.logicType != 0 && ProcessPlayerPrefsLogicEvent(event_cs7)))
			{
				return true;
			}
			return false;
		}

		public void SetupBackgroundLayers()
		{
			if (!(DialogUI.dui != null) || actions.sceneLayers == null || actions.sceneLayers.Length == 0)
			{
				return;
			}
			int num = 0;
			DialogUIBackgroundLayers[] sceneLayers = actions.sceneLayers;
			foreach (DialogUIBackgroundLayers dialogUIBackgroundLayers in sceneLayers)
			{
				if (dialogUIBackgroundLayers != null && DialogUI.dui.bgLayers[num] != null && (dialogUIBackgroundLayers.setLayer || actions.fadeAllSceneLayers))
				{
					if (!actions.fadeAllSceneLayers)
					{
						DialogUI.dui.bgLayers[num].tex = dialogUIBackgroundLayers.tex;
						DialogUI.dui.bgLayers[num].scale = dialogUIBackgroundLayers.scale;
						DialogUI.dui.bgLayers[num].display = dialogUIBackgroundLayers.display;
						DialogUI.dui.bgLayers[num].animationID = dialogUIBackgroundLayers.animationID;
					}
					if (DialogUI.dui.bgLayers[num].animationID != new Vector2(-1f, -1f) && DialogScenes.GetAnimation((int)DialogUI.dui.bgLayers[num].animationID.x, (int)DialogUI.dui.bgLayers[num].animationID.y) != null)
					{
						DialogCastActor animation = DialogScenes.GetAnimation((int)DialogUI.dui.bgLayers[num].animationID.x, (int)DialogUI.dui.bgLayers[num].animationID.y);
						DialogUI.dui.bgLayers[num].anim = new DialogCastActor();
						DialogUI.dui.bgLayers[num].anim.name = animation.name;
						DialogUI.dui.bgLayers[num].anim.icon = animation.icon;
						DialogUI.dui.bgLayers[num].anim.animated = animation.animated;
						DialogUI.dui.bgLayers[num].anim.frames = animation.frames;
						DialogUI.dui.bgLayers[num].anim.loopToFrame = animation.loopToFrame;
						DialogUI.dui.bgLayers[num].anim.animationSpeed = animation.animationSpeed;
						DialogUI.dui.bgLayers[num].anim.timer = 0f;
						DialogUI.dui.bgLayers[num].anim.currentFrame = 0;
					}
					else
					{
						DialogUI.dui.bgLayers[num].anim = null;
					}
					if (actions.fadeAllSceneLayers)
					{
						DialogUI.dui.bgLayers[num].display = DUI_LAYER_STATUS.FadeOut;
						DialogUI.dui.bgLayers[num].opacity = 1f;
					}
					else if (DialogUI.dui.bgLayers[num].display == DUI_LAYER_STATUS.FadeIn)
					{
						DialogUI.dui.bgLayers[num].opacity = 0f;
					}
					else if (DialogUI.dui.bgLayers[num].display == DUI_LAYER_STATUS.FadeOut)
					{
						DialogUI.dui.bgLayers[num].opacity = 1f;
					}
					else if (DialogUI.dui.bgLayers[num].display == DUI_LAYER_STATUS.Hide)
					{
						DialogUI.dui.bgLayers[num].opacity = 0f;
						DialogUI.dui.bgLayers[num].tex = null;
					}
					else if (DialogUI.dui.bgLayers[num].display == DUI_LAYER_STATUS.Show)
					{
						DialogUI.dui.bgLayers[num].opacity = 1f;
					}
				}
				num++;
			}
			bool displayBackgroundLayers = false;
			sceneLayers = DialogUI.dui.bgLayers;
			foreach (DialogUIBackgroundLayers dialogUIBackgroundLayers2 in sceneLayers)
			{
				if (dialogUIBackgroundLayers2 != null && dialogUIBackgroundLayers2.display != DUI_LAYER_STATUS.Hide)
				{
					displayBackgroundLayers = true;
				}
			}
			DialogUI.dui.displayBackgroundLayers = displayBackgroundLayers;
		}

		public void SetupActorLayers()
		{
			if (!(DialogUI.dui != null) || actions.actorLayers == null || actions.actorLayers.Length == 0)
			{
				return;
			}
			int num = 0;
			DialogUIActorLayers[] actorLayers = actions.actorLayers;
			foreach (DialogUIActorLayers dialogUIActorLayers in actorLayers)
			{
				if (dialogUIActorLayers != null && DialogUI.dui.bgActors[num] != null && (dialogUIActorLayers.setLayer || actions.fadeAllActorLayers))
				{
					if (!actions.fadeAllActorLayers)
					{
						DialogUI.dui.bgActors[num].tex = dialogUIActorLayers.tex;
						DialogUI.dui.bgActors[num].scale = dialogUIActorLayers.scale;
						DialogUI.dui.bgActors[num].display = dialogUIActorLayers.display;
						DialogUI.dui.bgActors[num].allignment = dialogUIActorLayers.allignment;
						DialogUI.dui.bgActors[num].motion = dialogUIActorLayers.motion;
						DialogUI.dui.bgActors[num].offset = dialogUIActorLayers.offset;
						DialogUI.dui.bgActors[num].animationID = dialogUIActorLayers.animationID;
						if (DialogUI.dui.bgActors[num].animationID != new Vector2(-1f, -1f) && DialogCast.GetAnimation((int)DialogUI.dui.bgActors[num].animationID.x, (int)DialogUI.dui.bgActors[num].animationID.y) != null)
						{
							DialogCastActor animation = DialogCast.GetAnimation((int)DialogUI.dui.bgActors[num].animationID.x, (int)DialogUI.dui.bgActors[num].animationID.y);
							DialogUI.dui.bgActors[num].anim = new DialogCastActor();
							DialogUI.dui.bgActors[num].anim.name = animation.name;
							DialogUI.dui.bgActors[num].anim.icon = animation.icon;
							DialogUI.dui.bgActors[num].anim.animated = animation.animated;
							DialogUI.dui.bgActors[num].anim.frames = animation.frames;
							DialogUI.dui.bgActors[num].anim.loopToFrame = animation.loopToFrame;
							DialogUI.dui.bgActors[num].anim.animationSpeed = animation.animationSpeed;
							DialogUI.dui.bgActors[num].anim.timer = 0f;
							DialogUI.dui.bgActors[num].anim.currentFrame = 0;
						}
						else
						{
							DialogUI.dui.bgActors[num].anim = null;
						}
						if (dialogUIActorLayers.tex != null)
						{
							Rect rect = DialogUI.dui.bgActors[num].rect;
							rect.width = (float)dialogUIActorLayers.tex.width * (dialogUIActorLayers.size / 100f);
							DialogUI.dui.bgActors[num].rect = rect;
							Rect rect2 = DialogUI.dui.bgActors[num].rect;
							rect2.height = (float)dialogUIActorLayers.tex.height * (dialogUIActorLayers.size / 100f);
							DialogUI.dui.bgActors[num].rect = rect2;
							DialogUI.dui.bgActors[num].rect = CalculateRectPosition(DialogUI.dui.bgActors[num].rect, DialogUI.dui.bgActors[num].allignment, DialogUI.dui.bgActors[num].offset);
						}
					}
					if (actions.fadeAllActorLayers)
					{
						DialogUI.dui.bgActors[num].display = DUI_LAYER_STATUS.FadeOut;
						DialogUI.dui.bgActors[num].opacity = 1f;
					}
					else if (DialogUI.dui.bgActors[num].display == DUI_LAYER_STATUS.FadeIn)
					{
						DialogUI.dui.bgActors[num].opacity = 0f;
					}
					else if (DialogUI.dui.bgActors[num].display == DUI_LAYER_STATUS.FadeOut)
					{
						DialogUI.dui.bgActors[num].opacity = 1f;
					}
					else if (DialogUI.dui.bgActors[num].display == DUI_LAYER_STATUS.Hide)
					{
						DialogUI.dui.bgActors[num].opacity = 0f;
						DialogUI.dui.bgActors[num].tex = null;
					}
					else if (DialogUI.dui.bgActors[num].display == DUI_LAYER_STATUS.Show)
					{
						DialogUI.dui.bgActors[num].opacity = 1f;
					}
				}
				else if (actions.fadeAllActorLayers && DialogUI.dui.bgActors[num] != null)
				{
					DialogUI.dui.bgActors[num].display = DUI_LAYER_STATUS.FadeOut;
					DialogUI.dui.bgActors[num].opacity = 1f;
				}
				num++;
			}
			bool displayActorLayers = false;
			actorLayers = DialogUI.dui.bgActors;
			foreach (DialogUIActorLayers dialogUIActorLayers2 in actorLayers)
			{
				if (dialogUIActorLayers2 != null && dialogUIActorLayers2.display != DUI_LAYER_STATUS.Hide)
				{
					displayActorLayers = true;
				}
			}
			DialogUI.dui.displayActorLayers = displayActorLayers;
		}

		public Rect CalculateRectPosition(Rect theRect, DUI_ACTOR_ALLIGN pos, Vector2 offset)
		{
			switch (pos)
			{
			case DUI_ACTOR_ALLIGN.TopLeft:
				theRect.x = 0f;
				theRect.y = 0f;
				break;
			case DUI_ACTOR_ALLIGN.Top:
				theRect.x = 480f - theRect.width / 2f;
				theRect.y = 0f;
				break;
			case DUI_ACTOR_ALLIGN.TopRight:
				theRect.x = 960f - theRect.width;
				theRect.y = 0f;
				break;
			case DUI_ACTOR_ALLIGN.MidLeft:
				theRect.x = 0f;
				theRect.y = 320f - theRect.height / 2f;
				break;
			case DUI_ACTOR_ALLIGN.Middle:
				theRect.x = 480f - theRect.width / 2f;
				theRect.y = 320f - theRect.height / 2f;
				break;
			case DUI_ACTOR_ALLIGN.MidRight:
				theRect.x = 960f - theRect.width;
				theRect.y = 320f - theRect.height / 2f;
				break;
			case DUI_ACTOR_ALLIGN.BotLeft:
				theRect.x = 0f;
				theRect.y = 640f - theRect.height;
				break;
			case DUI_ACTOR_ALLIGN.Bottom:
				theRect.x = 480f - theRect.width / 2f;
				theRect.y = 640f - theRect.height;
				break;
			case DUI_ACTOR_ALLIGN.BotRight:
				theRect.x = 960f - theRect.width;
				theRect.y = 640f - theRect.height;
				break;
			}
			theRect.x += offset.x;
			theRect.y += offset.y;
			return theRect;
		}

		public void SetupAudioActions()
		{
			if (typeof(DialogUI) != null && DialogUI.dui != null)
			{
				if (actions.music.action != 0)
				{
					StartCoroutine(DialogUI.dui.SetupAudio(0, CreateAudioSetupInstance(actions.music)));
				}
				if (actions.sfx1.action != 0)
				{
					StartCoroutine(DialogUI.dui.SetupAudio(1, CreateAudioSetupInstance(actions.sfx1)));
				}
				if (actions.sfx2.action != 0)
				{
					StartCoroutine(DialogUI.dui.SetupAudio(2, CreateAudioSetupInstance(actions.sfx2)));
				}
				if (actions.sfx3.action != 0)
				{
					StartCoroutine(DialogUI.dui.SetupAudio(3, CreateAudioSetupInstance(actions.sfx3)));
				}
			}
		}

		public DSAudioSetup CreateAudioSetupInstance(DSAudioSetup setup)
		{
			return new DSAudioSetup
			{
				source = setup.source,
				action = setup.action,
				useAudioPath = setup.useAudioPath,
				playFromPath = setup.playFromPath,
				clip = setup.clip,
				volume = setup.volume,
				currentVolume = setup.currentVolume,
				pitch = setup.pitch,
				loop = setup.loop,
				fadeDuration = setup.fadeDuration
			};
		}

		public void PrepareNewDialogsAndLoadLevelsAtEnd()
		{
			if (navigation.restartLevelAtEnd)
			{
				DialogUI.API_LoadLevel(SceneManager.GetActiveScene().name);
			}
			else if (navigation.loadLevelAtEnd != "")
			{
				DialogUI.API_LoadLevel(DialogUI.dui.ApplyTokens(navigation.loadLevelAtEnd));
			}
			else if (navigation.instantiateDialogPrefabAtEnd != null)
			{
				GameObject gameObject = Object.Instantiate(navigation.instantiateDialogPrefabAtEnd);
				if (gameObject != null && gameObject.GetComponent<DialogController>() != null)
				{
					DialogUI.changeThreadDC = gameObject.GetComponent<DialogController>();
					DialogUI.changeThreadOverrideID = navigation.newStartID;
				}
				else if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
				{
					Debug.Log("LDC: Warning - The Object you have created to play does not have a DialogController. This navigation action was skipped.");
				}
			}
			else
			{
				if (!(navigation.findAndPlayOtherDialogAtEnd != ""))
				{
					return;
				}
				string text = DialogUI.dui.ApplyTokens(navigation.findAndPlayOtherDialogAtEnd);
				if (GameObject.Find(text) != null)
				{
					GameObject gameObject2 = GameObject.Find(text);
					if (gameObject2 != null && gameObject2.GetComponent<DialogController>() != null)
					{
						DialogUI.changeThreadDC = gameObject2.GetComponent<DialogController>();
						DialogUI.changeThreadOverrideID = navigation.newStartID;
					}
					else if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: Warning - The Object you are to find and play does not have a DialogController. This navigation action was skipped.");
					}
				}
				else if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
				{
					Debug.Log("LDC: Warning - The Object you are to find and play could not be found. This navigation action was skipped.");
				}
			}
		}

		public void NavigationCallback(int buttonID, string buttonName)
		{
			if (navigation.navigationCallbackGOName != string.Empty && navigation.navigationCallbackFunctionName == string.Empty)
			{
				if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
				{
					Debug.Log("LDC: Couldn't create Navigation callback on DialogID " + dialogID + ". No function name was given.");
				}
			}
			else
			{
				if (!(navigation.navigationCallbackGOName != string.Empty) || !(navigation.navigationCallbackFunctionName != string.Empty))
				{
					return;
				}
				if (GameObject.Find(navigation.navigationCallbackGOName) != null)
				{
					GameObject gameObject = GameObject.Find(navigation.navigationCallbackGOName);
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: Sending NavigationCallback to GameObject: " + gameObject.name + "...");
					}
					string[] value = new string[5]
					{
						base.gameObject.name,
						dialogID.ToString(),
						buttonID.ToString(),
						buttonName,
						DialogUI.dui.ApplyTokens(navigation.navigationCallbackArg)
					};
					gameObject.SendMessage(navigation.navigationCallbackFunctionName, value, SendMessageOptions.DontRequireReceiver);
				}
				else if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
				{
					Debug.Log("LDC: Couldn't create Navigation callback on DialogID " + dialogID + ". Couldn't use SendMessage because the GameObject named '" + navigation.navigationCallbackGOName + "'' was not found in the scene.");
				}
			}
		}

		public void Skip()
		{
			if (DialogUI.status == DUISTATUS.FORCECLOSE)
			{
				return;
			}
			if (navigation.endDialogAfterThis)
			{
				isActive = false;
				if (navigation.instantiateDialogPrefabAtEnd == null && navigation.findAndPlayOtherDialogAtEnd == "")
				{
					DialogUI.isActive = false;
					DialogUI.status = DUISTATUS.ENDED;
					DialogUI.screenDuration = 0f;
					dc.status = DCSTATUS.ENDED;
					dc.currentScreen = null;
					dc.currentID = 0;
				}
				else
				{
					DialogUI.status = DUISTATUS.FADEOUT;
				}
			}
			else
			{
				dc.status = DCSTATUS.NEXT;
				dc.nextID = navigation.screenToLoadOnNext;
				isActive = false;
				DialogUI.status = DUISTATUS.FADEOUT;
			}
			SetupTransitions(navigation.screenTransitionOut);
			CreateObjectsAtEndOfScreen();
			ActivateObjectsAtEndOfScreen();
			DeactivateObjectsAtEndOfScreen();
			SendMessageAtEnd();
			DoConsoleMessages(actions.showMessageInConsoleAtEnd);
			DestroyObjectsAtEndOfScreen();
			ThirdPartyEnd();
			DoAPICallBacksAtEnd();
			if (screen.dialogStyle == DIALOGSTYLE.NextButton)
			{
				NavigationCallback(0, "Next");
			}
			else
			{
				NavigationCallback(0, screen.customButton1);
			}
			if (navigation.endDialogAfterThis)
			{
				PrepareNewDialogsAndLoadLevelsAtEnd();
			}
			if (navigation.endDialogAfterThis && navigation.destroyAtEnd)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void MultipleChoiceNext(int mcID)
		{
			if (DialogUI.status == DUISTATUS.FORCECLOSE)
			{
				return;
			}
			if (navigation.endDialogAfterThis)
			{
				isActive = false;
				if (navigation.instantiateDialogPrefabAtEnd == null && navigation.findAndPlayOtherDialogAtEnd == "")
				{
					DialogUI.isActive = false;
					DialogUI.status = DUISTATUS.ENDED;
					DialogUI.screenDuration = 0f;
					dc.status = DCSTATUS.ENDED;
					dc.currentScreen = null;
					dc.currentID = 0;
				}
				else
				{
					DialogUI.status = DUISTATUS.FADEOUT;
				}
			}
			else
			{
				dc.status = DCSTATUS.NEXT;
				dc.nextID = navigation.multipleButtonsEvaluated[mcID];
				isActive = false;
				DialogUI.status = DUISTATUS.FADEOUT;
			}
			SetupTransitions(navigation.screenTransitionOut);
			CreateObjectsAtEndOfScreen();
			ActivateObjectsAtEndOfScreen();
			DeactivateObjectsAtEndOfScreen();
			SendMessageAtEnd();
			DoConsoleMessages(actions.showMessageInConsoleAtEnd);
			DestroyObjectsAtEndOfScreen();
			ThirdPartyEnd();
			DoAPICallBacksAtEnd();
			NavigationCallback(mcID, screen.multipleButtonsEvaluated[mcID]);
			if (navigation.endDialogAfterThis)
			{
				PrepareNewDialogsAndLoadLevelsAtEnd();
			}
			if (navigation.endDialogAfterThis && navigation.destroyAtEnd)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void IconGridNext(int igID)
		{
			if (DialogUI.status == DUISTATUS.FORCECLOSE)
			{
				return;
			}
			if (navigation.endDialogAfterThis)
			{
				isActive = false;
				if (navigation.instantiateDialogPrefabAtEnd == null && navigation.findAndPlayOtherDialogAtEnd == "")
				{
					DialogUI.isActive = false;
					DialogUI.status = DUISTATUS.ENDED;
					DialogUI.screenDuration = 0f;
					dc.status = DCSTATUS.ENDED;
					dc.currentScreen = null;
					dc.currentID = 0;
				}
				else
				{
					DialogUI.status = DUISTATUS.FADEOUT;
				}
			}
			else
			{
				dc.status = DCSTATUS.NEXT;
				dc.nextID = screen.IG_buttonsEvaluated[igID].nextID;
				isActive = false;
				DialogUI.status = DUISTATUS.FADEOUT;
			}
			SetupTransitions(navigation.screenTransitionOut);
			CreateObjectsAtEndOfScreen();
			ActivateObjectsAtEndOfScreen();
			DeactivateObjectsAtEndOfScreen();
			SendMessageAtEnd();
			DoConsoleMessages(actions.showMessageInConsoleAtEnd);
			DestroyObjectsAtEndOfScreen();
			ThirdPartyEnd();
			DoAPICallBacksAtEnd();
			NavigationCallback(igID, screen.IG_buttonsEvaluated[igID].title);
			if (navigation.endDialogAfterThis)
			{
				PrepareNewDialogsAndLoadLevelsAtEnd();
			}
			if (navigation.endDialogAfterThis && navigation.destroyAtEnd)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void Yes()
		{
			if (DialogUI.status == DUISTATUS.FORCECLOSE)
			{
				return;
			}
			if (navigation.endDialogAfterThis)
			{
				isActive = false;
				if (navigation.instantiateDialogPrefabAtEnd == null && navigation.findAndPlayOtherDialogAtEnd == "")
				{
					DialogUI.isActive = false;
					DialogUI.status = DUISTATUS.ENDED;
					DialogUI.screenDuration = 0f;
					dc.status = DCSTATUS.ENDED;
					dc.currentScreen = null;
					dc.currentID = 0;
				}
				else
				{
					DialogUI.status = DUISTATUS.FADEOUT;
				}
			}
			else
			{
				dc.status = DCSTATUS.NEXT;
				dc.nextID = navigation.screenToLoadOnYes;
				isActive = false;
				DialogUI.status = DUISTATUS.FADEOUT;
			}
			SetupTransitions(navigation.screenTransitionOut);
			CreateObjectsAtEndOfScreen();
			ActivateObjectsAtEndOfScreen();
			DeactivateObjectsAtEndOfScreen();
			SendMessageAtEnd();
			DoConsoleMessages(actions.showMessageInConsoleAtEnd);
			DestroyObjectsAtEndOfScreen();
			ThirdPartyEnd();
			DoAPICallBacksAtEnd();
			if (screen.dialogStyle == DIALOGSTYLE.YesOrNo)
			{
				NavigationCallback(0, "Yes");
			}
			else
			{
				NavigationCallback(0, screen.customButton1);
			}
			if (navigation.endDialogAfterThis)
			{
				PrepareNewDialogsAndLoadLevelsAtEnd();
			}
			if (navigation.endDialogAfterThis && navigation.destroyAtEnd)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void No()
		{
			if (DialogUI.status == DUISTATUS.FORCECLOSE)
			{
				return;
			}
			if (navigation.endDialogAfterThis)
			{
				isActive = false;
				if (navigation.instantiateDialogPrefabAtEnd == null && navigation.findAndPlayOtherDialogAtEnd == "")
				{
					DialogUI.isActive = false;
					DialogUI.status = DUISTATUS.ENDED;
					DialogUI.screenDuration = 0f;
					dc.status = DCSTATUS.ENDED;
					dc.currentScreen = null;
					dc.currentID = 0;
				}
				else
				{
					DialogUI.status = DUISTATUS.FADEOUT;
				}
			}
			else
			{
				dc.status = DCSTATUS.NEXT;
				dc.nextID = navigation.screenToLoadOnNo;
				isActive = false;
				DialogUI.status = DUISTATUS.FADEOUT;
			}
			SetupTransitions(navigation.screenTransitionOut);
			CreateObjectsAtEndOfScreen();
			ActivateObjectsAtEndOfScreen();
			DeactivateObjectsAtEndOfScreen();
			SendMessageAtEnd();
			DoConsoleMessages(actions.showMessageInConsoleAtEnd);
			DestroyObjectsAtEndOfScreen();
			ThirdPartyEnd();
			DoAPICallBacksAtEnd();
			if (screen.dialogStyle == DIALOGSTYLE.YesOrNo)
			{
				NavigationCallback(1, "No");
			}
			else
			{
				NavigationCallback(1, screen.customButton2);
			}
			if (navigation.endDialogAfterThis)
			{
				PrepareNewDialogsAndLoadLevelsAtEnd();
			}
			if (navigation.endDialogAfterThis && navigation.destroyAtEnd)
			{
				Object.Destroy(base.gameObject);
			}
		}

		public void CreateObjectsAtStartOfScreen()
		{
			if (actions.createObjectsAtStart.Length == 0)
			{
				return;
			}
			for (int i = 0; i < actions.createObjectsAtStart.Length; i++)
			{
				if (actions.createObjectsAtStart[i].createObject != null)
				{
					Transform createLocation = base.transform;
					if (actions.createObjectsAtStart[i].createLocation != null)
					{
						createLocation = actions.createObjectsAtStart[i].createLocation;
					}
					if (GameObject.Find(actions.createObjectsAtStart[i].findGameObjectLocation) != null)
					{
						createLocation = GameObject.Find(actions.createObjectsAtStart[i].findGameObjectLocation).transform;
					}
					Object.Instantiate(actions.createObjectsAtStart[i].createObject, createLocation.position, createLocation.rotation);
				}
			}
		}

		public void CreateObjectsAtEndOfScreen()
		{
			if (actions.createObjectsAtEnd.Length == 0)
			{
				return;
			}
			for (int i = 0; i < actions.createObjectsAtEnd.Length; i++)
			{
				if (actions.createObjectsAtEnd[i].createObject != null)
				{
					Transform createLocation = base.transform;
					if (actions.createObjectsAtEnd[i].createLocation != null)
					{
						createLocation = actions.createObjectsAtEnd[i].createLocation;
					}
					if (GameObject.Find(actions.createObjectsAtEnd[i].findGameObjectLocation) != null)
					{
						createLocation = GameObject.Find(actions.createObjectsAtEnd[i].findGameObjectLocation).transform;
					}
					Object.Instantiate(actions.createObjectsAtEnd[i].createObject, createLocation.position, createLocation.rotation);
				}
			}
		}

		public void ActivateObjectsAtStartOfScreen()
		{
			if (actions.activateTheseObjectsAtStart.Length != 0)
			{
				string[] activateTheseObjectsAtStart = actions.activateTheseObjectsAtStart;
				foreach (string text in activateTheseObjectsAtStart)
				{
					if (text != null)
					{
						GameObject gameObject = GameObject.Find(text);
						if (gameObject != null)
						{
							gameObject.SetActive(value: true);
						}
					}
				}
			}
			if (actions.activateTheseObjectsAtStartDirectly.Length == 0)
			{
				return;
			}
			GameObject[] activateTheseObjectsAtStartDirectly = actions.activateTheseObjectsAtStartDirectly;
			foreach (GameObject gameObject2 in activateTheseObjectsAtStartDirectly)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(value: true);
				}
			}
		}

		public void DeactivateObjectsAtStartOfScreen()
		{
			if (actions.deactivateTheseObjectsAtStart.Length != 0)
			{
				string[] deactivateTheseObjectsAtStart = actions.deactivateTheseObjectsAtStart;
				foreach (string text in deactivateTheseObjectsAtStart)
				{
					if (text != null)
					{
						GameObject gameObject = GameObject.Find(text);
						if (gameObject != null)
						{
							gameObject.SetActive(value: false);
						}
					}
				}
			}
			if (actions.deactivateTheseObjectsAtStartDirectly.Length == 0)
			{
				return;
			}
			GameObject[] deactivateTheseObjectsAtStartDirectly = actions.deactivateTheseObjectsAtStartDirectly;
			foreach (GameObject gameObject2 in deactivateTheseObjectsAtStartDirectly)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(value: false);
				}
			}
		}

		public void ActivateObjectsAtEndOfScreen()
		{
			if (actions.activateTheseObjectsAtEnd.Length != 0)
			{
				GameObject[] activateTheseObjectsAtEnd = actions.activateTheseObjectsAtEnd;
				foreach (GameObject gameObject in activateTheseObjectsAtEnd)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(value: true);
					}
				}
			}
			if (actions.activateTheseObjectsAtEndByName.Length == 0)
			{
				return;
			}
			string[] activateTheseObjectsAtEndByName = actions.activateTheseObjectsAtEndByName;
			foreach (string text in activateTheseObjectsAtEndByName)
			{
				if (text != null)
				{
					GameObject gameObject2 = GameObject.Find(text);
					if (gameObject2 != null)
					{
						gameObject2.SetActive(value: true);
					}
				}
			}
		}

		public void DeactivateObjectsAtEndOfScreen()
		{
			if (actions.deactivateTheseObjectsAtEnd.Length != 0)
			{
				GameObject[] deactivateTheseObjectsAtEnd = actions.deactivateTheseObjectsAtEnd;
				foreach (GameObject gameObject in deactivateTheseObjectsAtEnd)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(value: false);
					}
				}
			}
			if (actions.deactivateTheseObjectsAtEndByName.Length == 0)
			{
				return;
			}
			string[] deactivateTheseObjectsAtEndByName = actions.deactivateTheseObjectsAtEndByName;
			foreach (string text in deactivateTheseObjectsAtEndByName)
			{
				if (text != null)
				{
					GameObject gameObject2 = GameObject.Find(text);
					if (gameObject2 != null)
					{
						gameObject2.SetActive(value: false);
					}
				}
			}
		}

		public void DestroyObjectsAtStartOfScreen()
		{
			if (actions.findAndDestroyTheseObjectsAtStart.Length != 0)
			{
				string[] findAndDestroyTheseObjectsAtStart = actions.findAndDestroyTheseObjectsAtStart;
				foreach (string text in findAndDestroyTheseObjectsAtStart)
				{
					if (GameObject.Find(text) != null)
					{
						Object.Destroy(GameObject.Find(text));
					}
				}
			}
			if (actions.destroyTheseObjectsAtStart.Length == 0)
			{
				return;
			}
			GameObject[] destroyTheseObjectsAtStart = actions.destroyTheseObjectsAtStart;
			foreach (GameObject gameObject in destroyTheseObjectsAtStart)
			{
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
		}

		public void DestroyObjectsAtEndOfScreen()
		{
			if (actions.findAndDestroyTheseObjectsAtEnd.Length != 0)
			{
				string[] findAndDestroyTheseObjectsAtEnd = actions.findAndDestroyTheseObjectsAtEnd;
				foreach (string text in findAndDestroyTheseObjectsAtEnd)
				{
					if (GameObject.Find(text) != null)
					{
						Object.Destroy(GameObject.Find(text));
					}
				}
			}
			if (actions.destroyTheseObjectsAtEnd.Length == 0)
			{
				return;
			}
			GameObject[] destroyTheseObjectsAtEnd = actions.destroyTheseObjectsAtEnd;
			foreach (GameObject gameObject in destroyTheseObjectsAtEnd)
			{
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
		}

		public void SendMessageAtStart()
		{
			if (actions.sendMessageAtStart.Length == 0)
			{
				return;
			}
			DS_SendMessage[] sendMessageAtStart = actions.sendMessageAtStart;
			foreach (DS_SendMessage dS_SendMessage in sendMessageAtStart)
			{
				if (dS_SendMessage.findDestination != "" && GameObject.Find(dS_SendMessage.findDestination) != null)
				{
					dS_SendMessage.destination = GameObject.Find(dS_SendMessage.findDestination);
				}
				if (dS_SendMessage.destination != null && dS_SendMessage.functionName != "")
				{
					if (dS_SendMessage.argType == DS_SendMessageArg.None)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendString)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.stringArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendInt)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.intArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendFloat)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.floatArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendBoolean)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.booleanArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendGameObject)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.goArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendTransform)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.transformArg);
					}
				}
			}
		}

		public void SendMessageAtEnd()
		{
			if (actions.sendMessageAtEnd.Length == 0)
			{
				return;
			}
			DS_SendMessage[] sendMessageAtEnd = actions.sendMessageAtEnd;
			foreach (DS_SendMessage dS_SendMessage in sendMessageAtEnd)
			{
				if (dS_SendMessage.findDestination != "" && GameObject.Find(dS_SendMessage.findDestination) != null)
				{
					dS_SendMessage.destination = GameObject.Find(dS_SendMessage.findDestination);
				}
				if (dS_SendMessage.destination != null && dS_SendMessage.functionName != "")
				{
					if (dS_SendMessage.argType == DS_SendMessageArg.None)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendString)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.stringArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendInt)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.intArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendFloat)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.floatArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendBoolean)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.booleanArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendGameObject)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.goArg);
					}
					else if (dS_SendMessage.argType == DS_SendMessageArg.SendTransform)
					{
						dS_SendMessage.destination.SendMessage(dS_SendMessage.functionName, dS_SendMessage.transformArg);
					}
				}
			}
		}

		public void DoPlayerPrefsActions()
		{
			string text = "";
			if (typeof(DialogUI) != null && DialogUI.dui != null)
			{
				text = DialogUI.dui.fileManagement.savePrefix.ToUpper();
				text = DialogUI.MakeSavePrefixSafe(text);
			}
			if (actions.playerPrefs.Length == 0)
			{
				return;
			}
			float num = 0f;
			int num2 = 0;
			DSPlayerPrefsActions[] playerPrefs = actions.playerPrefs;
			foreach (DSPlayerPrefsActions dSPlayerPrefsActions in playerPrefs)
			{
				if (dSPlayerPrefsActions == null)
				{
					continue;
				}
				if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.DeleteAllKeys)
				{
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Deleting All Keys In PlayerPrefs.");
					}
					PlayerPrefs.DeleteAll();
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.DeleteKey)
				{
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
						{
							Debug.Log("LDC: PlayerPrefs Action - Deleting Key In PlayerPrefs ( \"" + text + dSPlayerPrefsActions.key + "\").");
						}
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					else if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Error - Can't Delete Key because it doesn't exist ( \"" + text + dSPlayerPrefsActions.key + "\").");
					}
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.SetString)
				{
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Setting String ( \"" + text + dSPlayerPrefsActions.key + "\") to " + dSPlayerPrefsActions.stringArg);
					}
					PlayerPrefs.SetString(text + dSPlayerPrefsActions.key, dSPlayerPrefsActions.stringArg);
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.SetFloat)
				{
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Setting Float ( \"" + text + dSPlayerPrefsActions.key + "\") to " + dSPlayerPrefsActions.floatArg);
					}
					PlayerPrefs.SetFloat(text + dSPlayerPrefsActions.key, dSPlayerPrefsActions.floatArg);
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.SetInt)
				{
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Setting Int ( \"" + text + dSPlayerPrefsActions.key + "\") to " + dSPlayerPrefsActions.intArg);
					}
					PlayerPrefs.SetInt(text + dSPlayerPrefsActions.key, dSPlayerPrefsActions.intArg);
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.AddToFloat)
				{
					num = PlayerPrefs.GetFloat(text + dSPlayerPrefsActions.key);
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Add To Float ( \"" + text + dSPlayerPrefsActions.key + "\") to " + num + " + " + dSPlayerPrefsActions.floatArg + " = " + (num + dSPlayerPrefsActions.floatArg));
					}
					PlayerPrefs.SetFloat(text + dSPlayerPrefsActions.key, num + dSPlayerPrefsActions.floatArg);
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.SubtractFromFloat)
				{
					num = PlayerPrefs.GetFloat(text + dSPlayerPrefsActions.key);
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Subtract From Float ( \"" + text + dSPlayerPrefsActions.key + "\") to " + num + " - " + dSPlayerPrefsActions.floatArg + " = " + (num - dSPlayerPrefsActions.floatArg));
					}
					PlayerPrefs.SetFloat(text + dSPlayerPrefsActions.key, num - dSPlayerPrefsActions.floatArg);
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.AddToInt)
				{
					num2 = PlayerPrefs.GetInt(text + dSPlayerPrefsActions.key);
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Add To Int ( \"" + text + dSPlayerPrefsActions.key + "\") to " + num2 + " + " + dSPlayerPrefsActions.intArg + " = " + (num2 + dSPlayerPrefsActions.intArg));
					}
					PlayerPrefs.SetInt(text + dSPlayerPrefsActions.key, num2 + dSPlayerPrefsActions.intArg);
				}
				else if (dSPlayerPrefsActions.action == DSPlayerPrefsActionType.SubtractFromInt)
				{
					num2 = PlayerPrefs.GetInt(text + dSPlayerPrefsActions.key);
					if (PlayerPrefs.HasKey(text + dSPlayerPrefsActions.key))
					{
						PlayerPrefs.DeleteKey(text + dSPlayerPrefsActions.key);
					}
					if (DialogUI.dui != null && DialogUI.dui.options.debugActionMessagesInConsole)
					{
						Debug.Log("LDC: PlayerPrefs Action - Subtract From Int ( \"" + text + dSPlayerPrefsActions.key + "\") to " + num2 + " - " + dSPlayerPrefsActions.intArg + " = " + (num2 - dSPlayerPrefsActions.intArg));
					}
					PlayerPrefs.SetInt(text + dSPlayerPrefsActions.key, num2 - dSPlayerPrefsActions.intArg);
				}
			}
		}

		public void ThirdPartyStart()
		{
			if (actions.uSequencer.go == null && actions.uSequencer.findGo != "" && GameObject.Find(actions.uSequencer.findGo) != null)
			{
				actions.uSequencer.go = GameObject.Find(actions.uSequencer.findGo);
			}
			if (actions.uSequencer.go != null)
			{
				if (actions.uSequencer.setup)
				{
					actions.uSequencer.go.SendMessage("SetPlaybackTime", actions.uSequencer.setPlaybackTime);
					actions.uSequencer.go.SendMessage("SetPlaybackRate", actions.uSequencer.setPlaybackRate);
				}
				if (actions.uSequencer.startAction == DSuSequencerActionType.Play)
				{
					actions.uSequencer.go.SendMessage("Play", SendMessageOptions.DontRequireReceiver);
				}
				else if (actions.uSequencer.startAction == DSuSequencerActionType.Pause)
				{
					actions.uSequencer.go.SendMessage("Pause", SendMessageOptions.DontRequireReceiver);
				}
				else if (actions.uSequencer.startAction == DSuSequencerActionType.Stop)
				{
					actions.uSequencer.go.SendMessage("Stop", SendMessageOptions.DontRequireReceiver);
				}
				else if (actions.uSequencer.startAction == DSuSequencerActionType.Skip)
				{
					actions.uSequencer.go.SendMessage("Skip", SendMessageOptions.DontRequireReceiver);
				}
			}
			if (actions.rtVoice.action == DSRTVoiceActionType.None || !(GameObject.Find("RTVoice") != null))
			{
				return;
			}
			GameObject gameObject = GameObject.Find("RTVoice");
			if (actions.rtVoice.action == DSRTVoiceActionType.Silence)
			{
				gameObject.SendMessage("Silence", SendMessageOptions.DontRequireReceiver);
				return;
			}
			string text = "";
			if (actions.rtVoice.action == DSRTVoiceActionType.SayTitle)
			{
				text = screen.actorName;
			}
			else if (actions.rtVoice.action == DSRTVoiceActionType.SayText)
			{
				text = screen.dialogText;
			}
			else if (actions.rtVoice.action == DSRTVoiceActionType.SayTitleAndText)
			{
				text = screen.actorName + ". " + screen.dialogText;
			}
			if (DialogUI.dui != null && DialogUI.dui.thirdPartyTools != null && DialogUI.dui.thirdPartyTools.rtVoice != null && DialogUI.dui.thirdPartyTools.rtVoice.Length > actions.rtVoice.voiceToUse && DialogUI.dui.thirdPartyTools.rtVoice[actions.rtVoice.voiceToUse] != null)
			{
				LDC_ThirdPartySetup_RTVoice lDC_ThirdPartySetup_RTVoice = DialogUI.dui.thirdPartyTools.rtVoice[actions.rtVoice.voiceToUse];
				if ((!lDC_ThirdPartySetup_RTVoice.onlyUseVoiceInEditor || (lDC_ThirdPartySetup_RTVoice.onlyUseVoiceInEditor && Application.isEditor)) && (!lDC_ThirdPartySetup_RTVoice.playWhenNoDialogAudioExists || (lDC_ThirdPartySetup_RTVoice.playWhenNoDialogAudioExists && screen.soundToLoad == "")) && Application.platform != RuntimePlatform.OSXPlayer && Application.platform != 0 && (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor))
				{
					gameObject.SendMessage("Silence", SendMessageOptions.DontRequireReceiver);
					string[] value = new string[4]
					{
						text,
						lDC_ThirdPartySetup_RTVoice.cultureCode,
						lDC_ThirdPartySetup_RTVoice.windowsSetup.voiceID,
						lDC_ThirdPartySetup_RTVoice.rate.ToString()
					};
					gameObject.SendMessage("Speak", value, SendMessageOptions.DontRequireReceiver);
				}
			}
		}

		public void ThirdPartyEnd()
		{
			if (actions.uSequencer.go != null)
			{
				if (actions.uSequencer.endAction == DSuSequencerActionType.Play)
				{
					actions.uSequencer.go.SendMessage("Play", SendMessageOptions.DontRequireReceiver);
				}
				else if (actions.uSequencer.endAction == DSuSequencerActionType.Pause)
				{
					actions.uSequencer.go.SendMessage("Pause", SendMessageOptions.DontRequireReceiver);
				}
				else if (actions.uSequencer.endAction == DSuSequencerActionType.Stop)
				{
					actions.uSequencer.go.SendMessage("Stop", SendMessageOptions.DontRequireReceiver);
				}
				else if (actions.uSequencer.endAction == DSuSequencerActionType.Skip)
				{
					actions.uSequencer.go.SendMessage("Skip", SendMessageOptions.DontRequireReceiver);
				}
			}
		}

		public void DoAPICallBacksAtStart()
		{
			if (actions.actionAtStart != null)
			{
				actions.actionAtStart();
			}
			if (actions.callbacksAtStart != null)
			{
				actions.callbacksAtStart.Invoke();
			}
		}

		public void DoAPICallBacksAtEnd()
		{
			if (actions.actionAtEnd != null)
			{
				actions.actionAtEnd();
			}
			if (actions.callbacksAtEnd != null)
			{
				actions.callbacksAtEnd.Invoke();
			}
		}

		public void SetupCustomButtonIcons()
		{
			DialogUI.buttonIcon1 = screen.buttonIcon1;
			if (screen.animatedButtonIcon1 != new Vector2(-1f, -1f) && typeof(DialogButtons) != null && DialogButtons.GetAnimation((int)screen.animatedButtonIcon1.x, (int)screen.animatedButtonIcon1.y) != null)
			{
				DialogUI.buttonIcon1Animation = DialogButtons.GetAnimation((int)screen.animatedButtonIcon1.x, (int)screen.animatedButtonIcon1.y);
			}
			else
			{
				DialogUI.buttonIcon1Animation = null;
			}
			DialogUI.buttonIcon2 = screen.buttonIcon2;
			if (screen.animatedButtonIcon2 != new Vector2(-1f, -1f) && typeof(DialogButtons) != null && DialogButtons.GetAnimation((int)screen.animatedButtonIcon2.x, (int)screen.animatedButtonIcon2.y) != null)
			{
				DialogUI.buttonIcon2Animation = DialogButtons.GetAnimation((int)screen.animatedButtonIcon2.x, (int)screen.animatedButtonIcon2.y);
			}
			else
			{
				DialogUI.buttonIcon2Animation = null;
			}
			DialogUI.multipleButtonsIcon = screen.multipleButtonsIconEvaluated;
			ArrayList arrayList = new ArrayList();
			arrayList.Clear();
			if (screen.animatedMultipleButtonsIconEvaluated.Length != 0)
			{
				Vector2[] animatedMultipleButtonsIconEvaluated = screen.animatedMultipleButtonsIconEvaluated;
				for (int i = 0; i < animatedMultipleButtonsIconEvaluated.Length; i++)
				{
					Vector2 vector = animatedMultipleButtonsIconEvaluated[i];
					if (vector != new Vector2(-1f, -1f) && typeof(DialogButtons) != null && DialogButtons.GetAnimation((int)vector.x, (int)vector.y) != null)
					{
						DialogCastActor animation = DialogButtons.GetAnimation((int)vector.x, (int)vector.y);
						if (animation != null)
						{
							arrayList.Add(animation);
						}
						else
						{
							arrayList.Add(null);
						}
					}
					else
					{
						arrayList.Add(null);
					}
				}
			}
			DialogUI.multipleButtonsIconAnimation = arrayList.ToArray(typeof(DialogCastActor)) as DialogCastActor[];
		}

		public void SetupInjectors()
		{
			ReturnDUICachedInjectorsForScreen returnDUICachedInjectorsForScreen = null;
			returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.actorName, injectors.dialogTitleInjectors);
			screen.actorName = returnDUICachedInjectorsForScreen.theText;
			injectors.dialogTitle = returnDUICachedInjectorsForScreen.theText;
			injectors.dialogTitleInjectors = returnDUICachedInjectorsForScreen.injectors;
			returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.dialogText, injectors.dialogTextInjectors);
			screen.dialogText = returnDUICachedInjectorsForScreen.theText;
			injectors.dialogText = returnDUICachedInjectorsForScreen.theText;
			injectors.dialogTextInjectors = returnDUICachedInjectorsForScreen.injectors;
			returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.customButton1, injectors.customButton1Injectors);
			screen.customButton1 = returnDUICachedInjectorsForScreen.theText;
			injectors.customButton1 = returnDUICachedInjectorsForScreen.theText;
			injectors.customButton1Injectors = returnDUICachedInjectorsForScreen.injectors;
			returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.customButton2, injectors.customButton2Injectors);
			screen.customButton2 = returnDUICachedInjectorsForScreen.theText;
			injectors.customButton2 = returnDUICachedInjectorsForScreen.theText;
			injectors.customButton2Injectors = returnDUICachedInjectorsForScreen.injectors;
			if (screen.multipleButtons != null && screen.multipleButtons.Length != 0)
			{
				injectors.multipleButtonInjectors = new DUICachedInjectorsForScreenMultipleButton[screen.multipleButtons.Length];
				injectors.multipleButtons = new string[screen.multipleButtons.Length];
				for (int i = 0; i < injectors.multipleButtonInjectors.Length; i++)
				{
					injectors.multipleButtonInjectors[i] = new DUICachedInjectorsForScreenMultipleButton();
					returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.multipleButtons[i], injectors.multipleButtonInjectors[i].injectors);
					screen.multipleButtons[i] = returnDUICachedInjectorsForScreen.theText;
					injectors.multipleButtons[i] = returnDUICachedInjectorsForScreen.theText;
					injectors.multipleButtonInjectors[i].injectors = returnDUICachedInjectorsForScreen.injectors;
				}
			}
			if (screen.IG_buttons == null || screen.IG_buttons.Length == 0)
			{
				return;
			}
			injectors.iconGridInjectors = new DUICachedInjectorsForScreenIconGrids[screen.IG_buttons.Length];
			injectors.iconGridTitles = new string[screen.IG_buttons.Length];
			injectors.iconGridLabels = new string[screen.IG_buttons.Length];
			injectors.iconGridFailedLabels = new string[screen.IG_buttons.Length];
			for (int j = 0; j < injectors.iconGridInjectors.Length; j++)
			{
				if (screen.IG_buttons[j] != null)
				{
					if (injectors.iconGridInjectors[j] == null)
					{
						injectors.iconGridInjectors[j] = new DUICachedInjectorsForScreenIconGrids();
					}
					returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.IG_buttons[j].title, injectors.iconGridInjectors[j].title);
					screen.IG_buttons[j].title = returnDUICachedInjectorsForScreen.theText;
					injectors.iconGridTitles[j] = returnDUICachedInjectorsForScreen.theText;
					injectors.iconGridInjectors[j].title = returnDUICachedInjectorsForScreen.injectors;
					returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.IG_buttons[j].label, injectors.iconGridInjectors[j].label);
					screen.IG_buttons[j].label = returnDUICachedInjectorsForScreen.theText;
					injectors.iconGridLabels[j] = returnDUICachedInjectorsForScreen.theText;
					injectors.iconGridInjectors[j].label = returnDUICachedInjectorsForScreen.injectors;
					returnDUICachedInjectorsForScreen = DialogUI.CalculateStyleInjectors(screen.IG_buttons[j].failedLabel, injectors.iconGridInjectors[j].failedLabel);
					screen.IG_buttons[j].failedLabel = returnDUICachedInjectorsForScreen.theText;
					injectors.iconGridFailedLabels[j] = returnDUICachedInjectorsForScreen.theText;
					injectors.iconGridInjectors[j].failedLabel = returnDUICachedInjectorsForScreen.injectors;
				}
			}
		}
	}
}
