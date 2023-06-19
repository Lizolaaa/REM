using UnityEngine;

namespace Game.Interrogatorio {
	public class TomadorDeNota : MonoBehaviour {

		public string NomeDaPessoa;
		[Multiline] public string Nota;


		public void TomarNota() {
			DepoimentosManager.AddDepoimento(NomeDaPessoa, Nota);
		}
		
	}
}
