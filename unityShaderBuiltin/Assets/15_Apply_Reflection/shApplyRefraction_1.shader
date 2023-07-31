Shader "Custom/shApplyReflection_1"
{
    Properties
    {
       
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        GrabPass{}  // ��ũ�� ȭ�� ĸ�� ��ɹ�

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _GrabTexture; // GrabPass �� �����͸� �� �ؽ�ó�� ��´�

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
            // ��ũ���� ��ǥ�� �����ϱ� ���� �������� �ٷﺸ�Ҵ�
            // ���� ��ġ, ��ũ�� ��ǥ�� ��ġ
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
