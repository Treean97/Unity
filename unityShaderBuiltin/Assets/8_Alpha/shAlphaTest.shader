/*
    AlphaTest

    ������ ���ذ��� ���İ��� ����
    �ش� ���ذ� �̸��̸�
    �ȼ��� ĥ���� �ʰ�
    �̻�����
    �ȼ��� ĥ�Ѵ�

    AlphaTest ����ť�� �־��� ��
    �� -> ��
    ���ĵǾ� �־�����

    �ֳ��ϸ� ������ �������� �κ��� ĥ�ϴ� �����
    Opaque�� ���� �����̴�
    ������ �κ��� �ƿ� ĥ���� �����Ƿ� �������

*/

Shader "Custom/shAlphaTest"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
    }
    SubShader
    {
        // Tags { "RenderType"="Opaque" }
        // �������� TransparentCutout
        // ����ť�� AlphaTest
        Tags { "RenderType"="TransparentCutout" "Queue"="AlphaTest" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        // alphatest : _Cutoff �ش� ���ذ��� ���� alphatest������ ��������
        #pragma surface surf Standard fullforwardshadows alphatest:_Cutoff


        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };


        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            // o.Alpha = 0.7;
            // o.Alpha = 0.5;
            o.Alpha = c.a;
        }
        ENDCG
    }
    //FallBack "Diffuse"
    // alphatest�̹Ƿ� ������ �̰����� �Ѵ�
    FallBack "Legacy Shaders/Transparent/Cutout/VertexLit"

}
