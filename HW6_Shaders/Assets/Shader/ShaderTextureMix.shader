Shader"Custom/ShaderTexture" {


Properties {

        _MainTexture ("Texture", 2D) = "white" {}
        _SecondTexture("Texture", 2D) = "white" {}
        _Color ("Blend Color", Color) = (1, 1, 1, 1)
        _Intensity ("Intensity", Range(0, 1)) = 0.5

    }
 
    SubShader {
        Tags { "Queue" = "Transparent" }
        Pass {
            CGPROGRAM
            #pragma vertex vertex
            #pragma fragment fragment   

#include "UnityCG.cginc"
 
struct Data
{
    float4 vertex : POSITION;
    float2 textureCoordinates : TEXCOORD0;
};
 
struct VertexToFragment
{
    float2 textureCoordinates : TEXCOORD0;
    float4 vertex : SV_POSITION;
};
 
sampler2D _MainTexture;
sampler2D _SecondTexture;
float4 _Color;
float _Intensity;

 
VertexToFragment vertex(Data inputVertexData)
{
    VertexToFragment outputVertexData;
    outputVertexData.textureCoordinates = inputVertexData.textureCoordinates;
    outputVertexData.vertex = UnityObjectToClipPos(inputVertexData.vertex);
    return outputVertexData;
}


fixed4 fragment(VertexToFragment inputVertexData) : SV_Target
{
    fixed4 MainTexture = tex2D(_MainTexture, inputVertexData.textureCoordinates);
    fixed4 SecondTexture = tex2D(_SecondTexture, inputVertexData.textureCoordinates);
    fixed4 blendedColor = lerp(MainTexture, SecondTexture, _Intensity);
    return blendedColor;
}
            ENDCG
        }
    }
}