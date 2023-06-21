﻿using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Dialogs {
	public class Dialog : MonoBehaviour {

		[SerializeField] private Sprite _speakerBigSprite;
		[SerializeField] private Sprite _speakerSmallSprite;
		[SerializeField] private string _speakerName;
		[SerializeField, Multiline] private string _dialog;
		
		[Header("References")]
		[SerializeField] private TextMeshProUGUI _textSpeakerName;
		[SerializeField] private TextMeshProUGUI _textDialog;
		[SerializeField] private Image _speakerBigImage;
		[SerializeField] private Image _speakerSmallImage;
		[SerializeField] private AudioClip _audio;
		
		
		
		private void Awake() {
			this._textDialog.text = this._dialog;
			this._textSpeakerName.text = this._speakerName;
			this._speakerBigImage.gameObject.SetActive(_speakerBigSprite != null);
			this._speakerBigImage.sprite = this._speakerBigSprite;
			
			this._speakerSmallImage.gameObject.SetActive(_speakerSmallSprite != null);
			this._speakerSmallImage.sprite = this._speakerSmallSprite;
		}

		public AudioClip ShowDialog() {
			this.gameObject.SetActive(true);
			if (this._textDialog.TryGetComponent<DOTweenAnimation>(out var a)) {
				a.DOPlay();
			}

			return this._audio;
		}

		public void NextDialog() {
			FindObjectOfType<DialogController>().NextDialog();
		}
		
	}
}
