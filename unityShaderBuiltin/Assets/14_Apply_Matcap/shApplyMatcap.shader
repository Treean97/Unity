/*
    Matcap : Material Capture
    �̹��� ��� ����Ʈ ���

    ������ ������ ������ �ִ� ��ó�� �䳻���� ��(������ ����)
    ���� �����͸� ������� �Ѵ�
    
    vs diffuse warp
         : N dot L, ������ �ִ�

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
            float3 worldNormal; // ���庯ȯ���� ����� ��������
            float2 uv_BumpMap; // �븻���� uv��ǥ ����

            INTERNAL_DATA   // WorldNormalVector or WorldReflectionVector�� ����ϱ� ���� ���

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
            // ���� ��ȯ�� ����� ���� ������
            //float2 tMatcapUV = IN.worldNormal.xy * 0.5 + 0.5;   // [-1,1] -> [0,1]

            //// matcap texture���� ������ �ؼ��� ���ø�
            //fixed4 tMatcapColor = tex2D(_MapcapTex, tMatcapUV);
            
            //o.Emission = c.rgb * tMatcapColor;  // main texture ����� matcap ������ ����, ���� ���� ����

            //// o.Albedo = c.rgb;
            //o.Alpha = c.a;


            // step_1
            //// �亯ȯ���� ����� ���� ������
            //float3 tViewNormal = mul(UNITY_MATRIX_V, IN.worldNormal);

            //float2 tMatcapUV = tViewNormal * 0.5 + 0.5;   // [-1,1] -> [0,1]

            //// matcap texture���� ������ �ؼ��� ���ø�
            //fixed4 tMatcapColor = tex2D(_MapcapTex, tMatcapUV);
            
            //o.Emission = c.rgb * tMatcapColor;  // main texture ����� matcap ������ ����, ���� ���� ����

            //// o.Albedo = c.rgb;
            //o.Alpha = c.a;

            // step_2
            
            o.Normal = UnpackNormal(tex2D(_NormalTex, IN.uv_BumpMap));

            float3 tWorldNormal = WorldNormalVector(IN, o.Normal);

            float3 tViewNormal = mul(UNITY_MATRIX_V, tWorldNormal);
            float2 tMatcapUV = tViewNormal.xy * 0.5 + 0.5;   // [-1,1] -> [0,1]

            // matcap texture���� ������ �ؼ��� ���ø�
            fixed4 tMatcapColor = tex2D(_MapcapTex, tMatcapUV);
            
            o.Emission = c.rgb * tMatcapColor;  // main texture ����� matcap ������ ����, ���� ���� ����

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
