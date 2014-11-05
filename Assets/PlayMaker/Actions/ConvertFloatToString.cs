// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Convert)]
    [Tooltip("Converts a Float value to a String value with optional format.")]
	public class ConvertFloatToString : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat floatVariable;
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmString stringVariable;
        [Tooltip("Optional Format, allows for leading zeroes. eg.: 0000")]
        public FsmString format;
		public bool everyFrame;

		public override void Reset()
		{
			floatVariable = null;
			stringVariable = null;
			everyFrame = false;
            format = null;
		}

		public override void OnEnter()
		{
			DoConvertFloatToString();
			
			if (!everyFrame)
				Finish();
		}
		
		public override void OnUpdate()
		{
			DoConvertFloatToString();
		}
		
		void DoConvertFloatToString()
		{
            if (format == null)
                stringVariable.Value = floatVariable.Value.ToString();
            else
                stringVariable.Value = floatVariable.Value.ToString(format.Value);
		}
	}
}