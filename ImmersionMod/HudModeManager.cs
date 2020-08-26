using System;
using System.Collections.Generic;
using ImmersionMod.Config;
using UnityEngine;

namespace ImmersionMod
{
	// Token: 0x0200001B RID: 27
	internal class HudModeManager
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x00003E34 File Offset: 0x00002034
		public void Init()
		{
			if (this._initialized)
			{
				return;
			}
			Transform transform = uGUI.main.hud.transform.Find("Content");
			this._screenCanvas = transform.parent;
			while (null != this._screenCanvas && !(this._screenCanvas.name == "ScreenCanvas"))
			{
				this._screenCanvas = this._screenCanvas.parent;
			}
			this._elementDict = new Dictionary<string, Component>();
			foreach (Component component in this._screenCanvas.GetComponentsInChildren<Component>(true))
			{
				if (!this._elementDict.ContainsKey(component.name))
				{
					this._elementDict.Add(component.name, component);
				}
			}
			this._layerStack = new LayerStack();
			this._curModeIdx = 0;
			HudMode aMode;
			if (Mod.config.GetMode(this._curModeIdx, out aMode))
			{
				LayerInfo aLayer = LayerInfo.CreateFromHudMode(this, aMode);
				this._layerStack.AddLayer("base", aLayer);
			}
			this._initialized = true;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00003F44 File Offset: 0x00002144
		public void NextMode()
		{
			this.SetMode(this._curModeIdx + 1);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00003F54 File Offset: 0x00002154
		public void PrevMode()
		{
			this.SetMode(this._curModeIdx - 1);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00003F64 File Offset: 0x00002164
		public void SetMode(int aNewMode)
		{
			if (aNewMode < 0)
			{
				aNewMode = Mod.config.modeList.Count - 1;
			}
			else if (aNewMode >= Mod.config.modeList.Count)
			{
				aNewMode = 0;
			}
			HudMode hudMode;
			if (Mod.config.GetMode(aNewMode, out hudMode))
			{
				LayerInfo aLayer = LayerInfo.CreateFromHudMode(this, hudMode);
				this._layerStack.ReplaceLayer("base", aLayer);
				ErrorMessage.AddMessage("HUD Mode: " + hudMode.name);
				this._curModeIdx = aNewMode;
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00003FE4 File Offset: 0x000021E4
		public bool GetModeIdxByName(string aModeName, out int aIdx)
		{
			List<string> modeList = Mod.config.modeList;
			for (aIdx = 0; aIdx < modeList.Count; aIdx++)
			{
				if (modeList[aIdx] == aModeName)
				{
					return true;
				}
			}
			aIdx = -1;
			return false;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004028 File Offset: 0x00002228
		public void AddOverlayGroup(string aId, List<string> aHideGroups, List<string> aShowGroups, bool aHideCrosshairs)
		{
			List<Component> groupComponentsList = this.GetGroupComponentsList(aHideGroups);
			List<Component> groupComponentsList2 = this.GetGroupComponentsList(aShowGroups);
			this._layerStack.AddLayer(aId, new LayerInfo(this, groupComponentsList, groupComponentsList2, aHideCrosshairs));
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000405C File Offset: 0x0000225C
		public void RemoveOverlayGroup(string aId)
		{
			this._layerStack.RemoveLayer(aId);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000406C File Offset: 0x0000226C
		public List<Component> GetGroupComponentsList(List<string> aGroupsList)
		{
			List<Component> list = new List<Component>();
			List<string> list2;
			if (Mod.config.GetGroupsElements(aGroupsList, out list2))
			{
				foreach (string key in list2)
				{
					Component item;
					if (this._elementDict.TryGetValue(key, out item))
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000FA RID: 250 RVA: 0x000040E4 File Offset: 0x000022E4
		public int curModeIdx
		{
			get
			{
				return this._curModeIdx;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000FB RID: 251 RVA: 0x000040EC File Offset: 0x000022EC
		public Transform screenCanvas
		{
			get
			{
				return this._screenCanvas;
			}
		}

		// Token: 0x04000043 RID: 67
		public Dictionary<Component, CompInfo> _origValues = new Dictionary<Component, CompInfo>();

		// Token: 0x04000044 RID: 68
		private int _curModeIdx;

		// Token: 0x04000045 RID: 69
		private bool _initialized;

		// Token: 0x04000046 RID: 70
		private Dictionary<string, Component> _elementDict;

		// Token: 0x04000047 RID: 71
		private Transform _screenCanvas;

		// Token: 0x04000048 RID: 72
		private LayerStack _layerStack;
	}
}
