/*
   flat shading
   gourad shading
   
   
   두번 렌더링(그리기)을 통해 외곽선을 표현하자.

    i) 다음과 같은 방법으로 렌더링한다.

        가) 전면컬링, 즉 후면을 그린다.( 뒤집어서 그린다 )
        나) 정점에 저장된 법선벡터 방향으로 정점을 이동시켜 확대?시킨다.
            <-- 정점 셰이더vertex shader 함수가 필요하다.

    ii) 정상적으로 렌더링한다

*/

Shader "Ryu/shOutline2Pass"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)

        _OutlineColor("outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("outline width", Range(0.005,0.02)) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        cull front//전면 컬링, 후면만 렌더링

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

        //vertex shader함수
        void vert(inout appdata_full v)
        {
            float4 tRyu = UnityObjectToClipPos(v.vertex);
            float tDepth = tRyu.w * 0.7;

            //정점의 위치 v.vertex 를 정점의 법선벡터 v.normal 방향으로 이동
            v.vertex.xyz = v.vertex.xyz + v.normal.xyz * _OutlineWidth * tDepth;//<--벡터의 스칼라곱셈
                //<--벡터의 덧셈 연산

        }

        //void surf (Input IN, inout SurfaceOutputStandard o)
        void surf(Input IN, inout SurfaceOutputNoLight o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = _Color;
            o.Albedo = c.rgb;
            
            o.Alpha = c.a;
        }
        //조명은 적용하지 않겠다 
        float4 LightingNoLight(SurfaceOutputNoLight s, float3 lightDir, float3 viewDir, float attenu)
        {
            return _OutlineColor;  //검정색, 즉 조명을 적용하지 않겠다 
        }
        ENDCG



        cull back   //후면 컬링, 전면을 렌더링한다.

        //2 pass
        CGPROGRAM
        #pragma surface surf Lambert//Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)        
        {
            fixed4 c = _Color;

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG



    }
    FallBack "Diffuse"
}
