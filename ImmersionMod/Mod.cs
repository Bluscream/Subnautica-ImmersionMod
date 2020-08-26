using System;
using System.IO;
using System.Reflection;
using Harmony;
using ImmersionMod.Config;

namespace ImmersionMod
{
	// Token: 0x02000025 RID: 37
	internal static class Mod
	{
		// Token: 0x06000116 RID: 278 RVA: 0x00004A4F File Offset: 0x00002C4F
		public static void Patch(string aModDir)
		{
			Mod._modDir = aModDir;
			HarmonyInstance harmonyInstance = HarmonyInstance.Create("com.chisnexus.subnautica.hudimmersion.mod");
			Mod.ReloadConfig();
			harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00004A70 File Offset: 0x00002C70
		public static void ReloadConfig()
		{
			Mod.config = new Config();
			Mod.config.LoadConfig(Mod.GetConfigPath());
			VROptions.disableInputPitch = !Mod.config.options.unlockY;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004AA2 File Offset: 0x00002CA2
		public static string GetModPath()
		{
			return Path.Combine(Environment.CurrentDirectory, Mod._modDir);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00004AB3 File Offset: 0x00002CB3
		public static string GetAssetsPath()
		{
			return Path.Combine(Mod.GetModPath(), "Assets");
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004AC4 File Offset: 0x00002CC4
		public static string GetConfigPath()
		{
			return Path.Combine(Mod.GetAssetsPath(), "config.json");
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00004AD5 File Offset: 0x00002CD5
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00004ADC File Offset: 0x00002CDC
		public static Config config { get; private set; }

		// Token: 0x0400005C RID: 92
		private static string _modDir;
	}
}
