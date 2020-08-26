using System;
using System.Collections.Generic;
using ImmersionMod.Config;
using UnityEngine;

namespace ImmersionMod
{
	// Token: 0x0200001D RID: 29
	internal class LayerInfo
	{
		// Token: 0x060000FF RID: 255 RVA: 0x0000415C File Offset: 0x0000235C
		public LayerInfo(HudModeManager aHudManager, List<Component> aHideList, List<Component> aShowList, bool aHideCrosshairs)
		{
			LayerInfo.<>c__DisplayClass2_0 CS$<>8__locals1 = new LayerInfo.<>c__DisplayClass2_0();
			CS$<>8__locals1.aHideList = aHideList;
			CS$<>8__locals1.aHudManager = aHudManager;
			CS$<>8__locals1.aShowList = aShowList;
			CS$<>8__locals1.aHideCrosshairs = aHideCrosshairs;
			base..ctor();
			Dictionary<Component, CompInfo> origValues = new Dictionary<Component, CompInfo>();
			this._applyAction = delegate()
			{
				foreach (Component component in CS$<>8__locals1.aHideList)
				{
					if (!origValues.ContainsKey(component))
					{
						origValues[component] = new CompInfo(component);
					}
					if (!CS$<>8__locals1.aHudManager._origValues.ContainsKey(component))
					{
						CS$<>8__locals1.aHudManager._origValues[component] = new CompInfo(component);
					}
					component.transform.localScale = Vector3.zero;
				}
				foreach (Component component2 in CS$<>8__locals1.aShowList)
				{
					if (!origValues.ContainsKey(component2))
					{
						origValues[component2] = new CompInfo(component2);
					}
					CompInfo compInfo;
					if (CS$<>8__locals1.aHudManager._origValues.TryGetValue(component2, out compInfo))
					{
						compInfo.Restore();
					}
				}
				if (CS$<>8__locals1.aHideCrosshairs)
				{
					HandReticle.main.RequestCrosshairHide();
				}
			};
			this._undoAction = delegate()
			{
				foreach (KeyValuePair<Component, CompInfo> keyValuePair in origValues)
				{
					keyValuePair.Value.Restore();
				}
				origValues.Clear();
				if (CS$<>8__locals1.aHideCrosshairs)
				{
					HandReticle.main.UnrequestCrosshairHide();
				}
			};
		}

		// Token: 0x06000100 RID: 256 RVA: 0x000041D0 File Offset: 0x000023D0
		public static LayerInfo CreateFromHudMode(HudModeManager aHudManager, HudMode aMode)
		{
			List<Component> groupComponentsList = aHudManager.GetGroupComponentsList(aMode.hideList);
			List<Component> groupComponentsList2 = aHudManager.GetGroupComponentsList(aMode.showList);
			bool hideCrosshairs = aMode.hideCrosshairs;
			return new LayerInfo(aHudManager, groupComponentsList, groupComponentsList2, hideCrosshairs);
		}

		// Token: 0x0400004B RID: 75
		public Action _applyAction;

		// Token: 0x0400004C RID: 76
		public Action _undoAction;
	}
}
