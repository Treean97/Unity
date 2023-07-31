/*
    Alpha Blend를 제어하는 옵션

    Blend Factor의 종류

    One 1
    Zero 0

    SrcColor 소스의 컬러
    SrcAlpha 소스의 알파

    DstColor 배경의 컬러
    DstAlpha 배경의 알파

    OneMinusSrcColor 1 - 소스의 컬러
    OneMinusSrcAlpha 1 - 소스의 알파

    OneMinusDstColor 1 - 배경의 컬러
    OneMinusDstAlpha 1 - 배경의 알파

 주요한 매뉴얼 추천 조합
    
    Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency
    Blend SrcAlpha One              // Additive
    Blend One One                   // Additive No Alpha, Black is Transparent
    Blend DstColor Zero             // Multiplicative
    Blend DstColor SrcColor         // 2x Multiplicaative


*/


Shader "Custom/shCustomAlphaBlend_0"
{
    Properties
    {
        
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        LOD 200

        zwrite off

        Blend SrcAlpha OneMinusSrcAlpha
        // <- SRCCOLOR*0.3 + DSTCOLOR(1-0.3) = SRCCOLOR*0.3 + DSTCOLOR*0.7
        // 원본의 색상값 0.3 비율, 배경의 색상값 0.7 비율로 결정

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
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

            o.Alpha = c.a;
        }
        ENDCG
    }
    //FallBack "Diffuse"
    FallBack "Legacy Shaders/Transparent/VertexLit"

}
