Shader "Unlit/Checkerboard"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color1("Color1", Color) = (0, 0, 0, 1)
		_Color2("Color2", Color) = (1, 1, 1, 1)
		_Rows("Rows", Range(0,100)) = 8
		_Columns("Columns", Range(0,100)) = 8
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
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
				float4 _Color1;
				float4 _Color2;
				int _Rows;
				int _Columns;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					// sample the texture
					fixed4 col = tex2D(_MainTex, i.uv);

				//Create Rows
				float tempX = i.uv.x * _Rows;
				int squareWidth = int(tempX) % 2;

				//Create Columns
				float tempY = i.uv.y * _Columns;
				int squareLength = int(tempY) % 2;

				// Checks the remainders (AKA length and width of squares)
				if (squareWidth > 1 && squareLength > 1 || squareWidth < 1 && squareLength < 1)
				{
					col = _Color1;
				}

				else if (squareWidth == 1 && squareLength == 1)
				{
					col = _Color1;
				}

				else
				{
					col = _Color2;
					return col;
				}

				return col;
			}
			ENDCG
		}
		}
}
