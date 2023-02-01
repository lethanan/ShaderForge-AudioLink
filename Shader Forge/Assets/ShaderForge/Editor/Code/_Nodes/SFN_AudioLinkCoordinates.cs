using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ShaderForge
{

	[System.Serializable]
	public class SFN_AudioLinkCoordinates : SF_Node
	{


		public SFN_AudioLinkCoordinates()
		{

		}

		public override void Initialize()
		{
			node_height /= 4;
			base.Initialize("AudioLink Preset");
			base.UseLowerPropertyBox(true);
			base.texture.CompCount = 2;
			connectors = new SF_NodeConnector[]{
				SF_NodeConnector.Create(this,"OUT","XY",ConType.cOutput,ValueType.VTv2,false)
			};
		}

		// Options for dropdown (Just a few Audiolink presets - see docs for more)
		private Vector2[] AL_presets ={
			new Vector2(0, 0),
			new Vector2(0, 1),
			new Vector2(0, 2),
			new Vector2(0, 3),
			new Vector2(0, 28),
			new Vector2(0, 29),
			new Vector2(0, 30),
			new Vector2(0, 31),
		};
		public enum AL_preset
		{
			Bass,
			LowerMid,
			UpperMid,
			Treble,
			BassSmooth,
			LowerMidSmooth,
			UpperMidSmooth,
			TrebleSmooth
		};
		public AL_preset AL_preset_selected = AL_preset.Bass;

		public override bool IsUniformOutput()
		{
			return true;
		}

		public override string Evaluate(OutChannel channel = OutChannel.All)
		{
			Vector2 o = AL_presets[(int)AL_preset_selected];
			texture.dataUniform.x = o.x;
			texture.dataUniform.y = o.y;
			return precision.ToCode() + "2(" + o.x + "," + o.y + ")";

		}

		public override void DrawLowerPropertyBox()
		{
			// Dropdown for various AL presets
			EditorGUI.BeginChangeCheck();
			AL_preset_selected = (AL_preset)EditorGUI.EnumPopup(rectInner, AL_preset_selected);
			if (EditorGUI.EndChangeCheck())
			{
				Vector2 o = AL_presets[(int)AL_preset_selected];
				texture.dataUniform.x = o.x;
				texture.dataUniform.y = o.y;
				OnUpdateNode();
				if (SF_Settings.autoCompile) SF_Editor.instance.shaderEvaluator.Evaluate(); // only way I could get it to update on selection
			}

		}
		public override Vector4 EvalCPU()
		{
			Vector2 o = AL_presets[(int)AL_preset_selected];
			texture.dataUniform.x = o.x;
			texture.dataUniform.y = o.y;
			return new Vector4(o.x, o.y, 0, 0);
		}

		public override string SerializeSpecialData()
		{
			return "als:" + (int)AL_preset_selected;
		}

		public override void DeserializeSpecialData(string key, string value)
		{
			switch (key)
			{
				case "als":
					AL_preset_selected = (AL_preset)int.Parse(value);
					break;
			}

			Vector2 o = AL_presets[(int)AL_preset_selected];
			texture.dataUniform.x = o.x;
			texture.dataUniform.y = o.y;
		}




	}
}