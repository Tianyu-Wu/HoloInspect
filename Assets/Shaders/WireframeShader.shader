// Upgrade NOTE: replaced 'UNITY_INSTANCE_ID' with 'UNITY_VERTEX_INPUT_INSTANCE_ID'

Shader "Assets/Shaders"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _Wireframe("Wireframe thickness", Range(0.0, 0.005)) = 0.0025
        _Transparency("Transparency", Range(0.0, 1)) = 0.5
        /*_MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0*/
    }
        SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Back

            CGPROGRAM
            #pragma vertex vertexFunction
            #pragma fragment fragmentFunction
            #pragma geometry geometryFunction
            #include "UnityCG.cginc"


            struct appdata {
                float4 vertex: POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };
            
            struct v2g
            {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };
            struct g2f
            {
                float4 pos : SV_POSITION;
                float3 bary : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };

            v2g vertexFunction(appdata v)
            {
                v2g o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            [maxvertexcount(3)]
            void geometryFunction(triangle v2g IN[3],
                inout TriangleStream<g2f> triStream)
            {
                g2f o;
                UNITY_SETUP_INSTANCE_ID(IN[0]);
                UNITY_TRANSFER_INSTANCE_ID(IN[0], o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.pos = IN[0].pos;
                o.bary = float3(1, 0, 0);
                triStream.Append(o);
                UNITY_SETUP_INSTANCE_ID(IN[1]);
                UNITY_TRANSFER_INSTANCE_ID(IN[1], o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.pos = IN[1].pos;
                o.bary = float3(0, 0, 1);
                triStream.Append(o);
                UNITY_SETUP_INSTANCE_ID(IN[2]);
                UNITY_TRANSFER_INSTANCE_ID(IN[2], o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.pos = IN[2].pos;
                o.bary = float3(0, 1, 0);
                triStream.Append(o);
            }

            float _Wireframe;
            fixed4 _Color;
            float _Transparency;
            UNITY_DECLARE_SCREENSPACE_TEXTURE(_MainTex);
            fixed4 fragmentFunction(g2f i) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(i);
                float value = min(i.bary.x, (min(i.bary.y, i.bary.z)));
                value = exp2(-1 / _Wireframe * value * value);
                fixed4 col = _Color;
                col.a = _Transparency;
                return col * value;
            }

            ENDCG

        }

    }
       
}
