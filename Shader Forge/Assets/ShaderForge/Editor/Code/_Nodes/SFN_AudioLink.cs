using UnityEngine;

// Inserts the AudioLinkData() function into compiled shaders with UV input for the audiolink texture
// Does not do any audiolink in the shaderforge editor itself
namespace ShaderForge {

	[System.Serializable]
	public class SFN_AudioLink : SF_Node  {

		public SFN_AudioLink() {

		}

		public override void Initialize() {
			base.Initialize( "AudioLink" );
			//base.PrepareArithmetic(5);

			base.alwaysDefineVariable = true;
			base.shaderGenMode = ShaderGenerationMode.OffUniform;
			base.showColor = true;
			UseLowerReadonlyValues( true );

			connectors = new SF_NodeConnector[]{
				SF_NodeConnector.Create(this,"OUT","",ConType.cOutput,ValueType.VTvPending,false),
				SF_NodeConnector.Create(this,"A","A",ConType.cInput,ValueType.VTvPending,false).SetRequired(true),
				SF_NodeConnector.Create(this,"B","B",ConType.cInput,ValueType.VTvPending,false).SetRequired(true),
			};


			SetExtensionConnectorChain("B");

			base.conGroup = ScriptableObject.CreateInstance<SFNCG_Arithmetic>().Initialize( connectors[0], connectors[1], connectors[2]);

		}

		public override void GetModularShaderFixes( out string prefix, out string infix, out string suffix ) {
			//prefix = "AudioLinkData(uint2(";
			prefix = "_AudioTexture.Sample(sampler_AudioGraph_Point_Repeat, uint2(";
			infix  = ", ";
			suffix = "))";
		}
		public override bool UpdatesOverTime()
		{
			return true;
		}

		public override bool IsUniformOutput()
		{
			return true;
		}
		public override string Evaluate( OutChannel channel = OutChannel.All ) {


			string evalStr = "";

			//evalStr += "AudioLinkData(uint2("+GetConnectorByStringID("A").TryEvaluate()+","+ GetConnectorByStringID("B").TryEvaluate() + "))";
			evalStr += "_AudioTexture.Sample(sampler_AudioGraph_Point_Repeat, uint2(" + GetConnectorByStringID("A").TryEvaluate()+","+ GetConnectorByStringID("B").TryEvaluate() + "))";

			return evalStr;
		}


		public override float EvalCPU( int c ) {

			float result =  1F;

			return result;
		}

	}
}