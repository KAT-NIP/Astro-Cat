// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Pistol Gun"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_MainColor("MainColor", Color) = (1,0.8896552,0,0)
		_SecondaryColor("SecondaryColor", Color) = (1,1,1,0)
		_HandleColor("HandleColor", Color) = (0,0,0,0)
		_Emissive("Emissive", Color) = (0.007352948,1,0.1374241,0)
		_EmissiveIntensity("EmissiveIntensity", Float) = 1
		_Metal("Metal", Color) = (0.625,0.625,0.625,0)
		_Normal("Normal", 2D) = "bump" {}
		_Gun_Mask("Gun_Mask", 2D) = "white" {}
		_Gun_Mask_02("Gun_Mask_02", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform float4 _MainColor;
		uniform sampler2D _Gun_Mask_02;
		uniform float4 _Gun_Mask_02_ST;
		uniform float4 _SecondaryColor;
		uniform sampler2D _Gun_Mask;
		uniform float4 _Gun_Mask_ST;
		uniform float4 _HandleColor;
		uniform float4 _Metal;
		uniform float4 _Emissive;
		uniform float _EmissiveIntensity;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _Normal, uv_Normal ) );
			float2 uv_Gun_Mask_02 = i.uv_texcoord * _Gun_Mask_02_ST.xy + _Gun_Mask_02_ST.zw;
			float4 tex2DNode21 = tex2D( _Gun_Mask_02, uv_Gun_Mask_02 );
			float4 blendOpSrc29 = _MainColor;
			float blendOpDest29 = tex2DNode21.g;
			float2 uv_Gun_Mask = i.uv_texcoord * _Gun_Mask_ST.xy + _Gun_Mask_ST.zw;
			float4 tex2DNode6 = tex2D( _Gun_Mask, uv_Gun_Mask );
			float4 lerpResult10 = lerp( ( saturate( 	max( blendOpSrc29, blendOpDest29 ) )) , _SecondaryColor , tex2DNode6.r);
			float4 lerpResult11 = lerp( lerpResult10 , _HandleColor , tex2DNode6.g);
			float4 lerpResult13 = lerp( lerpResult11 , _Metal , tex2DNode6.b);
			float4 lerpResult12 = lerp( lerpResult13 , _Emissive , tex2DNode6.a);
			o.Albedo = ( lerpResult12 * tex2DNode21.r ).rgb;
			o.Emission = ( ( _Emissive * _EmissiveIntensity ) * tex2DNode6.a ).rgb;
			o.Metallic = tex2DNode6.b;
			o.Smoothness = tex2DNode21.a;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13101
7;29;2546;1364;4299.006;1268.852;1.676185;True;False
Node;AmplifyShaderEditor.ColorNode;7;-2863.245,-124.9942;Float;False;Property;_MainColor;MainColor;0;0;1,0.8896552,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;21;-2693.021,-599.8909;Float;True;Property;_Gun_Mask_02;Gun_Mask_02;8;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ColorNode;8;-1904.684,-83.27463;Float;False;Property;_SecondaryColor;SecondaryColor;1;0;1,1,1,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;6;-2411.809,130.8445;Float;True;Property;_Gun_Mask;Gun_Mask;7;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.BlendOpsNode;29;-2113.51,-175.8776;Float;False;Lighten;True;2;0;COLOR;0,0,0,0;False;1;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.ColorNode;33;-2542.458,-53.42957;Float;False;Property;_HandleColor;HandleColor;2;0;0,0,0,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.LerpOp;10;-1708.306,-268.6989;Float;False;3;0;COLOR;0.0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.LerpOp;11;-1493.904,-54.69885;Float;False;3;0;COLOR;0.0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.ColorNode;14;-1904.089,249.9739;Float;False;Property;_Metal;Metal;5;0;0.625,0.625,0.625,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;18;-1785.831,722.5159;Float;False;Property;_EmissiveIntensity;EmissiveIntensity;4;0;1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;15;-1900.188,430.6738;Float;False;Property;_Emissive;Emissive;3;0;0.007352948,1,0.1374241,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.LerpOp;13;-1366.504,106.101;Float;False;3;0;COLOR;0.0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-1437.426,601.6155;Float;False;2;2;0;COLOR;0.0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.LerpOp;12;-1216.004,276.5012;Float;False;3;0;COLOR;0.0;False;1;COLOR;0.0,0,0,0;False;2;FLOAT;0.0;False;1;COLOR
Node;AmplifyShaderEditor.SamplerNode;3;-1793.935,-770.1832;Float;True;Property;_Normal;Normal;6;0;None;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT3;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;16;-1151.225,461.2162;Float;False;2;2;0;COLOR;0.0;False;1;FLOAT;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-850.5997,-124.4396;Float;False;2;2;0;COLOR;0.0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-94.20805,-181.8875;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Pistol Gun;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;0;False;0;0;Opaque;0.5;True;True;0;False;Opaque;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;29;0;7;0
WireConnection;29;1;21;2
WireConnection;10;0;29;0
WireConnection;10;1;8;0
WireConnection;10;2;6;1
WireConnection;11;0;10;0
WireConnection;11;1;33;0
WireConnection;11;2;6;2
WireConnection;13;0;11;0
WireConnection;13;1;14;0
WireConnection;13;2;6;3
WireConnection;17;0;15;0
WireConnection;17;1;18;0
WireConnection;12;0;13;0
WireConnection;12;1;15;0
WireConnection;12;2;6;4
WireConnection;16;0;17;0
WireConnection;16;1;6;4
WireConnection;22;0;12;0
WireConnection;22;1;21;1
WireConnection;0;0;22;0
WireConnection;0;1;3;0
WireConnection;0;2;16;0
WireConnection;0;3;6;3
WireConnection;0;4;21;4
ASEEND*/
//CHKSM=9E4C0731BE4FC30D81FE45E613D6151AE2EBDEEE