using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Interrogatorio {
	public class DepoimentosManager : MonoBehaviour {

		#region <<---------- Properties and Fields ---------->>

		[Serializable]
		public class Depoimento {
			public string Pessoa;
			public List<string> Depoimentos = new List<string>();

			public Depoimento(string personName) {
				this.Pessoa = personName;
			}
		}

		private static List<Depoimento> AllDepoimentos = new List<Depoimento>();

		[SerializeField] private DepoimentoItem _templateDepoimentoItem;
		[SerializeField] private Transform _parentDepoimentos;

		private int _numberOfDepoimentos;
		private HashSet<DepoimentoItem> _clickedDepoimentos = new HashSet<DepoimentoItem>();

		[SerializeField] private UnityEvent _onClickedOnAllDepoimentos;

		#endregion <<---------- Properties and Fields ---------->>


		
		
		#region <<---------- Static ---------->>

		public static void AddDepoimento(string personName, string depoimentoText) {
			personName = personName.Trim().ToLower();
			var depoimento = AllDepoimentos.FirstOrDefault(d => d.Pessoa == personName);
			if (depoimento == null) {
				depoimento = new Depoimento(personName);
			}
			depoimento.Depoimentos.Add(depoimentoText);
		}

		public static void ClearAllDepoimentos() {
			Debug.Log("Todos os depoimentos zerados!");
			AllDepoimentos.Clear();
		}
		
		#endregion <<---------- Static ---------->>


		

		#region <<---------- Mono Behaviour ---------->>
		
		private void Awake() {
			this._templateDepoimentoItem.gameObject.SetActive(false);
			SpawnDepoimentos();
		}
		
		#endregion <<---------- Mono Behaviour ---------->>



		#region <<---------- General ---------->>

		public void SpawnDepoimentos() {
			foreach (var d in AllDepoimentos) {
				var instD = Instantiate(_templateDepoimentoItem, _parentDepoimentos);
				instD.Initialize(d, OnClickDepoimentoFolder);
			}
			this._numberOfDepoimentos = AllDepoimentos.Count;
			AllDepoimentos.Clear();
			_clickedDepoimentos.Clear();
		}

		private void OnClickDepoimentoFolder(DepoimentoItem obj) {
			if (!this._clickedDepoimentos.Add(obj)) return;
			if (this._clickedDepoimentos.Count < this._numberOfDepoimentos) return;
			_onClickedOnAllDepoimentos?.Invoke();
		}
		
		#endregion <<---------- General ---------->>

		
	}
}
