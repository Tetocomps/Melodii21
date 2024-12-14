using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "shader", "renderQueue", "shaderKeywords", "globalIlluminationFlags", "properties" })]
	public class ES3Type_Material : ES3UnityObjectType
	{
		public static ES3Type Instance;

		public ES3Type_Material()
			: base(typeof(Material))
		{
			Instance = this;
		}

		protected override void WriteUnityObject(object obj, ES3Writer writer)
		{
			Material material = (Material)obj;
			writer.WriteProperty("name", material.name);
			writer.WriteProperty("shader", material.shader);
			writer.WriteProperty("renderQueue", material.renderQueue, ES3Type_int.Instance);
			writer.WriteProperty("shaderKeywords", material.shaderKeywords);
			writer.WriteProperty("globalIlluminationFlags", material.globalIlluminationFlags);
			if (material.HasProperty("_Color"))
			{
				writer.WriteProperty("_Color", material.GetColor("_Color"));
			}
			if (material.HasProperty("_SpecColor"))
			{
				writer.WriteProperty("_SpecColor", material.GetColor("_SpecColor"));
			}
			if (material.HasProperty("_Shininess"))
			{
				writer.WriteProperty("_Shininess", material.GetFloat("_Shininess"));
			}
			if (material.HasProperty("_MainTex"))
			{
				writer.WriteProperty<Texture>("_MainTex", material.GetTexture("_MainTex"));
				writer.WriteProperty<Vector2>("_MainTex_Scale", material.GetTextureScale("_MainTex"));
			}
			if (material.HasProperty("_MainTex_TextureOffset"))
			{
				writer.WriteProperty("_MainTex_TextureOffset", material.GetTextureOffset("_MainTex_TextureOffset"));
			}
			if (material.HasProperty("_MainTex_TextureScale"))
			{
				writer.WriteProperty("_MainTex_TextureScale", material.GetTextureScale("_MainTex_TextureScale"));
			}
			if (material.HasProperty("_Illum"))
			{
				writer.WriteProperty<Texture>("_Illum", material.GetTexture("_Illum"));
			}
			if (material.HasProperty("_Illum_TextureOffset"))
			{
				writer.WriteProperty("_Illum_TextureOffset", material.GetTextureOffset("_Illum_TextureOffset"));
			}
			if (material.HasProperty("_Illum_TextureScale"))
			{
				writer.WriteProperty("_Illum_TextureScale", material.GetTextureScale("_Illum_TextureScale"));
			}
			if (material.HasProperty("_BumpMap"))
			{
				writer.WriteProperty<Texture>("_BumpMap", material.GetTexture("_BumpMap"));
			}
			if (material.HasProperty("_BumpMap_TextureOffset"))
			{
				writer.WriteProperty("_BumpMap_TextureOffset", material.GetTextureOffset("_BumpMap_TextureOffset"));
			}
			if (material.HasProperty("_BumpMap_TextureScale"))
			{
				writer.WriteProperty("_BumpMap_TextureScale", material.GetTextureScale("_BumpMap_TextureScale"));
			}
			if (material.HasProperty("_Emission"))
			{
				writer.WriteProperty("_Emission", material.GetFloat("_Emission"));
			}
			if (material.HasProperty("_Specular"))
			{
				writer.WriteProperty("_Specular", material.GetColor("_Specular"));
			}
			if (material.HasProperty("_MainBump"))
			{
				writer.WriteProperty<Texture>("_MainBump", material.GetTexture("_MainBump"));
			}
			if (material.HasProperty("_MainBump_TextureOffset"))
			{
				writer.WriteProperty("_MainBump_TextureOffset", material.GetTextureOffset("_MainBump_TextureOffset"));
			}
			if (material.HasProperty("_MainBump_TextureScale"))
			{
				writer.WriteProperty("_MainBump_TextureScale", material.GetTextureScale("_MainBump_TextureScale"));
			}
			if (material.HasProperty("_Mask"))
			{
				writer.WriteProperty<Texture>("_Mask", material.GetTexture("_Mask"));
			}
			if (material.HasProperty("_Mask_TextureOffset"))
			{
				writer.WriteProperty("_Mask_TextureOffset", material.GetTextureOffset("_Mask_TextureOffset"));
			}
			if (material.HasProperty("_Mask_TextureScale"))
			{
				writer.WriteProperty("_Mask_TextureScale", material.GetTextureScale("_Mask_TextureScale"));
			}
			if (material.HasProperty("_Focus"))
			{
				writer.WriteProperty("_Focus", material.GetFloat("_Focus"));
			}
			if (material.HasProperty("_StencilComp"))
			{
				writer.WriteProperty("_StencilComp", material.GetFloat("_StencilComp"));
			}
			if (material.HasProperty("_Stencil"))
			{
				writer.WriteProperty("_Stencil", material.GetFloat("_Stencil"));
			}
			if (material.HasProperty("_StencilOp"))
			{
				writer.WriteProperty("_StencilOp", material.GetFloat("_StencilOp"));
			}
			if (material.HasProperty("_StencilWriteMask"))
			{
				writer.WriteProperty("_StencilWriteMask", material.GetFloat("_StencilWriteMask"));
			}
			if (material.HasProperty("_StencilReadMask"))
			{
				writer.WriteProperty("_StencilReadMask", material.GetFloat("_StencilReadMask"));
			}
			if (material.HasProperty("_ColorMask"))
			{
				writer.WriteProperty("_ColorMask", material.GetFloat("_ColorMask"));
			}
			if (material.HasProperty("_UseUIAlphaClip"))
			{
				writer.WriteProperty("_UseUIAlphaClip", material.GetFloat("_UseUIAlphaClip"));
			}
			if (material.HasProperty("_SrcBlend"))
			{
				writer.WriteProperty("_SrcBlend", material.GetFloat("_SrcBlend"));
			}
			if (material.HasProperty("_DstBlend"))
			{
				writer.WriteProperty("_DstBlend", material.GetFloat("_DstBlend"));
			}
			if (material.HasProperty("_ReflectColor"))
			{
				writer.WriteProperty("_ReflectColor", material.GetColor("_ReflectColor"));
			}
			if (material.HasProperty("_Cube"))
			{
				writer.WriteProperty<Texture>("_Cube", material.GetTexture("_Cube"));
			}
			if (material.HasProperty("_Cube_TextureOffset"))
			{
				writer.WriteProperty("_Cube_TextureOffset", material.GetTextureOffset("_Cube_TextureOffset"));
			}
			if (material.HasProperty("_Cube_TextureScale"))
			{
				writer.WriteProperty("_Cube_TextureScale", material.GetTextureScale("_Cube_TextureScale"));
			}
			if (material.HasProperty("_Tint"))
			{
				writer.WriteProperty("_Tint", material.GetColor("_Tint"));
			}
			if (material.HasProperty("_Exposure"))
			{
				writer.WriteProperty("_Exposure", material.GetFloat("_Exposure"));
			}
			if (material.HasProperty("_Rotation"))
			{
				writer.WriteProperty("_Rotation", material.GetFloat("_Rotation"));
			}
			if (material.HasProperty("_Tex"))
			{
				writer.WriteProperty<Texture>("_Tex", material.GetTexture("_Tex"));
			}
			if (material.HasProperty("_Tex_TextureOffset"))
			{
				writer.WriteProperty("_Tex_TextureOffset", material.GetTextureOffset("_Tex_TextureOffset"));
			}
			if (material.HasProperty("_Tex_TextureScale"))
			{
				writer.WriteProperty("_Tex_TextureScale", material.GetTextureScale("_Tex_TextureScale"));
			}
			if (material.HasProperty("_Control"))
			{
				writer.WriteProperty<Texture>("_Control", material.GetTexture("_Control"));
			}
			if (material.HasProperty("_Control_TextureOffset"))
			{
				writer.WriteProperty("_Control_TextureOffset", material.GetTextureOffset("_Control_TextureOffset"));
			}
			if (material.HasProperty("_Control_TextureScale"))
			{
				writer.WriteProperty("_Control_TextureScale", material.GetTextureScale("_Control_TextureScale"));
			}
			if (material.HasProperty("_Splat3"))
			{
				writer.WriteProperty<Texture>("_Splat3", material.GetTexture("_Splat3"));
			}
			if (material.HasProperty("_Splat3_TextureOffset"))
			{
				writer.WriteProperty("_Splat3_TextureOffset", material.GetTextureOffset("_Splat3_TextureOffset"));
			}
			if (material.HasProperty("_Splat3_TextureScale"))
			{
				writer.WriteProperty("_Splat3_TextureScale", material.GetTextureScale("_Splat3_TextureScale"));
			}
			if (material.HasProperty("_Splat2"))
			{
				writer.WriteProperty<Texture>("_Splat2", material.GetTexture("_Splat2"));
			}
			if (material.HasProperty("_Splat2_TextureOffset"))
			{
				writer.WriteProperty("_Splat2_TextureOffset", material.GetTextureOffset("_Splat2_TextureOffset"));
			}
			if (material.HasProperty("_Splat2_TextureScale"))
			{
				writer.WriteProperty("_Splat2_TextureScale", material.GetTextureScale("_Splat2_TextureScale"));
			}
			if (material.HasProperty("_Splat1"))
			{
				writer.WriteProperty<Texture>("_Splat1", material.GetTexture("_Splat1"));
			}
			if (material.HasProperty("_Splat1_TextureOffset"))
			{
				writer.WriteProperty("_Splat1_TextureOffset", material.GetTextureOffset("_Splat1_TextureOffset"));
			}
			if (material.HasProperty("_Splat1_TextureScale"))
			{
				writer.WriteProperty("_Splat1_TextureScale", material.GetTextureScale("_Splat1_TextureScale"));
			}
			if (material.HasProperty("_Splat0"))
			{
				writer.WriteProperty<Texture>("_Splat0", material.GetTexture("_Splat0"));
			}
			if (material.HasProperty("_Splat0_TextureOffset"))
			{
				writer.WriteProperty("_Splat0_TextureOffset", material.GetTextureOffset("_Splat0_TextureOffset"));
			}
			if (material.HasProperty("_Splat0_TextureScale"))
			{
				writer.WriteProperty("_Splat0_TextureScale", material.GetTextureScale("_Splat0_TextureScale"));
			}
			if (material.HasProperty("_Normal3"))
			{
				writer.WriteProperty<Texture>("_Normal3", material.GetTexture("_Normal3"));
			}
			if (material.HasProperty("_Normal3_TextureOffset"))
			{
				writer.WriteProperty("_Normal3_TextureOffset", material.GetTextureOffset("_Normal3_TextureOffset"));
			}
			if (material.HasProperty("_Normal3_TextureScale"))
			{
				writer.WriteProperty("_Normal3_TextureScale", material.GetTextureScale("_Normal3_TextureScale"));
			}
			if (material.HasProperty("_Normal2"))
			{
				writer.WriteProperty<Texture>("_Normal2", material.GetTexture("_Normal2"));
			}
			if (material.HasProperty("_Normal2_TextureOffset"))
			{
				writer.WriteProperty("_Normal2_TextureOffset", material.GetTextureOffset("_Normal2_TextureOffset"));
			}
			if (material.HasProperty("_Normal2_TextureScale"))
			{
				writer.WriteProperty("_Normal2_TextureScale", material.GetTextureScale("_Normal2_TextureScale"));
			}
			if (material.HasProperty("_Normal1"))
			{
				writer.WriteProperty<Texture>("_Normal1", material.GetTexture("_Normal1"));
			}
			if (material.HasProperty("_Normal1_TextureOffset"))
			{
				writer.WriteProperty("_Normal1_TextureOffset", material.GetTextureOffset("_Normal1_TextureOffset"));
			}
			if (material.HasProperty("_Normal1_TextureScale"))
			{
				writer.WriteProperty("_Normal1_TextureScale", material.GetTextureScale("_Normal1_TextureScale"));
			}
			if (material.HasProperty("_Normal0"))
			{
				writer.WriteProperty<Texture>("_Normal0", material.GetTexture("_Normal0"));
			}
			if (material.HasProperty("_Normal0_TextureOffset"))
			{
				writer.WriteProperty("_Normal0_TextureOffset", material.GetTextureOffset("_Normal0_TextureOffset"));
			}
			if (material.HasProperty("_Normal0_TextureScale"))
			{
				writer.WriteProperty("_Normal0_TextureScale", material.GetTextureScale("_Normal0_TextureScale"));
			}
			if (material.HasProperty("_Cutoff"))
			{
				writer.WriteProperty("_Cutoff", material.GetFloat("_Cutoff"));
			}
			if (material.HasProperty("_BaseLight"))
			{
				writer.WriteProperty("_BaseLight", material.GetFloat("_BaseLight"));
			}
			if (material.HasProperty("_AO"))
			{
				writer.WriteProperty("_AO", material.GetFloat("_AO"));
			}
			if (material.HasProperty("_Occlusion"))
			{
				writer.WriteProperty("_Occlusion", material.GetFloat("_Occlusion"));
			}
			if (material.HasProperty("_TreeInstanceColor"))
			{
				writer.WriteProperty("_TreeInstanceColor", material.GetVector("_TreeInstanceColor"));
			}
			if (material.HasProperty("_TreeInstanceScale"))
			{
				writer.WriteProperty("_TreeInstanceScale", material.GetVector("_TreeInstanceScale"));
			}
			if (material.HasProperty("_SquashAmount"))
			{
				writer.WriteProperty("_SquashAmount", material.GetFloat("_SquashAmount"));
			}
			if (material.HasProperty("_TranslucencyColor"))
			{
				writer.WriteProperty("_TranslucencyColor", material.GetColor("_TranslucencyColor"));
			}
			if (material.HasProperty("_TranslucencyViewDependency"))
			{
				writer.WriteProperty("_TranslucencyViewDependency", material.GetFloat("_TranslucencyViewDependency"));
			}
			if (material.HasProperty("_ShadowStrength"))
			{
				writer.WriteProperty("_ShadowStrength", material.GetFloat("_ShadowStrength"));
			}
			if (material.HasProperty("_ShadowOffsetScale"))
			{
				writer.WriteProperty("_ShadowOffsetScale", material.GetFloat("_ShadowOffsetScale"));
			}
			if (material.HasProperty("_ShadowTex"))
			{
				writer.WriteProperty<Texture>("_ShadowTex", material.GetTexture("_ShadowTex"));
			}
			if (material.HasProperty("_ShadowTex_TextureOffset"))
			{
				writer.WriteProperty("_ShadowTex_TextureOffset", material.GetTextureOffset("_ShadowTex_TextureOffset"));
			}
			if (material.HasProperty("_ShadowTex_TextureScale"))
			{
				writer.WriteProperty("_ShadowTex_TextureScale", material.GetTextureScale("_ShadowTex_TextureScale"));
			}
			if (material.HasProperty("_BumpSpecMap"))
			{
				writer.WriteProperty<Texture>("_BumpSpecMap", material.GetTexture("_BumpSpecMap"));
			}
			if (material.HasProperty("_BumpSpecMap_TextureOffset"))
			{
				writer.WriteProperty("_BumpSpecMap_TextureOffset", material.GetTextureOffset("_BumpSpecMap_TextureOffset"));
			}
			if (material.HasProperty("_BumpSpecMap_TextureScale"))
			{
				writer.WriteProperty("_BumpSpecMap_TextureScale", material.GetTextureScale("_BumpSpecMap_TextureScale"));
			}
			if (material.HasProperty("_TranslucencyMap"))
			{
				writer.WriteProperty<Texture>("_TranslucencyMap", material.GetTexture("_TranslucencyMap"));
			}
			if (material.HasProperty("_TranslucencyMap_TextureOffset"))
			{
				writer.WriteProperty("_TranslucencyMap_TextureOffset", material.GetTextureOffset("_TranslucencyMap_TextureOffset"));
			}
			if (material.HasProperty("_TranslucencyMap_TextureScale"))
			{
				writer.WriteProperty("_TranslucencyMap_TextureScale", material.GetTextureScale("_TranslucencyMap_TextureScale"));
			}
			if (material.HasProperty("_LightMap"))
			{
				writer.WriteProperty<Texture>("_LightMap", material.GetTexture("_LightMap"));
			}
			if (material.HasProperty("_LightMap_TextureOffset"))
			{
				writer.WriteProperty("_LightMap_TextureOffset", material.GetTextureOffset("_LightMap_TextureOffset"));
			}
			if (material.HasProperty("_LightMap_TextureScale"))
			{
				writer.WriteProperty("_LightMap_TextureScale", material.GetTextureScale("_LightMap_TextureScale"));
			}
			if (material.HasProperty("_DetailTex"))
			{
				writer.WriteProperty<Texture>("_DetailTex", material.GetTexture("_DetailTex"));
			}
			if (material.HasProperty("_DetailTex_TextureOffset"))
			{
				writer.WriteProperty("_DetailTex_TextureOffset", material.GetTextureOffset("_DetailTex_TextureOffset"));
			}
			if (material.HasProperty("_DetailTex_TextureScale"))
			{
				writer.WriteProperty("_DetailTex_TextureScale", material.GetTextureScale("_DetailTex_TextureScale"));
			}
			if (material.HasProperty("_DetailBump"))
			{
				writer.WriteProperty<Texture>("_DetailBump", material.GetTexture("_DetailBump"));
			}
			if (material.HasProperty("_DetailBump_TextureOffset"))
			{
				writer.WriteProperty("_DetailBump_TextureOffset", material.GetTextureOffset("_DetailBump_TextureOffset"));
			}
			if (material.HasProperty("_DetailBump_TextureScale"))
			{
				writer.WriteProperty("_DetailBump_TextureScale", material.GetTextureScale("_DetailBump_TextureScale"));
			}
			if (material.HasProperty("_Strength"))
			{
				writer.WriteProperty("_Strength", material.GetFloat("_Strength"));
			}
			if (material.HasProperty("_InvFade"))
			{
				writer.WriteProperty("_InvFade", material.GetFloat("_InvFade"));
			}
			if (material.HasProperty("_EmisColor"))
			{
				writer.WriteProperty("_EmisColor", material.GetColor("_EmisColor"));
			}
			if (material.HasProperty("_Parallax"))
			{
				writer.WriteProperty("_Parallax", material.GetFloat("_Parallax"));
			}
			if (material.HasProperty("_ParallaxMap"))
			{
				writer.WriteProperty<Texture>("_ParallaxMap", material.GetTexture("_ParallaxMap"));
			}
			if (material.HasProperty("_ParallaxMap_TextureOffset"))
			{
				writer.WriteProperty("_ParallaxMap_TextureOffset", material.GetTextureOffset("_ParallaxMap_TextureOffset"));
			}
			if (material.HasProperty("_ParallaxMap_TextureScale"))
			{
				writer.WriteProperty("_ParallaxMap_TextureScale", material.GetTextureScale("_ParallaxMap_TextureScale"));
			}
			if (material.HasProperty("_DecalTex"))
			{
				writer.WriteProperty<Texture>("_DecalTex", material.GetTexture("_DecalTex"));
			}
			if (material.HasProperty("_DecalTex_TextureOffset"))
			{
				writer.WriteProperty("_DecalTex_TextureOffset", material.GetTextureOffset("_DecalTex_TextureOffset"));
			}
			if (material.HasProperty("_DecalTex_TextureScale"))
			{
				writer.WriteProperty("_DecalTex_TextureScale", material.GetTextureScale("_DecalTex_TextureScale"));
			}
			if (material.HasProperty("_GlossMap"))
			{
				writer.WriteProperty<Texture>("_GlossMap", material.GetTexture("_GlossMap"));
			}
			if (material.HasProperty("_GlossMap_TextureOffset"))
			{
				writer.WriteProperty("_GlossMap_TextureOffset", material.GetTextureOffset("_GlossMap_TextureOffset"));
			}
			if (material.HasProperty("_GlossMap_TextureScale"))
			{
				writer.WriteProperty("_GlossMap_TextureScale", material.GetTextureScale("_GlossMap_TextureScale"));
			}
			if (material.HasProperty("_ShadowOffset"))
			{
				writer.WriteProperty<Texture>("_ShadowOffset", material.GetTexture("_ShadowOffset"));
			}
			if (material.HasProperty("_ShadowOffset_TextureOffset"))
			{
				writer.WriteProperty("_ShadowOffset_TextureOffset", material.GetTextureOffset("_ShadowOffset_TextureOffset"));
			}
			if (material.HasProperty("_ShadowOffset_TextureScale"))
			{
				writer.WriteProperty("_ShadowOffset_TextureScale", material.GetTextureScale("_ShadowOffset_TextureScale"));
			}
			if (material.HasProperty("_SunDisk"))
			{
				writer.WriteProperty("_SunDisk", material.GetFloat("_SunDisk"));
			}
			if (material.HasProperty("_SunSize"))
			{
				writer.WriteProperty("_SunSize", material.GetFloat("_SunSize"));
			}
			if (material.HasProperty("_AtmosphereThickness"))
			{
				writer.WriteProperty("_AtmosphereThickness", material.GetFloat("_AtmosphereThickness"));
			}
			if (material.HasProperty("_SkyTint"))
			{
				writer.WriteProperty("_SkyTint", material.GetColor("_SkyTint"));
			}
			if (material.HasProperty("_GroundColor"))
			{
				writer.WriteProperty("_GroundColor", material.GetColor("_GroundColor"));
			}
			if (material.HasProperty("_WireThickness"))
			{
				writer.WriteProperty("_WireThickness", material.GetFloat("_WireThickness"));
			}
			if (material.HasProperty("_ZWrite"))
			{
				writer.WriteProperty("_ZWrite", material.GetFloat("_ZWrite"));
			}
			if (material.HasProperty("_ZTest"))
			{
				writer.WriteProperty("_ZTest", material.GetFloat("_ZTest"));
			}
			if (material.HasProperty("_Cull"))
			{
				writer.WriteProperty("_Cull", material.GetFloat("_Cull"));
			}
			if (material.HasProperty("_ZBias"))
			{
				writer.WriteProperty("_ZBias", material.GetFloat("_ZBias"));
			}
			if (material.HasProperty("_HueVariation"))
			{
				writer.WriteProperty("_HueVariation", material.GetColor("_HueVariation"));
			}
			if (material.HasProperty("_WindQuality"))
			{
				writer.WriteProperty("_WindQuality", material.GetFloat("_WindQuality"));
			}
			if (material.HasProperty("_DetailMask"))
			{
				writer.WriteProperty<Texture>("_DetailMask", material.GetTexture("_DetailMask"));
			}
			if (material.HasProperty("_DetailMask_TextureOffset"))
			{
				writer.WriteProperty("_DetailMask_TextureOffset", material.GetTextureOffset("_DetailMask_TextureOffset"));
			}
			if (material.HasProperty("_DetailMask_TextureScale"))
			{
				writer.WriteProperty("_DetailMask_TextureScale", material.GetTextureScale("_DetailMask_TextureScale"));
			}
			if (material.HasProperty("_MetallicTex"))
			{
				writer.WriteProperty<Texture>("_MetallicTex", material.GetTexture("_MetallicTex"));
			}
			if (material.HasProperty("_MetallicTex_TextureOffset"))
			{
				writer.WriteProperty("_MetallicTex_TextureOffset", material.GetTextureOffset("_MetallicTex_TextureOffset"));
			}
			if (material.HasProperty("_MetallicTex_TextureScale"))
			{
				writer.WriteProperty("_MetallicTex_TextureScale", material.GetTextureScale("_MetallicTex_TextureScale"));
			}
			if (material.HasProperty("_Glossiness"))
			{
				writer.WriteProperty("_Glossiness", material.GetFloat("_Glossiness"));
			}
			if (material.HasProperty("_GlossMapScale"))
			{
				writer.WriteProperty("_GlossMapScale", material.GetFloat("_GlossMapScale"));
			}
			if (material.HasProperty("_SmoothnessTextureChannel"))
			{
				writer.WriteProperty("_SmoothnessTextureChannel", material.GetFloat("_SmoothnessTextureChannel"));
			}
			if (material.HasProperty("_Metallic"))
			{
				writer.WriteProperty("_Metallic", material.GetFloat("_Metallic"));
			}
			if (material.HasProperty("_MetallicGlossMap"))
			{
				writer.WriteProperty<Texture>("_MetallicGlossMap", material.GetTexture("_MetallicGlossMap"));
			}
			if (material.HasProperty("_MetallicGlossMap_TextureOffset"))
			{
				writer.WriteProperty("_MetallicGlossMap_TextureOffset", material.GetTextureOffset("_MetallicGlossMap_TextureOffset"));
			}
			if (material.HasProperty("_MetallicGlossMap_TextureScale"))
			{
				writer.WriteProperty("_MetallicGlossMap_TextureScale", material.GetTextureScale("_MetallicGlossMap_TextureScale"));
			}
			if (material.HasProperty("_SpecularHighlights"))
			{
				writer.WriteProperty("_SpecularHighlights", material.GetFloat("_SpecularHighlights"));
			}
			if (material.HasProperty("_GlossyReflections"))
			{
				writer.WriteProperty("_GlossyReflections", material.GetFloat("_GlossyReflections"));
			}
			if (material.HasProperty("_BumpScale"))
			{
				writer.WriteProperty("_BumpScale", material.GetFloat("_BumpScale"));
			}
			if (material.HasProperty("_OcclusionStrength"))
			{
				writer.WriteProperty("_OcclusionStrength", material.GetFloat("_OcclusionStrength"));
			}
			if (material.HasProperty("_OcclusionMap"))
			{
				writer.WriteProperty<Texture>("_OcclusionMap", material.GetTexture("_OcclusionMap"));
			}
			if (material.HasProperty("_OcclusionMap_TextureOffset"))
			{
				writer.WriteProperty("_OcclusionMap_TextureOffset", material.GetTextureOffset("_OcclusionMap_TextureOffset"));
			}
			if (material.HasProperty("_OcclusionMap_TextureScale"))
			{
				writer.WriteProperty("_OcclusionMap_TextureScale", material.GetTextureScale("_OcclusionMap_TextureScale"));
			}
			if (material.HasProperty("_EmissionColor"))
			{
				writer.WriteProperty("_EmissionColor", material.GetColor("_EmissionColor"));
			}
			if (material.HasProperty("_EmissionMap"))
			{
				writer.WriteProperty<Texture>("_EmissionMap", material.GetTexture("_EmissionMap"));
			}
			if (material.HasProperty("_EmissionMap_TextureOffset"))
			{
				writer.WriteProperty("_EmissionMap_TextureOffset", material.GetTextureOffset("_EmissionMap_TextureOffset"));
			}
			if (material.HasProperty("_EmissionMap_TextureScale"))
			{
				writer.WriteProperty("_EmissionMap_TextureScale", material.GetTextureScale("_EmissionMap_TextureScale"));
			}
			if (material.HasProperty("_DetailAlbedoMap"))
			{
				writer.WriteProperty<Texture>("_DetailAlbedoMap", material.GetTexture("_DetailAlbedoMap"));
			}
			if (material.HasProperty("_DetailAlbedoMap_TextureOffset"))
			{
				writer.WriteProperty("_DetailAlbedoMap_TextureOffset", material.GetTextureOffset("_DetailAlbedoMap_TextureOffset"));
			}
			if (material.HasProperty("_DetailAlbedoMap_TextureScale"))
			{
				writer.WriteProperty("_DetailAlbedoMap_TextureScale", material.GetTextureScale("_DetailAlbedoMap_TextureScale"));
			}
			if (material.HasProperty("_DetailNormalMapScale"))
			{
				writer.WriteProperty("_DetailNormalMapScale", material.GetFloat("_DetailNormalMapScale"));
			}
			if (material.HasProperty("_DetailNormalMap"))
			{
				writer.WriteProperty<Texture>("_DetailNormalMap", material.GetTexture("_DetailNormalMap"));
			}
			if (material.HasProperty("_DetailNormalMap_TextureOffset"))
			{
				writer.WriteProperty("_DetailNormalMap_TextureOffset", material.GetTextureOffset("_DetailNormalMap_TextureOffset"));
			}
			if (material.HasProperty("_DetailNormalMap_TextureScale"))
			{
				writer.WriteProperty("_DetailNormalMap_TextureScale", material.GetTextureScale("_DetailNormalMap_TextureScale"));
			}
			if (material.HasProperty("_UVSec"))
			{
				writer.WriteProperty("_UVSec", material.GetFloat("_UVSec"));
			}
			if (material.HasProperty("_Mode"))
			{
				writer.WriteProperty("_Mode", material.GetFloat("_Mode"));
			}
			if (material.HasProperty("_TintColor"))
			{
				writer.WriteProperty("_TintColor", material.GetColor("_TintColor"));
			}
			if (material.HasProperty("_WavingTint"))
			{
				writer.WriteProperty("_WavingTint", material.GetColor("_WavingTint"));
			}
			if (material.HasProperty("_WaveAndDistance"))
			{
				writer.WriteProperty("_WaveAndDistance", material.GetVector("_WaveAndDistance"));
			}
			if (material.HasProperty("_LightTexture0"))
			{
				writer.WriteProperty<Texture>("_LightTexture0", material.GetTexture("_LightTexture0"));
			}
			if (material.HasProperty("_LightTexture0_TextureOffset"))
			{
				writer.WriteProperty("_LightTexture0_TextureOffset", material.GetTextureOffset("_LightTexture0_TextureOffset"));
			}
			if (material.HasProperty("_LightTexture0_TextureScale"))
			{
				writer.WriteProperty("_LightTexture0_TextureScale", material.GetTextureScale("_LightTexture0_TextureScale"));
			}
			if (material.HasProperty("_LightTextureB0"))
			{
				writer.WriteProperty<Texture>("_LightTextureB0", material.GetTexture("_LightTextureB0"));
			}
			if (material.HasProperty("_LightTextureB0_TextureOffset"))
			{
				writer.WriteProperty("_LightTextureB0_TextureOffset", material.GetTextureOffset("_LightTextureB0_TextureOffset"));
			}
			if (material.HasProperty("_LightTextureB0_TextureScale"))
			{
				writer.WriteProperty("_LightTextureB0_TextureScale", material.GetTextureScale("_LightTextureB0_TextureScale"));
			}
			if (material.HasProperty("_ShadowMapTexture"))
			{
				writer.WriteProperty<Texture>("_ShadowMapTexture", material.GetTexture("_ShadowMapTexture"));
			}
			if (material.HasProperty("_ShadowMapTexture_TextureOffset"))
			{
				writer.WriteProperty("_ShadowMapTexture_TextureOffset", material.GetTextureOffset("_ShadowMapTexture_TextureOffset"));
			}
			if (material.HasProperty("_ShadowMapTexture_TextureScale"))
			{
				writer.WriteProperty("_ShadowMapTexture_TextureScale", material.GetTextureScale("_ShadowMapTexture_TextureScale"));
			}
			if (material.HasProperty("_SecondTex"))
			{
				writer.WriteProperty<Texture>("_SecondTex", material.GetTexture("_SecondTex"));
			}
			if (material.HasProperty("_SecondTex_TextureOffset"))
			{
				writer.WriteProperty("_SecondTex_TextureOffset", material.GetTextureOffset("_SecondTex_TextureOffset"));
			}
			if (material.HasProperty("_SecondTex_TextureScale"))
			{
				writer.WriteProperty("_SecondTex_TextureScale", material.GetTextureScale("_SecondTex_TextureScale"));
			}
			if (material.HasProperty("_ThirdTex"))
			{
				writer.WriteProperty<Texture>("_ThirdTex", material.GetTexture("_ThirdTex"));
			}
			if (material.HasProperty("_ThirdTex_TextureOffset"))
			{
				writer.WriteProperty("_ThirdTex_TextureOffset", material.GetTextureOffset("_ThirdTex_TextureOffset"));
			}
			if (material.HasProperty("_ThirdTex_TextureScale"))
			{
				writer.WriteProperty("_ThirdTex_TextureScale", material.GetTextureScale("_ThirdTex_TextureScale"));
			}
			if (material.HasProperty("PixelSnap"))
			{
				writer.WriteProperty("PixelSnap", material.GetFloat("PixelSnap"));
			}
			if (material.HasProperty("_RendererColor"))
			{
				writer.WriteProperty("_RendererColor", material.GetColor("_RendererColor"));
			}
			if (material.HasProperty("_Flip"))
			{
				writer.WriteProperty("_Flip", material.GetVector("_Flip"));
			}
			if (material.HasProperty("_AlphaTex"))
			{
				writer.WriteProperty<Texture>("_AlphaTex", material.GetTexture("_AlphaTex"));
			}
			if (material.HasProperty("_AlphaTex_TextureOffset"))
			{
				writer.WriteProperty("_AlphaTex_TextureOffset", material.GetTextureOffset("_AlphaTex_TextureOffset"));
			}
			if (material.HasProperty("_AlphaTex_TextureScale"))
			{
				writer.WriteProperty("_AlphaTex_TextureScale", material.GetTextureScale("_AlphaTex_TextureScale"));
			}
			if (material.HasProperty("_EnableExternalAlpha"))
			{
				writer.WriteProperty("_EnableExternalAlpha", material.GetFloat("_EnableExternalAlpha"));
			}
			if (material.HasProperty("_Level"))
			{
				writer.WriteProperty("_Level", material.GetFloat("_Level"));
			}
			if (material.HasProperty("_SpecGlossMap"))
			{
				writer.WriteProperty<Texture>("_SpecGlossMap", material.GetTexture("_SpecGlossMap"));
			}
			if (material.HasProperty("_SpecGlossMap_TextureOffset"))
			{
				writer.WriteProperty("_SpecGlossMap_TextureOffset", material.GetTextureOffset("_SpecGlossMap_TextureOffset"));
			}
			if (material.HasProperty("_SpecGlossMap_TextureScale"))
			{
				writer.WriteProperty("_SpecGlossMap_TextureScale", material.GetTextureScale("_SpecGlossMap_TextureScale"));
			}
			if (material.HasProperty("_FrontTex"))
			{
				writer.WriteProperty<Texture>("_FrontTex", material.GetTexture("_FrontTex"));
			}
			if (material.HasProperty("_FrontTex_TextureOffset"))
			{
				writer.WriteProperty("_FrontTex_TextureOffset", material.GetTextureOffset("_FrontTex_TextureOffset"));
			}
			if (material.HasProperty("_FrontTex_TextureScale"))
			{
				writer.WriteProperty("_FrontTex_TextureScale", material.GetTextureScale("_FrontTex_TextureScale"));
			}
			if (material.HasProperty("_BackTex"))
			{
				writer.WriteProperty<Texture>("_BackTex", material.GetTexture("_BackTex"));
			}
			if (material.HasProperty("_BackTex_TextureOffset"))
			{
				writer.WriteProperty("_BackTex_TextureOffset", material.GetTextureOffset("_BackTex_TextureOffset"));
			}
			if (material.HasProperty("_BackTex_TextureScale"))
			{
				writer.WriteProperty("_BackTex_TextureScale", material.GetTextureScale("_BackTex_TextureScale"));
			}
			if (material.HasProperty("_LeftTex"))
			{
				writer.WriteProperty<Texture>("_LeftTex", material.GetTexture("_LeftTex"));
			}
			if (material.HasProperty("_LeftTex_TextureOffset"))
			{
				writer.WriteProperty("_LeftTex_TextureOffset", material.GetTextureOffset("_LeftTex_TextureOffset"));
			}
			if (material.HasProperty("_LeftTex_TextureScale"))
			{
				writer.WriteProperty("_LeftTex_TextureScale", material.GetTextureScale("_LeftTex_TextureScale"));
			}
			if (material.HasProperty("_RightTex"))
			{
				writer.WriteProperty<Texture>("_RightTex", material.GetTexture("_RightTex"));
			}
			if (material.HasProperty("_RightTex_TextureOffset"))
			{
				writer.WriteProperty("_RightTex_TextureOffset", material.GetTextureOffset("_RightTex_TextureOffset"));
			}
			if (material.HasProperty("_RightTex_TextureScale"))
			{
				writer.WriteProperty("_RightTex_TextureScale", material.GetTextureScale("_RightTex_TextureScale"));
			}
			if (material.HasProperty("_UpTex"))
			{
				writer.WriteProperty<Texture>("_UpTex", material.GetTexture("_UpTex"));
			}
			if (material.HasProperty("_UpTex_TextureOffset"))
			{
				writer.WriteProperty("_UpTex_TextureOffset", material.GetTextureOffset("_UpTex_TextureOffset"));
			}
			if (material.HasProperty("_UpTex_TextureScale"))
			{
				writer.WriteProperty("_UpTex_TextureScale", material.GetTextureScale("_UpTex_TextureScale"));
			}
			if (material.HasProperty("_DownTex"))
			{
				writer.WriteProperty<Texture>("_DownTex", material.GetTexture("_DownTex"));
			}
			if (material.HasProperty("_DownTex_TextureOffset"))
			{
				writer.WriteProperty("_DownTex_TextureOffset", material.GetTextureOffset("_DownTex_TextureOffset"));
			}
			if (material.HasProperty("_DownTex_TextureScale"))
			{
				writer.WriteProperty("_DownTex_TextureScale", material.GetTextureScale("_DownTex_TextureScale"));
			}
			if (material.HasProperty("_Metallic0"))
			{
				writer.WriteProperty("_Metallic0", material.GetFloat("_Metallic0"));
			}
			if (material.HasProperty("_Metallic1"))
			{
				writer.WriteProperty("_Metallic1", material.GetFloat("_Metallic1"));
			}
			if (material.HasProperty("_Metallic2"))
			{
				writer.WriteProperty("_Metallic2", material.GetFloat("_Metallic2"));
			}
			if (material.HasProperty("_Metallic3"))
			{
				writer.WriteProperty("_Metallic3", material.GetFloat("_Metallic3"));
			}
			if (material.HasProperty("_Smoothness0"))
			{
				writer.WriteProperty("_Smoothness0", material.GetFloat("_Smoothness0"));
			}
			if (material.HasProperty("_Smoothness1"))
			{
				writer.WriteProperty("_Smoothness1", material.GetFloat("_Smoothness1"));
			}
			if (material.HasProperty("_Smoothness2"))
			{
				writer.WriteProperty("_Smoothness2", material.GetFloat("_Smoothness2"));
			}
			if (material.HasProperty("_Smoothness3"))
			{
				writer.WriteProperty("_Smoothness3", material.GetFloat("_Smoothness3"));
			}
			if (material.HasProperty("_TexA"))
			{
				writer.WriteProperty<Texture>("_TexA", material.GetTexture("_TexA"));
			}
			if (material.HasProperty("_TexA_TextureOffset"))
			{
				writer.WriteProperty("_TexA_TextureOffset", material.GetTextureOffset("_TexA_TextureOffset"));
			}
			if (material.HasProperty("_TexA_TextureScale"))
			{
				writer.WriteProperty("_TexA_TextureScale", material.GetTextureScale("_TexA_TextureScale"));
			}
			if (material.HasProperty("_TexB"))
			{
				writer.WriteProperty<Texture>("_TexB", material.GetTexture("_TexB"));
			}
			if (material.HasProperty("_TexB_TextureOffset"))
			{
				writer.WriteProperty("_TexB_TextureOffset", material.GetTextureOffset("_TexB_TextureOffset"));
			}
			if (material.HasProperty("_TexB_TextureScale"))
			{
				writer.WriteProperty("_TexB_TextureScale", material.GetTextureScale("_TexB_TextureScale"));
			}
			if (material.HasProperty("_value"))
			{
				writer.WriteProperty("_value", material.GetFloat("_value"));
			}
			if (material.HasProperty("_Texel"))
			{
				writer.WriteProperty("_Texel", material.GetFloat("_Texel"));
			}
			if (material.HasProperty("_Detail"))
			{
				writer.WriteProperty<Texture>("_Detail", material.GetTexture("_Detail"));
			}
			if (material.HasProperty("_Detail_TextureOffset"))
			{
				writer.WriteProperty("_Detail_TextureOffset", material.GetTextureOffset("_Detail_TextureOffset"));
			}
			if (material.HasProperty("_Detail_TextureScale"))
			{
				writer.WriteProperty("_Detail_TextureScale", material.GetTextureScale("_Detail_TextureScale"));
			}
			if (material.HasProperty("_HalfOverCutoff"))
			{
				writer.WriteProperty("_HalfOverCutoff", material.GetFloat("_HalfOverCutoff"));
			}
		}

		protected override object ReadUnityObject<T>(ES3Reader reader)
		{
			Material material = new Material(Shader.Find("Diffuse"));
			ReadUnityObject<T>(reader, material);
			return material;
		}

		protected override void ReadUnityObject<T>(ES3Reader reader, object obj)
		{
			Material material = (Material)obj;
			IEnumerator enumerator = reader.Properties.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					switch ((string)enumerator.Current)
					{
					case "name":
						material.name = reader.Read<string>(ES3Type_string.Instance);
						break;
					case "shader":
						material.shader = reader.Read<Shader>(ES3Type_Shader.Instance);
						break;
					case "renderQueue":
						material.renderQueue = reader.Read<int>(ES3Type_int.Instance);
						break;
					case "shaderKeywords":
						material.shaderKeywords = reader.Read<string[]>();
						break;
					case "globalIlluminationFlags":
						material.globalIlluminationFlags = reader.Read<MaterialGlobalIlluminationFlags>();
						break;
					case "_Color":
						material.SetColor("_Color", reader.Read<Color>());
						break;
					case "_SpecColor":
						material.SetColor("_SpecColor", reader.Read<Color>());
						break;
					case "_Shininess":
						material.SetFloat("_Shininess", reader.Read<float>());
						break;
					case "_MainTex":
						material.SetTexture("_MainTex", reader.Read<Texture>());
						break;
					case "_MainTex_TextureOffset":
						material.SetTextureOffset("_MainTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_MainTex_TextureScale":
						material.SetTextureScale("_MainTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_Illum":
						material.SetTexture("_Illum", reader.Read<Texture>());
						break;
					case "_Illum_TextureOffset":
						material.SetTextureOffset("_Illum_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Illum_TextureScale":
						material.SetTextureScale("_Illum_TextureScale", reader.Read<Vector2>());
						break;
					case "_BumpMap":
						material.SetTexture("_BumpMap", reader.Read<Texture>());
						break;
					case "_BumpMap_TextureOffset":
						material.SetTextureOffset("_BumpMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_BumpMap_TextureScale":
						material.SetTextureScale("_BumpMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_Emission":
						material.SetFloat("_Emission", reader.Read<float>());
						break;
					case "_Specular":
						material.SetColor("_Specular", reader.Read<Color>());
						break;
					case "_MainBump":
						material.SetTexture("_MainBump", reader.Read<Texture>());
						break;
					case "_MainBump_TextureOffset":
						material.SetTextureOffset("_MainBump_TextureOffset", reader.Read<Vector2>());
						break;
					case "_MainBump_TextureScale":
						material.SetTextureScale("_MainBump_TextureScale", reader.Read<Vector2>());
						break;
					case "_Mask":
						material.SetTexture("_Mask", reader.Read<Texture>());
						break;
					case "_Mask_TextureOffset":
						material.SetTextureOffset("_Mask_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Mask_TextureScale":
						material.SetTextureScale("_Mask_TextureScale", reader.Read<Vector2>());
						break;
					case "_Focus":
						material.SetFloat("_Focus", reader.Read<float>());
						break;
					case "_StencilComp":
						material.SetFloat("_StencilComp", reader.Read<float>());
						break;
					case "_Stencil":
						material.SetFloat("_Stencil", reader.Read<float>());
						break;
					case "_StencilOp":
						material.SetFloat("_StencilOp", reader.Read<float>());
						break;
					case "_StencilWriteMask":
						material.SetFloat("_StencilWriteMask", reader.Read<float>());
						break;
					case "_StencilReadMask":
						material.SetFloat("_StencilReadMask", reader.Read<float>());
						break;
					case "_ColorMask":
						material.SetFloat("_ColorMask", reader.Read<float>());
						break;
					case "_UseUIAlphaClip":
						material.SetFloat("_UseUIAlphaClip", reader.Read<float>());
						break;
					case "_SrcBlend":
						material.SetFloat("_SrcBlend", reader.Read<float>());
						break;
					case "_DstBlend":
						material.SetFloat("_DstBlend", reader.Read<float>());
						break;
					case "_ReflectColor":
						material.SetColor("_ReflectColor", reader.Read<Color>());
						break;
					case "_Cube":
						material.SetTexture("_Cube", reader.Read<Texture>());
						break;
					case "_Cube_TextureOffset":
						material.SetTextureOffset("_Cube_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Cube_TextureScale":
						material.SetTextureScale("_Cube_TextureScale", reader.Read<Vector2>());
						break;
					case "_Tint":
						material.SetColor("_Tint", reader.Read<Color>());
						break;
					case "_Exposure":
						material.SetFloat("_Exposure", reader.Read<float>());
						break;
					case "_Rotation":
						material.SetFloat("_Rotation", reader.Read<float>());
						break;
					case "_Tex":
						material.SetTexture("_Tex", reader.Read<Texture>());
						break;
					case "_Tex_TextureOffset":
						material.SetTextureOffset("_Tex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Tex_TextureScale":
						material.SetTextureScale("_Tex_TextureScale", reader.Read<Vector2>());
						break;
					case "_MainTex_Scale":
						material.SetTextureScale("_MainTex", reader.Read<Vector2>());
						break;
					case "_Control":
						material.SetTexture("_Control", reader.Read<Texture>());
						break;
					case "_Control_TextureOffset":
						material.SetTextureOffset("_Control_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Control_TextureScale":
						material.SetTextureScale("_Control_TextureScale", reader.Read<Vector2>());
						break;
					case "_Splat3":
						material.SetTexture("_Splat3", reader.Read<Texture>());
						break;
					case "_Splat3_TextureOffset":
						material.SetTextureOffset("_Splat3_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Splat3_TextureScale":
						material.SetTextureScale("_Splat3_TextureScale", reader.Read<Vector2>());
						break;
					case "_Splat2":
						material.SetTexture("_Splat2", reader.Read<Texture>());
						break;
					case "_Splat2_TextureOffset":
						material.SetTextureOffset("_Splat2_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Splat2_TextureScale":
						material.SetTextureScale("_Splat2_TextureScale", reader.Read<Vector2>());
						break;
					case "_Splat1":
						material.SetTexture("_Splat1", reader.Read<Texture>());
						break;
					case "_Splat1_TextureOffset":
						material.SetTextureOffset("_Splat1_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Splat1_TextureScale":
						material.SetTextureScale("_Splat1_TextureScale", reader.Read<Vector2>());
						break;
					case "_Splat0":
						material.SetTexture("_Splat0", reader.Read<Texture>());
						break;
					case "_Splat0_TextureOffset":
						material.SetTextureOffset("_Splat0_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Splat0_TextureScale":
						material.SetTextureScale("_Splat0_TextureScale", reader.Read<Vector2>());
						break;
					case "_Normal3":
						material.SetTexture("_Normal3", reader.Read<Texture>());
						break;
					case "_Normal3_TextureOffset":
						material.SetTextureOffset("_Normal3_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Normal3_TextureScale":
						material.SetTextureScale("_Normal3_TextureScale", reader.Read<Vector2>());
						break;
					case "_Normal2":
						material.SetTexture("_Normal2", reader.Read<Texture>());
						break;
					case "_Normal2_TextureOffset":
						material.SetTextureOffset("_Normal2_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Normal2_TextureScale":
						material.SetTextureScale("_Normal2_TextureScale", reader.Read<Vector2>());
						break;
					case "_Normal1":
						material.SetTexture("_Normal1", reader.Read<Texture>());
						break;
					case "_Normal1_TextureOffset":
						material.SetTextureOffset("_Normal1_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Normal1_TextureScale":
						material.SetTextureScale("_Normal1_TextureScale", reader.Read<Vector2>());
						break;
					case "_Normal0":
						material.SetTexture("_Normal0", reader.Read<Texture>());
						break;
					case "_Normal0_TextureOffset":
						material.SetTextureOffset("_Normal0_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Normal0_TextureScale":
						material.SetTextureScale("_Normal0_TextureScale", reader.Read<Vector2>());
						break;
					case "_Cutoff":
						material.SetFloat("_Cutoff", reader.Read<float>());
						break;
					case "_BaseLight":
						material.SetFloat("_BaseLight", reader.Read<float>());
						break;
					case "_AO":
						material.SetFloat("_AO", reader.Read<float>());
						break;
					case "_Occlusion":
						material.SetFloat("_Occlusion", reader.Read<float>());
						break;
					case "_TreeInstanceColor":
						material.SetVector("_TreeInstanceColor", reader.Read<Vector4>());
						break;
					case "_TreeInstanceScale":
						material.SetVector("_TreeInstanceScale", reader.Read<Vector4>());
						break;
					case "_SquashAmount":
						material.SetFloat("_SquashAmount", reader.Read<float>());
						break;
					case "_TranslucencyColor":
						material.SetColor("_TranslucencyColor", reader.Read<Color>());
						break;
					case "_TranslucencyViewDependency":
						material.SetFloat("_TranslucencyViewDependency", reader.Read<float>());
						break;
					case "_ShadowStrength":
						material.SetFloat("_ShadowStrength", reader.Read<float>());
						break;
					case "_ShadowOffsetScale":
						material.SetFloat("_ShadowOffsetScale", reader.Read<float>());
						break;
					case "_ShadowTex":
						material.SetTexture("_ShadowTex", reader.Read<Texture>());
						break;
					case "_ShadowTex_TextureOffset":
						material.SetTextureOffset("_ShadowTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_ShadowTex_TextureScale":
						material.SetTextureScale("_ShadowTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_BumpSpecMap":
						material.SetTexture("_BumpSpecMap", reader.Read<Texture>());
						break;
					case "_BumpSpecMap_TextureOffset":
						material.SetTextureOffset("_BumpSpecMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_BumpSpecMap_TextureScale":
						material.SetTextureScale("_BumpSpecMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_TranslucencyMap":
						material.SetTexture("_TranslucencyMap", reader.Read<Texture>());
						break;
					case "_TranslucencyMap_TextureOffset":
						material.SetTextureOffset("_TranslucencyMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_TranslucencyMap_TextureScale":
						material.SetTextureScale("_TranslucencyMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_LightMap":
						material.SetTexture("_LightMap", reader.Read<Texture>());
						break;
					case "_LightMap_TextureOffset":
						material.SetTextureOffset("_LightMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_LightMap_TextureScale":
						material.SetTextureScale("_LightMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_DetailTex":
						material.SetTexture("_DetailTex", reader.Read<Texture>());
						break;
					case "_DetailTex_TextureOffset":
						material.SetTextureOffset("_DetailTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_DetailTex_TextureScale":
						material.SetTextureScale("_DetailTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_DetailBump":
						material.SetTexture("_DetailBump", reader.Read<Texture>());
						break;
					case "_DetailBump_TextureOffset":
						material.SetTextureOffset("_DetailBump_TextureOffset", reader.Read<Vector2>());
						break;
					case "_DetailBump_TextureScale":
						material.SetTextureScale("_DetailBump_TextureScale", reader.Read<Vector2>());
						break;
					case "_Strength":
						material.SetFloat("_Strength", reader.Read<float>());
						break;
					case "_InvFade":
						material.SetFloat("_InvFade", reader.Read<float>());
						break;
					case "_EmisColor":
						material.SetColor("_EmisColor", reader.Read<Color>());
						break;
					case "_Parallax":
						material.SetFloat("_Parallax", reader.Read<float>());
						break;
					case "_ParallaxMap":
						material.SetTexture("_ParallaxMap", reader.Read<Texture>());
						break;
					case "_ParallaxMap_TextureOffset":
						material.SetTextureOffset("_ParallaxMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_ParallaxMap_TextureScale":
						material.SetTextureScale("_ParallaxMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_DecalTex":
						material.SetTexture("_DecalTex", reader.Read<Texture>());
						break;
					case "_DecalTex_TextureOffset":
						material.SetTextureOffset("_DecalTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_DecalTex_TextureScale":
						material.SetTextureScale("_DecalTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_GlossMap":
						material.SetTexture("_GlossMap", reader.Read<Texture>());
						break;
					case "_GlossMap_TextureOffset":
						material.SetTextureOffset("_GlossMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_GlossMap_TextureScale":
						material.SetTextureScale("_GlossMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_ShadowOffset":
						material.SetTexture("_ShadowOffset", reader.Read<Texture>());
						break;
					case "_ShadowOffset_TextureOffset":
						material.SetTextureOffset("_ShadowOffset_TextureOffset", reader.Read<Vector2>());
						break;
					case "_ShadowOffset_TextureScale":
						material.SetTextureScale("_ShadowOffset_TextureScale", reader.Read<Vector2>());
						break;
					case "_SunDisk":
						material.SetFloat("_SunDisk", reader.Read<float>());
						break;
					case "_SunSize":
						material.SetFloat("_SunSize", reader.Read<float>());
						break;
					case "_AtmosphereThickness":
						material.SetFloat("_AtmosphereThickness", reader.Read<float>());
						break;
					case "_SkyTint":
						material.SetColor("_SkyTint", reader.Read<Color>());
						break;
					case "_GroundColor":
						material.SetColor("_GroundColor", reader.Read<Color>());
						break;
					case "_WireThickness":
						material.SetFloat("_WireThickness", reader.Read<float>());
						break;
					case "_ZWrite":
						material.SetFloat("_ZWrite", reader.Read<float>());
						break;
					case "_ZTest":
						material.SetFloat("_ZTest", reader.Read<float>());
						break;
					case "_Cull":
						material.SetFloat("_Cull", reader.Read<float>());
						break;
					case "_ZBias":
						material.SetFloat("_ZBias", reader.Read<float>());
						break;
					case "_HueVariation":
						material.SetColor("_HueVariation", reader.Read<Color>());
						break;
					case "_WindQuality":
						material.SetFloat("_WindQuality", reader.Read<float>());
						break;
					case "_DetailMask":
						material.SetTexture("_DetailMask", reader.Read<Texture>());
						break;
					case "_DetailMask_TextureOffset":
						material.SetTextureOffset("_DetailMask_TextureOffset", reader.Read<Vector2>());
						break;
					case "_DetailMask_TextureScale":
						material.SetTextureScale("_DetailMask_TextureScale", reader.Read<Vector2>());
						break;
					case "_MetallicTex":
						material.SetTexture("_MetallicTex", reader.Read<Texture>());
						break;
					case "_MetallicTex_TextureOffset":
						material.SetTextureOffset("_MetallicTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_MetallicTex_TextureScale":
						material.SetTextureScale("_MetallicTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_Glossiness":
						material.SetFloat("_Glossiness", reader.Read<float>());
						break;
					case "_GlossMapScale":
						material.SetFloat("_GlossMapScale", reader.Read<float>());
						break;
					case "_SmoothnessTextureChannel":
						material.SetFloat("_SmoothnessTextureChannel", reader.Read<float>());
						break;
					case "_Metallic":
						material.SetFloat("_Metallic", reader.Read<float>());
						break;
					case "_MetallicGlossMap":
						material.SetTexture("_MetallicGlossMap", reader.Read<Texture>());
						break;
					case "_MetallicGlossMap_TextureOffset":
						material.SetTextureOffset("_MetallicGlossMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_MetallicGlossMap_TextureScale":
						material.SetTextureScale("_MetallicGlossMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_SpecularHighlights":
						material.SetFloat("_SpecularHighlights", reader.Read<float>());
						break;
					case "_GlossyReflections":
						material.SetFloat("_GlossyReflections", reader.Read<float>());
						break;
					case "_BumpScale":
						material.SetFloat("_BumpScale", reader.Read<float>());
						break;
					case "_OcclusionStrength":
						material.SetFloat("_OcclusionStrength", reader.Read<float>());
						break;
					case "_OcclusionMap":
						material.SetTexture("_OcclusionMap", reader.Read<Texture>());
						break;
					case "_OcclusionMap_TextureOffset":
						material.SetTextureOffset("_OcclusionMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_OcclusionMap_TextureScale":
						material.SetTextureScale("_OcclusionMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_EmissionColor":
						material.SetColor("_EmissionColor", reader.Read<Color>());
						break;
					case "_EmissionMap":
						material.SetTexture("_EmissionMap", reader.Read<Texture>());
						break;
					case "_EmissionMap_TextureOffset":
						material.SetTextureOffset("_EmissionMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_EmissionMap_TextureScale":
						material.SetTextureScale("_EmissionMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_DetailAlbedoMap":
						material.SetTexture("_DetailAlbedoMap", reader.Read<Texture>());
						break;
					case "_DetailAlbedoMap_TextureOffset":
						material.SetTextureOffset("_DetailAlbedoMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_DetailAlbedoMap_TextureScale":
						material.SetTextureScale("_DetailAlbedoMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_DetailNormalMapScale":
						material.SetFloat("_DetailNormalMapScale", reader.Read<float>());
						break;
					case "_DetailNormalMap":
						material.SetTexture("_DetailNormalMap", reader.Read<Texture>());
						break;
					case "_DetailNormalMap_TextureOffset":
						material.SetTextureOffset("_DetailNormalMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_DetailNormalMap_TextureScale":
						material.SetTextureScale("_DetailNormalMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_UVSec":
						material.SetFloat("_UVSec", reader.Read<float>());
						break;
					case "_Mode":
						material.SetFloat("_Mode", reader.Read<float>());
						break;
					case "_TintColor":
						material.SetColor("_TintColor", reader.Read<Color>());
						break;
					case "_WavingTint":
						material.SetColor("_WavingTint", reader.Read<Color>());
						break;
					case "_WaveAndDistance":
						material.SetVector("_WaveAndDistance", reader.Read<Vector4>());
						break;
					case "_LightTexture0":
						material.SetTexture("_LightTexture0", reader.Read<Texture>());
						break;
					case "_LightTexture0_TextureOffset":
						material.SetTextureOffset("_LightTexture0_TextureOffset", reader.Read<Vector2>());
						break;
					case "_LightTexture0_TextureScale":
						material.SetTextureScale("_LightTexture0_TextureScale", reader.Read<Vector2>());
						break;
					case "_LightTextureB0":
						material.SetTexture("_LightTextureB0", reader.Read<Texture>());
						break;
					case "_LightTextureB0_TextureOffset":
						material.SetTextureOffset("_LightTextureB0_TextureOffset", reader.Read<Vector2>());
						break;
					case "_LightTextureB0_TextureScale":
						material.SetTextureScale("_LightTextureB0_TextureScale", reader.Read<Vector2>());
						break;
					case "_ShadowMapTexture":
						material.SetTexture("_ShadowMapTexture", reader.Read<Texture>());
						break;
					case "_ShadowMapTexture_TextureOffset":
						material.SetTextureOffset("_ShadowMapTexture_TextureOffset", reader.Read<Vector2>());
						break;
					case "_ShadowMapTexture_TextureScale":
						material.SetTextureScale("_ShadowMapTexture_TextureScale", reader.Read<Vector2>());
						break;
					case "_SecondTex":
						material.SetTexture("_SecondTex", reader.Read<Texture>());
						break;
					case "_SecondTex_TextureOffset":
						material.SetTextureOffset("_SecondTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_SecondTex_TextureScale":
						material.SetTextureScale("_SecondTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_ThirdTex":
						material.SetTexture("_ThirdTex", reader.Read<Texture>());
						break;
					case "_ThirdTex_TextureOffset":
						material.SetTextureOffset("_ThirdTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_ThirdTex_TextureScale":
						material.SetTextureScale("_ThirdTex_TextureScale", reader.Read<Vector2>());
						break;
					case "PixelSnap":
						material.SetFloat("PixelSnap", reader.Read<float>());
						break;
					case "_RendererColor":
						material.SetColor("_RendererColor", reader.Read<Color>());
						break;
					case "_Flip":
						material.SetVector("_Flip", reader.Read<Vector4>());
						break;
					case "_AlphaTex":
						material.SetTexture("_AlphaTex", reader.Read<Texture>());
						break;
					case "_AlphaTex_TextureOffset":
						material.SetTextureOffset("_AlphaTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_AlphaTex_TextureScale":
						material.SetTextureScale("_AlphaTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_EnableExternalAlpha":
						material.SetFloat("_EnableExternalAlpha", reader.Read<float>());
						break;
					case "_Level":
						material.SetFloat("_Level", reader.Read<float>());
						break;
					case "_SpecGlossMap":
						material.SetTexture("_SpecGlossMap", reader.Read<Texture>());
						break;
					case "_SpecGlossMap_TextureOffset":
						material.SetTextureOffset("_SpecGlossMap_TextureOffset", reader.Read<Vector2>());
						break;
					case "_SpecGlossMap_TextureScale":
						material.SetTextureScale("_SpecGlossMap_TextureScale", reader.Read<Vector2>());
						break;
					case "_FrontTex":
						material.SetTexture("_FrontTex", reader.Read<Texture>());
						break;
					case "_FrontTex_TextureOffset":
						material.SetTextureOffset("_FrontTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_FrontTex_TextureScale":
						material.SetTextureScale("_FrontTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_BackTex":
						material.SetTexture("_BackTex", reader.Read<Texture>());
						break;
					case "_BackTex_TextureOffset":
						material.SetTextureOffset("_BackTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_BackTex_TextureScale":
						material.SetTextureScale("_BackTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_LeftTex":
						material.SetTexture("_LeftTex", reader.Read<Texture>());
						break;
					case "_LeftTex_TextureOffset":
						material.SetTextureOffset("_LeftTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_LeftTex_TextureScale":
						material.SetTextureScale("_LeftTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_RightTex":
						material.SetTexture("_RightTex", reader.Read<Texture>());
						break;
					case "_RightTex_TextureOffset":
						material.SetTextureOffset("_RightTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_RightTex_TextureScale":
						material.SetTextureScale("_RightTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_UpTex":
						material.SetTexture("_UpTex", reader.Read<Texture>());
						break;
					case "_UpTex_TextureOffset":
						material.SetTextureOffset("_UpTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_UpTex_TextureScale":
						material.SetTextureScale("_UpTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_DownTex":
						material.SetTexture("_DownTex", reader.Read<Texture>());
						break;
					case "_DownTex_TextureOffset":
						material.SetTextureOffset("_DownTex_TextureOffset", reader.Read<Vector2>());
						break;
					case "_DownTex_TextureScale":
						material.SetTextureScale("_DownTex_TextureScale", reader.Read<Vector2>());
						break;
					case "_Metallic0":
						material.SetFloat("_Metallic0", reader.Read<float>());
						break;
					case "_Metallic1":
						material.SetFloat("_Metallic1", reader.Read<float>());
						break;
					case "_Metallic2":
						material.SetFloat("_Metallic2", reader.Read<float>());
						break;
					case "_Metallic3":
						material.SetFloat("_Metallic3", reader.Read<float>());
						break;
					case "_Smoothness0":
						material.SetFloat("_Smoothness0", reader.Read<float>());
						break;
					case "_Smoothness1":
						material.SetFloat("_Smoothness1", reader.Read<float>());
						break;
					case "_Smoothness2":
						material.SetFloat("_Smoothness2", reader.Read<float>());
						break;
					case "_Smoothness3":
						material.SetFloat("_Smoothness3", reader.Read<float>());
						break;
					case "_TexA":
						material.SetTexture("_TexA", reader.Read<Texture>());
						break;
					case "_TexA_TextureOffset":
						material.SetTextureOffset("_TexA_TextureOffset", reader.Read<Vector2>());
						break;
					case "_TexA_TextureScale":
						material.SetTextureScale("_TexA_TextureScale", reader.Read<Vector2>());
						break;
					case "_TexB":
						material.SetTexture("_TexB", reader.Read<Texture>());
						break;
					case "_TexB_TextureOffset":
						material.SetTextureOffset("_TexB_TextureOffset", reader.Read<Vector2>());
						break;
					case "_TexB_TextureScale":
						material.SetTextureScale("_TexB_TextureScale", reader.Read<Vector2>());
						break;
					case "_value":
						material.SetFloat("_value", reader.Read<float>());
						break;
					case "_Texel":
						material.SetFloat("_Texel", reader.Read<float>());
						break;
					case "_Detail":
						material.SetTexture("_Detail", reader.Read<Texture>());
						break;
					case "_Detail_TextureOffset":
						material.SetTextureOffset("_Detail_TextureOffset", reader.Read<Vector2>());
						break;
					case "_Detail_TextureScale":
						material.SetTextureScale("_Detail_TextureScale", reader.Read<Vector2>());
						break;
					case "_HalfOverCutoff":
						material.SetFloat("_HalfOverCutoff", reader.Read<float>());
						break;
					default:
						reader.Skip();
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}
}
