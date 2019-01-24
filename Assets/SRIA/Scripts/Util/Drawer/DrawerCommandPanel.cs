
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;

namespace frame8.ScrollRectItemsAdapter.Util.Drawer
{
	/// <summary>
	/// Versatile context menu drawer that is programmatically configured for each demo scene to contain specific UI controls
	/// </summary>
	public class DrawerCommandPanel : MonoBehaviour
	{
		public static DrawerCommandPanel Instance { get; private set; }

		public event Action<int> ItemCountChangeRequested;
		public event Action<bool> AddItemRequested;
		public event Action<bool> RemoveItemRequested;


		public ButtonWithInputPanel buttonWithInputPrefab;
		public LabelWithInputPanel labelWithInputPrefab;
		public LabelWithToggle labelWithTogglePrefab;
		public LabelWithToggles labelWithTogglesPrefab;
		public LabelWithSliderPanel labelWithSliderPrefab;
		public ButtonsPanel buttonsPrefab;
		public bool skipAutoDraw;


		[NonSerialized] public Text titleText;
		[NonSerialized] public LoadSceneOnClick backButtonBehavior, nextButtonBehavior;
		[NonSerialized] public LabelWithToggles contentGravityPanel;
		[NonSerialized] public ButtonsPanel addRemoveOnePanel;
		[NonSerialized] public ButtonWithInputPanel setCountPanel;
		[NonSerialized] public ScrollToPanel scrollToPanel;
		[NonSerialized] public RectTransform settingsPanel;
		[NonSerialized] public Toggle freezeItemEndEdgeToggle, freezeContentEndEdgeToggle;
		[NonSerialized] public LabelWithInputPanel serverDelaySetting;
		[NonSerialized] public LabelWithToggle simulateLowEndDeviceSetting;
		[NonSerialized] public LabelWithSliderPanel galleryEffectSetting;
		
		//[NonSerialized]
		//public List<ButtonWithInputPanel> buttonWithInput_Panels = new List<ButtonWithInputPanel>();
		//[NonSerialized]
		//public List<LabelWithInputPanel> labelWithInput_Panels = new List<LabelWithInputPanel>();
		//[NonSerialized]
		//public List<LabelWithToggle> labelWithToggle_Panels = new List<LabelWithToggle>();
		//[NonSerialized]
		//public List<LabelWithToggles> labelWithToggles_Panels = new List<LabelWithToggles>();
		//[NonSerialized]
		//public List<ButtonsPanel> buttons_Panels = new List<ButtonsPanel>();

		const int TARGET_FRAMERATE_FOR_SIMULATING_SLOW_DEVICES = 20;

		ScrollRect _ScrollRect;
		ISRIA[] _Adapters;
		float _LastScreenWidth, _LastScreenHeight;


		void Awake()
		{
			Instance = this;

			transform.GetComponentAtPath("SettingsScrollView/SettingsPanel", out settingsPanel);
			transform.GetComponentAtPath("TitlePanel/LabelText", out titleText);
			transform.GetComponentAtPath("NavPanelParent/BackPanel/Button", out backButtonBehavior);
			transform.GetComponentAtPath("NavPanelParent/NextPanel/Button", out nextButtonBehavior);
			settingsPanel.GetComponentAtPath("ScrollToPanel", out scrollToPanel);
			settingsPanel.GetComponentAtPath("SetCountPanel", out setCountPanel);

			SetSceneName();

			var p = transform;
			while (!_ScrollRect && (p = p.parent))
				_ScrollRect = p.GetComponent<ScrollRect>();
		}

		void Start()
		{
			if (!skipAutoDraw)
				Draw(100f); // draw the scrollrect from the left
		}

