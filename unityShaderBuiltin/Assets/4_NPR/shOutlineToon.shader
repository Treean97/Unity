//Outline2Pass�� ToonShade�� �����غ�����.

Shader "Ryu/shOutlineToon"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)

        _OutlineColor("outline Color", Color) = (0,0,0,1)
        _OutlineWidth("outline width", Range(0.005,0.02)) = 0.01


        _ToonShadeLevel("toon shade level", Range(1,10)) = 5
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        cull front//���� �ø�, �ĸ鸸 ������

        //1 pass
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf NoLight noambient noshadow vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        //sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

    //half _Glossiness;
    //half _Metallic;
    fixed4 _Color;

    float4 _OutlineColor;
    fixed _OutlineWidth;


    struct SurfaceOutputNoLight {
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

        //vertex shader�Լ�
        void vert(inout appdata_full v)
        {
        //������ ��ġ v.vertex �� ������ �������� v.normal �������� �̵�
        v.vertex.xyz = v.vertex.xyz + v.normal.xyz * _OutlineWidth;//<--������ ��Į�����
        //<--������ ���� ����
}

    //void surf (Input IN, inout SurfaceOutputStandard o)
    void surf(Input IN, inout SurfaceOutputNoLight o)
    {
        // Albedo comes from a texture tinted by color
        fixed4 c = _Color;
        o.Albedo = c.rgb;

        o.Alpha = c.a;
    }
    //������ �������� �ʰڴ� 
    float4 LightingNoLight(SurfaceOutputNoLight s, float3 lightDir, float3 viewDir, float attenu)
    {
        return _OutlineColor;  //������, �� ������ �������� �ʰڴ� 
    }
    ENDCG



    cull back   //�ĸ� �ø�, ������ �������Ѵ�.

        //2 pass
        CGPROGRAM
        #pragma surface surf RyuToonShade//Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };
        fixed4 _Color;

        fixed _ToonShadeLevel;

        struct SurfaceOutputRyuToonShade {
            fixed3 Albedo;
            fixed3 Normal;
            fixed3 Emission;
            half Specular;
            fixed Gloss;
            fixed Alpha;
        };

        void surf(Input IN, inout SurfaceOutputRyuToonShade o)
        {
            fixed4 c = _Color;

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        float4 LightingRyuToonShade(SurfaceOutputRyuToonShade s, float3 lightDir, float3 viewDir, float atten)
        {
            float4 tResult = float4(0, 0, 0, 1);

            //Lambert lighting model
            float tDot = dot(s.Normal, lightDir);   //[-1,1]
            float tDotResult = saturate(tDot);      //[0,1]

            float tToonShade = tDotResult * _ToonShadeLevel;//[0,_ToonShadeLevel]       <-- ������ �ø�
            tToonShade = ceil(tToonShade);   //0, 1, 2, 3, 4, 5, ... 

            tToonShade = tToonShade / _ToonShadeLevel;            //[0,1]���̿� �ҿ������� �ܰ躰 ���� �����.

            tResult.rgb = s.Albedo * tToonShade;
            tResult.a = s.Alpha;

            return tResult;
        }
        ENDCG



}
FallBack "Diffuse"
}