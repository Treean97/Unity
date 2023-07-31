/*
    Dissolve Effect

    ������ Ÿ���� ȿ��

    1)main texture
    2)������ �������� ����
    3)Noise Texture(�ұ�Ģ�� ������ ���� �ؽ�ó �̹��� ������)
    4)��踦 ��Ȯ�� �Ͽ� ���̰� �Ⱥ��̰� ������ �и��Ѵ�. ���ĺ���

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
        sampler2D _NoiseTex;    // ������ ������ ���� �ؽ�ó

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NoiseTex; // ������ �ؽ�ó�� uv��ǥ ����
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

            // �ұ�Ģ ������ ������ ���� ���
            fixed4 tNoise = tex2D(_NoiseTex, IN.uv_NoiseTex);

            float tAlpha = 0;
            // ��踦 ��Ȯ�� �����Ͽ� ���İ��� �����Ѵ�
            // �ؽ�ó���̹Ƿ� �񱳱��� r,g,b�� �ƹ��ų� �������
            tAlpha = step(0.2, tNoise.r);   // tNoise.r >= 0.5 ? 1 : 0

            o.Alpha = tAlpha;
            //o.Alpha = c.a;
            //o.Alpha = 0.5;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