		void Update()
		{
			if (Screen.width != _LastScreenWidth && Screen.height != _LastScreenHeight)
			{
				if (Screen.width < Screen.height)
					Draw(-100f);

				_LastScreenWidth = Screen.width;
				_LastScreenHeight = Screen.height;
			}

			if (contentGravityPanel)
			{
				bool contentGravityEnabled = false;
				foreach (var adapter in _Adapters)
					if (adapter.ContentVirtualSizeToViewportRatio < 1d)
					{
						contentGravityEnabled = true;
						break;
					}

				contentGravityPanel.Interactable = contentGravityEnabled;
			}
		}

		void OnDestroy()
		{
			if (simulateLowEndDeviceSetting)
				simulateLowEndDeviceSetting.toggle.isOn = false;

			Instance = null;
		}

		public void Init(
			ISRIA adapter,
			bool addGravityCommand = true,
			bool addItemEdgeFreezeCommand = true,
			bool addContentEdgeFreezeCommand = true,
			bool addServerDelaySetting = true,
			bool addOneItemAddRemovePanel = true
		) { Init(new ISRIA[] { adapter }, addGravityCommand, addItemEdgeFreezeCommand, addContentEdgeFreezeCommand, addServerDelaySetting, addOneItemAddRemovePanel); }

		public void Init(
			ISRIA[] adapters, 
			bool addGravityCommand = true, 
			bool addItemEdgeFreezeCommand = true, 
			bool addContentEdgeFreezeCommand = true,
			bool addServerDelaySetting = true,
			bool addOneItemAddRemovePanel = true
		) {
			_Adapters = adapters;

			scrollToPanel.mainSubPanel.button.onClick.AddListener(RequestSmoothScrollToSpecified);
			setCountPanel.button.onClick.AddListener(RequestChangeItemCountToSpecifiedIgnoringServerDelay);

			if (addGravityCommand)
			{
				contentGravityPanel = AddLabelWithTogglesPanel("Gravity when content smaller than viewport", "Start", "Center", "End");
				contentGravityPanel.ToggleChanged += (toggleIdx, isOn) =>
				{
					if (!isOn)
						return;

					DoForAllAdapters((adapter) =>
					{
						if (adapter.Initialized)
						{
							adapter.BaseParameters.contentGravity = (BaseParams.ContentGravity)(toggleIdx + 1);
							adapter.BaseParameters.UpdateContentPivotFromGravityType();
							adapter.SetVirtualAbstractNormalizedScrollPosition(1d, true); // scrollto start
						}
					});
				};
			}

			if (addItemEdgeFreezeCommand)
				freezeItemEndEdgeToggle = AddLabelWithTogglePanel("Freeze item end edge when expanding/collapsing").toggle;
			if (addContentEdgeFreezeCommand)
				freezeContentEndEdgeToggle = AddLabelWithTogglePanel("Freeze content end edge when adding items (ex. for chat)").toggle;

			if (addServerDelaySetting)
			{
				serverDelaySetting = AddLabelWithInputPanel("Server simulated delay:");
				serverDelaySetting.inputField.text = 1 + ""; // 1 second, initially
				serverDelaySetting.inputField.keyboardType = TouchScreenKeyboardType.NumberPad;
				serverDelaySetting.inputField.characterLimit = 1;
			}

			if (addOneItemAddRemovePanel)
			{
				addRemoveOnePanel = AddButtonsPanel("+1 tail", "+1 head", "-1 tail", "-1 head");
				addRemoveOnePanel.transform.SetSiblingIndex(1);
				addRemoveOnePanel.button1.onClick.AddListener(() => { if (AddItemRequested != null) AddItemRequested(true); });
				addRemoveOnePanel.button2.onClick.AddListener(() => { if (AddItemRequested != null) AddItemRequested(false); });
				addRemoveOnePanel.button3.onClick.AddListener(() => { if (RemoveItemRequested != null) RemoveItemRequested(true); });
				addRemoveOnePanel.button4.onClick.AddListener(() => { if (RemoveItemRequested != null) RemoveItemRequested(false); });
			}

			galleryEffectSetting = AddLabelWithSliderPanel("Gallery effect", "None", "Max");
			galleryEffectSetting.slider.onValueChanged.AddListener((v) => DoForAllAdapters((adapter) => adapter.BaseParameters.galleryEffectAmount = v));
			galleryEffectSetting.Set(0f, 1f, .1f);

			// Simulate low end device toggle
			int vSyncCountBefore = QualitySettings.vSyncCount;
			int targetFrameRateBefore = Application.targetFrameRate;
			simulateLowEndDeviceSetting = AddLabelWithTogglePanel("Simulate low-end device");
			simulateLowEndDeviceSetting.transform.SetAsLastSibling();
			simulateLowEndDeviceSetting.toggle.onValueChanged.AddListener(isOn =>
			{
				if (isOn)
				{
					vSyncCountBefore = QualitySettings.vSyncCount;
					targetFrameRateBefore = Application.targetFrameRate;

					QualitySettings.vSyncCount = 0;  // VSync must be disabled for Application.targetFrameRate to work
					Application.targetFrameRate = TARGET_FRAMERATE_FOR_SIMULATING_SLOW_DEVICES;
				}
				else
				{
					if (QualitySettings.vSyncCount == 0) // if it wasn't modified since the last time we modified it (i.e. if it was modified externally, don't override that value)
						QualitySettings.vSyncCount = vSyncCountBefore;

					if (Application.targetFrameRate == TARGET_FRAMERATE_FOR_SIMULATING_SLOW_DEVICES) // item comment as above
						Application.targetFrameRate = targetFrameRateBefore;
				}
			});
		}

