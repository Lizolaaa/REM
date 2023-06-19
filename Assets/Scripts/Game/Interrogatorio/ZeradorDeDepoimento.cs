using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interrogatorio {
	public class ZeradorDeDepoimento : MonoBehaviour {
		
		// codigo zera depoimento ao sair da cena

		private void OnDisable() {
			DepoimentosManager.ClearAllDepoimentos();
		}
	}
}
