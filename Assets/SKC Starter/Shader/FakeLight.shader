Shader "SKC/Mobile/FakeLighting"
{
    Properties
    {
      _Color("Color", Color) = (1,1,1,1)
      _Brightness("Brightness", Range(0,1)) = 0.4
      _MainTex("Albedo (RGB)", 2D) = "white" {}
    }

        SubShader
    {
      Tags { "RenderType" = "Opaque" }
      LOD 200
      Pass
      {
        CGPROGRAM

        // Define name of vertex shader
        #pragma vertex vert
        // Define name of fragment shader
        #pragma fragment frag

        // Include some common helper functions, such as UnityObjectToClipPos
        #include "UnityCG.cginc"

        float4 _Color;
        float _Brightness;

        // Color Diffuse Map
        sampler2D _MainTex;
        // Tiling/Offset for _MainTex, used by TRANSFORM_TEX in vertex shader
        float4 _MainTex_ST;

        // This is the vertex shader input: position, UV0, UV1, normal
        struct appdata
        {
          float4 vertex   : POSITION;
          float2 texcoord : TEXCOORD0;
          float3 normal: NORMAL;
        };

        // This is the data passed from the vertex to fragment shader
        struct v2f
        {
          float4 pos  : SV_POSITION;
          float2 txuv : TEXCOORD0;
          float3 normalDir : TEXCOORD2;
        };

        // This is the vertex shader
        v2f vert(appdata v)
        {
          v2f o;
          o.pos = UnityObjectToClipPos(v.vertex);
          o.txuv = TRANSFORM_TEX(v.texcoord.xy,_MainTex);

          // Calculating normal so it can be used for fake lighting
          // in the fragment shader
          float4x4 modelMatrixInverse = unity_WorldToObject;
          o.normalDir = normalize(mul(float4(v.normal, 0.0), modelMatrixInverse).xyz);

          return o;
        }

        // This is the fragment shader
        half4 frag(v2f i) : COLOR
        {
            // Reading color from diffuse texture
            half4 col = tex2D(_MainTex, i.txuv.xy);

            // Using hard-coded light direction for fake lighting
            half3 th = normalize(half3(0.25, 1, -0.25));
            // Using hard-coded light direction for fake specular
            // This matches the value inside the LightmappedPrefabWithSpec shader
            half3 sth = normalize(half3(0, 1, -0.25));

            // Fake lighting
            float lightVal = max(0, dot(i.normalDir, th));
            float lightScale = 0.75;
            lightVal = lightVal * lightScale;

            // Fake spec
            float spec = max(0, dot(i.normalDir, sth));
            float specScale = 0.65;
            float specAtt = 0.65;
            spec = specScale * pow(spec, 40.0 * specAtt);

            // Add in a general brightness (similar to ambient/gamma) and then
            // calculate the final color of the pixel
            col.rgb = min(half4(1,1,1,1), col.rgb * _Brightness +
                          col.rgb * lightVal * _Color + col.rgb * spec);
            return col;
          }

          ENDCG
        }
    }
        FallBack "Diffuse"
}