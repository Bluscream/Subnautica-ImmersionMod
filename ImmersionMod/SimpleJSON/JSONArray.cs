using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleJSON
{
	// Token: 0x0200000C RID: 12
	public class JSONArray : JSONNode
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002CC8 File Offset: 0x00000EC8
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002CD0 File Offset: 0x00000ED0
		public override bool Inline
		{
			get
			{
				return this.inline;
			}
			set
			{
				this.inline = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.Array;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public override bool IsArray
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002CDC File Offset: 0x00000EDC
		public override JSONNode.Enumerator GetEnumerator()
		{
			return new JSONNode.Enumerator(this.m_List.GetEnumerator());
		}

		// Token: 0x17000026 RID: 38
		public override JSONNode this[int aIndex]
		{
			get
			{
				if (aIndex < 0 || aIndex >= this.m_List.Count)
				{
					return new JSONLazyCreator(this);
				}
				return this.m_List[aIndex];
			}
			set
			{
				if (value == null)
				{
					value = JSONNull.CreateOrGet();
				}
				if (aIndex < 0 || aIndex >= this.m_List.Count)
				{
					this.m_List.Add(value);
					return;
				}
				this.m_List[aIndex] = value;
			}
		}

		// Token: 0x17000027 RID: 39
		public override JSONNode this[string aKey]
		{
			get
			{
				return new JSONLazyCreator(this);
			}
			set
			{
				if (value == null)
				{
					value = JSONNull.CreateOrGet();
				}
				this.m_List.Add(value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00002D79 File Offset: 0x00000F79
		public override int Count
		{
			get
			{
				return this.m_List.Count;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002D5B File Offset: 0x00000F5B
		public override void Add(string aKey, JSONNode aItem)
		{
			if (aItem == null)
			{
				aItem = JSONNull.CreateOrGet();
			}
			this.m_List.Add(aItem);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002D86 File Offset: 0x00000F86
		public override JSONNode Remove(int aIndex)
		{
			if (aIndex < 0 || aIndex >= this.m_List.Count)
			{
				return null;
			}
			JSONNode result = this.m_List[aIndex];
			this.m_List.RemoveAt(aIndex);
			return result;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002DB4 File Offset: 0x00000FB4
		public override JSONNode Remove(JSONNode aNode)
		{
			this.m_List.Remove(aNode);
			return aNode;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002DC4 File Offset: 0x00000FC4
		public override IEnumerable<JSONNode> Children
		{
			get
			{
				foreach (JSONNode jsonnode in this.m_List)
				{
					yield return jsonnode;
				}
				List<JSONNode>.Enumerator enumerator = default(List<JSONNode>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002DD4 File Offset: 0x00000FD4
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append('[');
			int count = this.m_List.Count;
			if (this.inline)
			{
				aMode = JSONTextMode.Compact;
			}
			for (int i = 0; i < count; i++)
			{
				if (i > 0)
				{
					aSB.Append(',');
				}
				if (aMode == JSONTextMode.Indent)
				{
					aSB.AppendLine();
				}
				if (aMode == JSONTextMode.Indent)
				{
					aSB.Append(' ', aIndent + aIndentInc);
				}
				this.m_List[i].WriteToStringBuilder(aSB, aIndent + aIndentInc, aIndentInc, aMode);
			}
			if (aMode == JSONTextMode.Indent)
			{
				aSB.AppendLine().Append(' ', aIndent);
			}
			aSB.Append(']');
		}

		// Token: 0x04000023 RID: 35
		private List<JSONNode> m_List = new List<JSONNode>();

		// Token: 0x04000024 RID: 36
		private bool inline;
	}
}
