using System;
using System.Text;

namespace SimpleJSON
{
	// Token: 0x02000012 RID: 18
	public class JSONNumber : JSONNode
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000035DF File Offset: 0x000017DF
		public override JSONNodeType Tag
		{
			get
			{
				return JSONNodeType.Number;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public override bool IsNumber
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000035E4 File Offset: 0x000017E4
		public override JSONNode.Enumerator GetEnumerator()
		{
			return default(JSONNode.Enumerator);
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000AC RID: 172 RVA: 0x000035FA File Offset: 0x000017FA
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00003608 File Offset: 0x00001808
		public override string Value
		{
			get
			{
				return this.m_Data.ToString();
			}
			set
			{
				double data;
				if (double.TryParse(value, out data))
				{
					this.m_Data = data;
				}
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00003626 File Offset: 0x00001826
		// (set) Token: 0x060000AF RID: 175 RVA: 0x0000362E File Offset: 0x0000182E
		public override double AsDouble
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

		// Token: 0x060000B0 RID: 176 RVA: 0x00003637 File Offset: 0x00001837
		public JSONNumber(double aData)
		{
			this.m_Data = aData;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003646 File Offset: 0x00001846
		public JSONNumber(string aData)
		{
			this.Value = aData;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003655 File Offset: 0x00001855
		internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
		{
			aSB.Append(this.m_Data);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003664 File Offset: 0x00001864
		private static bool IsNumeric(object value)
		{
			return value is int || value is uint || value is float || value is double || value is decimal || value is long || value is ulong || value is short || value is ushort || value is sbyte || value is byte;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000036CC File Offset: 0x000018CC
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (base.Equals(obj))
			{
				return true;
			}
			JSONNumber jsonnumber = obj as JSONNumber;
			if (jsonnumber != null)
			{
				return this.m_Data == jsonnumber.m_Data;
			}
			return JSONNumber.IsNumeric(obj) && Convert.ToDouble(obj) == this.m_Data;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003720 File Offset: 0x00001920
		public override int GetHashCode()
		{
			return this.m_Data.GetHashCode();
		}

		// Token: 0x04000033 RID: 51
		private double m_Data;
	}
}
