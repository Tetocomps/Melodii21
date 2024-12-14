Shader "Ciconia Studio/Double Sided/Standard/Diffuse Bump" {
	Properties {
		_Diffusecolor ("Diffuse color", Vector) = (1,1,1,1)
		_MainTex ("Diffuse Map (Spec A)", 2D) = "white" {}
		_Speccolor ("Spec color", Vector) = (1,1,1,1)
		_SpecIntensity ("Spec Intensity", Range(0, 2)) = 0.2
		_Glossiness ("Glossiness", Range(0, 1)) = 0.5
		_BumpMap ("Normal Map", 2D) = "bump" {}
		_NormalIntensity ("Normal Intensity", Range(0, 2)) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}