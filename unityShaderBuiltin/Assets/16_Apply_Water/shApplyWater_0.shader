/*
    물을 표현하는 재질

    하늘이 반사되는 느낌의 반사맵을 구현(큐브맵을 이용)

*/

Shader "Custom/shApplyWater_0"
{
    Properties
    {
        _Cube("Cube Map", Cube) = "" {}
        _BumpMap("Bump Map", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        samplerCUBE _Cube;
        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float3 worldRefl;   // 반사벡터정보

            INTERNAL_DATA   // WorldReflectionVector를 사용하기 위해 표기
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //o.Albedo = c.rgb;
            //o.Alpha = c.a;

            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

            // o.Normal = float3(0,0,1);

            float3 tReflectColor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));

            o.Albedo = 0;
            o.Emission = tReflectColor;
            o.Alpha = 0.5;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
