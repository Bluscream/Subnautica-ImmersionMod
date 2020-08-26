using System;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;

namespace ImmersionMod.Config
{
	// Token: 0x02000027 RID: 39
	internal class Config
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00004AF0 File Offset: 0x00002CF0
		public void LoadConfig(string aPath)
		{
			string aJSON = File.ReadAllText(aPath);
			this._json = JSON.Parse(aJSON);
			JSONNode aNode = this._json["Options"];
			this.options = new Options(aNode);
			JSONNode aNode2 = this._json["Controls"];
			this.controls = new ControlInput(aNode2);
			JSONNode aNode3 = this._json["LowWarningThresholds"];
			this.warningLevels = new WarningLevels(aNode3);
			JSONNode jsonnode = this._json["Hud"];
			this.quickPeekGroup = jsonnode["quickPeekGroup"];
			this._hudGroups = new Dictionary<string, List<string>>();
			foreach (KeyValuePair<string, JSONNode> keyValuePair in jsonnode["Groups"])
			{
				if (keyValuePair.Value.IsArray)
				{
					List<string> list = new List<string>();
					string key = keyValuePair.Key;
					foreach (KeyValuePair<string, JSONNode> aKeyValue in keyValuePair.Value)
					{
						JSONNode jsonnode2 = aKeyValue;
						if (jsonnode2.IsString)
						{
							list.Add(jsonnode2.Value);
						}
					}
					this._hudGroups[key.ToLower()] = list;
				}
			}
			this._hudModes = new Dictionary<string, HudMode>();
			this._hudModeList = new List<string>();
			foreach (KeyValuePair<string, JSONNode> keyValuePair2 in jsonnode["HudModes"])
			{
				if (keyValuePair2.Value.IsObject)
				{
					HudMode value = new HudMode(keyValuePair2.Value, keyValuePair2.Key);
					this._hudModes[keyValuePair2.Key] = value;
					this._hudModeList.Add(keyValuePair2.Key);
				}
			}
			this._motorModes = new Dictionary<string, HudMode>();
			foreach (KeyValuePair<string, JSONNode> keyValuePair3 in jsonnode["MotorModeOverlays"])
			{
				if (keyValuePair3.Value.IsObject)
				{
					HudMode value2 = new HudMode(keyValuePair3.Value, keyValuePair3.Key);
					this._motorModes[keyValuePair3.Key.ToLower()] = value2;
				}
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004D29 File Offset: 0x00002F29
		public bool GetMode(string aName, out HudMode aMode)
		{
			return this._hudModes.TryGetValue(aName, out aMode);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004D38 File Offset: 0x00002F38
		public bool GetMode(int idx, out HudMode aMode)
		{
			if (idx >= this._hudModeList.Count)
			{
				aMode = null;
				return false;
			}
			return this.GetMode(this._hudModeList[idx], out aMode);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00004D60 File Offset: 0x00002F60
		public bool getMotorMode(Player.MotorMode aMode, out HudMode aHudMode)
		{
			return this._motorModes.TryGetValue(aMode.ToString().ToLower(), out aHudMode);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00004D80 File Offset: 0x00002F80
		public bool GetGroupsElements(List<string> aGroupNames, out List<string> aElements)
		{
			bool result = false;
			aElements = new List<string>();
			foreach (string aGroupName in aGroupNames)
			{
				List<string> collection;
				if (this.GetGroupElements(aGroupName, out collection))
				{
					aElements.AddRange(collection);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004DE8 File Offset: 0x00002FE8
		public bool GetGroupElements(string aGroupName, out List<string> aElements)
		{
			return this._hudGroups.TryGetValue(aGroupName.ToLower(), out aElements);
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004DFC File Offset: 0x00002FFC
		public List<string> modeList
		{
			get
			{
				return this._hudModeList;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00004E04 File Offset: 0x00003004
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00004E0C File Offset: 0x0000300C
		public ControlInput controls { get; private set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00004E15 File Offset: 0x00003015
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00004E1D File Offset: 0x0000301D
		public Options options { get; private set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00004E26 File Offset: 0x00003026
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00004E2E File Offset: 0x0000302E
		public string quickPeekGroup { get; private set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00004E37 File Offset: 0x00003037
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00004E3F File Offset: 0x0000303F
		public WarningLevels warningLevels { get; private set; }

		// Token: 0x0400005D RID: 93
		private JSONNode _json;

		// Token: 0x0400005E RID: 94
		private List<string> _hudModeList;

		// Token: 0x0400005F RID: 95
		private Dictionary<string, HudMode> _hudModes;

		// Token: 0x04000060 RID: 96
		private Dictionary<string, HudMode> _motorModes;

		// Token: 0x04000061 RID: 97
		private Dictionary<string, List<string>> _hudGroups;
	}
}
