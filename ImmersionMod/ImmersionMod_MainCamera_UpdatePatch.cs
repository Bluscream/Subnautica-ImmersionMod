using System;
using System.Collections.Generic;
using System.IO;
using Harmony;
using ImmersionMod.Config;
using UnityEngine;
using UnityEngine.VR;

namespace ImmersionMod
{
	// Token: 0x02000023 RID: 35
	[HarmonyPatch(typeof(MainCameraControl))]
	[HarmonyPatch("Update")]
	internal class ImmersionMod_MainCamera_UpdatePatch
	{
		// Token: 0x06000110 RID: 272 RVA: 0x000045C8 File Offset: 0x000027C8
		[HarmonyPrefix]
		public static bool Update(ref MainCameraControl __instance)
		{
			try
			{
				if (!ImmersionMod_MainCamera_UpdatePatch.Init())
				{
					return true;
				}
				if (Mod.config.options.unlockY && VRSettings.enabled)
				{
					__instance.rotationY = Mathf.Clamp(__instance.rotationY, -50f, 60f);
				}
				if (!ImmersionMod_MainCamera_UpdatePatch._showingWarning && Mod.config.warningLevels.HasWarning())
				{
					ImmersionMod_MainCamera_UpdatePatch._hudManager.AddOverlayGroup("warnings", new List<string>(), new List<string>
					{
						Mod.config.warningLevels.warningGroup
					}, false);
					ImmersionMod_MainCamera_UpdatePatch._showingWarning = true;
				}
				if (ImmersionMod_MainCamera_UpdatePatch._curMotorMode != Player.main.motorMode)
				{
					ImmersionMod_MainCamera_UpdatePatch._hudManager.RemoveOverlayGroup("motormode");
					ImmersionMod_MainCamera_UpdatePatch._curMotorMode = Player.main.motorMode;
					HudMode hudMode;
					HudMode hudMode2;
					if (Mod.config.getMotorMode(ImmersionMod_MainCamera_UpdatePatch._curMotorMode, out hudMode) && Mod.config.GetMode(ImmersionMod_MainCamera_UpdatePatch._hudManager.curModeIdx, out hudMode2) && !hudMode.exceptList.Contains(hudMode2.name))
					{
						ImmersionMod_MainCamera_UpdatePatch._hudManager.AddOverlayGroup("motormode", hudMode.hideList, hudMode.showList, hudMode.hideCrosshairs);
					}
				}
				ControlInput.ActionInfo actionInfo;
				if (Mod.config.controls.CheckInput(out actionInfo) && !actionInfo.held)
				{
					if (actionInfo.released)
					{
						if (actionInfo.action == "quickpeek")
						{
							ImmersionMod_MainCamera_UpdatePatch._hudManager.RemoveOverlayGroup("quickpeek");
						}
						else if (actionInfo.action == "reloadconfig")
						{
							ErrorMessage.AddMessage("Reloading config");
							ImmersionMod_MainCamera_UpdatePatch._hudManager.SetMode(0);
							Mod.ReloadConfig();
						}
					}
					else if (actionInfo.action == "quickpeek")
					{
						ImmersionMod_MainCamera_UpdatePatch._hudManager.AddOverlayGroup("quickpeek", new List<string>(), new List<string>
						{
							Mod.config.quickPeekGroup
						}, false);
						Mod.config.warningLevels.DismissWarnings();
						if (ImmersionMod_MainCamera_UpdatePatch._showingWarning)
						{
							ImmersionMod_MainCamera_UpdatePatch._hudManager.RemoveOverlayGroup("warnings");
							ImmersionMod_MainCamera_UpdatePatch._showingWarning = false;
						}
					}
					else if (actionInfo.action == "nextmode")
					{
						ImmersionMod_MainCamera_UpdatePatch._hudManager.NextMode();
						ImmersionMod_MainCamera_UpdatePatch._curMotorMode = 0;
					}
					else if (actionInfo.action == "prevmode")
					{
						ImmersionMod_MainCamera_UpdatePatch._hudManager.PrevMode();
						ImmersionMod_MainCamera_UpdatePatch._curMotorMode = 0;
					}
					else if (actionInfo.action == "debugdump")
					{
						ImmersionMod_MainCamera_UpdatePatch.Utils.DebugDump();
					}
					else if (actionInfo.action == "muteengine")
					{
						SeaMoth seaMoth = Player.main.GetVehicle() as SeaMoth;
						if (null != seaMoth)
						{
							seaMoth.engineSound.enabled = !seaMoth.engineSound.enabled;
						}
					}
					else if (actionInfo.action == "recentervr")
					{
						InputTracking.Recenter();
					}
				}
			}
			catch (Exception ex)
			{
				ErrorMessage.AddMessage("Exception: " + ex.ToString());
			}
			return true;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000048E8 File Offset: 0x00002AE8
		private static bool Init()
		{
			if (ImmersionMod_MainCamera_UpdatePatch._initialized)
			{
				return true;
			}
			Mod.ReloadConfig();
			ErrorMessage.AddMessage("Initializing ImmersionMod");
			VROptions.disableInputPitch = !Mod.config.options.unlockY;
			ImmersionMod_MainCamera_UpdatePatch._hudManager.Init();
			Mod.config.warningLevels.DismissWarnings();
			ImmersionMod_MainCamera_UpdatePatch._curMotorMode = Player.main.motorMode;
			ErrorMessage.AddMessage("Done!");
			ImmersionMod_MainCamera_UpdatePatch._initialized = true;
			return true;
		}

		// Token: 0x04000057 RID: 87
		private static bool _initialized = false;

		// Token: 0x04000058 RID: 88
		private static bool _showingWarning = false;

		// Token: 0x04000059 RID: 89
		private static Player.MotorMode _curMotorMode;

		// Token: 0x0400005A RID: 90
		private static HudModeManager _hudManager = new HudModeManager();

		// Token: 0x02000024 RID: 36
		private static class Utils
		{
			// Token: 0x06000114 RID: 276 RVA: 0x00004978 File Offset: 0x00002B78
			public static void DebugDump()
			{
				string debugDumpFile = Mod.config.options.debugDumpFile;
				if (string.IsNullOrEmpty(debugDumpFile))
				{
					return;
				}
				ErrorMessage.AddMessage("Dumping components to " + debugDumpFile);
				StreamWriter streamWriter = File.CreateText(debugDumpFile);
				if (null != ImmersionMod_MainCamera_UpdatePatch._hudManager.screenCanvas)
				{
					foreach (Component component in ImmersionMod_MainCamera_UpdatePatch._hudManager.screenCanvas.GetComponentsInChildren<Component>(true))
					{
						streamWriter.WriteLine(ImmersionMod_MainCamera_UpdatePatch.Utils.GetParentDump(component.transform));
					}
				}
				streamWriter.Close();
				ErrorMessage.AddMessage("Done");
			}

			// Token: 0x06000115 RID: 277 RVA: 0x00004A10 File Offset: 0x00002C10
			private static string GetParentDump(Transform aTrans)
			{
				string text = "";
				Transform transform = aTrans;
				while (null != transform)
				{
					text = string.Format("{0} -> {1}", transform.name.ToString(), text);
					transform = transform.parent;
				}
				return text;
			}
		}
	}
}
