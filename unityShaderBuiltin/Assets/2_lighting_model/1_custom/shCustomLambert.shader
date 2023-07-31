/*
    i) surface shader���� ������� ���������� 'Custom Light ���� ����� ���'�� ���캸��.
        <-- surface shader�� ���� ���̶� �����ؼ� ���� �۵��ϴ� ���̴�

        ��) ����� ����ü�� ���Ǹ� ����

        ��) Ŀ���� ����Ʈ �Լ��� ���Ǹ� �����

        ��) ���̴� ������ �ɼ� ������ �� Ŀ���� ����Ʈ �Լ� ����� �����Ѵ�


    ii) Lambert ���� ��
    : �������Ϳ� �������� ������ �̿��Ͽ� ������ �����ϴ� �����

        N dot L
        
        Normal Vector
        Light Vector

    ii) ��� ���̴� �Լ� ���캸��


    iv) ���̴� �ڵ忡���� �Ǵ�������� �����Ѵ�( �ǵ��� ���� �ʵ��� �Ѵ� )
    <-- �ֳ��ϸ�, GPU�� CPU�� �޸� �������� ��ɾ� ó�� ���μ����� �ƴϱ� �����̴�.
            �׷��� '�б�'�� �� �ڵ��� ���࿡ �������� �ʴ�

            CPU: '��ɾ�'�� ó���ϱ� ���� ������� �������� ���μ���
            GPU: �����ð��� �����͸� �뷮���� ó���ϱ� ���� ������� Ư��ȭ�� ���μ���

*/

Shader "Ryu/shCustomLambert"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf RyuLambert//Standard fullforwardshadows
        //#pragma surface surf RyuLambertEdge 
        #pragma surface surf RyuLambertEdgeAdv 
        //<----custom light model�� ������ش�.

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;
        
        struct Input
        {
            float2 uv_MainTex;
        };//<--������ ���������ο��� �Ѿ�� ���鿡 ���� ����ü �� �����ϴ� ���̴�.

        //half _Glossiness;
        //half _Metallic;
        fixed4 _Color;



        struct SurfaceOutputRyuLambert {
            fixed3 Albedo;
            fixed3 Normal;
            fixed3 Emission;
            half Specular;
            fixed Gloss;
            fixed Alpha;
        };


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        //void surf (Input IN, inout SurfaceOutputStandard o)
        //<---- ����ü ������ �����ش�.
        void surf(Input IN, inout SurfaceOutputRyuLambert o)
        {
            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        
        //step_0
        //custom lighting model
        //���� �� �Լ�: ����(��)�� ���� ó���� �����ϴ� ���̴� �Լ� �� ����
        //Lighting~ ���·� �̸��� ���߾�� �Ѵ�.
        //<--�Ŵ��� ���۹���� �����Ƿ� ���캸�� ���߸� �ȴ�.
        //lightDir: ������
        //viewDir:�ü�����
        //tAtten: ����
        inline fixed4 LightingRyuLambert(SurfaceOutputRyuLambert s, fixed3 lightDir, half3 viewDir, fixed tAtten)
        {
            fixed4 tResult;

            fixed tDot = dot(s.Normal, lightDir);//N dot L      [-1, 1]�� ��
            fixed tDotResult = max(0, tDot); //[0,1]�� ��

            tResult.rgb = s.Albedo*tDotResult;      //ǥ���� ���� ���� ����, ������� ����
            tResult.a = s.Alpha;

            return tResult;
        }

        //step_1
        //�Ǵ�������� ����غ���
        inline fixed4 LightingRyuLambertEdge(SurfaceOutputRyuLambert s, fixed3 lightDir, half3 viewDir, fixed tAtten)
        {
            fixed4 tResult;

            fixed tDot = dot(s.Normal, lightDir);//N dot L      [-1, 1]�� ��
            fixed tDotResult = max(0, tDot); //[0,1]�� ��

            //�Ǵ������
            //<-- ��谡 ��Ȯ�� ���̵��� �����ϱ� ���� ���
            if (tDotResult < 0.2)
            {
                tResult.rgb = 0;
            }
            else
            {
                tResult.rgb = s.Albedo * tDotResult;      //ǥ���� ���� ���� ����, ������� ����
            }

            tResult.a = s.Alpha;

            return tResult;
        }

        //step_2
        inline fixed4 LightingRyuLambertEdgeAdv(SurfaceOutputRyuLambert s, fixed3 lightDir, half3 viewDir, fixed tAtten)
        {
            fixed4 tResult;

            fixed tDot = dot(s.Normal, lightDir);//N dot L      [-1, 1]�� ��
            fixed tDotResult = max(0, tDot); //[0,1]�� ��

            //�Ǵ�������� ����Ͽ� step���̴� �Լ��� ���
            // step(y,x) <------ x>=y?1:0
            //<-- ��谡 ��Ȯ�� ���̵��� �����ϱ� ���� ���
            fixed tStep = step(0.2, tDotResult)* tDotResult;    //tDotResult>=0.2?1:0

            tResult.rgb = s.Albedo * tStep;
            tResult.a = s.Alpha;

            return tResult;
        }



        ENDCG
    }
    FallBack "Diffuse"
}
