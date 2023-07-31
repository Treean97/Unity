/*
Reflection

*/

Shader "Custom/shApplyReflection_3"
{
    Properties
    {
       _RefractionTex ("Refraction", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200

        GrabPass{}  // ��ũ�� ȭ�� ĸ�� ��ɹ�

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _GrabTexture; // GrabPass �� �����͸� �� �ؽ�ó�� ��´�
        sampler2D _RefractionTex;

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
            // o.Emission = IN.screenPos.rgb;

            // uv animation�� ��ġ ���μ� ������ �ؽ�ó �̹��� �����͸� ���
            float4 tRyu = tex2D(_RefractionTex, IN.uv_MainTex);

            float2 tScreenUV = IN.screenPos.rgb;
            // �ݺ����� ������ ������, �ð��� �帧�� ���� uv animation
            o.Emission = tex2D(_GrabTexture, tScreenUV.xy + tRyu.x * sin(_Time.y*2)*0.05);
            
        }        

        float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)
        {

            return float4(0,0,0,1);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
