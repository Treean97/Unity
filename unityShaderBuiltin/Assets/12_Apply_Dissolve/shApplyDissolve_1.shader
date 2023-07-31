/*
    Dissolve Effect

    서서히 타들어가는 효과

    1)main texture
    2)반투명 렌더모드로 설정
    3)Noise Texture(불규칙한 패턴을 갖는 텍스처 이미지 데이터)
    4)경계를 명확히 하여 보이고 안보이고 영역을 분리한다. 알파블랜드

*/


Shader "Custom/shApplyDissolve_1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _NoiseTex ("Noise Texture", 2D) = "white" {}

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _NoiseTex;    // 노이즈 정보를 위한 텍스처

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NoiseTex; // 노이즈 텍스처의 uv좌표 정보
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
            o.Albedo = c.rgb;

            // 불규칙 패턴의 노이즈 정보 얻기
            fixed4 tNoise = tex2D(_NoiseTex, IN.uv_NoiseTex);

            float tAlpha = 0;
            // 경계를 명확히 설정하여 알파값을 결정한다
            // 텍스처백이므로 비교군이 r,g,b중 아무거나 상관없다
            tAlpha = step(0.2, tNoise.r);   // tNoise.r >= 0.5 ? 1 : 0

            o.Alpha = tAlpha;
            //o.Alpha = c.a;
            //o.Alpha = 0.5;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
