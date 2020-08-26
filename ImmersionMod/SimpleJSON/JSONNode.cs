using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SimpleJSON
{
	// Token: 0x02000004 RID: 4
	public abstract class JSONNode
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1
		public abstract JSONNodeType Tag { get; }

		// Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
		public virtual bool Contains(string aKey)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000002 RID: 2
		public virtual JSONNode this[int aIndex]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000003 RID: 3
		public virtual JSONNode this[string aKey]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000205C File Offset: 0x0000025C
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000205A File Offset: 0x0000025A
		public virtual string Value
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002063 File Offset: 0x00000263
		public virtual int Count
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002063 File Offset: 0x00000263
		public virtual bool IsNumber
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002063 File Offset: 0x00000263
		public virtual bool IsString
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002063 File Offset: 0x00000263
		public virtual bool IsBoolean
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002063 File Offset: 0x00000263
		public virtual bool IsNull
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002063 File Offset: 0x00000263
		public virtual bool IsArray
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002063 File Offset: 0x00000263
		public virtual bool IsObject
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002063 File Offset: 0x00000263
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000205A File Offset: 0x0000025A
		public virtual bool Inline
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000205A File Offset: 0x0000025A
		public virtual void Add(string aKey, JSONNode aItem)
		{
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002066 File Offset: 0x00000266
		public virtual void Add(JSONNode aItem)
		{
			this.Add("", aItem);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002057 File Offset: 0x00000257
		public virtual JSONNode Remove(string aKey)
		{
			return null;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002057 File Offset: 0x00000257
		public virtual JSONNode Remove(int aIndex)
		{
			return null;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002074 File Offset: 0x00000274
		public virtual JSONNode Remove(JSONNode aNode)
		{
			return aNode;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002077 File Offset: 0x00000277
		public virtual IEnumerable<JSONNode> Children
		{
			get
			{
				yield break;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002080 File Offset: 0x00000280
		public IEnumerable<JSONNode> DeepChildren
		{
			get
			{
				foreach (JSONNode jsonnode in this.Children)
				{
					foreach (JSONNode jsonnode2 in jsonnode.DeepChildren)
					{
						yield return jsonnode2;
					}
					IEnumerator<JSONNode> enumerator2 = null;
				}
				IEnumerator<JSONNode> enumerator = null;
				yield break;
				yield break;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002090 File Offset: 0x00000290
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.WriteToStringBuilder(stringBuilder, 0, 0, JSONTextMode.Compact);
			return stringBuilder.ToString();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000020B4 File Offset: 0x000002B4
		public virtual string ToString(int aIndent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			this.WriteToStringBuilder(stringBuilder, 0, aIndent, JSONTextMode.Indent);
			return stringBuilder.ToString();
		}

		// Token: 0x0600001B RID: 27
		internal abstract void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode);

		// Token: 0x0600001C RID: 28
		public abstract JSONNode.Enumerator GetEnumerator();

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000020D7 File Offset: 0x000002D7
		public IEnumerable<KeyValuePair<string, JSONNode>> Linq
		{
			get
			{
				return new JSONNode.LinqEnumerator(this);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000020DF File Offset: 0x000002DF
		public JSONNode.KeyEnumerator Keys
		{
			get
			{
				return new JSONNode.KeyEnumerator(this.GetEnumerator());
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000020EC File Offset: 0x000002EC
		public JSONNode.ValueEnumerator Values
		{
			get
			{
				return new JSONNode.ValueEnumerator(this.GetEnumerator());
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000020FC File Offset: 0x000002FC
		// (set) Token: 0x06000021 RID: 33 RVA: 0x0000212D File Offset: 0x0000032D
		public virtual double AsDouble
		{
			get
			{
				double result = 0.0;
				if (double.TryParse(this.Value, out result))
				{
					return result;
				}
				return 0.0;
			}
			set
			{
				this.Value = value.ToString();
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000213C File Offset: 0x0000033C
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002145 File Offset: 0x00000345
		public virtual int AsInt
		{
			get
			{
				return (int)this.AsDouble;
			}
			set
			{
				this.AsDouble = (double)value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000214F File Offset: 0x0000034F
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002145 File Offset: 0x00000345
		public virtual float AsFloat
		{
			get
			{
				return (float)this.AsDouble;
			}
			set
			{
				this.AsDouble = (double)value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002158 File Offset: 0x00000358
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00002186 File Offset: 0x00000386
		public virtual bool AsBool
		{
			get
			{
				bool result = false;
				if (bool.TryParse(this.Value, out result))
				{
					return result;
				}
				return !string.IsNullOrEmpty(this.Value);
			}
			set
			{
				this.Value = (value ? "true" : "false");
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000219D File Offset: 0x0000039D
		public virtual JSONArray AsArray
		{
			get
			{
				return this as JSONArray;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000021A5 File Offset: 0x000003A5
		public virtual JSONObject AsObject
		{
			get
			{
				return this as JSONObject;
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000021AD File Offset: 0x000003AD
		public static implicit operator JSONNode(string s)
		{
			return new JSONString(s);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000021B5 File Offset: 0x000003B5
		public static implicit operator string(JSONNode d)
		{
			if (!(d == null))
			{
				return d.Value;
			}
			return null;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000021C8 File Offset: 0x000003C8
		public static implicit operator JSONNode(double n)
		{
			return new JSONNumber(n);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000021D0 File Offset: 0x000003D0
		public static implicit operator double(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsDouble;
			}
			return 0.0;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000021EB File Offset: 0x000003EB
		public static implicit operator JSONNode(float n)
		{
			return new JSONNumber((double)n);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000021F4 File Offset: 0x000003F4
		public static implicit operator float(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsFloat;
			}
			return 0f;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000021EB File Offset: 0x000003EB
		public static implicit operator JSONNode(int n)
		{
			return new JSONNumber((double)n);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000220B File Offset: 0x0000040B
		public static implicit operator int(JSONNode d)
		{
			if (!(d == null))
			{
				return d.AsInt;
			}
			return 0;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000221E File Offset: 0x0000041E
		public static implicit operator JSONNode(bool b)
		{
			return new JSONBool(b);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002226 File Offset: 0x00000426
		public static implicit operator bool(JSONNode d)
		{
			return !(d == null) && d.AsBool;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002239 File Offset: 0x00000439
		public static implicit operator JSONNode(KeyValuePair<string, JSONNode> aKeyValue)
		{
			return aKeyValue.Value;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002244 File Offset: 0x00000444
		public static bool operator ==(JSONNode a, object b)
		{
			if (a == b)
			{
				return true;
			}
			bool flag = a is JSONNull || a == null || a is JSONLazyCreator;
			bool flag2 = b is JSONNull || b == null || b is JSONLazyCreator;
			return (flag && flag2) || (!flag && a.Equals(b));
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000229A File Offset: 0x0000049A
		public static bool operator !=(JSONNode a, object b)
		{
			return !(a == b);
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000022A6 File Offset: 0x000004A6
		public override bool Equals(object obj)
		{
			return this == obj;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000022AC File Offset: 0x000004AC
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000022B4 File Offset: 0x000004B4
		internal static StringBuilder EscapeBuilder
		{
			get
			{
				if (JSONNode.m_EscapeBuilder == null)
				{
					JSONNode.m_EscapeBuilder = new StringBuilder();
				}
				return JSONNode.m_EscapeBuilder;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000022CC File Offset: 0x000004CC
		internal static string Escape(string aText)
		{
			StringBuilder escapeBuilder = JSONNode.EscapeBuilder;
			escapeBuilder.Length = 0;
			if (escapeBuilder.Capacity < aText.Length + aText.Length / 10)
			{
				escapeBuilder.Capacity = aText.Length + aText.Length / 10;
			}
			int i = 0;
			while (i < aText.Length)
			{
				char c = aText[i];
				switch (c)
				{
				case '\b':
					escapeBuilder.Append("\\b");
					break;
				case '\t':
					escapeBuilder.Append("\\t");
					break;
				case '\n':
					escapeBuilder.Append("\\n");
					break;
				case '\v':
					goto IL_E2;
				case '\f':
					escapeBuilder.Append("\\f");
					break;
				case '\r':
					escapeBuilder.Append("\\r");
					break;
				default:
					if (c != '"')
					{
						if (c != '\\')
						{
							goto IL_E2;
						}
						escapeBuilder.Append("\\\\");
					}
					else
					{
						escapeBuilder.Append("\\\"");
					}
					break;
				}
				IL_121:
				i++;
				continue;
				IL_E2:
				if (c < ' ' || (JSONNode.forceASCII && c > '\u007f'))
				{
					ushort num = (ushort)c;
					escapeBuilder.Append("\\u").Append(num.ToString("X4"));
					goto IL_121;
				}
				escapeBuilder.Append(c);
				goto IL_121;
			}
			string result = escapeBuilder.ToString();
			escapeBuilder.Length = 0;
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000241C File Offset: 0x0000061C
		private static void ParseElement(JSONNode ctx, string token, string tokenName, bool quoted)
		{
			if (quoted)
			{
				ctx.Add(tokenName, token);
				return;
			}
			string a = token.ToLower();
			if (a == "false" || a == "true")
			{
				ctx.Add(tokenName, a == "true");
				return;
			}
			if (a == "null")
			{
				ctx.Add(tokenName, null);
				return;
			}
			double n;
			if (double.TryParse(token, out n))
			{
				ctx.Add(tokenName, n);
				return;
			}
			ctx.Add(tokenName, token);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000024B0 File Offset: 0x000006B0
		public static JSONNode Parse(string aJSON)
		{
			Stack<JSONNode> stack = new Stack<JSONNode>();
			JSONNode jsonnode = null;
			int i = 0;
			StringBuilder stringBuilder = new StringBuilder();
			string text = "";
			bool flag = false;
			bool flag2 = false;
			while (i < aJSON.Length)
			{
				char c = aJSON[i];
				if (c <= ',')
				{
					if (c <= ' ')
					{
						switch (c)
						{
						case '\t':
							break;
						case '\n':
						case '\r':
							goto IL_33E;
						case '\v':
						case '\f':
							goto IL_330;
						default:
							if (c != ' ')
							{
								goto IL_330;
							}
							break;
						}
						if (flag)
						{
							stringBuilder.Append(aJSON[i]);
						}
					}
					else if (c != '"')
					{
						if (c != ',')
						{
							goto IL_330;
						}
						if (flag)
						{
							stringBuilder.Append(aJSON[i]);
						}
						else
						{
							if (stringBuilder.Length > 0 || flag2)
							{
								JSONNode.ParseElement(jsonnode, stringBuilder.ToString(), text, flag2);
							}
							text = "";
							stringBuilder.Length = 0;
							flag2 = false;
						}
					}
					else
					{
						flag = !flag;
						flag2 = (flag2 || flag);
					}
				}
				else
				{
					if (c <= ']')
					{
						if (c != ':')
						{
							switch (c)
							{
							case '[':
								if (flag)
								{
									stringBuilder.Append(aJSON[i]);
									goto IL_33E;
								}
								stack.Push(new JSONArray());
								if (jsonnode != null)
								{
									jsonnode.Add(text, stack.Peek());
								}
								text = "";
								stringBuilder.Length = 0;
								jsonnode = stack.Peek();
								goto IL_33E;
							case '\\':
								i++;
								if (flag)
								{
									char c2 = aJSON[i];
									if (c2 <= 'f')
									{
										if (c2 == 'b')
										{
											stringBuilder.Append('\b');
											goto IL_33E;
										}
										if (c2 == 'f')
										{
											stringBuilder.Append('\f');
											goto IL_33E;
										}
									}
									else
									{
										if (c2 == 'n')
										{
											stringBuilder.Append('\n');
											goto IL_33E;
										}
										switch (c2)
										{
										case 'r':
											stringBuilder.Append('\r');
											goto IL_33E;
										case 't':
											stringBuilder.Append('\t');
											goto IL_33E;
										case 'u':
										{
											string s = aJSON.Substring(i + 1, 4);
											stringBuilder.Append((char)int.Parse(s, NumberStyles.AllowHexSpecifier));
											i += 4;
											goto IL_33E;
										}
										}
									}
									stringBuilder.Append(c2);
									goto IL_33E;
								}
								goto IL_33E;
							case ']':
								break;
							default:
								goto IL_330;
							}
						}
						else
						{
							if (flag)
							{
								stringBuilder.Append(aJSON[i]);
								goto IL_33E;
							}
							text = stringBuilder.ToString();
							stringBuilder.Length = 0;
							flag2 = false;
							goto IL_33E;
						}
					}
					else if (c != '{')
					{
						if (c != '}')
						{
							goto IL_330;
						}
					}
					else
					{
						if (flag)
						{
							stringBuilder.Append(aJSON[i]);
							goto IL_33E;
						}
						stack.Push(new JSONObject());
						if (jsonnode != null)
						{
							jsonnode.Add(text, stack.Peek());
						}
						text = "";
						stringBuilder.Length = 0;
						jsonnode = stack.Peek();
						goto IL_33E;
					}
					if (flag)
					{
						stringBuilder.Append(aJSON[i]);
					}
					else
					{
						if (stack.Count == 0)
						{
							throw new Exception("JSON Parse: Too many closing brackets");
						}
						stack.Pop();
						if (stringBuilder.Length > 0 || flag2)
						{
							JSONNode.ParseElement(jsonnode, stringBuilder.ToString(), text, flag2);
							flag2 = false;
						}
						text = "";
						stringBuilder.Length = 0;
						if (stack.Count > 0)
						{
							jsonnode = stack.Peek();
						}
					}
				}
				IL_33E:
				i++;
				continue;
				IL_330:
				stringBuilder.Append(aJSON[i]);
				goto IL_33E;
			}
			if (flag)
			{
				throw new Exception("JSON Parse: Quotation marks seems to be messed up.");
			}
			return jsonnode;
		}

		// Token: 0x0400000D RID: 13
		public static bool forceASCII;

		// Token: 0x0400000E RID: 14
		[ThreadStatic]
		private static StringBuilder m_EscapeBuilder;

		// Token: 0x02000005 RID: 5
		public struct Enumerator
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600003F RID: 63 RVA: 0x00002823 File Offset: 0x00000A23
			public bool IsValid
			{
				get
				{
					return this.type > JSONNode.Enumerator.Type.None;
				}
			}

			// Token: 0x06000040 RID: 64 RVA: 0x0000282E File Offset: 0x00000A2E
			public Enumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				this.type = JSONNode.Enumerator.Type.Array;
				this.m_Object = default(Dictionary<string, JSONNode>.Enumerator);
				this.m_Array = aArrayEnum;
			}

			// Token: 0x06000041 RID: 65 RVA: 0x0000284A File Offset: 0x00000A4A
			public Enumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				this.type = JSONNode.Enumerator.Type.Object;
				this.m_Object = aDictEnum;
				this.m_Array = default(List<JSONNode>.Enumerator);
			}

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000042 RID: 66 RVA: 0x00002868 File Offset: 0x00000A68
			public KeyValuePair<string, JSONNode> Current
			{
				get
				{
					if (this.type == JSONNode.Enumerator.Type.Array)
					{
						return new KeyValuePair<string, JSONNode>(string.Empty, this.m_Array.Current);
					}
					if (this.type == JSONNode.Enumerator.Type.Object)
					{
						return this.m_Object.Current;
					}
					return new KeyValuePair<string, JSONNode>(string.Empty, null);
				}
			}

			// Token: 0x06000043 RID: 67 RVA: 0x000028B4 File Offset: 0x00000AB4
			public bool MoveNext()
			{
				if (this.type == JSONNode.Enumerator.Type.Array)
				{
					return this.m_Array.MoveNext();
				}
				return this.type == JSONNode.Enumerator.Type.Object && this.m_Object.MoveNext();
			}

			// Token: 0x0400000F RID: 15
			private JSONNode.Enumerator.Type type;

			// Token: 0x04000010 RID: 16
			private Dictionary<string, JSONNode>.Enumerator m_Object;

			// Token: 0x04000011 RID: 17
			private List<JSONNode>.Enumerator m_Array;

			// Token: 0x02000006 RID: 6
			private enum Type
			{
				// Token: 0x04000013 RID: 19
				None,
				// Token: 0x04000014 RID: 20
				Array,
				// Token: 0x04000015 RID: 21
				Object
			}
		}

		// Token: 0x02000007 RID: 7
		public struct ValueEnumerator
		{
			// Token: 0x06000044 RID: 68 RVA: 0x000028E1 File Offset: 0x00000AE1
			public ValueEnumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				this = new JSONNode.ValueEnumerator(new JSONNode.Enumerator(aArrayEnum));
			}

			// Token: 0x06000045 RID: 69 RVA: 0x000028EF File Offset: 0x00000AEF
			public ValueEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				this = new JSONNode.ValueEnumerator(new JSONNode.Enumerator(aDictEnum));
			}

			// Token: 0x06000046 RID: 70 RVA: 0x000028FD File Offset: 0x00000AFD
			public ValueEnumerator(JSONNode.Enumerator aEnumerator)
			{
				this.m_Enumerator = aEnumerator;
			}

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000047 RID: 71 RVA: 0x00002908 File Offset: 0x00000B08
			public JSONNode Current
			{
				get
				{
					KeyValuePair<string, JSONNode> keyValuePair = this.m_Enumerator.Current;
					return keyValuePair.Value;
				}
			}

			// Token: 0x06000048 RID: 72 RVA: 0x00002928 File Offset: 0x00000B28
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x06000049 RID: 73 RVA: 0x00002935 File Offset: 0x00000B35
			public JSONNode.ValueEnumerator GetEnumerator()
			{
				return this;
			}

			// Token: 0x04000016 RID: 22
			private JSONNode.Enumerator m_Enumerator;
		}

		// Token: 0x02000008 RID: 8
		public struct KeyEnumerator
		{
			// Token: 0x0600004A RID: 74 RVA: 0x0000293D File Offset: 0x00000B3D
			public KeyEnumerator(List<JSONNode>.Enumerator aArrayEnum)
			{
				this = new JSONNode.KeyEnumerator(new JSONNode.Enumerator(aArrayEnum));
			}

			// Token: 0x0600004B RID: 75 RVA: 0x0000294B File Offset: 0x00000B4B
			public KeyEnumerator(Dictionary<string, JSONNode>.Enumerator aDictEnum)
			{
				this = new JSONNode.KeyEnumerator(new JSONNode.Enumerator(aDictEnum));
			}

			// Token: 0x0600004C RID: 76 RVA: 0x00002959 File Offset: 0x00000B59
			public KeyEnumerator(JSONNode.Enumerator aEnumerator)
			{
				this.m_Enumerator = aEnumerator;
			}

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x0600004D RID: 77 RVA: 0x00002964 File Offset: 0x00000B64
			public JSONNode Current
			{
				get
				{
					KeyValuePair<string, JSONNode> keyValuePair = this.m_Enumerator.Current;
					return keyValuePair.Key;
				}
			}

			// Token: 0x0600004E RID: 78 RVA: 0x00002989 File Offset: 0x00000B89
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x0600004F RID: 79 RVA: 0x00002996 File Offset: 0x00000B96
			public JSONNode.KeyEnumerator GetEnumerator()
			{
				return this;
			}

			// Token: 0x04000017 RID: 23
			private JSONNode.Enumerator m_Enumerator;
		}

		// Token: 0x02000009 RID: 9
		public class LinqEnumerator : IEnumerator<KeyValuePair<string, JSONNode>>, IDisposable, IEnumerator, IEnumerable<KeyValuePair<string, JSONNode>>, IEnumerable
		{
			// Token: 0x06000050 RID: 80 RVA: 0x0000299E File Offset: 0x00000B9E
			internal LinqEnumerator(JSONNode aNode)
			{
				this.m_Node = aNode;
				if (this.m_Node != null)
				{
					this.m_Enumerator = this.m_Node.GetEnumerator();
				}
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000051 RID: 81 RVA: 0x000029CC File Offset: 0x00000BCC
			public KeyValuePair<string, JSONNode> Current
			{
				get
				{
					return this.m_Enumerator.Current;
				}
			}

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000052 RID: 82 RVA: 0x000029D9 File Offset: 0x00000BD9
			object IEnumerator.Current
			{
				get
				{
					return this.m_Enumerator.Current;
				}
			}

			// Token: 0x06000053 RID: 83 RVA: 0x000029EB File Offset: 0x00000BEB
			public bool MoveNext()
			{
				return this.m_Enumerator.MoveNext();
			}

			// Token: 0x06000054 RID: 84 RVA: 0x000029F8 File Offset: 0x00000BF8
			public void Dispose()
			{
				this.m_Node = null;
				this.m_Enumerator = default(JSONNode.Enumerator);
			}

			// Token: 0x06000055 RID: 85 RVA: 0x00002A0D File Offset: 0x00000C0D
			public IEnumerator<KeyValuePair<string, JSONNode>> GetEnumerator()
			{
				return new JSONNode.LinqEnumerator(this.m_Node);
			}

			// Token: 0x06000056 RID: 86 RVA: 0x00002A1A File Offset: 0x00000C1A
			public void Reset()
			{
				if (this.m_Node != null)
				{
					this.m_Enumerator = this.m_Node.GetEnumerator();
				}
			}

			// Token: 0x06000057 RID: 87 RVA: 0x00002A0D File Offset: 0x00000C0D
			IEnumerator IEnumerable.GetEnumerator()
			{
				return new JSONNode.LinqEnumerator(this.m_Node);
			}

			// Token: 0x04000018 RID: 24
			private JSONNode m_Node;

			// Token: 0x04000019 RID: 25
			private JSONNode.Enumerator m_Enumerator;
		}
	}
}
