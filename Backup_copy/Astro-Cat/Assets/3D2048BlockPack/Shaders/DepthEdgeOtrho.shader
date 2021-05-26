Shader "DepthTexture/DepthEdgeOtrho"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Intensity("Intensity", Range(-1,1)) = 0
		_Distance("Distance", Float) = 1
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		//LOD 100

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Cull Off

			CGPROGRAM
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _CameraDepthTexture;
			float4 _Color;
			float _Intensity, _Distance;

			struct VertexInput
			{
				float4 vertex : POSITION;
			};

			struct VertexOutput
			{
				float4 vertex : SV_POSITION;
				float4 screenPos : TEXCOORD0;
			};

			VertexOutput vert(VertexInput v)
			{
				VertexOutput o;
				float4 pos0 = mul(unity_ObjectToWorld, v.vertex);
				o.vertex = mul(UNITY_MATRIX_VP, pos0);
				o.screenPos = ComputeScreenPos(o.vertex);
				o.screenPos.z = mul(UNITY_MATRIX_V, pos0).z;
				return o;
			}

			fixed4 frag(VertexOutput i) : SV_Target
			{
				float4 finalColor = _Color;
				float zDepth = SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPos));
			#if defined(UNITY_REVERSED_Z)	//Other platforms
				zDepth = 1 - zDepth;
			#endif
				float orthoCam = zDepth * (_ProjectionParams.y - _ProjectionParams.z) - _ProjectionParams.y;

				float alpha = abs(orthoCam - i.screenPos.z) / _Distance;
				alpha = smoothstep(_Intensity, 1, alpha);
				finalColor.a = alpha;
				
				return finalColor;
			}
			ENDCG
		}
	}
		FallBack "Standard"
}
