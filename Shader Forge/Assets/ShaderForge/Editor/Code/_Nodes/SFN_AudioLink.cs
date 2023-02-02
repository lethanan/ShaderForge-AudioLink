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

			UseLowerReadonlyValues( true );

			connectors = new SF_NodeConnector[]{
				SF_NodeConnector.Create(this,"OUT","",ConType.cOutput,ValueType.VTv3,false),
				SF_NodeConnector.Create(this,"UVIN","XY",ConType.cInput,ValueType.VTv2,false).SetRequired(true),
			};


			SetExtensionConnectorChain("UVIN");

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
			evalStr += "_AudioTexture.Sample(sampler_AudioGraph_Point_Repeat, float2(" + GetConnectorByStringID("UVIN").TryEvaluate() + "))";

			return evalStr;
		}


		public override float EvalCPU( int c ) {

			float result =  1F;

			return result;
		}

	}
}