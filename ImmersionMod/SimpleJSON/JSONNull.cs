using System;
using System.Text;

namespace SimpleJSON
{
	// Token: 0x02000014 RID: 20
	public class JSONNull : JSONNode
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x000037DB File Offset: 0x000019DB
		public static JSONNull CreateOrGet()
		{
			if (JSONNull.reuseSameInstance)
			{
				return JSONNull.m_StaticInstance;
			}
			return new JSONNull();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000037EF File Offset: 0x000019EF
		private JSONNull()
		{
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000037F7 File Offset: 0x000019F7
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.NullValue;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public override bool IsNull
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000037FC File Offset: 0x000019FC
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00003812 File Offset: 0x00001A12
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x0000205A File Offset: 0x0000025A
		public override string Value
		{
			get
			{
				return "null";
			}
			set
			{
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00002063 File Offset: 0x00000263
		// (set) Token: 0x060000CA RID: 202 RVA: 0x0000205A File Offset: 0x0000025A
		public override bool AsBool
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003819 File Offset: 0x00001A19
		public override bool Equals(object obj)
		{
			return this == obj || obj is JSONNull;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00002063 File Offset: 0x00000263
		public override int GetHashCode()
		{
			return 0;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000382A File Offset: 0x00001A2A
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append("null");
		}

		// Token: 0x04000035 RID: 53
		private static JSONNull m_StaticInstance = new JSONNull();

		// Token: 0x04000036 RID: 54
		public static bool reuseSameInstance = true;
	}
}
