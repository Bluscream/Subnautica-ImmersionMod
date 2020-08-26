using System;
using System.Collections.Generic;
using SimpleJSON;

namespace ImmersionMod.Config
{
	// Token: 0x02000028 RID: 40
	internal class HudMode
	{
		// Token: 0x0600012E RID: 302 RVA: 0x00004E48 File Offset: 0x00003048
		public HudMode(JSONNode aNode, string aName)
		{
			this.name = aName;
			this.hideList = this.GetList(aNode, "Hide", null);
			this.showList = this.GetList(aNode, "Show", null);
			this.exceptList = this.GetList(aNode, "ExceptModes", null);
			this.hideCrosshairs = (aNode.Contains("HideCrosshairs") && aNode["HideCrosshairs"].AsBool);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004EC1 File Offset: 0x000030C1
		public HudMode(string aName, List<string> aShowList = null, List<string> aHideList = null, bool aHideCrosshairs = false)
		{
			this.name = aName;
			this.hideList = aHideList;
			this.showList = aShowList;
			this.exceptList = new List<string>();
			this.hideCrosshairs = aHideCrosshairs;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004EF4 File Offset: 0x000030F4
		private List<string> GetList(JSONNode aNode, string aKey, List<string> aDefault = null)
		{
			List<string> list = new List<string>();
			if (aNode.Contains(aKey))
			{
				list = new List<string>();
				foreach (KeyValuePair<string, JSONNode> keyValuePair in aNode[aKey].AsArray)
				{
					list.Add(keyValuePair.Value);
				}
			}
			else if (aDefault != null)
			{
				list = aDefault;
			}
			return list;
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00004F55 File Offset: 0x00003155
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00004F5D File Offset: 0x0000315D
		public List<string> hideList { get; private set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00004F66 File Offset: 0x00003166
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00004F6E File Offset: 0x0000316E
		public List<string> showList { get; private set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004F77 File Offset: 0x00003177
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00004F7F File Offset: 0x0000317F
		public List<string> exceptList { get; private set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00004F88 File Offset: 0x00003188
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00004F90 File Offset: 0x00003190
		public bool hideCrosshairs { get; private set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00004F99 File Offset: 0x00003199
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00004FA1 File Offset: 0x000031A1
		public string name { get; private set; }
	}
}
