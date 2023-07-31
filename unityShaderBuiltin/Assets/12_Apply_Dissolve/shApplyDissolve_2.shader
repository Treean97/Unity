/*
    Dissolve Effect

    서서히 타들어가는 효과

    1)main texture
    2)반투명 렌더모드로 설정
    3)Noise Texture(불규칙한 패턴을 갖는 텍스처 이미지 데이터)
    4)경계를 명확히 하여 보이고 안보이고 영역을 분리한다. 알파블랜드
    5)경계를 좀 더 크게 조정하여 더 넓은 범위를 확보한다
    6) 5)의 영역은 Emission으로 처리한다
    7) 최종적으로는 Albedo, Emission, Alpha의 성분들이 결합되어 dissolve효과를 만든다
        Albedo 물체의 원래 외관
        Emission 타들어가는 가장자리
        Alpha 보이는, 안보이는(타들어가서 안보이는) 영역 표현


*/


Shader "Custom/shApplyDissolve_2"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _NoiseTex ("Noise Texture", 2D) = "white" {}

        _Cut("Edge Cut", Range(0.01, 1)) = 0.01
        _OutlineWidth("Outline Width", Range(1, 2)) = 1
        _OutlineColor("Outline Color", Color) = (1,1,1,1)
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
        fixed _Cut;
        fixed _OutlineWidth;
        fixed4 _OutlineColor;

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
            tAlpha = step(_Cut, tNoise.r);   // tNoise.r >= 0.5 ? 1 : 0

            o.Alpha = tAlpha;
            //o.Alpha = c.a;
            //o.Alpha = 0.5;

            // 가장자리 경계의 타들어가는 부분
            float tOutline = 1 - step(_Cut * _OutlineWidth, tNoise.r);
            o.Emission = tOutline * _OutlineColor;


        }
        ENDCG
    }
    FallBack "Diffuse"
}
