using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

namespace ImmersionMod
{
	// Token: 0x02000017 RID: 23
	internal class ControlInput
	{
		// Token: 0x060000EA RID: 234 RVA: 0x00003AB8 File Offset: 0x00001CB8
		public ControlInput(JSONNode aNode)
		{
			this._keyActionList = new List<ControlInput.KeyAction>();
			foreach (KeyValuePair<string, JSONNode> keyValuePair in aNode)
			{
				this._keyActionList.Add(new ControlInput.KeyAction(keyValuePair.Value.Value.ToLower(), this.StringToKeyList(keyValuePair.Key)));
			}
			this._keyActionList.Sort((ControlInput.KeyAction a, ControlInput.KeyAction b) => a.keycodeList.Count.CompareTo(b.keycodeList.Count));
			this._keyActionList.Reverse();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003C00 File Offset: 0x00001E00
		public bool CheckInput(out ControlInput.ActionInfo aAction)
		{
			aAction = null;
			foreach (ControlInput.KeyAction keyAction in this._keyActionList)
			{
				bool flag = keyAction.keycodeList.Count > 0;
				using (List<KeyCode>.Enumerator enumerator2 = keyAction.keycodeList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (!Input.GetKey(enumerator2.Current))
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					string action = keyAction.action;
					ControlInput.ActionInfo prevAction = this._prevAction;
					aAction = new ControlInput.ActionInfo(action, ((prevAction != null) ? prevAction.action : null) == keyAction.action, false);
					break;
				}
			}
			if (this._prevAction != null && !this._prevAction.released && (aAction == null || !aAction.held))
			{
				aAction = this._prevAction;
				aAction.held = false;
				aAction.released = true;
			}
			this._prevAction = aAction;
			return aAction != null;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00003D20 File Offset: 0x00001F20
		private List<KeyCode> StringToKeyList(string aKeyString)
		{
			List<KeyCode> list = new List<KeyCode>();
			string[] array = aKeyString.Split(new char[]
			{
				'+'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim().ToLower();
				bool flag = false;
				KeyCode item;
				if (this._keycode_map.TryGetValue(text, out item))
				{
					list.Add(item);
					flag = true;
				}
				else
				{
					try
					{
						list.Add((KeyCode)Enum.Parse(typeof(KeyCode), text, true));
						flag = true;
					}
					catch (Exception)
					{
					}
				}
				if (!flag)
				{
					ErrorMessage.AddMessage(string.Format("Bad key config [{0}]. Unknown symbol [{1}]", aKeyString, text));
				}
			}
			return list;
		}

		// Token: 0x04000039 RID: 57
		private List<ControlInput.KeyAction> _keyActionList;

		// Token: 0x0400003A RID: 58
		private ControlInput.ActionInfo _prevAction;

		// Token: 0x0400003B RID: 59
		private Dictionary<string, KeyCode> _keycode_map = new Dictionary<string, KeyCode>
		{
			{
				"joy_a",
				350
			},
			{
				"joy_b",
				351
			},
			{
				"joy_x",
				352
			},
			{
				"joy_y",
				353
			},
			{
				"joy_lb",
				354
			},
			{
				"joy_rb",
				355
			},
			{
				"joy_back",
				356
			},
			{
				"joy_start",
				357
			},
			{
				"joy_ls",
				358
			},
			{
				"joy_rs",
				359
			}
		};

		// Token: 0x02000018 RID: 24
		public class ActionInfo
		{
			// Token: 0x060000ED RID: 237 RVA: 0x00003DCC File Offset: 0x00001FCC
			public ActionInfo(string aAction, bool aHeld, bool aReleased)
			{
				this.action = aAction;
				this.held = aHeld;
				this.released = aReleased;
			}

			// Token: 0x0400003C RID: 60
			public string action;

			// Token: 0x0400003D RID: 61
			public bool held;

			// Token: 0x0400003E RID: 62
			public bool released;
		}

		// Token: 0x02000019 RID: 25
		private struct KeyAction
		{
			// Token: 0x060000EE RID: 238 RVA: 0x00003DE9 File Offset: 0x00001FE9
			public KeyAction(string aAction, List<KeyCode> aKeycodeList)
			{
				this.action = aAction;
				this.keycodeList = aKeycodeList;
			}

			// Token: 0x0400003F RID: 63
			public string action;

			// Token: 0x04000040 RID: 64
			public List<KeyCode> keycodeList;
		}
	}
}
