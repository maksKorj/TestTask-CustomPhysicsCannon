Shader"Custom/URPWallWithMarks"
{
    Properties
    {
        _BaseMap("Base Texture", 2D) = "white" {}      // Base wall texture
        [HideInInspector] _BaseMap_ST("Base Texture Tiling", Vector) = (1,1,0,0) // Base texture tiling and offset

        _RenderTex("Render Texture (Marks)", 2D) = "white" {}  // Marks texture
        [HideInInspector] _RenderTex_ST("Render Texture Tiling", Vector) = (1,1,0,0) // Render texture tiling and offset
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry" }

        Pass
        {
            Tags { "LightMode" = "UniversalForward" }
            
            // Blending setup
Blend SrcAlpha

OneMinusSrcAlpha
            ZWrite

On
            ZTest

LEqual

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            // Vertex input structure
struct Attributes
{
    float4 positionOS : POSITION; // Object space position
    float2 uv : TEXCOORD0; // Original UV coordinates
};

            // Vertex output structure
struct Varyings
{
    float4 positionHCS : SV_POSITION; // Homogeneous clip space position
    float2 uvBase : TEXCOORD0; // UV coordinates for base texture
    float2 uvMark : TEXCOORD1; // UV coordinates for marks texture
};

            // Texture samplers
            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            TEXTURE2D(_RenderTex);
            SAMPLER(sampler_RenderTex);

            // Scaling and offset variables
float4 _BaseMap_ST; // Base map tiling and offset
float4 _RenderTex_ST; // Render texture tiling and offset

            // Vertex shader
Varyings vert(Attributes v)
{
    Varyings o;
    o.positionHCS = TransformObjectToHClip(v.positionOS);

                // Apply tiling and offset to UVs
    o.uvBase = TRANSFORM_TEX(v.uv, _BaseMap);
    o.uvMark = TRANSFORM_TEX(v.uv, _RenderTex);
    return o;
}

            // Fragment shader
half4 frag(Varyings i) : SV_Target
{
                // Sample base texture with tiling
    half4 baseColor = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, i.uvBase);

                // Sample marks texture with tiling
    half4 markColor = SAMPLE_TEXTURE2D(_RenderTex, sampler_RenderTex, i.uvMark);

                // Blend base color and mark color using the alpha of the mark texture
    return lerp(baseColor, markColor, markColor.a);
}

            ENDHLSL
        }
    }

    // Fallback for older systems
Fallback"Diffuse"
}
