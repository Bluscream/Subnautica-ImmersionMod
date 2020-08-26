using System;
using UnityEngine;

namespace ImmersionMod
{
	// Token: 0x0200001C RID: 28
	internal class CompInfo
	{
		// Token: 0x060000FD RID: 253 RVA: 0x00004107 File Offset: 0x00002307
		public CompInfo(Component aComponent)
		{
			this._comp = aComponent;
			this._scale = aComponent.transform.localScale;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00004127 File Offset: 0x00002327
		public void Restore()
		{
			Component comp = this._comp;
			if (((comp != null) ? comp.transform : null) != null)
			{
				this._comp.transform.localScale = this._scale;
			}
		}

		// Token: 0x04000049 RID: 73
		private Component _comp;

		// Token: 0x0400004A RID: 74
		private Vector3 _scale;
	}
}
