Shader "Custom/shTwinkle"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        // ���� ��ġ�̴�. �׷��Ƿ� ������ ������ �뵵�� ����� �����ϴ�
        // ������ ������ �����ϱ� ���� ������ �뵵�μ��� �ؽ�ó
        _MaskTex("Mask Tex", 2D) = "white" {}

        // �ұ�Ģ���� �ֱ⸦ ������ ��ȣ�� ������ �뵵�μ��� �ؽ�ó
        _RampTex("Ramp Tex", 2D) = "white" {}
        
        _Frequency("Frequency", Range(0,10)) = 0.1
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _MaskTex;
        sampler2D _RampTex;
        float _Frequency;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_MaskTex;
            float2 uv_RampTex;
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

            // ������ ���� ���� ������
            fixed4 tMask = tex2D (_MaskTex, IN.uv_MaskTex);

            // �ұ�Ģ���� �ֱ��� ������
            fixed4 tFrequency = tex2D(_RampTex, float2(_Time.y * _Frequency, 0.5));


            o.Albedo = c.rgb;
            // ������ ������ �ұ�Ģ���� �ֱ�� ������ ����
            o.Emission = c.rgb * tMask.r * tFrequency.r;

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
