Shader "Unlit/Water"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Amplitud ("Amplitud", Range(-10,10)) = 1
        _Periodicity ("Periodicity", Range(-100,100)) = 50
        _Velocity ("Velocity", Range(-10,10)) = 1
        _WaveAmplitud ("Wave Amplitud", Range(-10,10)) = 1
        _WavePeriodicity ("Wave Periodicity", Range(-100,100)) = 50
        _WaveVelocity ("WaveVelocity", Range(-10,10)) = 1
        _CollisionPosition ("Collision Position", Vector) = (0,0,0)
        _Collided ("Collided", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        
        Pass
        {
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _WaveAmplitud;
            float _WavePeriodicity;
            float _WaveVelocity;
            float _Collided;
            float4 _CollisionPosition;
            
            v2f vert (appdata v)
            {
                float PI = 3.1416;
                float radius = sqrt(pow(v.vertex.x-_CollisionPosition.x,2) + pow(v.vertex.z-_CollisionPosition.z,2));
                if(radius < 0.2f){
                    v.vertex.y += (sin((_Time.z * _WaveVelocity)+((radius) * (_WavePeriodicity * 2 * PI)) )) * _WaveAmplitud * _Collided;
                }
                
                
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
        Pass
        {
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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Amplitud;
            float _Periodicity;
            float _Velocity;

            v2f vert (appdata v)
            {
                float PI = 3.1416;
             
                
                v.vertex.y += _Amplitud * sin( (_Time.z * _Velocity ) + (v.vertex.x *  v.vertex.z *(_Periodicity * 2 * PI)));
             
                
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
