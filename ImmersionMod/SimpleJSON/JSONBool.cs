using System;
using System.Text;

namespace SimpleJSON
{
	// Token: 0x02000013 RID: 19
	public class JSONBool : JSONNode
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0000372D File Offset: 0x0000192D
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.Boolean;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public override bool IsBoolean
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003730 File Offset: 0x00001930
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00003746 File Offset: 0x00001946
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00003754 File Offset: 0x00001954
		public override string Value
		{
			get
			{
				return this.m_Data.ToString();
			}
			set
			{
				bool data;
				if (bool.TryParse(value, out data))
				{
					this.m_Data = data;
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00003772 File Offset: 0x00001972
		// (set) Token: 0x060000BC RID: 188 RVA: 0x0000377A File Offset: 0x0000197A
		public override bool AsBool
		{
			get
			{
				return this.m_Data;
			}
			set
			{
				this.m_Data = value;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003783 File Offset: 0x00001983
		public JSONBool(bool aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003646 File Offset: 0x00001846
		public JSONBool(string aData)
		{
			this.Value = aData;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003792 File Offset: 0x00001992
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append(this.m_Data ? "true" : "false");
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000037AF File Offset: 0x000019AF
		public override bool Equals(object obj)
		{
			return obj != null && obj is bool && this.m_Data == (bool)obj;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000037CE File Offset: 0x000019CE
		public override int GetHashCode()
		{
			return this.m_Data.GetHashCode();
		}

		// Token: 0x04000034 RID: 52
		private bool m_Data;
	}
}
