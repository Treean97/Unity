/*
    Shader �Լ�

*/

Shader "Unlit/shUnlitEdge"
{
    Properties
    {
        _Color("Color", Color) = (1,0,0,0)
        _EdgeColor ("Edge Color", Color) = (0,1,0,1)

        _Width("Edge Width", Range(0.01,0.9)) = 0.1

        //_MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // Tags { "RenderType"="Opaque" }
        Tags{"RanderType" = "Transparent" "Queue" = "Transparent"}
        // "RenderType" = "Transparent" : ������� ������
        // "Queue" = "Transparent" ����ť�� Transparent ���

        LOD 100

        Pass
        {
            Cull Off

            Blend SrcAlpha OneMinusSrcAlpha
            // blend factor�� ��������
            // SRCCOLOR * SrcAlpha + DSTCOLOR * OneMinusSrcAlpha


            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;


            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            float4 _MainTex_ST;

            fixed4 _Color;
            fixed4 _EdgeColor;
            fixed _Width;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;    // uv��ǥ�� ���� �ܰ迡 ����
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 col = fixed4(0,0,0,1);
               
                float tLowX = step(_Width, i.uv.x);     // i.uv.x >= _Width ? 1 : 0
                float tLowY = step(_Width, i.uv.y);     // i.uv.y >= _Width ? 1 : 0

                float tHighX = step(i.uv.x, 1 - _Width);    // 1 - _Width >= i.uv.x ? 1 : 0
                float tHighY = step(i.uv.y, 1 - _Width);    // 1 - _Width >= i.uv.y ? 1 : 0

                // ��������
                // col = lerp(_EdgeColor, _Color, tLowX);
                col = lerp(_EdgeColor, _Color, tHighX * tHighY * tLowX * tLowY);

                return col;
            }
            ENDCG
        }
    }
}
