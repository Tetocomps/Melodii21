Shader "Cans" {
	Properties {
		[Header(Translucency)] _Translucency ("Strength", Range(0, 50)) = 1
		_TransNormalDistortion ("Normal Distortion", Range(0, 1)) = 0.1
		_TransScattering ("Scaterring Falloff", Range(1, 50)) = 2
		_TransDirect ("Direct", Range(0, 1)) = 1
		_TransAmbient ("Ambient", Range(0, 1)) = 0.2
		_TransShadow ("Shadow", Range(0, 1)) = 0.9
		[HideInInspector] __dirty ("", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = 1;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "ASEMaterialInspector"
}