using System;
using SimpleJSON;

namespace ImmersionMod.Config
{
	// Token: 0x02000029 RID: 41
	internal class Options
	{
		// Token: 0x0600013B RID: 315 RVA: 0x00004FAC File Offset: 0x000031AC
		public Options(JSONNode aNode)
		{
			this.unlockY = (!aNode.Contains("UnlockY") || aNode["UnlockY"].AsBool);
			this.disableScreenshot = (!aNode.Contains("DisableScreenshot") || aNode["DisableScreenshot"].AsBool);
			this.debugDumpFile = (aNode.Contains("DebugDumpFile") ? aNode["DebugDumpFile"].Value : "");
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00005035 File Offset: 0x00003235
		// (set) Token: 0x0600013D RID: 317 RVA: 0x0000503D File Offset: 0x0000323D
		public bool disableScreenshot { get; private set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00005046 File Offset: 0x00003246
		// (set) Token: 0x0600013F RID: 319 RVA: 0x0000504E File Offset: 0x0000324E
		public bool unlockY { get; private set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00005057 File Offset: 0x00003257
		// (set) Token: 0x06000141 RID: 321 RVA: 0x0000505F File Offset: 0x0000325F
		public string debugDumpFile { get; private set; }
	}
}
