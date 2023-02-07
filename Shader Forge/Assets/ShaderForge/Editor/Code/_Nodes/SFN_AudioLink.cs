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

				SF_NodeConnector.Create(this,"RGB","RGB",ConType.cOutput,ValueType.VTv3).Outputting(OutChannel.RGB),
				SF_NodeConnector.Create(this,"R","R",ConType.cOutput,   ValueType.VTv1).WithColor(Color.red).Outputting(OutChannel.R),
				SF_NodeConnector.Create(this,"G","G",ConType.cOutput,ValueType.VTv1).WithColor(Color.green).Outputting(OutChannel.G),
				SF_NodeConnector.Create(this,"B","B",ConType.cOutput,ValueType.VTv1).WithColor(Color.blue).Outputting(OutChannel.B),
				SF_NodeConnector.Create(this,"UVIN","XY",ConType.cInput,ValueType.VTv2,false).SetRequired(true),
			};

			base.alwaysDefineVariable = true;
			base.neverDefineVariable = false;
			base.texture.CompCount = 3;

			SetExtensionConnectorChain("UVIN");

		}

		public override bool UpdatesOverTime()
		{
			return true;
		}

		public override bool IsUniformOutput()
		{
			return false;
		}

		public override int GetEvaluatedComponentCount()
		{
			return 3;
		}

		public override string Evaluate( OutChannel channel = OutChannel.All ) {


			string evalStr = "(_AudioTexture.Sample(sampler_AudioGraph_Point_Repeat, float2(" + GetConnectorByStringID("UVIN").TryEvaluate() + ")))";
			//evalStr += "AudioLinkData(uint2("+GetConnectorByStringID("A").TryEvaluate()+","+ GetConnectorByStringID("B").TryEvaluate() + "))";
			//if(channel == OutChannel.All) evalStr += ".rgb";
			//else if(channel == OutChannel.R) evalStr += ".r";
			//else if(channel == OutChannel.G) evalStr += ".g";
			//else if(channel == OutChannel.B) evalStr += ".b";
			return evalStr;
		}


		public override float EvalCPU( int c ) {

			float result =  1F;

			return result;
		}

	}
}