		public ButtonWithInputPanel AddButtonWithInputPanel(string label = "")
		{
			var go = Instantiate(buttonWithInputPrefab.gameObject) as GameObject;
			go.transform.SetParent(settingsPanel, false);
			var comp = go.GetComponent<ButtonWithInputPanel>();
			//buttonWithInput_Panels.Add(comp);
			comp.button.transform.GetComponentAtPath<Text>("Text").text = label;

			return comp;
		}

		public LabelWithInputPanel AddLabelWithInputPanel(string label = "")
		{
			var go = Instantiate(labelWithInputPrefab.gameObject) as GameObject;
			go.transform.SetParent(settingsPanel, false);
			var comp = go.GetComponent<LabelWithInputPanel>();
			//labelWithInput_Panels.Add(comp);
			comp.labelText.text = label;

			return comp;
		}

		public ButtonsPanel AddButtonsPanel(string label1 = "", string label2 = "", string label3 = "", string label4 = "")
		{
			var go = Instantiate(buttonsPrefab.gameObject) as GameObject;
			go.transform.SetParent(settingsPanel, false);
			var comp = go.GetComponent<ButtonsPanel>();
			//buttons_Panels.Add(comp);
			comp.Init(label1, label2, label3, label4);

			return comp;
		}

		public LabelWithToggle AddLabelWithTogglePanel(string label = "")
		{
			var go = Instantiate(labelWithTogglePrefab.gameObject) as GameObject;
			go.transform.SetParent(settingsPanel, false);
			var comp = go.GetComponent<LabelWithToggle>();
			//labelWithToggle_Panels.Add(comp);
			comp.Init(label);

			return comp;
		}

		public LabelWithToggles AddLabelWithTogglesPanel(string mainLabel, params string[] subItemLabels)
		{
			var go = Instantiate(labelWithTogglesPrefab.gameObject) as GameObject;
			go.transform.SetParent(settingsPanel, false);
			var comp = go.GetComponent<LabelWithToggles>();
			//labelWithToggles_Panels.Add(comp);
			comp.Init(mainLabel, subItemLabels);

			return comp;
		}

		public LabelWithSliderPanel AddLabelWithSliderPanel(string label = "", string minLabel = "", string maxLabel = "")
		{
			var go = Instantiate(labelWithSliderPrefab.gameObject) as GameObject;
			go.transform.SetParent(settingsPanel, false);
			var comp = go.GetComponent<LabelWithSliderPanel>();
			//buttons_Panels.Add(comp);
			comp.Init(label, minLabel, maxLabel);

			return comp;
		}

