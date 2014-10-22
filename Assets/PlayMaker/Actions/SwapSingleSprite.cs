// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.
//--- __ECO__ __ACTION__

using UnityEngine;
using System.Collections;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Animation)]
	[Tooltip("Replaces a single Sprite on any GameObject. Object must have a Sprite Renderer.")]
	public class SwapSingleSprite : FsmStateAction
	{
		
		[RequiredField]
		[CheckForComponent(typeof(SpriteRenderer))]
		public FsmOwnerDefault gameObject;
		
		public Sprite spriteToSwap;
		
		private SpriteRenderer spriteRenderer;
		
		public override void Reset()
		{
			gameObject = null;
			
			spriteToSwap = new Sprite();
		}
		
		public override void OnEnter()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null) return;
			
			spriteRenderer = go.GetComponent<SpriteRenderer>();
			
			if (spriteRenderer == null)
			{
				LogError("SwapSingleSprite: Missing SpriteRenderer!");
				return;
			}
			
			SwapSprites();
			
			Finish();
		}
		
		void SwapSprites()
		{
			spriteRenderer.sprite = spriteToSwap;
		}
		
	}
}