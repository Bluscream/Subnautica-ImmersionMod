using System;
using System.Collections.Generic;
using SimpleJSON;

namespace ImmersionMod.Config
{
	// Token: 0x0200002A RID: 42
	internal class WarningLevels
	{
		// Token: 0x06000142 RID: 322 RVA: 0x00005068 File Offset: 0x00003268
		public WarningLevels(JSONNode aNode)
		{
			this.health = aNode["health"].AsFloat;
			this.oxygen = aNode["oxygen"].AsFloat;
			this.hunger = aNode["hunger"].AsFloat;
			this.thirst = aNode["thirst"].AsFloat;
			this.warningGroup = aNode["warningGroup"].Value;
			this._ranges = new List<WarningLevels.WarningRange>();
			this._ranges.Add(new WarningLevels.WarningRange("Health", aNode["health"].AsFloat / 100f, 10000f, delegate()
			{
				LiveMixin liveMixin = Player.main.liveMixin;
				if (liveMixin == null)
				{
					return null;
				}
				return new float?(liveMixin.GetHealthFraction());
			}));
			this._ranges.Add(new WarningLevels.WarningRange("Oxygen", aNode["oxygen"].AsFloat / 100f, 10000f, delegate()
			{
				OxygenManager oxygenMgr = Player.main.oxygenMgr;
				if (oxygenMgr == null)
				{
					return null;
				}
				return new float?(oxygenMgr.GetOxygenFraction());
			}));
			this._ranges.Add(new WarningLevels.WarningRange("Thirst", aNode["thirst"].AsFloat, 10000f, delegate()
			{
				Survival component = Player.main.GetComponent<Survival>();
				if (component == null)
				{
					return null;
				}
				return new float?(component.water);
			}));
			this._ranges.Add(new WarningLevels.WarningRange("Hunger", aNode["hunger"].AsFloat, 10000f, delegate()
			{
				Survival component = Player.main.GetComponent<Survival>();
				if (component == null)
				{
					return null;
				}
				return new float?(component.food);
			}));
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005224 File Offset: 0x00003424
		public bool HasWarning()
		{
			using (List<WarningLevels.WarningRange>.Enumerator enumerator = this._ranges.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.CheckAlert())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005280 File Offset: 0x00003480
		public void DismissWarnings()
		{
			foreach (WarningLevels.WarningRange warningRange in this._ranges)
			{
				warningRange.Dismiss();
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000145 RID: 325 RVA: 0x000052D0 File Offset: 0x000034D0
		// (set) Token: 0x06000146 RID: 326 RVA: 0x000052D8 File Offset: 0x000034D8
		public float health { get; private set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000147 RID: 327 RVA: 0x000052E1 File Offset: 0x000034E1
		// (set) Token: 0x06000148 RID: 328 RVA: 0x000052E9 File Offset: 0x000034E9
		public float hunger { get; private set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000149 RID: 329 RVA: 0x000052F2 File Offset: 0x000034F2
		// (set) Token: 0x0600014A RID: 330 RVA: 0x000052FA File Offset: 0x000034FA
		public float thirst { get; private set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00005303 File Offset: 0x00003503
		// (set) Token: 0x0600014C RID: 332 RVA: 0x0000530B File Offset: 0x0000350B
		public float oxygen { get; private set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00005314 File Offset: 0x00003514
		// (set) Token: 0x0600014E RID: 334 RVA: 0x0000531C File Offset: 0x0000351C
		public string warningGroup { get; private set; }

		// Token: 0x0400006E RID: 110
		private List<WarningLevels.WarningRange> _ranges;

		// Token: 0x0200002B RID: 43
		// (Invoke) Token: 0x06000150 RID: 336
		public delegate float? ValueGetter();

		// Token: 0x0200002C RID: 44
		private class WarningRange
		{
			// Token: 0x06000153 RID: 339 RVA: 0x00005325 File Offset: 0x00003525
			public WarningRange(string aId, float aLow, float aHigh, WarningLevels.ValueGetter aGetter)
			{
				this._min = aLow;
				this._max = aHigh;
				this._getter = aGetter;
				this._id = aId;
				this._dismissed_high = true;
				this._dismissed_low = false;
			}

			// Token: 0x06000154 RID: 340 RVA: 0x00005358 File Offset: 0x00003558
			public bool CheckAlert()
			{
				float? num = this._getter();
				if (num != null)
				{
					if (num <= this._min && !this._dismissed_low)
					{
						return true;
					}
					if (num >= this._max && !this._dismissed_high)
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000155 RID: 341 RVA: 0x000053D0 File Offset: 0x000035D0
			public void Dismiss()
			{
				float? num = this._getter();
				if (num == null)
				{
					this._dismissed_high = true;
					this._dismissed_low = true;
					return;
				}
				if (num <= this._min)
				{
					this._dismissed_low = true;
					this._dismissed_high = false;
					return;
				}
				if (num >= this._max)
				{
					this._dismissed_low = false;
					this._dismissed_high = true;
					return;
				}
				this._dismissed_low = false;
				this._dismissed_high = false;
			}

			// Token: 0x04000074 RID: 116
			private bool _dismissed_low;

			// Token: 0x04000075 RID: 117
			private bool _dismissed_high;

			// Token: 0x04000076 RID: 118
			public string _id;

			// Token: 0x04000077 RID: 119
			private float _min;

			// Token: 0x04000078 RID: 120
			private float _max;

			// Token: 0x04000079 RID: 121
			private WarningLevels.ValueGetter _getter;
		}
	}
}
