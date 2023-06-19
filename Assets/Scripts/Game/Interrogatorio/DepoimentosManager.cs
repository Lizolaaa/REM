using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
			
		}
		
		#endregion <<---------- Mono Behaviour ---------->>
		
	}
}