		#region UI events
		/// <summary>Callback from UI Button. Parses the text in <see cref="_CountText"/> as an int and sets it as the new item count, refreshing all the views. It mocks a basic server communication where you request x items and you receive them after a few seconds</summary>
		public void RequestChangeItemCountToSpecified()
		{
			int newCount = setCountPanel.InputFieldValueAsInt;
			if (ItemCountChangeRequested != null)
				ItemCountChangeRequested(newCount);
		}
		public void RequestChangeItemCountToSpecifiedIgnoringServerDelay()
		{
			var ignoreServerDelaySetting = serverDelaySetting != null;
			string textBefore = ignoreServerDelaySetting ? serverDelaySetting.inputField.text : null;
			if (ignoreServerDelaySetting)
				serverDelaySetting.inputField.text = "0";

			RequestChangeItemCountToSpecified();

			if (ignoreServerDelaySetting)
				serverDelaySetting.inputField.text = textBefore;
		}

		public void RequestSmoothScrollToSpecified() { RequestSmoothScrollTo(scrollToPanel.mainSubPanel.InputFieldValueAsInt, null); }
		#endregion

		public void RequestSmoothScrollTo(int index, Action onDone)
		{
			if (index < 0 || index + 1 > _Adapters[0].GetItemsCount())
				return;

			int numDone = 0;

			float dur = scrollToPanel.durationAdvPanel.InputFieldValueAsFloat;
			dur = Mathf.Clamp(dur, .01f, 9f);
			//if (_AdaptersParamsArray[0].loopItems && dur < .1f)
			//{
			//	dur = .1f;
			//	scrollToPanel.durationAdvPanel.inputField.text = dur + "";
			//}

			//scrollToPanel.mainSubPanel.button.interactable = false;
			DoForAllAdapters((adapter) =>
			{
				//if (adapterParams.data == null || adapterParams.data.Count > 10)
				//bool started = 
				adapter.SmoothScrollTo(
					index,
					dur,
					Mathf.Clamp01(scrollToPanel.gravityAdvPanel.InputFieldValueAsFloat),
					Mathf.Clamp01(scrollToPanel.itemPivotAdvPanel.InputFieldValueAsFloat),
					progress => 
					{
						scrollToPanel.durationAdvPanel.inputField.text = (dur * progress).ToString("#0.##"); // show the scroll progress

						if (progress == 1f 
							 && ++numDone == _Adapters.Length) // only do it when the last one has finished
						{
							//scrollToPanel.mainSubPanel.button.interactable = true;
							if (onDone != null)
								onDone();
						}
						return true;
					},
					true
				);

				//if (!started)
				//	scrollToPanel.mainSubPanel.button.interactable = true;
			});
		}

		public void DoForAllAdapters(Action<ISRIA> action)
		{
			for (int i = 0; i < _Adapters.Length; i++)
				action(_Adapters[i]);
		}

		void Draw(float horSpeed)
		{
			PointerEventData ped = new PointerEventData(EventSystem.current);
			ped.scrollDelta = new Vector2(horSpeed, 0f);
			_ScrollRect.OnScroll(ped);
			_ScrollRect.velocity = ped.scrollDelta * 7;
		}

		void SetSceneName()
		{
			string sceneFriendlyName;
#if UNITY_5_3_OR_NEWER
			sceneFriendlyName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
#else
			sceneFriendlyName = Application.loadedLevelName;
#endif
			sceneFriendlyName = sceneFriendlyName.Replace("_", " ");

			// Hardcoding the main scene's name, because "example" is not that descriptive, adn changing the scene would break the scene indices for those that update from a previous package
			if (sceneFriendlyName == "example")
				sceneFriendlyName = "main demo";
			else
				sceneFriendlyName = sceneFriendlyName.Replace("example", "");

			sceneFriendlyName = char.ToUpper(sceneFriendlyName[0]) + sceneFriendlyName.Substring(1);
			titleText.text = sceneFriendlyName;
		}
	}
}
