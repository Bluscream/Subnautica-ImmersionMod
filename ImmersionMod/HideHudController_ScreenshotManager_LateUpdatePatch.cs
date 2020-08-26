using System;
using Harmony;

namespace ImmersionMod
{
	// Token: 0x02000022 RID: 34
	[HarmonyPatch(typeof(ScreenshotManager))]
	[HarmonyPatch("LateUpdate")]
	internal class HideHudController_ScreenshotManager_LateUpdatePatch
	{
		// Token: 0x0600010E RID: 270 RVA: 0x000045B2 File Offset: 0x000027B2
		[HarmonyPrefix]
		public static bool LateUpdate()
		{
			return !Mod.config.options.disableScreenshot;
		}
	}
}
