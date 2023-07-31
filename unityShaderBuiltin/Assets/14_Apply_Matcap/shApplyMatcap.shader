/*
    Matcap : Material Capture
    이미지 기반 라이트 기법

    조명이 없지만 조명이 있는 것처럼 흉내내는 것(연산이 적다)
    법선 데이터를 기반으로 한다
    
    vs diffuse warp
         : N dot L, 조명이 있다

*/

Shader "Custom/shApplyMatcap"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _MapcapTex ("Matcap Texture", 2D) = "white" {}
        _NormalTex ("Normal Texture", 2D) = "white" {}
       
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _MapcapTex;
        sampler2D _NormalTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal; // 월드변환까지 적용된 법선벡터
            float2 uv_BumpMap; // 노말맵의 uv좌표 정보

            INTERNAL_DATA   // WorldNormalVector or WorldReflectionVector를 사용하기 위해 명시

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
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);


            // step_0
            // 월드 변환만 적용된 법선 데이터
            //float2 tMatcapUV = IN.worldNormal.xy * 0.5 + 0.5;   // [-1,1] -> [0,1]

            //// matcap texture에서 임의의 텍셀을 샘플링
            //fixed4 tMatcapColor = tex2D(_MapcapTex, tMatcapUV);
            
            //o.Emission = c.rgb * tMatcapColor;  // main texture 색상과 matcap 색상의 결합, 색상 곱셈 연산

            //// o.Albedo = c.rgb;
            //o.Alpha = c.a;


            // step_1
            //// 뷰변환까지 적용된 법선 데이터
            //float3 tViewNormal = mul(UNITY_MATRIX_V, IN.worldNormal);

            //float2 tMatcapUV = tViewNormal * 0.5 + 0.5;   // [-1,1] -> [0,1]

            //// matcap texture에서 임의의 텍셀을 샘플링
            //fixed4 tMatcapColor = tex2D(_MapcapTex, tMatcapUV);
            
            //o.Emission = c.rgb * tMatcapColor;  // main texture 색상과 matcap 색상의 결합, 색상 곱셈 연산

            //// o.Albedo = c.rgb;
            //o.Alpha = c.a;

            // step_2
            
            o.Normal = UnpackNormal(tex2D(_NormalTex, IN.uv_BumpMap));

            float3 tWorldNormal = WorldNormalVector(IN, o.Normal);

            float3 tViewNormal = mul(UNITY_MATRIX_V, tWorldNormal);
            float2 tMatcapUV = tViewNormal.xy * 0.5 + 0.5;   // [-1,1] -> [0,1]

            // matcap texture에서 임의의 텍셀을 샘플링
            fixed4 tMatcapColor = tex2D(_MapcapTex, tMatcapUV);
            
            o.Emission = c.rgb * tMatcapColor;  // main texture 색상과 matcap 색상의 결합, 색상 곱셈 연산

            // o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        // custom light model function
        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {
            return float4(0,0,0,1);
        }

        ENDCG
    }
    FallBack "Diffuse"
}
