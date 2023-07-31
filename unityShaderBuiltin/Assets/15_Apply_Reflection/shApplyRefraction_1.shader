Shader "Custom/shApplyReflection_1"
{
    Properties
    {
       
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        GrabPass{}  // 스크린 화면 캡춰 명령문

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _GrabTexture; // GrabPass 한 데이터를 이 텍스처에 담는다

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)



        void surf (Input IN, inout SurfaceOutput o)
        {
            // 스크린의 좌표를 관찰하기 위해 색상값으로 다뤄보았다
            // 색상도 수치, 스크린 좌표도 수치
            o.Emission = IN.screenPos.rgb;
            
        }        

        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {

            return float4(0,0,0,1);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
