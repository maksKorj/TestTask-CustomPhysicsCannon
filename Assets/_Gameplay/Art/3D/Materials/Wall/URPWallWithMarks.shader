Shader "Custom/URPWallWithMarks"
{
    Properties
    {
        _BaseMap ("Base Texture", 2D) = "white" {}      // Base texture of the wall
        _RenderTex ("Render Texture", 2D) = "white" {}  // Texture where marks will be drawn
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 200
        
        // This is the pass where the actual work is done (blending the textures)
        Pass
        {
            Tags { "LightMode"="UniversalForward" }

            // Ensure proper blending for transparency
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On
            ZTest LEqual

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            // Define input structure
            struct Attributes
            {
                float4 positionOS : POSITION; // Object space position
                float2 uv : TEXCOORD0;       // UV coordinates
            };

            // Define output structure for the fragment shader
            struct Varyings
            {
                float4 positionHCS : SV_POSITION; // Homogeneous clip space position
                float2 uv : TEXCOORD0;           // Interpolated UV coordinates
            };

            // Texture samplers for base texture and render texture
            TEXTURE2D(_BaseMap);      // Base texture of the wall
            SAMPLER(sampler_BaseMap);

            TEXTURE2D(_RenderTex);    // Render texture where marks are drawn
            SAMPLER(sampler_RenderTex);

            // Vertex shader
            Varyings vert(Attributes v)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(v.positionOS);
                o.uv = v.uv;  // Pass the UV coordinates directly to fragment shader
                return o;
            }

            // Fragment shader
            half4 frag(Varyings i) : SV_Target
            {
                // Sample the base texture (wall texture)
                half4 baseColor = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, i.uv);

                // Sample the render texture (marks texture)
                half4 markColor = SAMPLE_TEXTURE2D(_RenderTex, sampler_RenderTex, i.uv);

                // Blend the base color with the mark texture using the alpha of the mark texture
                return lerp(baseColor, markColor, markColor.a);
            }

            ENDHLSL
        }
    }

    // Fallback for when this shader cannot be used
    Fallback "Diffuse"
}