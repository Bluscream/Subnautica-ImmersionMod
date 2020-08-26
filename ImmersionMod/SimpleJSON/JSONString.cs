using System;
using System.Text;

namespace SimpleJSON
{
	// Token: 0x02000011 RID: 17
	public class JSONString : JSONNode
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003524 File Offset: 0x00001724
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.String;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public override bool IsString
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00003528 File Offset: 0x00001728
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000353E File Offset: 0x0000173E
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00003546 File Offset: 0x00001746
		public override string Value
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

		// Token: 0x060000A5 RID: 165 RVA: 0x0000354F File Offset: 0x0000174F
		public JSONString(string aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000355E File Offset: 0x0000175E
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append('"').Append(JSONNode.Escape(this.m_Data)).Append('"');
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003580 File Offset: 0x00001780
		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				return true;
			}
			string text = obj as string;
			if (text != null)
			{
				return this.m_Data == text;
			}
			JSONString jsonstring = obj as JSONString;
			return jsonstring != null && this.m_Data == jsonstring.m_Data;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000035D2 File Offset: 0x000017D2
		public override int GetHashCode()
		{
			return this.m_Data.GetHashCode();
		}

		// Token: 0x04000032 RID: 50
		private string m_Data;
	}
}
