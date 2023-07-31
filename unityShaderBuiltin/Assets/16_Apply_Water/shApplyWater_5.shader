/*
    step_5

    ����

    GrabPass
*/

Shader "Custom/shApplyWater_5"
{
    Properties
    {
        _Frequency("Wave Frequency", Range(30, 200)) = 30
        _Amplitude("Wave Amplitude", Range(0.1, 0.9)) = 0.1
        _Cube("Cube Map", Cube) = "" {}
        _BumpMap("Bump Map", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" = "Transparent"}
        LOD 200

        // ȭ�� ĸ��
        GrabPass{}

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:fade vertex:dovert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        // ȭ�� ĸ���� �ؽ�ó �̹��� ������
        sampler2D _GrabTexture;
        samplerCUBE _Cube;
        sampler2D _BumpMap;
        fixed _Frequency;
        fixed _Amplitude;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float3 worldRefl;   // �ݻ纤������
            float3 viewDir;

            float4 screenPos;   // ��ũ�� ��ǥ��

            INTERNAL_DATA   // WorldReflectionVector�� ����ϱ� ���� ǥ��
        };

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void dovert(inout appdata_full v)
        {
            // v.vertex.y += abs(v.texcoord.x * 2 - 1) * 30;
            /*
                UV�� U��[0,1]
                *2�ϸ� [0,2]
                -1�ϸ� [-1,1]

                abs�ϸ� [0,1] <- 1 ~ 0 ~ 1
                �̷��� ��ġ�� �����Ͽ� V���¸� �����  
                
                [0,30] <- 30 ~ 0 ~ 30
            */

            // sin(30) ~ sin(0) ~ sin(30)
            // v.vertex.y += sin(abs(v.texcoord.x * 2 - 1) * _Frequency) * _Amplitude;

            v.vertex.y += sin(abs(v.texcoord.x * 2 - 1) * _Frequency + _Time.y) * _Amplitude;
            
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            //o.Albedo = c.rgb;
            //o.Alpha = c.a;

            // �ݻ縦 ����
            //�ؼ��� ���ø��ϰ�, �������� ��ȯ�� ����
            // ����
            // o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

            // �������� �帣�� ����
            // uv animation�� normal map�� �����Ͽ� ���������͸� ����
            // ���� ��ũ�� �˰����� ���۸� ������ �������� �Ͼ�� �ִ� ������ ���� �ȴ�
            // o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap + _Time.y * 0.1));

            // ����
            // ���� �ݴ�������� �帣�� �ϰ� ���ؼ� ����
            // ������ �Ϸ��̴� ����
            float3 tNormal_0 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap + _Time.x * 0.1));
            float3 tNormal_1 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap - _Time.x * 0.1));

            o.Normal = (tNormal_0 + tNormal_1) / 2;

            // o.Normal = float3(0,0,1);
            float3 tReflectColor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));

            // ����
            // IN.screenPos.a �� ���̰� depth, �̰����� ������ �Ÿ��� ������� ������ ����� �������� ����
            float3 tScreenUV = IN.screenPos.rgb / IN.screenPos.a;   
            float tRefraction = tex2D(_GrabTexture, tScreenUV.xy);

            //o.Albedo = 0;
            //o.Emission = tReflectColor;
            //o.Alpha = 0.5;

            // ������ȿ�� ����(������Ʈ)
            float tRim = saturate(dot(o.Normal, IN.viewDir));
            tRim = 1 - tRim;
            tRim = pow(tRim, 3);

            o.Albedo = 0;
            o.Emission = tReflectColor * tRim * 1.2 + tRefraction * 0.6;  // �ݻ�� �������� ����
            // ��ġ����, ��ġ��������
            // �̸� ���� ���� �����ڸ��� ������ �����ݻ��Ͽ� (�������� �ʵ���)
            // �� ���� ��ġ�� �ʵ��� �����ϰ� �ִ�
            o.Alpha = saturate(tRim + 0.5);
            
            // IN.screenPos.a �� ���̰� depth, �̰����� ������ �Ÿ��� ������� ������ ����� �������� ����
            //float3 tScreenUV = IN.screenPos.rgb / IN.screenPos.a;   
            //float tRefraction = tex2D(_GrabTexture, tScreenUV.xy);

            //o.Albedo = 0;
            //o.Emission = tRefraction * tRim;
            //o.Alpha = 1;


        }
        ENDCG
    }
    FallBack "Diffuse"
}
