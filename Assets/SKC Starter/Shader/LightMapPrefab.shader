Shader "SKC/Mobile/LightmappedPrefabWithSpec"
{
    Properties
    {
      _MainTex("Base (RGB)", 2D) = "white" {}
      _Lightmap("Lightmap", 2D) = "white" {}
      _Specmap("Specmap", 2D) = "white" {}
      _SpecularAtt("Glossiness", Range(0.1, 2)) = 0.5
      _SpecularAmt("Specular", Range(0, 1)) = 0.5
    }

        SubShader
      {
        Tags{ "Queue" = "Geometry+1" }
        Pass
        {
          CGPROGRAM

          // Defining the name of the vertex shader
          #pragma vertex vert

          // Defining the name of the fragment shader
          #pragma fragment frag

          // Include some common helper functions,
          // specifically UnityObjectToClipPos and DecodeLightmap.
          #include "UnityCG.cginc"

          // Color Diffuse Map
          sampler2D _MainTex;
      // Tiling/Offset for _MainTex, used by TRANSFORM_TEX in vertex shader
      float4 _MainTex_ST;

      // Lightmap (created via Unity Lightbaking)
      sampler2D _Lightmap;
      // Tiling/Offset for _Lightmap, used by TRANSFORM_TEX in vertex shader
      float4 _Lightmap_ST;

      // Grayscale Map indicating which parts of the models have specular
      // Note: _Specmap_ST is not needed, as this map is using the same 
      // UVs as for the _MainTex.
      sampler2D _Specmap;

      // This is the vertex shader input: position, UV0, UV1, normal
      // UV1 (= second UV channel) needed for the lightmap texture coordinates
      struct appdata
      {
        float4 vertex   : POSITION;
        float2 texcoord : TEXCOORD0;
        float2 texcoord1: TEXCOORD1;
        float3 normal: NORMAL;
      };

      // This is the data passed from the vertex to fragment shader
      struct v2f
      {
        float4 pos  : SV_POSITION; // position of the pixel
        float2 txuv : TEXCOORD0; // for accessing the diffuse color map
        float2 lmuv : TEXCOORD1; // for accessing the light map
        float3 normalDir : TEXCOORD2; // for fake specular
      };

      // This is the vertext shader, doing nothing special at all.
      // Most notably it is calculating the surface normal, because that
      // is needed for the fake specular lighting in the fragment shader.
      v2f vert(appdata v)
      {
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);
        o.txuv = TRANSFORM_TEX(v.texcoord.xy, _MainTex); // using _MainTex_ST
        o.lmuv = TRANSFORM_TEX(v.texcoord1.xy, _Lightmap); // using _Lightmap_ST

        // Calculating the normal of the vertex for the fragment shader
        float4x4 modelMatrixInverse = unity_WorldToObject;
        o.normalDir = normalize(mul(float4(v.normal, 0.0), modelMatrixInverse).xyz);

        return o;
      }

      uniform float _SpecularAtt;
      uniform float _SpecularAmt;

      // Fragment Shader
      half4 frag(v2f i) : COLOR
      {
          // Reading color directly from the diffuse texture, using first UV channel
          half4 col = tex2D(_MainTex, i.txuv.xy);
          // Reading specular (on/off) value from spec map texture
          half4 specVal = tex2D(_Specmap, i.txuv.xy);
          // Reading lightmap value from the lightmap texture
          half4 lm = tex2D(_Lightmap, i.lmuv.xy);

          // Fake specular light angle calculation with a hard-coded light direction
          half3 th = normalize(half3(0, 1, -0.25));
          float spec = max(0, dot(i.normalDir, th));

          // Adjusting by overall specular amount and glossyness (material parameters)
          spec = _SpecularAmt * pow(spec, 40.0 * _SpecularAtt);
          // We're just using red value of the specular texture, like a grayscale map,
          // although technically spec could be colored.
          // Example: float3 specCol = specVal * spec;
          spec = spec * specVal.r;

          // Calculating the final color of the pixel by bringing it all together
          col.rgb = min(half4(1,1,1,1), col.rgb * DecodeLightmap(lm) + col.rgb * spec);
          return col;
        }
        ENDCG
      }
      }
          Fallback "Diffuse"
}