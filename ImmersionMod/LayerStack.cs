using System;
using System.Collections.Generic;

namespace ImmersionMod
{
	// Token: 0x02000020 RID: 32
	internal class LayerStack
	{
		// Token: 0x06000105 RID: 261 RVA: 0x000043D0 File Offset: 0x000025D0
		private void ApplyStack()
		{
			for (int i = 0; i < this._layers.Count; i++)
			{
				this._layers[i].layer._applyAction();
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004410 File Offset: 0x00002610
		private void UndoStack()
		{
			for (int i = this._layers.Count - 1; i >= 0; i--)
			{
				this._layers[i].layer._undoAction();
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00004450 File Offset: 0x00002650
		public int Count
		{
			get
			{
				return this._layers.Count;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00004460 File Offset: 0x00002660
		public bool AddLayer(string aId, LayerInfo aLayer)
		{
			bool result = false;
			if (!this._layerIds.Contains(aId))
			{
				this._layers.Add(new LayerStack.StackInfo(aId, aLayer));
				this._layerIds.Add(aId);
				aLayer._applyAction();
				result = true;
			}
			return result;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000044AC File Offset: 0x000026AC
		public bool RemoveLayer(string aId)
		{
			bool result = false;
			int index;
			if (this._layerIds.Contains(aId) && this.GetIndexOf(aId, out index))
			{
				this.UndoStack();
				this._layers.RemoveAt(index);
				this.ApplyStack();
				this._layerIds.Remove(aId);
				result = true;
			}
			return result;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000044FC File Offset: 0x000026FC
		public bool ReplaceLayer(string aId, LayerInfo aLayer)
		{
			bool result = false;
			int index;
			if (this._layerIds.Contains(aId) && this.GetIndexOf(aId, out index))
			{
				this.UndoStack();
				this._layers[index].layer = aLayer;
				this.ApplyStack();
				result = true;
			}
			return result;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00004545 File Offset: 0x00002745
		private bool GetIndexOf(string aId, out int aIdx)
		{
			for (aIdx = 0; aIdx < this._layers.Count; aIdx++)
			{
				if (this._layers[aIdx].id == aId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000053 RID: 83
		private List<LayerStack.StackInfo> _layers = new List<LayerStack.StackInfo>();

		// Token: 0x04000054 RID: 84
		private HashSet<string> _layerIds = new HashSet<string>();

		// Token: 0x02000021 RID: 33
		private class StackInfo
		{
			// Token: 0x0600010D RID: 269 RVA: 0x0000459C File Offset: 0x0000279C
			public StackInfo(string aId, LayerInfo aLayer)
			{
				this.layer = aLayer;
				this.id = aId;
			}

			// Token: 0x04000055 RID: 85
			public LayerInfo layer;

			// Token: 0x04000056 RID: 86
			public string id;
		}
	}
}
