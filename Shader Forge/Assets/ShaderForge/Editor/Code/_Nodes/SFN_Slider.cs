using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ShaderForge {

	[System.Serializable]
	public class SFN_Slider : SF_Node {


		public float min = 0.0f;
		public float max = 1.0f;
		public float current = 0.0f;

		GUIStyle centerFloatField;
		//GUIStyle centerFloatFieldDark;

		public SFN_Slider() {

		}

		public override void Initialize() {
			node_width = 256;
			node_height = 58;
			base.Initialize( "Slider" );
			base.showColor = false;
			base.UseLowerPropertyBox( false );
			base.texture.uniform = true;
			base.texture.CompCount = 1;
			property = ScriptableObject.CreateInstance<SFP_Slider>().Initialize( this );

			centerFloatField = new GUIStyle( EditorStyles.numberField );
			centerFloatField.alignment = TextAnchor.MiddleCenter;

			connectors = new SF_NodeConnector[]{
				SF_NodeConnector.Create(this,"OUT","",ConType.cOutput,ValueType.VTv1,false)
			};
		}

		/*public override bool IsUniformOutput() {
			return true;
		}*/

		public override string Evaluate( OutChannel channel = OutChannel.All ) {
			return property.GetVariable();
		}

		public override float NodeOperator( int x, int y, int c ) {
			Debug.Log( "Slider operator!" );
			return current;
		}


		public override void NeatWindow( ) {
			PrepareWindowColor();
			int labelWidth = 28;
			int sliderWidth = (int)( rectInner.width - 4 * labelWidth );
			GUI.BeginGroup( rect );
			Rect r = new Rect( rectInner );
			r.height = 16;
			//	r.width = labelWidth*3;
			// Upper:
			//float normSlider = Mathf.InverseLerp( min, max, current );
			//r.x = normSlider * sliderWidth + 0.5f * labelWidth;
			float prevValue = current;
			current = Mathf.Clamp( EditorGUI.FloatField( r, current, centerFloatField ), min, max );

			// Lower:
			r.y += r.height + 4;
			r.x = rectInner.x;
			r.width = labelWidth;

			GUI.Label( r, "Min" );
			r.x += r.width;
			min = EditorGUI.FloatField( r, min, centerFloatField );
			r.x += r.width;
			r.width = sliderWidth;
			float beforeSlider = current;

			string sliderName = "slider" + this.id;
			GUI.SetNextControlName( sliderName );
			current = GUI.HorizontalSlider( r, current, min, max );
			if( beforeSlider != current )
				GUI.FocusControl( sliderName );
			r.x += r.width;
			r.width = labelWidth;
			max = EditorGUI.FloatField( r, max, centerFloatField );
			r.x += r.width;
			GUI.Label( r, "Max" );

			// sliderRect.x += labelWidth;
			// sliderRect.width -= labelWidth * 2;

			if( prevValue != current )
				OnValueChanged();
			GUI.EndGroup();
			ResetWindowColor();
			//GUI.DragWindow();
		}

		// TODO: Refresh node thumbs
		public void OnValueChanged() {
			texture.dataUniform[0] = current;
			editor.shaderEvaluator.ApplyProperty( this );
			OnUpdateNode( NodeUpdateType.Soft );
		}


		public override string SerializeSpecialData() {
			string s = "";
			s += "min:" + min + ",";
			s += "cur:" + current + ",";
			s += "max:" + max;
			return s;
		}

		public override void DeserializeSpecialData( string key, string value ) {
			switch( key ) {
				case "min":
					min = float.Parse( value );
					break;
				case "cur":
					current = float.Parse( value );
					OnValueChanged();
					break;
				case "max":
					max = float.Parse( value );
					break;
			}
		}




	}
}