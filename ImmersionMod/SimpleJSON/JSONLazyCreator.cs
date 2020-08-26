using System;
using System.Text;

namespace SimpleJSON
{
	// Token: 0x02000015 RID: 21
	internal class JSONLazyCreator : JSONNode
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000384A File Offset: 0x00001A4A
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.None;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003850 File Offset: 0x00001A50
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003866 File Offset: 0x00001A66
		public JSONLazyCreator(JSONNode aNode)
		{
			this.m_Node = aNode;
			this.m_Key = null;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000387C File Offset: 0x00001A7C
		public JSONLazyCreator(JSONNode aNode, string aKey)
		{
			this.m_Node = aNode;
			this.m_Key = aKey;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003892 File Offset: 0x00001A92
		private void Set(JSONNode aVal)
		{
			if (this.m_Key == null)
			{
				this.m_Node.Add(aVal);
			}
			else
			{
				this.m_Node.Add(this.m_Key, aVal);
			}
			this.m_Node = null;
		}

		// Token: 0x17000045 RID: 69
		public override JSONNode this[int aIndex]
		{
			get
			{
				return new JSONLazyCreator(this);
			}
			set
			{
				JSONArray jsonarray = new JSONArray();
				jsonarray.Add(value);
				this.Set(jsonarray);
			}
		}

		// Token: 0x17000046 RID: 70
		public override JSONNode this[string aKey]
		{
			get
			{
				return new JSONLazyCreator(this, aKey);
			}
			set
			{
				JSONObject jsonobject = new JSONObject();
				jsonobject.Add(aKey, value);
				this.Set(jsonobject);
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00003914 File Offset: 0x00001B14
		public override void Add(JSONNode aItem)
		{
			JSONArray jsonarray = new JSONArray();
			jsonarray.Add(aItem);
			this.Set(jsonarray);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003938 File Offset: 0x00001B38
		public override void Add(string aKey, JSONNode aItem)
		{
			JSONObject jsonobject = new JSONObject();
			jsonobject.Add(aKey, aItem);
			this.Set(jsonobject);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000395A File Offset: 0x00001B5A
		public static bool operator ==(JSONLazyCreator a, object b)
		{
			return b == null || a == b;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003965 File Offset: 0x00001B65
		public static bool operator !=(JSONLazyCreator a, object b)
		{
			return !(a == b);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000395A File Offset: 0x00001B5A
		public override bool Equals(object obj)
		{
			return obj == null || this == obj;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00002063 File Offset: 0x00000263
		public override int GetHashCode()
		{
			return 0;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00003974 File Offset: 0x00001B74
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00003998 File Offset: 0x00001B98
		public override int AsInt
		{
			get
			{
				JSONNumber aVal = new JSONNumber(0.0);
				this.Set(aVal);
				return 0;
			}
			set
			{
				JSONNumber aVal = new JSONNumber((double)value);
				this.Set(aVal);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x000039B4 File Offset: 0x00001BB4
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x000039DC File Offset: 0x00001BDC
		public override float AsFloat
		{
			get
			{
				JSONNumber aVal = new JSONNumber(0.0);
				this.Set(aVal);
				return 0f;
			}
			set
			{
				JSONNumber aVal = new JSONNumber((double)value);
				this.Set(aVal);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x000039F8 File Offset: 0x00001BF8
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00003A24 File Offset: 0x00001C24
		public override double AsDouble
		{
			get
			{
				JSONNumber aVal = new JSONNumber(0.0);
				this.Set(aVal);
				return 0.0;
			}
			set
			{
				JSONNumber aVal = new JSONNumber(value);
				this.Set(aVal);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00003A40 File Offset: 0x00001C40
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00003A5C File Offset: 0x00001C5C
		public override bool AsBool
		{
			get
			{
				JSONBool aVal = new JSONBool(false);
				this.Set(aVal);
				return false;
			}
			set
			{
				JSONBool aVal = new JSONBool(value);
				this.Set(aVal);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00003A78 File Offset: 0x00001C78
		public override JSONArray AsArray
		{
			get
			{
				JSONArray jsonarray = new JSONArray();
				this.Set(jsonarray);
				return jsonarray;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00003A94 File Offset: 0x00001C94
		public override JSONObject AsObject
		{
			get
			{
				JSONObject jsonobject = new JSONObject();
				this.Set(jsonobject);
				return jsonobject;
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000382A File Offset: 0x00001A2A
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append("null");
		}

		// Token: 0x04000037 RID: 55
		private JSONNode m_Node;

		// Token: 0x04000038 RID: 56
		private string m_Key;
	}
}
